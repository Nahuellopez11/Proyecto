using System.Security.AccessControl;

namespace Program;

public static class CatalogoPokemones
//catalogo estatico de pokemones
{
    public static Dictionary<int, IPokemones> CatalogoPoke { get; private set; } = new Dictionary<int, IPokemones>();
    // Visitor utilizado para gestionar la selección de Pokemones por el jugador
    private static readonly SeleccionPokesVisitorPoke SelectionVisitorPoke = new SeleccionPokesVisitorPoke();
   
    static CatalogoPokemones()
    {
        AgregarPokemonesCatalogo();
    }

    public static void AgregarPokemonesCatalogo()
    {
        var armador = new Armar();
        
        CatalogoPoke.Add(1, armador.CrearPokemon("Charizard", 100, TipoPokemon.Fuego,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Fuego)));
        CatalogoPoke.Add(2, armador.CrearPokemon("Blastoise", 100, TipoPokemon.Agua,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Agua)));
        CatalogoPoke.Add(3, armador.CrearPokemon("Venusaur", 100, TipoPokemon.Planta,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Planta)));
        CatalogoPoke.Add(4, armador.CrearPokemon("Pikachu", 100, TipoPokemon.Electrico,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Electrico)));
        CatalogoPoke.Add(5, armador.CrearPokemon("Gengar", 100, TipoPokemon.Fantasma,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Fantasma)));
        CatalogoPoke.Add(6, armador.CrearPokemon("Machamp", 100, TipoPokemon.Lucha,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Lucha)));
        CatalogoPoke.Add(7, armador.CrearPokemon("Pidgeot", 100, TipoPokemon.Volador,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Volador)));
        CatalogoPoke.Add(8, armador.CrearPokemon("Sandslash", 100, TipoPokemon.Tierra,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Tierra)));
        CatalogoPoke.Add(9, armador.CrearPokemon("Rhydon", 100, TipoPokemon.Roca,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Roca)));
        CatalogoPoke.Add(10, armador.CrearPokemon("Butterfree", 100, TipoPokemon.Bicho,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Bicho)));
        CatalogoPoke.Add(11, armador.CrearPokemon("Arbok", 100, TipoPokemon.Veneno,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Veneno)));
        CatalogoPoke.Add(12, armador.CrearPokemon("Alakazam", 100, TipoPokemon.Psiquico,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Psiquico)));
        CatalogoPoke.Add(13, armador.CrearPokemon("Jynx", 100, TipoPokemon.Hielo,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Hielo)));
        CatalogoPoke.Add(14, armador.CrearPokemon("Dragonite", 100, TipoPokemon.Dragon,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Dragon)));
        CatalogoPoke.Add(15, armador.CrearPokemon("Eevie", 100, TipoPokemon.Fuego,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Fuego)));
        CatalogoPoke.Add(16, armador.CrearPokemon("Bulbasaur", 100, TipoPokemon.Planta,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Planta)));

    }

    public static bool SeleccionarPokemon(int indice)
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

    // Utiliza el Visitor para obtener la lista actual del equipo
    public static List<IPokemones> ObtenerEquipoActual()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
    {
        return SelectionVisitorPoke.Equipo;
    }

    public static void MostrarCatalogo()
    {
        Console.WriteLine("\nCatálogo de Pokemones Disponibles:");
        foreach (var pokemon in CatalogoPoke)
        {
            Console.WriteLine($"{pokemon.Key}. {pokemon.Value.Nombre} ");
        }
    }
    
}