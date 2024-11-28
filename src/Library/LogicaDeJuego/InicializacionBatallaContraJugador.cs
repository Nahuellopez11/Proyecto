using Program;
namespace Program
{
    /// <summary>
    /// Clase encargada de inicializar y gestionar la lógica de la batalla entre dos jugadores.
    /// </summary>
    public class InicializacionBatallaContraJugador
    {
        private Jugador jugador1;
        private Jugador jugador2;

        /// <summary>
        /// Constructor para inicializar la batalla entre dos jugadores.
        /// </summary>
        /// <param name="elegirPokemon">Instancia de <see cref="ElegirPokemon"/> que proporciona los equipos de ambos jugadores.</param>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="elegirPokemon"/> es null.</exception>
        /// <exception cref="InvalidOperationException">Se lanza si alguno de los equipos está vacío.</exception>
        public InicializacionBatallaContraJugador(ElegirPokemon elegirPokemon)
        {
            if (elegirPokemon == null)
            {
                throw new ArgumentNullException(nameof(elegirPokemon), "El objeto ElegirPokemon no puede ser null.");
            }

            // Crear los jugadores
            jugador1 = new Jugador(elegirPokemon.DevolverListajugador1());
            jugador2 = new Jugador(elegirPokemon.DevolverListajugador2());

            // Asignar los equipos
            jugador1.ListaDePokemones = elegirPokemon.DevolverListajugador1();
            jugador2.ListaDePokemones = elegirPokemon.DevolverListajugador2();

            // Verificar que los equipos estén completos
            if (jugador1.ListaDePokemones == null || jugador1.ListaDePokemones.Count == 0)
            {
                throw new InvalidOperationException("El equipo del Jugador 1 está vacío.");
            }

            if (jugador2.ListaDePokemones == null || jugador2.ListaDePokemones.Count == 0)
            {
                throw new InvalidOperationException("El equipo del Jugador 2 está vacío.");
            }

            // Elegir los primeros Pokémon activos de ambos jugadores


        }

        /// <summary>
        /// Ejecuta la lógica principal de la batalla entre los jugadores, alternando turnos hasta que uno gane o el juego termine.
        /// </summary>
        public void LogicaJuego()
        {
            IPokemon pokemonActivoJugador1 = jugador1.ListaDePokemones[0];
            IPokemon pokemonActivoJugador2 = jugador2.ListaDePokemones[0];
            Random random = new Random();
            int turno = random.Next(0, 2); // 0 = jugador1, 1 = jugador2
            bool batallaActiva = true; // Controla si la batalla sigue activa

            while (batallaActiva)
            {
                if (turno == 0)
                {
                    if (pokemonActivoJugador1.Vida <= 0)
                    {
                        Console.WriteLine($"{pokemonActivoJugador1.Nombre} ha muerto.");
                        var nuevoPokemon = Utilities.CambiarPokemonJugador(jugador1, pokemonActivoJugador1);

                        if (nuevoPokemon != pokemonActivoJugador1)
                        {
                            pokemonActivoJugador1 = nuevoPokemon;
                            turno = 1;
                        }

                        continue;
                    }

                    Console.WriteLine("¡Turno de jugador1!");
                    MostrarInformacionPokemon(pokemonActivoJugador1);
                    int opcion = MostrarMenuOpciones();

                    switch (opcion)
                    {
                        case 1: // Ataque
                            SistemaCombate.RealizarAtaqueJugador(pokemonActivoJugador1, pokemonActivoJugador2);
                            break;
                        case 2: // Cambiar Pokémon
                            var nuevoPokemon = Utilities.CambiarPokemonJugador(jugador1, pokemonActivoJugador1);
                            if (nuevoPokemon != pokemonActivoJugador1)
                            {
                                pokemonActivoJugador1 = nuevoPokemon;
                                turno = 1;
                            }

                            continue;
                        case 3: // Usar ítem
                            turno = Utilities.UsarItem(jugador1, turno);
                            continue;
                        case 4: // Terminar juego
                            Console.WriteLine("Terminando el juego...");
                            batallaActiva = false;
                            continue;
                        case 5://Quien Va Gananado?
                            QuienVaGananado.Quiengana(jugador1.ListaDePokemones,jugador2.ListaDePokemones,jugador1.Items,jugador2.Items);
                            turno = 0;
                            continue;
                            
                        default:
                            Console.WriteLine("Opción inválida.");
                            continue;
                    }

                    if (Utilities.VerificarFinBatalla(jugador1.ListaDePokemones))
                    {
                        Console.WriteLine("¡La batalla ha terminado! El jugador2 ha ganado.");
                        batallaActiva = false;
                    }
                    else
                    {
                        turno = 1;
                    }
                }
                else
                {
                    if (pokemonActivoJugador2.Vida <= 0)
                    {
                        Console.WriteLine($"{pokemonActivoJugador2.Nombre} ha muerto.");
                        var nuevoPokemon = Utilities.CambiarPokemonJugador(jugador2, pokemonActivoJugador2);

                        if (nuevoPokemon != pokemonActivoJugador2)
                        {
                            pokemonActivoJugador2 = nuevoPokemon;
                            turno = 0;
                        }

                        continue;
                    }

                    Console.WriteLine("¡Turno de jugador2!");
                    MostrarInformacionPokemon(pokemonActivoJugador2);
                    int opcion = MostrarMenuOpciones();

                    switch (opcion)
                    {
                        case 1: // Ataque
                            SistemaCombate.RealizarAtaqueJugador(pokemonActivoJugador2, pokemonActivoJugador1);
                            break;
                        case 2: // Cambiar Pokémon
                            var nuevoPokemon = Utilities.CambiarPokemonJugador(jugador2, pokemonActivoJugador2);
                            if (nuevoPokemon != pokemonActivoJugador2)
                            {
                                pokemonActivoJugador2 = nuevoPokemon;
                                turno = 0;
                            }

                            continue;
                        case 3: // Usar ítem
                            turno = Utilities.UsarItem(jugador2, turno);
                            continue;
                        case 4: // Terminar juego
                            Console.WriteLine("Terminando el juego...");
                            batallaActiva = false;
                            continue;
                        case 5://Quien Va Gananado?
                            QuienVaGananado.Quiengana(jugador1.ListaDePokemones,jugador2.ListaDePokemones,jugador1.Items,jugador2.Items);
                            turno = 0;
                            continue;
                        
                        default:
                            Console.WriteLine("Opción inválida.");
                            continue;
                    }

                    if (Utilities.VerificarFinBatalla(jugador2.ListaDePokemones))
                    {
                        Console.WriteLine("¡La batalla ha terminado! El jugador1 ha ganado.");
                        batallaActiva = false;
                    }
                    else
                    {
                        turno = 0;
                    }
                }
            }
        }

        private void MostrarInformacionPokemon(IPokemon pokemon)
        {
            Console.WriteLine($"Tu Pokémon elegido es: {pokemon.Nombre}");
            Console.WriteLine($"Vida actual: {pokemon.Vida}");
        }

        private int MostrarMenuOpciones()
        {
            Console.WriteLine("Selecciona una opción:");
            Console.WriteLine("1. Ataque");
            Console.WriteLine("2. Cambiar Pokémon");
            Console.WriteLine("3. Items");
            Console.WriteLine("4. Terminar juego");
            Console.WriteLine("5. Quien va ganando?");

            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
            {
                Console.WriteLine("Por favor, ingresa una opción válida (1-5).");
            }

            return opcion;
        }
    }
}

