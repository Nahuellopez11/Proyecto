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
    public  Dictionary<int, IPokemon> CatalogoPoke { get; private set; } = new Dictionary<int, IPokemon>();
    
    /// <summary>
    /// Visitor utilizado para gestionar la selección de Pokémon del primer jugador.
    /// </summary>
    private  readonly SeleccionPokesVisitorPoke SelectionVisitorPoke = new SeleccionPokesVisitorPoke();
   
    /// <summary>
    /// Visitor utilizado para gestionar la selección de Pokémon del segundo jugador.
    /// </summary>
    private  readonly SeleccionPokesVisitorPoke SelectionVisitorPoke2 = new SeleccionPokesVisitorPoke();
    
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
    public CatalogoPokemones()
    
    {
        AgregarPokemonesCatalogo();
    }
   
    /// <summary>
    /// Agrega todos los Pokémon predefinidos al catálogo.
    /// Inicializa el diccionario CatalogoPoke con diferentes especies de Pokémon.
    /// </summary>
    public  void AgregarPokemonesCatalogo()
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
    /// Permite al primer jugador seleccionar un Pokémon del catálogo por su índice.
    /// </summary>
    /// <param name="indice">Índice del Pokémon en el catálogo.</param>
    /// <returns>true si la selección fue exitosa, false en caso contrario.</returns>
    public  bool SeleccionarPokemon(int indice)
    {
        if (!CatalogoPoke.ContainsKey(indice))
        {
            Console.WriteLine("Índice de pokémon no válido.");
            return false;
        }

        var pokemon = CatalogoPoke[indice];
        Console.WriteLine($"Seleccionando Pokémon: {pokemon.Nombre}"); 
    // Usa el Visitor para añadir el Pokémon seleccionado al equipo del jugador

        pokemon.Accept(SelectionVisitorPoke);


        return SelectionVisitorPoke.FueElegido;
    }
    
    /// <summary>
    /// Permite al segundo jugador seleccionar un Pokémon del catálogo por su índice.
    /// </summary>
    /// <param name="indice">Índice del Pokémon en el catálogo.</param>
    /// <returns>true si la selección fue exitosa, false en caso contrario.</returns>
    public  bool SeleccionarPokemon2(int indice)
    {
        if (!CatalogoPoke.ContainsKey(indice))
        {
            Console.WriteLine("Índice de pokémon no válido.");
            return false;
        }

        var pokemon = CatalogoPoke[indice];
        Console.WriteLine($"Seleccionando Pokémon: {pokemon.Nombre}"); 
// Usa el Visitor para añadir el Pokémon seleccionado al equipo del jugador
        pokemon.Accept(SelectionVisitorPoke2);


        return SelectionVisitorPoke2.FueElegido;
    }
    

    /// <summary>
    /// Obtiene la lista de Pokémon seleccionados por el primer jugador.
    /// </summary>
    /// <returns>Lista de Pokémon en el equipo del primer jugador.</returns>
    public  List<IPokemon> ObtenerEquipoActual()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
    {
        return SelectionVisitorPoke.Equipo;
    }
    /// <summary>
    /// Obtiene la lista de Pokémon seleccionados por el segundo jugador.
    /// </summary>
    /// <returns>Lista de Pokémon en el equipo del segundo jugador.</returns>
    public  List<IPokemon> ObtenerEquipoActual2()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
    {
        return SelectionVisitorPoke2.Equipo;
    }
    /// <summary>
    /// Muestra en consola todos los Pokémon disponibles en el catálogo.
    /// Lista cada Pokémon con su índice y nombre.
    /// </summary>
    public  void MostrarCatalogo()
    {
        Console.WriteLine("\nCatálogo de Pokemones Disponibles:");
        foreach (var pokemon in CatalogoPoke)
        {
            Console.WriteLine($"{pokemon.Key}. {pokemon.Value.Nombre} ");
        }
    }
    
}