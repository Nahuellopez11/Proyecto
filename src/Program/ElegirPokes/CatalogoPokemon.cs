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
        CatalogoPoke.Add(4, armador.CrearPokemon("Pikachu", 90, "Eléctrico"));
        CatalogoPoke.Add(5, armador.CrearPokemon("Gengar", 85, "Fantasma"));
        CatalogoPoke.Add(6, armador.CrearPokemon("Machamp", 95, "Lucha"));
        CatalogoPoke.Add(7, armador.CrearPokemon("Pidgeot", 85, "Volador"));
        CatalogoPoke.Add(8, armador.CrearPokemon("Sandslash", 90, "Tierra"));
        CatalogoPoke.Add(9, armador.CrearPokemon("Rhydon", 105, "Roca"));
        CatalogoPoke.Add(10, armador.CrearPokemon("Butterfree", 80, "Bicho"));
        CatalogoPoke.Add(11, armador.CrearPokemon("Arbok", 85, "Veneno"));
        CatalogoPoke.Add(12, armador.CrearPokemon("Alakazam", 90, "Psíquico"));
        CatalogoPoke.Add(13, armador.CrearPokemon("Jynx", 85, "Hielo"));
        CatalogoPoke.Add(14, armador.CrearPokemon("Dragonite", 100, "Dragón"));
        CatalogoPoke.Add(15, armador.CrearPokemon("Mawile", 85, "Acero"));
        CatalogoPoke.Add(16, armador.CrearPokemon("Umbreon", 90, "Siniestro"));
        
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