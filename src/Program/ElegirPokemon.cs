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
                CatalogoPokemones.SeleccionarPokemon(seleccion);
            }
            else
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
            }
        }

        Console.WriteLine("\n¡Tu equipo está completo!");
        MostrarEquipoFinal();
    }

    private static void MostrarEquipoFinal()
    {
        Console.WriteLine("\nTu equipo final es:");
        var equipo = CatalogoPokemones.ObtenerEquipoActual();
        for (int i = 0; i < equipo.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {equipo[i].Nombre} - Tipo: {equipo[i].Tipo} - Vida: {equipo[i].Vida}");
        }
    }

}