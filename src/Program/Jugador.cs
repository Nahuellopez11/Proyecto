namespace Program;

public class Jugador : IJugadores
{
    
    public Dictionary<int, IPokemones> Pokemones { get; set; } = new Dictionary<int, IPokemones>();
    public List<IPokemones> ListaDePokemones { get; set; } = new List<IPokemones>();
    public IPokemones pokemonActivo { get; set; }

    public Jugador(List<IPokemones> listaDePokemones)
    {
        this.ListaDePokemones = ListaDePokemones;
    }

}
    



