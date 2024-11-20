namespace Program;

public class Jugador : IJugador
{
    public int Id { get; set; }
    public List<IPokemon> ListaDePokemones { get; set; } = new List<IPokemon>();

    public List<IItem> Items { get; set; } = new List<IItem>
    {
        new SuperPocion(),
        new Revivir(),
        //aqui se agrega el otro item

    };

    public Jugador(List<IPokemon> listaDePokemones)
    {
        this.ListaDePokemones = listaDePokemones;
    }

    public IPokemon ElegirPrimerPokemon()
    {

        return ListaDePokemones[0];
    }

}


