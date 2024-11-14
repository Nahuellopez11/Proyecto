namespace Program;

public class ElegirPokemon
{
    public static void SeleccionarEquipo()
    {
        Console.WriteLine("¡Bienvenido al Selector de Equipo Pokémon!");
        Console.WriteLine("Selecciona 6 Pokémon para formar tu equipo.");

        while (CatalogoPokemones.ObtenerEquipoActual().Count < 6)
        {
            CatalogoPokemones.MostrarCatalogo();
            Console.WriteLine(
                $"\nSelecciona el número del pokémon que deseas añadir a tu equipo ({CatalogoPokemones.ObtenerEquipoActual().Count}/6):");

            if (int.TryParse(Console.ReadLine(), out int seleccion))
            {
                bool seleccionado = CatalogoPokemones.SeleccionarPokemon(seleccion);
                if (!seleccionado)
                {
                    Console.WriteLine("Pokémon no seleccionado. Intenta de nuevo.");
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
            }

            Console.WriteLine(
                $"Actualmente tienes {CatalogoPokemones.ObtenerEquipoActual().Count} Pokémon en tu equipo.");
        }

        Console.WriteLine("\n¡Tu equipo está completo!");
        MostrarEquipoFinal();
    }

    // Muestra los Pokémon en el equipo junto con su tipo y vida
    public static void MostrarEquipoFinal()
    {
        Console.WriteLine("\nTu equipo final es:");
        var equipo = CatalogoPokemones.ObtenerEquipoActual();
        Console.WriteLine($"Tienes {equipo.Count} Pokémon en tu equipo."); // verificar pokemones en equipo

        for (int i = 0; i < equipo.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {equipo[i].Nombre} - Tipo: {equipo[i].Tipo} - Vida: {equipo[i].Vida}");
        }
    }

// Método DevolverLista: devuelve la lista de Pokémon del equipo actual del jugador
    public static List<IPokemones> DevolverListajugador1()
    {
        List<IPokemones> jugador1lista ;
        var equipo = CatalogoPokemones.ObtenerEquipoActual();
        jugador1lista = equipo;
        return jugador1lista;
    }
    
    public static List<IPokemones> DevolverListajugador2()
    {
        List<IPokemones> jugador2lista ;
        var equipo = CatalogoPokemones.ObtenerEquipoActual();
        jugador2lista = equipo;
        return jugador2lista;
    }


}