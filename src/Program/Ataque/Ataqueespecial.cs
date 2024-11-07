/*
namespace Program;

{
public class AtaqueEspecial
  {
      public string Nombre { get; private set; }
      public Tipo Tipo { get; private set; }
      public int DañoBase { get; private set; }
      public bool EsEspecial { get; private set; }
      public double Precision { get; private set; }
      private static Random random = new Random();

      public AtaqueEspecial(string nombre, Tipo tipo, int dañoBase, bool esEspecial, double precision)
      {
          Nombre = nombre;
          Tipo = tipo;
          DañoBase = dañoBase;
          EsEspecial = esEspecial;
          Precision = precision;
      }

      // Aca se ejecuta el ataque
      public int EjecutarAtaque(Pokemon1 objetivo)
      {
          // Ver si el ataque es critico
          if (!EsExitoso())
          {
              Console.WriteLine($"{Nombre} falló.");
              return 0;
          }

          // En caso de ser critico, calcula el daño
          int daño = CalcularCritico(DañoBase);

          // Si es especial, aplica un efecto
          if (EsEspecial)
          {
              AplicarEfectoEspecial(objetivo);
          }

          // 4. Aplicar el daño calculado al objetivo
          objetivo.RecibirDaño(daño);
          return daño;
      }

      // Método que indica si el ataque se acierta, teniendo en cuenta la precisión
      private bool EsExitoso()
      {
          return random.NextDouble() <= Precision; // Si el ataque fuera 0.8 se acertaría el 80% de las veces
      }

      // Calcula si el ataque es crítico (10% de posibilidad)
      private int CalcularCritico(int daño)
      {
          if (random.NextDouble() <= 0.1)
          {
              Console.WriteLine("¡Golpe crítico!");
              daño = (int)(daño * 1.2); // Aumentar el daño en 20% si es crítico
          }
          return daño;
      }

      // Método para aplicar un efecto especial
      private void AplicarEfectoEspecial(Pokemon1 objetivo)
      {
          if (objetivo.TieneEstadoEspecial())
          {
              Console.WriteLine($"{objetivo.Nombre} ya tiene un efecto especial.");
              return;
          }

          // Elegir un efecto especial aleatorio
          int efecto = random.Next(1, 5);
          switch (efecto)
          {
              case 1:
                  objetivo.AplicarEstadoDormido();
                  Console.WriteLine($"{objetivo.Nombre} se ha quedado dormido.");
                  break;
              case 2:
                  objetivo.AplicarEstadoParalizado();
                  Console.WriteLine($"{objetivo.Nombre} ha sido paralizado.");
                  break;
              case 3:
                  objetivo.AplicarEstadoEnvenenado();
                  Console.WriteLine($"{objetivo.Nombre} ha sido envenenado.");
                  break;
              case 4:
                  objetivo.AplicarEstadoQuemado();
                  Console.WriteLine($"{objetivo.Nombre} ha sido quemado.");
                  break;
          }
      }
  }
}
*/
