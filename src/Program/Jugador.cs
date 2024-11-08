namespace Program;

public class Jugador : IJugadores
{
    public List<IPokemones> ListaDePokemones { get; set; } = new List<IPokemones>();

    public List<IItem> Items { get; set; } = new List<IItem>
    {
        new SuperPocion(),
        new Revivir(),
        //aqui se agrega el otro item

    };

    public Jugador(List<IPokemones> listaDePokemones)
    {
        this.ListaDePokemones = listaDePokemones;
    }
}


