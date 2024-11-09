using System.Security.AccessControl;

namespace Program;

public static class CatalogoPokemones
{
    public static Dictionary<int, IPokemones> CatalogoPoke { get; private set; } = new Dictionary<int, IPokemones>();
    private static readonly SeleccionPokesVisitorPoke SelectionVisitorPoke = new SeleccionPokesVisitorPoke();
   
    static CatalogoPokemones()
    {
        AgregarPokemonesCatalogo();
    }

    public static void AgregarPokemonesCatalogo()
    {
        var armador = new Armar();
        
        CatalogoPoke.Add(1, armador.CrearPokemon("Charizard", 100, "Fuego"));
        CatalogoPoke.Add(2, armador.CrearPokemon("Blastoise", 100, "Agua"));
        CatalogoPoke.Add(3, armador.CrearPokemon("Venusaur", 100, "Planta"));
        CatalogoPoke.Add(4, armador.CrearPokemon("Pikachu", 100, "Eléctrico"));
        CatalogoPoke.Add(5, armador.CrearPokemon("Gengar", 100, "Fantasma"));
        CatalogoPoke.Add(6, armador.CrearPokemon("Machamp", 100, "Lucha"));
        CatalogoPoke.Add(7, armador.CrearPokemon("Pidgeot", 100, "Volador"));
        CatalogoPoke.Add(8, armador.CrearPokemon("Sandslash", 100, "Tierra"));
        CatalogoPoke.Add(9, armador.CrearPokemon("Rhydon", 100, "Roca"));
        CatalogoPoke.Add(10, armador.CrearPokemon("Butterfree", 100, "Bicho"));
        CatalogoPoke.Add(11, armador.CrearPokemon("Arbok", 100, "Veneno"));
        CatalogoPoke.Add(12, armador.CrearPokemon("Alakazam", 100, "Psíquico"));
        CatalogoPoke.Add(13, armador.CrearPokemon("Jynx", 100, "Hielo"));
        CatalogoPoke.Add(14, armador.CrearPokemon("Dragonite", 100, "Dragón"));
        CatalogoPoke.Add(15, armador.CrearPokemon("Mawile", 100, "Acero"));
        CatalogoPoke.Add(16, armador.CrearPokemon("Umbreon", 100, "Siniestro"));
        
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

        pokemon.Accept(SelectionVisitorPoke);


        return SelectionVisitorPoke.FueElegido;
    }


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