namespace Program;

public class Maquina : IJugador
{

    public string Nombre { get; private set; }
    public List<IPokemon> ListaDePokemones { get;  set; }

    public Maquina(string nombre, List<IPokemon> listaDePokemones)
    {
        Nombre = nombre;
        ListaDePokemones = listaDePokemones;
    }
    
    public List<IItem> Items { get; set; } = new List<IItem>
    {
        new SuperPocion(),
        new Revivir(),
        //aqui se agrega el otro item

    };
    


    


}

// hace lo mismo que Jugador solo que sin escribir (sino te spamea mal)