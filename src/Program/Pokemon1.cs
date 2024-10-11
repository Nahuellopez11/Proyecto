namespace Program;

public class Pokemon1 : IPokemones
{
    //Atributos
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    
    private int vida;
    public int Vida
    {
        get { return vida; }
        set
        {
            vida = value;
            EstaVivo = vida > 0;
        }
    }
    public bool EstaVivo { get; set; }
    public List<HabilidadesPokemon> Habilidades { get; set; } = new List<HabilidadesPokemon>();
    
    //Metodo Constructor
    public Pokemon1(string nombre, string tipo, int vidaInicial)
    {
        Nombre = nombre;
        Tipo = tipo;
        Vida = vidaInicial;
        EstaVivo = vidaInicial > 0; 
    }
    
    //Metodos
    public void AgregarHabilidad(HabilidadesPokemon habilidad)
    {
        Habilidades.Add(habilidad);
    }

    public void QuitarHabilidad(HabilidadesPokemon habilidad)
    {
        Habilidades.Remove(habilidad);
    }

}