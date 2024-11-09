namespace Program;

public class ElegirPokemonMaquina
{
    
    private static Random random = new Random();
    private static List<IPokemones> equipoMaquina = new List<IPokemones>();

    public static void SeleccionarEquipo()
    {
        equipoMaquina.Clear();

        while (equipoMaquina.Count < 6)
        {
            // Generar un número aleatorio entre 1 y 16
            int seleccion = random.Next(1, 17);

            // Obtener el pokemon correspondiente al índice generado
            if (CatalogoPokemones.CatalogoPoke.TryGetValue(seleccion, out IPokemones pokemonSeleccionado))
            {
                // Verificar si el pokemon ya está en el equipo de la máquina
                if (!equipoMaquina.Any(p => p.Nombre == pokemonSeleccionado.Nombre))
                {
                    equipoMaquina.Add(pokemonSeleccionado);
                }
            }
        }
    }

    public static List<IPokemones> DevolverLista()
    {
        return equipoMaquina;
    }

   
    

    

  
}
/*
 public static void SeleccionarEquipo()
        {
        private static Random random = new Random();
            while (CatalogoPokemones.ObtenerEquipoActual().Count < 6)
            {
                // un número aleatorio entre 1 y 16
                int seleccion = random.Next(1, 17);

                // pokemon correspondiente al índice generado
                IPokemones pokemonSeleccionado;
                if (CatalogoPokemones.CatalogoPoke.TryGetValue(seleccion, out pokemonSeleccionado))
                {
                    // verifica si el pokemon ya esta en el equipo
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

        */