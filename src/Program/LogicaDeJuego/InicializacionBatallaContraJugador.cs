namespace Program
{
    public class InicializacionBatallaContraJugador
    {
        public static Jugador jugador1 = new Jugador(ClonandoListaJugador1.ClonarJugador1());
        public static List<IPokemones> pokemonesJugador2 = ElegirPokemon.DevolverListajugador2();
        public static Jugador jugador2 = new Jugador(pokemonesJugador2);
        public static IPokemones pokemonActivoJugador1 = jugador1.ListaDePokemones[0];
        public static IPokemones pokemonActivoJugador2 = pokemonesJugador2[0];

        public static void LogicaJuego()
        {
            Random random = new Random();
            int turno = random.Next(0, 2); // random int entre 0 y 1; 0 = jugador, 1 = jugador

            while (true)
            {
                if (turno == 0)
                {
                    if (pokemonActivoJugador1.Vida <= 0)
                    {
                        Console.WriteLine($"{pokemonActivoJugador1.Nombre} ha muerto.");
                        {
                            var nuevoPokemon = CambiarPokemon.Cambiar(jugador1, pokemonActivoJugador1);

                            if (nuevoPokemon != pokemonActivoJugador1) // cambia de turno solo si el pokemon cambio
                            {
                                pokemonActivoJugador1 = nuevoPokemon;
                                turno = 1;
                            }
                        }
                    }

                    Console.WriteLine("¡Turno de jugador1!");

                    // muetsra la informacion del pokemon
                    Console.WriteLine($"Tu Pokémon elegido es: {pokemonActivoJugador1.Nombre}");
                    Console.WriteLine($"Vida actual: {pokemonActivoJugador1.Vida}");

                    // menú "principal" de opciones
                    Console.WriteLine("Selecciona una opción:");
                    Console.WriteLine("1. Ataque");
                    Console.WriteLine("2. Cambiar Pokémon");
                    Console.WriteLine("3. Items");
                    Console.WriteLine("4. terminar juego");

                    int opcion =
                        Convert.ToInt32(Console.ReadLine()); // eleccion del jugador sobre que quiere hacer (1, 2 o 3)

                    if (opcion == 1)
                    {
                        Console.WriteLine("El jugador1 ataca.");
                        SistemaCombate.RealizarAtaqueJugador(pokemonActivoJugador1, pokemonActivoJugador2);

                    }

                    if (opcion == 2)
                    {
                        var nuevoPokemon = CambiarPokemon.Cambiar(jugador1, pokemonActivoJugador1);

                        if (nuevoPokemon != pokemonActivoJugador1) // cambia de turno solo si el pokemon cambio
                        {
                            pokemonActivoJugador1 = nuevoPokemon;
                            turno = 1;
                        }
                    }

                    if (opcion == 3)
                    {
                        turno = UtilizacionItem.UsarItem(jugador1, turno); // al principio hice la logica aca
                        // pero no siguiria SRP estaria muy lleno de cosas
                    }

                    if (opcion == 4)
                    {
                        Console.WriteLine("Terminando el juego...");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Opción Inválida.");
                        continue; // sigue si metes cualquier cosa
                    }

                    // Verificar si la batalla terminó después de la acción del jugador
                    if (VerificarFinBatalla(jugador1.ListaDePokemones))
                    {
                        Console.WriteLine("¡La batalla ha terminado! El jugador2 ha ganado.");
                        break; // Termina el juego
                    }

                    turno = 1; // Cambiar turno a la máquina


                }
                else
                {
                    if (pokemonActivoJugador2.Vida <= 0)
                    {
                        Console.WriteLine($"{pokemonActivoJugador2.Nombre} ha muerto.");
                        {
                            var nuevoPokemon = CambiarPokemon.Cambiar(jugador2, pokemonActivoJugador2);

                            if (nuevoPokemon != pokemonActivoJugador2) // cambia de turno solo si el pokemon cambio
                            {
                                pokemonActivoJugador2 = nuevoPokemon;
                                turno = 0;
                            }
                        }
                    }

                    Console.WriteLine("¡Turno de jugador2!");

                    // muetsra la informacion del pokemon
                    Console.WriteLine($"Tu Pokémon elegido es: {pokemonActivoJugador2.Nombre}");
                    Console.WriteLine($"Vida actual: {pokemonActivoJugador2.Vida}");

                    // menú "principal" de opciones
                    Console.WriteLine("Selecciona una opción:");
                    Console.WriteLine("1. Ataque");
                    Console.WriteLine("2. Cambiar Pokémon");
                    Console.WriteLine("3. Items");
                    Console.WriteLine("4. terminar juego");

                    int opcion =
                        Convert.ToInt32(Console.ReadLine()); // eleccion del jugador sobre que quiere hacer (1, 2 o 3)

                    if (opcion == 1)
                    {
                        Console.WriteLine("El jugador2 ataca.");
                        SistemaCombate.RealizarAtaqueJugador(pokemonActivoJugador2, pokemonActivoJugador1);

                    }

                    if (opcion == 2)
                    {
                        var nuevoPokemon = CambiarPokemon.Cambiar(jugador2, pokemonActivoJugador2);

                        if (nuevoPokemon != pokemonActivoJugador2) // cambia de turno solo si el pokemon cambio
                        {
                            pokemonActivoJugador2 = nuevoPokemon;
                            turno = 0;
                        }
                    }

                    if (opcion == 3)
                    {
                        turno = UtilizacionItem.UsarItem(jugador2, turno); // al principio hice la logica aca
                        // pero no siguiria SRP estaria muy lleno de cosas
                    }

                    if (opcion == 4)
                    {
                        Console.WriteLine("Terminando el juego...");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Opción Inválida.");
                        continue; // sigue si metes cualquier cosa
                    }

                    // Verificar si la batalla terminó después de la acción del jugador
                    if (VerificarFinBatalla(pokemonesJugador2))
                    {
                        Console.WriteLine("¡La batalla ha terminado! el jugador1 ha ganado.");
                        break; // Termina el juego
                    }

                }
            }

        }
    

    public static bool VerificarFinBatalla(List<IPokemones> listaPokemones)
        {
            double vidaTotal = 0;
            foreach (var pokemon in listaPokemones)
            {
                vidaTotal += pokemon.Vida;
            }

            return vidaTotal <= 0;
        }
    }
}

