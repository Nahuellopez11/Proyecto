namespace Program;

public class Maquina : IJugadores
{
    public Dictionary<int, IPokemones> Pokemones { get; set; } = new Dictionary<int, IPokemones>();
    public List<IPokemones> ListaDePokemones { get; set; } = new List<IPokemones>();
    public IPokemones pokemonActivo { get; set; }
    
    public Maquina(List<IPokemones> listaDePokemones)
    {
        this.ListaDePokemones = ListaDePokemones;
    }

    


}

// hace lo mismo que Jugador solo que sin escribir (sino te spamea mal)