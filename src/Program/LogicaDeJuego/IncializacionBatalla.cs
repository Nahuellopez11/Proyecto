using System;
using System.Collections.Generic;

namespace Program
{
    public class IncializacionBatalla
    {
        // inicializamos los jugadores con sus pokemones
        public static List<IPokemones> pokemonesJugador = ElegirPokemon.DevolverLista();
        public static Jugador jugador1 = new Jugador(pokemonesJugador);

        // Declaramos la máquina seleccionada
        public static Maquina maquinaSeleccionada;
        public static IPokemones pokemonActivoJugador = pokemonesJugador[0];
        public static IPokemones pokemonActivoMaquina;

        public static void LogicaJuego()
        {
            List<Maquina> oponentes = Oponentes.CrearOponentes();
            maquinaSeleccionada = Oponentes.SeleccionarOponente(oponentes);
            List<IPokemones>pokemonesMaquina = maquinaSeleccionada.ListaDePokemones;

            // Selecciona el primer Pokémon de la máquina seleccionada como activo
            pokemonActivoMaquina = maquinaSeleccionada.ListaDePokemones[0];
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
                            var nuevoPokemon = CambiarPokemon.Cambiar(jugador1, pokemonActivoJugador);

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
                        var nuevoPokemon = CambiarPokemon.Cambiar(jugador1, pokemonActivoJugador);

                        if (nuevoPokemon != pokemonActivoJugador) // cambia de turno solo si el pokemon cambio
                        {
                            pokemonActivoJugador = nuevoPokemon;
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
                    if (VerificarFinBatalla(pokemonesJugador))
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
                        pokemonActivoMaquina = CambiarPokemonMaquina.Cambiar(maquinaSeleccionada, pokemonActivoMaquina);
                        turno = 0;
                    }

                    // Mostrar información del Pokémon activo de la máquina
                    Console.WriteLine($"El Pokémon de la máquina es: {pokemonActivoMaquina.Nombre}");
                    Console.WriteLine($"Vida actual: {pokemonActivoMaquina.Vida}");
                    
                    if (pokemonActivoMaquina.Vida <= 30 && random.NextDouble() < 0.45) // 45% de chance de usar item
                    {
                        bool itemUsado = UtilizacionItemMaquina.UsarItemMaquina(maquinaSeleccionada, pokemonActivoMaquina);
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
                    if (VerificarFinBatalla(pokemonesMaquina))
                    {
                        Console.WriteLine("¡La batalla ha terminado! El jugador ha ganado.");
                        break; // Termina el juego
                    }

                    turno = 0; // Cambiar turno al jugador
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



