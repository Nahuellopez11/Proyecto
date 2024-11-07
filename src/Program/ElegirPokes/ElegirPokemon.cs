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
            Console.WriteLine($"\nSelecciona el número del pokémon que deseas añadir a tu equipo ({CatalogoPokemones.ObtenerEquipoActual().Count}/6):");

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

            // Depuración para ver cuántos Pokémon se han añadido
            Console.WriteLine($"Actualmente tienes {CatalogoPokemones.ObtenerEquipoActual().Count} Pokémon en tu equipo.");
        }

        Console.WriteLine("\n¡Tu equipo está completo!");
        MostrarEquipoFinal();
    }


    public static void MostrarEquipoFinal()
    {
        Console.WriteLine("\nTu equipo final es:");
        var equipo = CatalogoPokemones.ObtenerEquipoActual();
        Console.WriteLine($"Tienes {equipo.Count} Pokémon en tu equipo."); // Verifica cuántos Pokémon están en el equipo

        for (int i = 0; i < equipo.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {equipo[i].Nombre} - Tipo: {equipo[i].Tipo} - Vida: {equipo[i].Vida}");
        }
    }


    public static List<IPokemones> DevolverLista()
    {
        var equipo = CatalogoPokemones.ObtenerEquipoActual();
        return equipo;

    }

}