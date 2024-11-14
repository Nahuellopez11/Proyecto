namespace Program;

public class ElegirPokemon
{
    private static Random random = new Random();
    private static List<IPokemon> equipoMaquina = new List<IPokemon>();
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
    public static List<IPokemon> DevolverListajugador1()
    {
        List<IPokemon> jugador1lista ;
        var equipo = CatalogoPokemones.ObtenerEquipoActual();
        jugador1lista = equipo;
        return jugador1lista;
    }
    // SELECCIONAR EQUIPO PARA MÁQUINA
    public static void SeleccionarEquipoMaquina()
    {// La clase depende de CatalogoPokemones y de la interfaz IPokemones, lo que permite que esta clase
        // sea flexible y reutilizable. No tiene acoplamientos innecesarios con otras clases.
        equipoMaquina.Clear();

        while (equipoMaquina.Count < 6)
        {
            // Generar un número aleatorio entre 1 y 16
            int seleccion = random.Next(1, 17);

            // Obtener el pokemon correspondiente al índice generado
            if (CatalogoPokemones.CatalogoPoke.TryGetValue(seleccion, out IPokemon pokemonSeleccionado))
            {
                // Verificar si el pokemon ya está en el equipo de la máquina
                if (!equipoMaquina.Any(p => p.Nombre == pokemonSeleccionado.Nombre))
                {
                    equipoMaquina.Add(pokemonSeleccionado);
                }
            }
        }
    }

    public static List<IPokemon> DevolverListaMaquina()
    {
        return equipoMaquina;
    }

}