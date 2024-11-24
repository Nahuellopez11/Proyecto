namespace Program;
/// <summary>
/// Clase que gestiona la selección de equipos Pokémon para los jugadores.
/// Permite a los jugadores seleccionar sus equipos de 6 Pokémon del catálogo disponible.
/// </summary>
public class ElegirPokemon
{
    /// <summary>
    /// Instancia del catálogo de Pokémon que contiene todos los Pokémon disponibles para selección.
    /// </summary>
    public CatalogoPokemones catalogo = new CatalogoPokemones();
    
    /// <summary>
    /// Generador de números aleatorios utilizado para selecciones aleatorias.
    /// </summary>
    public   Random random = new Random();

    /// <summary>
    /// Permite al primer jugador seleccionar interactivamente su equipo de 6 Pokémon.
    /// Muestra el catálogo y permite la selección uno por uno hasta completar el equipo.
    /// </summary>
    public void SeleccionarEquipo()
    {
        Console.WriteLine("¡Bienvenido al Selector de Equipo Pokémon!");
        Console.WriteLine("Selecciona 6 Pokémon para formar tu equipo.");

        while (catalogo.ObtenerEquipoActual().Count < 6)
        {
            catalogo.MostrarCatalogo();
            Console.WriteLine(
                $"\nSelecciona el número del pokémon que deseas añadir a tu equipo ({catalogo.ObtenerEquipoActual().Count}/6):");

            if (int.TryParse(Console.ReadLine(), out int seleccion))
            {
                bool seleccionado = catalogo.SeleccionarPokemon(seleccion);
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
                $"Actualmente tienes {catalogo.ObtenerEquipoActual().Count} Pokémon en tu equipo.");
        }

        Console.WriteLine("\n¡Tu equipo está completo!");
        MostrarEquipoFinal();
    }
    
    /// <summary>
    /// Permite al segundo jugador seleccionar interactivamente su equipo de 6 Pokémon.
    /// Muestra el catálogo y permite la selección uno por uno hasta completar el equipo.
    /// </summary>
    public  void SeleccionarEquipo2()
    {
        Console.WriteLine("¡Bienvenido al Selector de Equipo Pokémon!");
        Console.WriteLine("Selecciona 6 Pokémon para formar tu equipo.");

        while (catalogo.ObtenerEquipoActual2().Count < 6)
        {
            catalogo.MostrarCatalogo();
            Console.WriteLine(
                $"\nSelecciona el número del pokémon que deseas añadir a tu equipo ({catalogo.ObtenerEquipoActual2().Count}/6):");

            if (int.TryParse(Console.ReadLine(), out int seleccion))
            {
                bool seleccionado = catalogo.SeleccionarPokemon2(seleccion);
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
                $"Actualmente tienes {catalogo.ObtenerEquipoActual2().Count} Pokémon en tu equipo.");
        }

        Console.WriteLine("\n¡Tu equipo está completo!");
        MostrarEquipoFinal2();
    }
    
    
    /// <summary>
    /// Muestra en consola el equipo final del primer jugador.
    /// Lista cada Pokémon con su nombre, tipo y puntos de vida.
    /// </summary>
    public  void MostrarEquipoFinal()
    {
        Console.WriteLine("\nTu equipo final es:");
        var equipo = catalogo.ObtenerEquipoActual();
        Console.WriteLine($"Tienes {equipo.Count} Pokémon en tu equipo."); // verificar pokemones en equipo

        for (int i = 0; i < equipo.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {equipo[i].Nombre} - Tipo: {equipo[i].Tipo} - Vida: {equipo[i].Vida}");
        }
    }
    
    /// <summary>
    /// Muestra en consola el equipo final del segundo jugador.
    /// Lista cada Pokémon con su nombre, tipo y puntos de vida.
    /// </summary>
    public  void MostrarEquipoFinal2()
    {
        Console.WriteLine("\nTu equipo final es:");
        var equipo2 = catalogo.ObtenerEquipoActual2();
        Console.WriteLine($"Tienes {equipo2.Count} Pokémon en tu equipo."); // verificar pokemones en equipo

        for (int i = 0; i < equipo2.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {equipo2[i].Nombre} - Tipo: {equipo2[i].Tipo} - Vida: {equipo2[i].Vida}");
        }
    }

    /// <summary>
    /// Obtiene la lista de Pokémon seleccionados por el primer jugador.
    /// </summary>
    /// <returns>Lista de IPokemon que representa el equipo completo del primer jugador.</returns>
    public  List<IPokemon> DevolverListajugador1()
    {

        var equipo = catalogo.ObtenerEquipoActual();

        return equipo;
    }
    /// <summary>
    /// Obtiene la lista de Pokémon seleccionados por el segundo jugador.
    /// </summary>
    /// <returns>Lista de IPokemon que representa el equipo completo del segundo jugador.</returns>
    public  List<IPokemon> DevolverListajugador2()
    {

        var equipo2 = catalogo.ObtenerEquipoActual2();

        return equipo2;
    }



}