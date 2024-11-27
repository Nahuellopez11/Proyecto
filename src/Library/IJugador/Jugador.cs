namespace Program;

public class Jugador : IJugador
{

    public List<IPokemon> ListaDePokemones { get; set; } = new List<IPokemon>();
    public int Puntos { get; set; }

    public List<IItem> Items { get; set; } = new List<IItem>
    {
        new SuperPocion(),
        new Revivir(),
        //aqui se agrega el otro item

    };

    public Jugador(List<IPokemon> listaDePokemones, int puntos)
    {
        this.ListaDePokemones = listaDePokemones;
        this.Puntos = puntos;
    }

    public IPokemon ElegirPrimerPokemon()
    {

        return ListaDePokemones[0];
    }

}


