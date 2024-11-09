// Separe la logica para que cumpla con SRP y también para que no quede super largo InicializacionBatalla
namespace Program;

public class CambiarPokemon
//lógica para permitir que el jugador cambie su Pokémon activo.
{
    public static IPokemones Cambiar(Jugador jugador, IPokemones pokemonActivo)
    {
        bool cambioExitoso = false;
        IPokemones nuevoPokemon = pokemonActivo;
        // Ciclo que continúa hasta que el jugador seleccione un Pokémon válido o decida no realizar el cambio.
        while (!cambioExitoso)
        {
            Console.WriteLine("Selecciona un Pokémon para cambiar:");
            for (int i = 0; i < jugador.ListaDePokemones.Count; i++)
            {
                var pokemon = jugador.ListaDePokemones[i];
                Console.WriteLine($"{i + 1}. {pokemon.Nombre} - Vida: {pokemon.Vida}");
            }

            Console.WriteLine("0. Volver al menú anterior");
            int seleccion = Convert.ToInt32(Console.ReadLine()) - 1;

            if (seleccion == -1) // Si se selecciona 0, vuelve al menú principal sin cambiar de Pokémon
            {
                Console.WriteLine("Volviendo al menú de acciones...");
                return pokemonActivo; // Retorna el Pokémon actual sin cambiar
            }
            // Valida la selección del jugador y verifica que el Pokémon tenga vida
            if (seleccion >= 0 && seleccion < jugador.ListaDePokemones.Count)
            {
                nuevoPokemon = jugador.ListaDePokemones[seleccion];
                if (nuevoPokemon.Vida > 0)
                {
                    Console.WriteLine($"Has cambiado a {nuevoPokemon.Nombre}.");
                    cambioExitoso = true;
                }
                else
                {
                    Console.WriteLine("Ese Pokémon está debilitado. Elige otro.");
                }
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }

        return nuevoPokemon;
    }
}