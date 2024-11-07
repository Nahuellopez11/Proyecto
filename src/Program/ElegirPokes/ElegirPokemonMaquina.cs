namespace Program;

public class ElegirPokemonMaquina
{
    
    private static Random random = new Random();

    public static void SeleccionarEquipo()
        {
            while (CatalogoPokemones.ObtenerEquipoActual().Count < 6)
            {
                // Generar un número aleatorio entre 1 y 16
                int seleccion = random.Next(1, 17);

                // Obtener el Pokémon correspondiente al índice generado
                IPokemones pokemonSeleccionado;
                if (CatalogoPokemones.CatalogoPoke.TryGetValue(seleccion, out pokemonSeleccionado))
                {
                    // Verificar si el Pokémon ya está en el equipo
                    if (!CatalogoPokemones.ObtenerEquipoActual().Contains(pokemonSeleccionado))
                    {
                        CatalogoPokemones.SeleccionarPokemon(seleccion); // Agregar el Pokémon al equipo
                    }
                }

            }
            
        }
    

    

    public static List<IPokemones> DevolverLista()
    {
        var equipo = CatalogoPokemones.ObtenerEquipoActual();
        return equipo;
    }

}