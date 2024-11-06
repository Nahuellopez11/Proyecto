using System.Security.Cryptography;

using System;

namespace Program
{
    public class Pokemon1 : IPokemones
    {
        public string Nombre { get; private set; }
        public string Tipo { get; private set; }
        public int Vida { get; private set; }

        // Variables para estados especiales
        private bool estaDormido;
        private bool estaParalizado;
        private bool estaEnvenenado;
        private bool estaQuemado;
        private int turnosDormido;

        private static Random random = new Random();

        public Pokemon1(string nombre, int vida, string tipo)
        {
            Nombre = nombre;
            Vida = vida;
            Tipo = tipo;
        }

        // Método necesario para la visita del visitante
        public void Accept(IVisitor visitor)
        {
            visitor.VisitPokemon(this);
        }

        // Método para recibir daño
        public void RecibirDaño(int cantidad)
        {
            if (Vida <= 0)
            {
                Console.WriteLine($"{Nombre} ya está fuera de combate.");
                return;
            }

            Vida -= cantidad;
            if (Vida < 0) Vida = 0;

            Console.WriteLine($"{Nombre} recibió {cantidad} puntos de daño.");

            if (Vida <= 0)
            {
                Console.WriteLine($"{Nombre} ha sido derrotado.");
            }
        }

        // Métodos para aplicar estados especiales
        public void AplicarEstadoDormido()
        {
            estaDormido = true;
            turnosDormido = random.Next(1, 5); // Dormido entre 1 y 4 turnos
            Console.WriteLine($"{Nombre} está dormido por {turnosDormido} turnos.");
        }

        public void AplicarEstadoParalizado()
        {
            estaParalizado = true;
            Console.WriteLine($"{Nombre} está paralizado.");
        }

        public void AplicarEstadoEnvenenado()
        {
            estaEnvenenado = true;
            Console.WriteLine($"{Nombre} está envenenado.");
        }

        public void AplicarEstadoQuemado()
        {
            estaQuemado = true;
            Console.WriteLine($"{Nombre} está quemado.");
        }

        // Método para verificar si ya tiene un estado especial
        public bool TieneEstadoEspecial()
        {
            return estaDormido || estaParalizado || estaEnvenenado || estaQuemado;
        }

        // Método para actualizar el estado en cada turno
        public void ActualizarEstado()
        {
            if (estaDormido)
            {
                turnosDormido--;
                if (turnosDormido <= 0)
                {
                    estaDormido = false;
                    Console.WriteLine($"{Nombre} se ha despertado.");
                }
                else
                {
                    Console.WriteLine($"{Nombre} sigue dormido. Turnos restantes: {turnosDormido}");
                }
            }

            if (estaParalizado && random.Next(0, 2) == 0) // 50% de probabilidad de no poder atacar
            {
                Console.WriteLine($"{Nombre} está paralizado y no puede moverse este turno.");
            }

            if (estaEnvenenado)
            {
                int dañoVeneno = (int)(Vida * 0.05);
                RecibirDaño(dañoVeneno);
                Console.WriteLine($"{Nombre} pierde {dañoVeneno} puntos de vida por envenenamiento.");
            }

            if (estaQuemado)
            {
                int dañoQuemadura = (int)(Vida * 0.10);
                RecibirDaño(dañoQuemadura);
                Console.WriteLine($"{Nombre} pierde {dañoQuemadura} puntos de vida por quemadura.");
            }
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