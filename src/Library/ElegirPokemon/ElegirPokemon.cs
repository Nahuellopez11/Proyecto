namespace Program
{
    public class ElegirPokemon
    {
        public CatalogoPokemones catalogo = new CatalogoPokemones();
        public Random random = new Random();

        // Constructor que acepta nombres de los jugadores

        // Este método se podría modificar o adaptarse al bot de Discord si es necesario
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

        public async Task SeleccionarEquipo2()
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

        // Muestra los Pokémon en el equipo junto con su tipo y vida
        public void MostrarEquipoFinal()
        {
            Console.WriteLine("\nTu equipo final es:");
            var equipo = catalogo.ObtenerEquipoActual();
            Console.WriteLine($"Tienes {equipo.Count} Pokémon en tu equipo.");

            for (int i = 0; i < equipo.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {equipo[i].Nombre} - Tipo: {equipo[i].Tipo} - Vida: {equipo[i].Vida}");
            }
        }

        public void MostrarEquipoFinal2()
        {
            Console.WriteLine("\nTu equipo final es:");
            var equipo2 = catalogo.ObtenerEquipoActual2();
            Console.WriteLine($"Tienes {equipo2.Count} Pokémon en tu equipo.");

            for (int i = 0; i < equipo2.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {equipo2[i].Nombre} - Tipo: {equipo2[i].Tipo} - Vida: {equipo2[i].Vida}");
            }
        }

        // Devolver lista de Pokémon para el jugador 1
        public List<IPokemon> DevolverListajugador1()
        {
            var equipo = catalogo.ObtenerEquipoActual();
            return equipo;
        }

        // Devolver lista de Pokémon para el jugador 2
        public List<IPokemon> DevolverListajugador2()
        {
            var equipo2 = catalogo.ObtenerEquipoActual2();
            return equipo2;
        }
    }
}
