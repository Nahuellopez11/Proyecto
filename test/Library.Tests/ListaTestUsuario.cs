namespace Program;

public static class ListaTestUsuario
{
    // Lista estática de prueba de Pokémon
    public static List<IPokemon> ListaPokeTest { get; private set; } = new List<IPokemon>();

    // Constructor estático para inicializar la lista
    static ListaTestUsuario()
    {
        AgregarPokemonesAListaTest();
    }

    // Método para agregar Pokémon a la lista de prueba
    public static void AgregarPokemonesAListaTest()
    {
        var armador = new Armar();

        // Agregando Pokémon a la lista de prueba
        ListaPokeTest.Add(armador.CrearPokemon("Charizard", 100, TipoPokemon.Fuego, HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Fuego)));
        ListaPokeTest.Add(armador.CrearPokemon("Blastoise", 100, TipoPokemon.Agua, HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Agua)));
        ListaPokeTest.Add(armador.CrearPokemon("Venusaur", 100, TipoPokemon.Planta, HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Planta)));
        ListaPokeTest.Add(armador.CrearPokemon("Pikachu", 100, TipoPokemon.Electrico, HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Electrico)));
        ListaPokeTest.Add(armador.CrearPokemon("Gengar", 100, TipoPokemon.Fantasma, HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Fantasma)));
        ListaPokeTest.Add(armador.CrearPokemon("Snorlax", 100, TipoPokemon.Normal, HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Normal)));
    }
}