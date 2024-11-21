using Program;
namespace Program;

public static class ListaTestJugador1
{
    // Lista estática de prueba de Pokémon
    public static List<IPokemon> ListaPokeTest { get; private set; } = new List<IPokemon>();

    // Constructor estático para inicializar la lista
    static ListaTestJugador1()
    {
        AgregarPokemonesAListaTest();
    }

    // Método para agregar Pokémon a la lista de prueba
    public static void AgregarPokemonesAListaTest()
    {


        // Agregando Pokémon a la lista de prueba
        ListaPokeTest.Add(Program.CatalogoPokemones.CrearPokemon("Charizard", 100, TipoPokemon.Fuego, HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Fuego)));
        ListaPokeTest.Add(Program.CatalogoPokemones.CrearPokemon("Blastoise", 100, TipoPokemon.Agua, HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Agua)));
        ListaPokeTest.Add(Program.CatalogoPokemones.CrearPokemon("Venusaur", 100, TipoPokemon.Planta, HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Planta)));
        ListaPokeTest.Add(Program.CatalogoPokemones.CrearPokemon("Pikachu", 100, TipoPokemon.Electrico, HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Electrico)));
        ListaPokeTest.Add(Program.CatalogoPokemones.CrearPokemon("Gengar", 100, TipoPokemon.Fantasma, HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Fantasma)));
        ListaPokeTest.Add(Program.CatalogoPokemones.CrearPokemon("Snorlax", 100, TipoPokemon.Normal, HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Normal)));
    }
}