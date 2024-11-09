using System.Security.Cryptography;
// ya no es "pokemon1" yippeeee !
namespace Program
{ 
    public class Pokemon : IPokemones
    {
        public string Nombre { get; private set; }
        public TipoPokemon Tipo { get; private set; }
        public double Vida { get; set; }
        public int VidaInicial { get; set; }
        private string Estado { get; set; }
        private int TurnosEstado { get; set; }
        private static Random random = new Random();
        private bool PuedoAtacar { get; set; }
        public List<Ataque> AtaquesDisponibles { get; private set; }
        

        public Pokemon(string nombre, int vida, TipoPokemon tipo)
        {
            Nombre = nombre;
            Vida = vida;
            Tipo = tipo;
            VidaInicial = vida;
            Estado = "Normal";
            TurnosEstado = 0;
            
            AtaquesDisponibles = HabilidadesPorTipo.ObtenerAtaquesPorTipo(tipo)
                .Cast<Ataque>()  // Convertir a Ataque
                .ToList();       // Convertir a lista
        }

        public void RecibirDaño(int daño)
        {
            Vida = Math.Max(0, Vida - daño);
        }
        
        public void TieneEstadoEspecial()
        {
            if (Estado == "Paralizado")
            {
                ProcesarParalisis();
            }
            else if (Estado == "Dormido")
            {
                ProcesarDormido();
            }
            else if (Estado == "Envenenado")
            {
                ProcesarEnvenenado();
            }
            else if (Estado == "Quemado")
            {
                ProcesarQuemado();
            }
        }

        public void AplicarEstadoParalizado()
        {
            Estado = "Paralizado";
            TurnosEstado = 3;
            while (TurnosEstado>0)
            {
                ProcesarParalisis();

            }
        }   
       /* public void AplicarEstadoDormido()
        {
            Estado = "Dormido";
            TurnosEstado = random.Next(1, 5); // Entre 1 y 4 turnos
            if (turno == TurnosEstado)
            {
                ProcesarDormido();
            }

        }
*/
        public void AplicarEstadoEnvenenado()
        {
            Estado = "Envenenado";
            TurnosEstado = 3;
            while (TurnosEstado>0)
            {
                ProcesarQuemado();
            }
            
        }

        public void AplicarEstadoQuemado()
        {
            Estado = "Quemado";
            TurnosEstado = 3;
            ProcesarQuemado();
        }

        

        public void ProcesarParalisis()
        {
            if (random.NextDouble() <= 0.25)
            {
                PuedoAtacar = false;
            }
            else
            {
                PuedoAtacar = true;
            }
        }

        public void ProcesarDormido()
        {
            
            PuedoAtacar = false;
        }

        public void ProcesarQuemado()
        {
            int dañoVeneno = (int)(VidaInicial * 0.05); // 5% de la vida máxima
            RecibirDaño(dañoVeneno);
            Console.WriteLine($"{Nombre} sufre {dañoVeneno} de daño por envenenamiento.");
        }

        public void ProcesarEnvenenado()
        {
            int dañoQuemadura = (int)(VidaInicial * 0.10); // 10% de la vida máxima
            RecibirDaño(dañoQuemadura);
            Console.WriteLine($"{Nombre} sufre {dañoQuemadura} de daño por quemadura.");
        }
        public override bool Equals(object obj)
        {
            if (obj is Pokemon other)
            {
                return this.Nombre == other.Nombre && this.Tipo == other.Tipo;
            }
            return false;
        }
        

        public override int GetHashCode()
        {
            return HashCode.Combine(Nombre, Tipo);
        }

        public void Accept(IVisitorPoke visitorPoke)
        {
            visitorPoke.VisitPokemon(this);  // Llamamos a VisitPokemon directamente
        }
        
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
            if (indiceAtaque >= 0 && indiceAtaque < AtaquesDisponibles.Count)
            {
                var ataque = AtaquesDisponibles[indiceAtaque];
                int daño = ataque.CalcularDaño(this, objetivo);
                
                if (daño > 0)
                {
                    objetivo.RecibirDaño(daño);
                    Console.WriteLine($"{Nombre} usó {ataque.NombreHabilidad} y causó {daño} de daño a {objetivo.Nombre}!");
                    Console.WriteLine($"Vida restante de {objetivo.Nombre}: {objetivo.Vida}");
                }
            }
        }
        
    }
}

