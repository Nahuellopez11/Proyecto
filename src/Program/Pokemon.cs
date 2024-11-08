using System.Security.Cryptography;
// ya no es "pokemon1" yippeeee !
namespace Program
{
    public class Pokemon : IPokemones
    {
        public string Nombre { get; private set; }
        public string Tipo { get; private set; }
        public double Vida { get; set; }

        public Pokemon(string nombre, int vida, string tipo)
        {
            Nombre = nombre;
            Vida = vida;
            Tipo = tipo;
        }

        public override bool Equals(object obj)
        {
            if (obj is Pokemon other)
            {
                return this.Nombre == other.Nombre && this.Tipo == other.Tipo;
            }
            return false;
        }
        

        public void Accept(IVisitorPoke visitorPoke)
        {
            visitorPoke.VisitPokemon(this);  // Llamamos a VisitPokemon directamente
        }
    }
}

    /* bool EstaVivo { get; set; }
     List<HabilidadesPokemon> Habilidades { get; set; }
     public HabilidadesPokemon AgregarHabilidad(HabilidadesPokemon habilidad);
     public HabilidadesPokemon QuitarHabilidad(HabilidadesPokemon habilidad);
     public Atacar Atacar(IPokemones defensor, HabilidadesPokemon habilidadUsada);
     */






/*
    //Atributos
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    
    private int vida;
    private bool EstaActivo;
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
        EstaVivo = vida > 0;
        EstaActivo = false;
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

    public int MostrarVida()
    {
        if (EstaVivo = true)
        {
            return vida;
        }

        return 0;
    }
    public void Atacar(IPokemones defensor, HabilidadesPokemon habilidadUsada)
    {
        int dañoBase = habilidadUsada.ValorAtaque;
        string tipoAtaque = this.Tipo; 
        string tipoDefensor = defensor.Tipo;
        double modificador = DañoSegunTipo(tipoAtaque, tipoDefensor);
        int dañoTotal = (int)(dañoBase * modificador);
        defensor.Vida -= dañoTotal;
        if (defensor.Vida < 0)
        {
            defensor.Vida = 0;
        }

        // Mensaje de resultado del ataque
        Console.WriteLine($"{Nombre} atacó a {defensor.Nombre} con {habilidadUsada.NombreHabilidad}, causando {dañoTotal} puntos de daño.");
        Console.WriteLine($"{defensor.Nombre} ahora tiene {defensor.Vida} puntos de vida.");
    }

    public void RecibirDaño(int cantidad)
    {
        if (!EstaVivo)
        {
            Console.WriteLine($"{Nombre} ya está fuera de combate.");
            return;
        }
        Vida -= cantidad;
        Console.WriteLine($"{Nombre} recibió {cantidad} puntos de daño.");
        if (!EstaVivo)
        {
            Console.WriteLine($"{Nombre} ha sido derrotado.");
        }
    }
    
    private double DañoSegunTipo(string tipoAtaque, string tipoDefensor)
    {
        if (tipoAtaque == "Agua" && tipoDefensor == "Fuego")
        {
            return 1.0; // Agua es fuerte contra Fuego
        }
        else if (tipoAtaque == "Fuego" && tipoDefensor == "Agua")
        {
            return 0.3; // Agua es fuerte contra Fuego
        }
        else if (tipoAtaque == "Planta" && tipoDefensor == "Agua")
        {
            return 1.0; // Planta es fuerte contra Agua
        }
        else if (tipoAtaque == "Agua" && tipoDefensor == "Planta")
        {
            return 0.3; // Agua es débil contra Planta
        }
        else if (tipoAtaque == "Fuego" && tipoDefensor == "Planta")
        {
            return 1.0; // Fuego es fuerte contra Planta
        }
        else if (tipoAtaque == "Planta" && tipoDefensor == "Fuego")
        {
            return 0.3; // Planta es débil contra Fuego
        }

        // Si son neutros
        return 0.5;
    }
    public void MarcarComoActivo()
    {
        EstaActivo = true; // Marca este Pokémon como activo
    }

    // Método para desmarcar este Pokémon
    public void Desmarcar()
    {
        EstaActivo = false; // Desmarca este Pokémon
    }
   */