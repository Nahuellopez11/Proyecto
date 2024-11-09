namespace Program;

using System;
using System.Collections.Generic;

public class IncializacionBatalla
{
    public static List<IPokemones> pokemonesJugador = ElegirPokemon.DevolverLista();
    public static List<IPokemones> pokemonesMaquina = ElegirPokemonMaquina.DevolverLista();
    public static Jugador jugador1 = new Jugador(pokemonesJugador);
    public static Maquina maquina = new Maquina(pokemonesMaquina);

    // pokemon activo siempre es el primero
    public static IPokemones pokemonActivoJugador = pokemonesJugador[0];

    public static IPokemones pokemonActivoMaquina = pokemonesMaquina[0];
    
    public static void LogicaJuego()
    {
        Random random = new Random();
        int turno = random.Next(0, 2); // 0 = Jugador, 1 = Maquina

        while (true)
        {
            if (turno == 0)
            {
                // El jugador comienza
                Console.WriteLine("¡Es tu turno!");

                // Mostrar información del Pokémon activo del jugador
                Console.WriteLine($"Tu Pokémon elegido es: {pokemonActivoJugador.Nombre}");
                Console.WriteLine($"Vida actual: {pokemonActivoJugador.Vida}");

                // Menú de opciones para el jugador
                Console.WriteLine("Selecciona una opción:");
                Console.WriteLine("1. Ataque");
                Console.WriteLine("2. Cambiar Pokémon");
                Console.WriteLine("3. Items");

                int opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion == 1)
                {
                    Console.WriteLine("El jugador ataca.");
                    SistemaCombate.RealizarAtaqueJugador(pokemonActivoJugador, pokemonActivoMaquina);
                }
                if (opcion == 2)
                {
                    Console.WriteLine("El jugador cambia de Pokémon.");
                    // Lógica para cambiar Pokémon (seleccionar otro Pokémon de la lista)
                    // Cambiar el Pokémon aquí
                }
                if (opcion == 3)
                {
                    turno = UtilizacionItem.UsarItem(jugador1, turno); // al principio hice la logica aca
                                                                       // pero no siguiria SRP estaria muy lleno de cosas
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
                // La máquina comienza
                Console.WriteLine("¡Es el turno de la máquina!");

                // Mostrar información del Pokémon activo de la máquina
                Console.WriteLine($"El Pokémon de la máquina es: {pokemonActivoMaquina.Nombre}");
                Console.WriteLine($"Vida actual: {pokemonActivoMaquina.Vida}");

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

