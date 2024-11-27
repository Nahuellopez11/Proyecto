namespace Program;

public interface IJugador
{
    public List<IPokemon> ListaDePokemones { get; set; }
    
    int Puntos { get; set; }
    public List<IItem> Items { get; set; }

}