using System.Security.Cryptography;
// ya no es "pokemon1" yippeeee !
namespace Program
{ 
    public class Pokemon : IPokemon
    {
        public string Nombre { get; private set; }
        public TipoPokemon Tipo { get; private set; }
        public double Vida { get; set; }
        public int VidaInicial { get; set; }
        public string Estado { get; set; }
        private static Random random = new Random();
        public List<Ataque> AtaquesDisponibles { get;  set; }
        public EstadoEspecial EstadoActual { get; set; }
        private int TurnosDormido { get; set; }
        public bool FueAfectado { get; set; }

        public Pokemon(string nombre, int vida, TipoPokemon tipo)
        {
            Nombre = nombre;
            Vida = vida;
            Tipo = tipo;
            VidaInicial = vida;
            Estado = "Normal";
            FueAfectado = false;
            
            AtaquesDisponibles = HabilidadesPorTipo.ObtenerAtaquesPorTipo(tipo)
                .Cast<Ataque>()  // Convertir a Ataque
                .ToList();       // Convertir a lista
        }

        public void RecibirDaño(int daño)
        {
            Vida = Math.Max(0, Vida - daño);
        }
        
       //------------------Efectos-------------------------------//
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
               FueAfectado = true;
               return false;
           }

           if (EstadoActual == EstadoEspecial.Paralizado)
           {
               bool puedeAtacar = random.Next(2) == 0; // 50% de probabilidad
               if (!puedeAtacar)
               {
                   Console.WriteLine($"{Nombre} está paralizado y no puede atacar!");
               }

               FueAfectado = true;
               return puedeAtacar;
           }

           return true;
       }

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
               FueAfectado = true;
           }
           else if (nuevoEstado == EstadoEspecial.Paralizado)
           {
               Console.WriteLine($"{Nombre} ha sido paralizado!");
               FueAfectado = true;
           }
           else if (nuevoEstado == EstadoEspecial.Envenenado)
           {
               Console.WriteLine($"{Nombre} ha sido envenenado!");
               FueAfectado = true;
           }
           else if (nuevoEstado == EstadoEspecial.Quemado)
           {
               Console.WriteLine($"{Nombre} ha sido quemado!");
               FueAfectado = true;
           }


        }
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

