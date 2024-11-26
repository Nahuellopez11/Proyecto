using System.Security.AccessControl;

namespace Program;
/// <summary>
/// Clase que actúa como catálogo y fábrica de Pokémon.
/// Gestiona la creación y almacenamiento de Pokémon disponibles en el juego.
/// </summary>
public  class CatalogoPokemones
{ 
    /// <summary>
    /// Diccionario que almacena todos los Pokémon disponibles en el catálogo.
    /// La clave es un identificador único del Pokémon y el valor es la instancia del Pokémon.
    /// </summary>
    public static Dictionary<int, IPokemon> CatalogoPoke { get; private set; } = new Dictionary<int, IPokemon>();
    
    /// <summary>
    /// Crea una nueva instancia de Pokémon con los parámetros especificados.
    /// </summary>
    /// <param name="nombre">Nombre del Pokémon.</param>
    /// <param name="vida">Puntos de vida del Pokémon.</param>
    /// <param name="tipo">Tipo elemental del Pokémon.</param>
    /// <param name="habilidadesPokemons">Lista de habilidades del Pokémon.</param>
    /// <returns>Una nueva instancia de IPokemon.</returns>
    public static IPokemon CrearPokemon(string nombre, int vida, TipoPokemon tipo, List<IHabilidadesPokemon> habilidadesPokemons)
    {
        return new Pokemon(nombre, vida, tipo);
    }
    /// <summary>
    /// Constructor de la clase. Inicializa el catálogo de Pokémon llamando a AgregarPokemonesCatalogo.
    /// </summary>
    static CatalogoPokemones()
    
    {
        AgregarPokemonesCatalogo();
    }
   
    /// <summary>
    /// Agrega todos los Pokémon predefinidos al catálogo.
    /// Inicializa el diccionario CatalogoPoke con diferentes especies de Pokémon.
    /// </summary>
    public static void AgregarPokemonesCatalogo()
    {
        
        CatalogoPoke.Add(1, CrearPokemon("Charizard", 100, TipoPokemon.Fuego,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Fuego)));
        CatalogoPoke.Add(2, CrearPokemon("Blastoise", 100, TipoPokemon.Agua,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Agua)));
        CatalogoPoke.Add(3, CrearPokemon("Venusaur", 100, TipoPokemon.Planta,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Planta)));
        CatalogoPoke.Add(4, CrearPokemon("Pikachu", 100, TipoPokemon.Electrico,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Electrico)));
        CatalogoPoke.Add(5, CrearPokemon("Gengar", 100, TipoPokemon.Fantasma,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Fantasma)));
        CatalogoPoke.Add(6, CrearPokemon("Machamp", 100, TipoPokemon.Lucha,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Lucha)));
        CatalogoPoke.Add(7, CrearPokemon("Pidgeot", 100, TipoPokemon.Volador,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Volador)));
        CatalogoPoke.Add(8, CrearPokemon("Sandslash", 100, TipoPokemon.Tierra,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Tierra)));
        CatalogoPoke.Add(9, CrearPokemon("Rhydon", 100, TipoPokemon.Roca,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Roca)));
        CatalogoPoke.Add(10, CrearPokemon("Butterfree", 100, TipoPokemon.Bicho,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Bicho)));
        CatalogoPoke.Add(11, CrearPokemon("Arbok", 100, TipoPokemon.Veneno,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Veneno)));
        CatalogoPoke.Add(12, CrearPokemon("Alakazam", 100, TipoPokemon.Psiquico,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Psiquico)));
        CatalogoPoke.Add(13, CrearPokemon("Jynx", 100, TipoPokemon.Hielo,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Hielo)));
        CatalogoPoke.Add(14, CrearPokemon("Dragonite", 100, TipoPokemon.Dragon,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Dragon)));
        CatalogoPoke.Add(15, CrearPokemon("Eevie", 100, TipoPokemon.Fuego,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Fuego)));
        CatalogoPoke.Add(16, CrearPokemon("Bulbasaur", 100, TipoPokemon.Planta,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Planta)));

    }
    /// <summary>
        /// Muestra en consola todos los Pokémon disponibles en el catálogo.
        /// </summary>
        public static void MostrarCatalogo()
        {
            Console.WriteLine("\nCatálogo de Pokemones Disponibles:");
            foreach (var pokemon in CatalogoPoke)
            {
                Console.WriteLine($"{pokemon.Key}. {pokemon.Value.Nombre} - Tipo: {pokemon.Value.Tipo}");
            }
        }


        /// <summary>
        /// Permite seleccionar un Pokémon del catálogo por su índice.
        /// </summary>
        public static IPokemon SeleccionarPokemon(int indice, List<IPokemon> equipoActual)
        {
            if (!CatalogoPoke.ContainsKey(indice))
            {
                Console.WriteLine("Índice de pokémon no válido.");
                return null;
            }

            var pokemon = CatalogoPoke[indice];

            if (equipoActual.Count >= 6)
            {
                Console.WriteLine("El equipo ya está completo.");
                return null;
            }

            if (equipoActual.Any(p => p.Nombre == pokemon.Nombre))
            {
                Console.WriteLine($"{pokemon.Nombre} ya está en tu equipo.");
                return null;
            }

            Console.WriteLine($"Seleccionando Pokémon: {pokemon.Nombre}");
            return pokemon;
        }
    }

    /// <summary>
    /// Clase para manejar la selección de equipos Pokémon.
    /// </summary>
    public class SelectorEquipoPokemon
    {
        /// <summary>
        /// Permite seleccionar un equipo de 6 Pokémon.
        /// </summary>
        public List<IPokemon> SeleccionarEquipo()
        {
            List<IPokemon> equipo = new List<IPokemon>();
            
            Console.WriteLine("¡Bienvenido al Selector de Equipo Pokémon!");
            Console.WriteLine("Selecciona 6 Pokémon para formar tu equipo.");
            

            while (equipo.Count < 6)
            {
                CatalogoPokemones.MostrarCatalogo();
                Console.WriteLine($"\nSelecciona el número del pokémon que deseas añadir a tu equipo ({equipo.Count}/6):");

                if (int.TryParse(Console.ReadLine(), out int seleccion))
                {
                    var pokemonSeleccionado = CatalogoPokemones.SeleccionarPokemon(seleccion, equipo);
                    
                    if (pokemonSeleccionado != null)
                    {
                        equipo.Add(pokemonSeleccionado);
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }
            }

            Console.WriteLine("\n¡Tu equipo está completo!");
            MostrarEquipoFinal(equipo);
            return equipo;
        }

        /// <summary>
        /// Muestra en consola el equipo final seleccionado.
        /// </summary>
        private void MostrarEquipoFinal(List<IPokemon> equipo)
        {
            Console.WriteLine($"Tienes {equipo.Count} Pokémon en tu equipo:");
            for (int i = 0; i < equipo.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {equipo[i].Nombre} - Tipo: {equipo[i].Tipo} - Vida: {equipo[i].Vida}");
            }
        }
}