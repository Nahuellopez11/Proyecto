using System.Security.Cryptography;
// ya no es "pokemon1" yippeeee !
namespace Program
{ 
    /// <summary>
    /// Representa un Pokémon en el juego, con atributos, estados y habilidades.
    /// </summary>
    public class Pokemon : IPokemon
    {
        /// <summary>
        /// Obtiene el nombre del Pokémon.
        /// </summary>
        public string Nombre { get; private set; }
        /// <summary>
        /// Obtiene el tipo del Pokémon.
        /// </summary>
        public TipoPokemon Tipo { get; private set; }
        /// <summary>
        /// Obtiene o establece la cantidad actual de vida del Pokémon.
        /// </summary>
        public double Vida { get; set; }
        /// <summary>
        /// Obtiene o establece la cantidad inicial de vida del Pokémon.
        /// </summary>
        public int VidaInicial { get; set; }

        private string Estado { get; set; }
        private static Random random = new Random();
        /// <summary>
        /// Lista de ataques que el Pokémon tiene disponibles.
        /// </summary>
        public List<Ataque> AtaquesDisponibles { get; private set; }
        /// <summary>
        /// Obtiene o establece el estado especial actual del Pokémon.
        /// </summary>
        public EstadoEspecial EstadoActual { get; set; }
        private int TurnosDormido { get; set; }
        

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Pokemon"/> con los atributos básicos.
        /// </summary>
        /// <param name="nombre">Nombre del Pokémon.</param>
        /// <param name="vida">Cantidad inicial de vida.</param>
        /// <param name="tipo">Tipo del Pokémon.</param>
        public Pokemon(string nombre, int vida, TipoPokemon tipo)
        {
            Nombre = nombre;
            Vida = vida;
            Tipo = tipo;
            VidaInicial = vida;
            Estado = "Normal";

            
            AtaquesDisponibles = HabilidadesPorTipo.ObtenerAtaquesPorTipo(tipo)
                .Cast<Ataque>()  // Convertir a Ataque
                .ToList();       // Convertir a lista
        }
        /// <summary>
        /// Reduce la vida del Pokémon en una cantidad específica de daño.
        /// </summary>
        /// <param name="daño">Cantidad de daño recibido.</param>
        public void RecibirDaño(int daño)
        {
            Vida = Math.Max(0, Vida - daño);
        }
        
       //------------------Efectos-------------------------------//
       /// <summary>
       /// Determina si el Pokémon puede atacar dependiendo de su estado actual.
       /// </summary>
       /// <returns>Verdadero si el Pokémon puede atacar; de lo contrario, falso.</returns>

       public bool PuedeAtacar()
       {
           if (TurnosDormido > 0)
           {
               TurnosDormido -= 1;
               Console.WriteLine($"{Nombre} está dormido y no puede atacar!");
               if (TurnosDormido == 0)
               {
                   EstadoActual = EstadoEspecial.Normal;
                   Console.WriteLine($"{Nombre} se ha despertado!");
               }

               return false;
           }

           if (EstadoActual == EstadoEspecial.Paralizado)
           {
               bool puedeAtacar = random.Next(2) == 0; // 50% de probabilidad
               if (!puedeAtacar)
               {
                   Console.WriteLine($"{Nombre} está paralizado y no puede atacar!");
               }
               return puedeAtacar;
           }

           return true;
       }
       
       /// <summary>
       /// Aplica un nuevo estado especial al Pokémon.
       /// </summary>
       /// <param name="nuevoEstado">El nuevo estado especial a aplicar.</param>
       public void AplicarEfectoEstado(EstadoEspecial nuevoEstado)
       {
           if (EstadoActual != EstadoEspecial.Normal)
           {
               Console.WriteLine(
                   $"{Nombre} ya está afectado por {EstadoActual} y no puede ser afectado por {nuevoEstado}");
               return;
           }

           EstadoActual = nuevoEstado;
           if (nuevoEstado == EstadoEspecial.Dormido)
           {
               TurnosDormido = random.Next(1, 5); // 1-4 turnos
               Console.WriteLine($"{Nombre} se ha dormido por {TurnosDormido} turnos!");
           }
           else if (nuevoEstado == EstadoEspecial.Paralizado)
           {
               Console.WriteLine($"{Nombre} ha sido paralizado!");
           }
           else if (nuevoEstado == EstadoEspecial.Envenenado)
           {
               Console.WriteLine($"{Nombre} ha sido envenenado!");
           }
           else if (nuevoEstado == EstadoEspecial.Quemado)
           {
               Console.WriteLine($"{Nombre} ha sido quemado!"); 
           }


        }
       /// <summary>
       /// Aplica los efectos de fin de turno en función del estado especial actual del Pokémon.
       /// </summary>
       public void AplicarEfectosFinTurno()
       {
           switch (EstadoActual)
           {
               case EstadoEspecial.Envenenado:
                   double dañoVeneno = VidaInicial * 0.05; // 5% del HP total
                   RecibirDaño((int)dañoVeneno);
                   Console.WriteLine($"{Nombre} pierde {dañoVeneno} HP por envenenamiento!");
                   break;
               case EstadoEspecial.Quemado:
                   double dañoQuemadura = VidaInicial * 0.10; // 10% del HP total
                   RecibirDaño((int)dañoQuemadura);
                   Console.WriteLine($"{Nombre} pierde {dañoQuemadura} HP por quemadura!");
                   break;
           }
       }
       /// <summary>
       /// Cura al Pokémon de todos los estados especiales.
       /// </summary>
       public void CurarEstados()
       {
           EstadoActual = EstadoEspecial.Normal;
           TurnosDormido = 0;
           Console.WriteLine($"{Nombre} ha sido curado de todos los estados!");
       }
        
       public override bool Equals(object obj)
        {
            if (obj is Pokemon other)
            {
                return this.Nombre == other.Nombre && this.Tipo == other.Tipo;
            }
            return false;
        }
        
        //---------Visitor-----------//
        public override int GetHashCode()
        {
            return HashCode.Combine(Nombre, Tipo);
        }

        public void Accept(IVisitorPoke visitorPoke)
        {
            visitorPoke.VisitPokemon(this);  // Llamamos a VisitPokemon directamente
        }
        //----------Ataques----------------//
        /// <summary>
        /// Agrega un nuevo ataque al conjunto de ataques disponibles del Pokémon.
        /// </summary>
        /// <param name="ataque">El ataque que el Pokémon aprenderá.</param>
        public void AprenderAtaque(Ataque ataque)
        {
            if (AtaquesDisponibles.Count < 4)
            {
                AtaquesDisponibles.Add(ataque);
            }
            else
            {
                Console.WriteLine($"{Nombre} ya tiene 4 ataques. Debe olvidar uno para aprender {ataque.NombreHabilidad}");
            }
        }
        /// <summary>
        /// Realiza un ataque al Pokémon objetivo.
        /// </summary>
        /// <param name="indiceAtaque">El índice del ataque en la lista de ataques disponibles.</param>
        /// <param name="objetivo">El Pokémon objetivo del ataque.</param>
        public void RealizarAtaque(int indiceAtaque, Pokemon objetivo)
        {
            if (!PuedeAtacar())
            {
                return;
            }

            if (indiceAtaque >= 0 && indiceAtaque < AtaquesDisponibles.Count)
            {
                var ataque = AtaquesDisponibles[indiceAtaque];
                int daño = ataque.CalcularDaño(this, objetivo);
                
                if (daño > 0)
                {
                    objetivo.RecibirDaño(daño);
                    Console.WriteLine($"Vida restante de {objetivo.Nombre}: {objetivo.Vida}");
                }
            }
        }
        
    }
}

