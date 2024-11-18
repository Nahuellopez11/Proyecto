namespace Program;

public interface IJugador
{
    public List<IPokemon> ListaDePokemones { get; set; }
    public int Id { get; set; }

}