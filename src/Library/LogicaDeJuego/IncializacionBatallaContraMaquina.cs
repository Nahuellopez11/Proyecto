using System;
using System.Collections.Generic;

namespace Program
{
    public static class IncializacionBatallaContraMaquina
    {
        public static void LogicaJuego()
        {
            //INICIALIZAMOS EL JUGADOR CON SUS POKEMONES
            List<IPokemon> pokemonesJugador = ElegirPokemon.DevolverListajugador1();
            Jugador jugador1 = new Jugador(pokemonesJugador);

            
            // INICIALIZAMOS MAQUINA CON SUS POKEMONES
            Maquina maquinaSeleccionada;
            List<Maquina> oponentes = Oponentes.CrearOponentes();
            maquinaSeleccionada = Oponentes.SeleccionarOponente(oponentes);
            List<IPokemon> pokemonesMaquina = maquinaSeleccionada.ListaDePokemones;
            
            // SELECCIONA EL PRIMER POKEMON COMO ACTIVO DEL JUGADOR
            IPokemon pokemonActivoJugador = pokemonesJugador[0];
            
            // SELECCIONA EL PRIMER POKEMON COMO ACTIVO DE LA MÁQUINA
            IPokemon pokemonActivoMaquina;
            pokemonActivoMaquina = maquinaSeleccionada.ListaDePokemones[0];
            
            //-------------------------------
            
            // AQUI COMIENZA LA BATALLA
            Random random = new Random();
            int turno = random.Next(0, 2); // random int entre 0 y 1; 0 = jugador, 1 = maquina

            while (true)
            {
                if (turno == 0)
                {
                    if (pokemonActivoJugador.Vida <= 0)
                    {
                        Console.WriteLine($"{pokemonActivoJugador.Nombre} ha muerto.");
                        {
                            var nuevoPokemon = Utilities.CambiarPokemonJugador(jugador1, pokemonActivoJugador);

                            if (nuevoPokemon != pokemonActivoJugador) // cambia de turno solo si el pokemon cambio
                            {
                                pokemonActivoJugador = nuevoPokemon;
                                turno = 1;
                            }
                        }
                    }

                    Console.WriteLine("¡Es tu turno!");

                    // muetsra la informacion del pokemon
                    Console.WriteLine($"Tu Pokémon elegido es: {pokemonActivoJugador.Nombre}");
                    Console.WriteLine($"Vida actual: {pokemonActivoJugador.Vida}");

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
                        Console.WriteLine("El jugador ataca.");
                        SistemaCombate.RealizarAtaqueJugador(pokemonActivoJugador, pokemonActivoMaquina);

                    }

                    if (opcion == 2)
                    {
                        var nuevoPokemon = Utilities.CambiarPokemonJugador(jugador1, pokemonActivoJugador);

                        if (nuevoPokemon != pokemonActivoJugador) // cambia de turno solo si el pokemon cambio
                        {
                            pokemonActivoJugador = nuevoPokemon;
                            turno = 1;
                        }
                    }

                    if (opcion == 3)
                    {
                        turno = Utilities.UsarItem(jugador1, turno); // al principio hice la logica aca
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
                    if (Utilities.VerificarFinBatalla(pokemonesJugador))
                    {
                        Console.WriteLine("¡La batalla ha terminado! La máquina ha ganado.");
                        break; // Termina el juego
                    }

                    turno = 1; // Cambiar turno a la máquina
                }
                else
                {
                    //turno maquina
                    Console.WriteLine("¡Es el turno de la máquina!");
                    Console.WriteLine($"Los pokemones de la maquina son:{pokemonesMaquina}");
                    if (pokemonActivoMaquina.Vida <=
                        0) // logica para cambiar de pokemon automatico de la maquina si muere
                    {
                        pokemonActivoMaquina =
                            Utilities.CambiarPokemonMaquina(maquinaSeleccionada, pokemonActivoMaquina);
                        turno = 0;
                    }

                    // Mostrar información del Pokémon activo de la máquina
                    Console.WriteLine($"El Pokémon de la máquina es: {pokemonActivoMaquina.Nombre}");
                    Console.WriteLine($"Vida actual: {pokemonActivoMaquina.Vida}");

                    if (pokemonActivoMaquina.Vida <= 30 && random.NextDouble() < 0.45) // 45% de chance de usar item
                    {
                        bool itemUsado = Utilities.UsarItemMaquina(maquinaSeleccionada, pokemonActivoMaquina);
                        if (itemUsado)
                        {
                            turno = 0; // turno al jugador después de usar el ítem
                            continue;
                        }
                    }

                    // Lógica de ataque de la máquina (por ejemplo, atacar al jugador)
                    Console.WriteLine("La máquina ataca.");

                    SistemaCombate.RealizarAtaqueMaquina(pokemonActivoMaquina, pokemonActivoJugador);

                    // Verificar si la batalla terminó después de la acción de la máquina
                    if (Utilities.VerificarFinBatalla(pokemonesMaquina))
                    {
                        Console.WriteLine("¡La batalla ha terminado! El jugador ha ganado.");
                        break; // Termina el juego
                    }

                    turno = 0; // Cambiar turno al jugador
                }
            }
        }


    }
}



