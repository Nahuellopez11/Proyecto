using Program;
namespace Program;

public static class ListaTestUsuario2
{
    // Lista estática de prueba de Pokémon
    public static List<IPokemon> ListaPokeTest2 { get; private set; } = new List<IPokemon>();

    // Constructor estático para inicializar la lista
    static ListaTestUsuario2()
    {
        AgregarPokemonesAListaTest2();
    }

    // Método para agregar Pokémon a la lista de prueba
    public static void AgregarPokemonesAListaTest2()
    {


        // Agregando Pokémon a la lista de prueba
        ListaPokeTest2.Add(Program.CatalogoPokemones.CrearPokemon("Arbok", 100, TipoPokemon.Veneno,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Veneno)));
        ListaPokeTest2.Add(Program.CatalogoPokemones.CrearPokemon("Alakazam", 100, TipoPokemon.Psiquico,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Psiquico)));
        ListaPokeTest2.Add(Program.CatalogoPokemones.CrearPokemon("Jynx", 100, TipoPokemon.Hielo,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Hielo)));
        ListaPokeTest2.Add(Program.CatalogoPokemones.CrearPokemon("Dragonite", 100, TipoPokemon.Dragon,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Dragon)));
        ListaPokeTest2.Add(Program.CatalogoPokemones.CrearPokemon("Eevie", 100, TipoPokemon.Fuego,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Fuego)));
        ListaPokeTest2.Add(Program.CatalogoPokemones.CrearPokemon("Bulbasaur", 100, TipoPokemon.Planta,HabilidadesPorTipo.ObtenerAtaquesPorTipo(TipoPokemon.Planta)));
    }
}