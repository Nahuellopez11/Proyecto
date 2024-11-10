namespace Program;

public static class ListaTestMaquina
{
    // Lista estática de Pokémon seleccionados para la máquina
    public static List<IPokemones> ListaPokeMaquina { get; private set; } = new List<IPokemones>();

    // Constructor estático para inicializar la lista
    static ListaTestMaquina()
    {
        GenerarEquipoMaquina();
    }

    // Método para generar el equipo de la máquina
    public static void GenerarEquipoMaquina()
    {
        // Utilizar la lógica de ElegirPokemonMaquina para seleccionar el equipo
        ElegirPokemonMaquina.SeleccionarEquipo();
        ListaPokeMaquina = ElegirPokemonMaquina.DevolverLista();
    }

    // Método para mostrar la lista de Pokémon de la máquina
    public static void MostrarListaMaquina()
    {
        Console.WriteLine("\nLista de Pokémon seleccionados para la máquina:");
        foreach (var pokemon in ListaPokeMaquina)
        {
            Console.WriteLine($"{pokemon.Nombre} - Tipo: {pokemon.Tipo}");
        }
    }
}