namespace Program;

public class Maquina : IJugadores
{

    public string Nombre { get; private set; }
    public List<IPokemones> ListaDePokemones { get; private set; }

    public Maquina(string nombre, List<IPokemones> listaDePokemones)
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