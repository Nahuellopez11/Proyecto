namespace Program;

public class Ataque: IHabilidadesPokemon
{
    public string NombreHabilidad { get; set; }
    public int ValorAtaque { get; set; }
    public TipoPokemon Tipo { get; private set; }
    public int DañoBase { get; private set; }
    public double Precision { get; private set; }
    private static Random random = new Random();

    public Ataque(string nombre, TipoPokemon tipo, int dañoBase, double precision)
    {
        NombreHabilidad = nombre;
        Tipo = tipo;
        DañoBase = dañoBase;
        Precision = precision;
    }

    public virtual int CalcularDaño(Pokemon atacante, Pokemon objetivo)
    {
        // Verificar precisión
        if (!EsExitoso())
        {
            Console.WriteLine($"¡{NombreHabilidad} falló!");
            return 0;
        }

        // Calcular daño base
        double daño = DañoBase;

        // Aplicar efectividad de tipos
        double efectividad = TablaEfectividad.ObtenerEfectividad(Tipo, objetivo.Tipo);
        daño *= efectividad;

        // Mostrar mensaje de efectividad
        if (efectividad > 1.0)
            Console.WriteLine("¡Es super efectivo!");
        else if (efectividad < 1.0 && efectividad > 0)
            Console.WriteLine("No es muy efectivo...");
        else if (efectividad == 0)
            Console.WriteLine("No afecta al Pokemon enemigo...");

        // Aplicar crítico si corresponde
        if (EsCritico())
        {
            daño *= 1.2;
            Console.WriteLine("¡Golpe crítico!");
        }

        return (int)Math.Round(daño);
    }

    private bool EsExitoso()
    {
        return random.NextDouble() <= Precision;
    }

    private bool EsCritico()
    {
        return random.NextDouble() <= 0.1; // 10% de probabilidad
    }
}