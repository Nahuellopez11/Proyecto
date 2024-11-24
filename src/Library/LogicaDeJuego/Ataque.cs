namespace Program;
/// <summary>
/// Representa un ataque que un Pokémon puede realizar, incluyendo sus propiedades y lógica de cálculo de daño.
/// </summary>
public class Ataque: IHabilidadesPokemon
{
    /// <summary>
    /// Obtiene o establece el nombre del ataque.
    /// </summary>
    public string NombreHabilidad { get; set; }
    /// <summary>
    /// Obtiene o establece el valor base de ataque.
    /// </summary>
    public int ValorAtaque { get; set; }
   
    /// <summary>
    /// Obtiene el tipo del ataque.
    /// </summary>
    public TipoPokemon Tipo { get; private set; }
    
    /// <summary>
    /// Obtiene el daño base del ataque.
    /// </summary>
    public int DañoBase { get; private set; }
    /// <summary>
    /// Obtiene la precisión del ataque, representada como un valor entre 0 y 1.
    /// </summary>
    public double Precision { get; private set; }
    private static Random random = new Random();

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Ataque"/>.
    /// </summary>
    /// <param name="nombre">El nombre del ataque.</param>
    /// <param name="tipo">El tipo del ataque.</param>
    /// <param name="dañoBase">El daño base del ataque.</param>
    /// <param name="precision">La precisión del ataque (valor entre 0 y 1).</param>
    public Ataque(string nombre, TipoPokemon tipo, int dañoBase, double precision)
    {
        NombreHabilidad = nombre;
        Tipo = tipo;
        DañoBase = dañoBase;
        Precision = precision;
    }
    /// <summary>
    /// Calcula el daño infligido por este ataque a un objetivo, considerando precisión, efectividad de tipos y golpes críticos.
    /// </summary>
    /// <param name="atacante">El Pokémon que realiza el ataque.</param>
    /// <param name="objetivo">El Pokémon objetivo del ataque.</param>
    /// <returns>La cantidad de daño infligido.</returns>
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
    /// <summary>
    /// Determina si el ataque fue exitoso, basado en la precisión del ataque.
    /// </summary>
    /// <returns>Verdadero si el ataque es exitoso; de lo contrario, falso.</returns>

    private bool EsExitoso()
    {
        return random.NextDouble() <= Precision;
    }
    /// <summary>
    /// Determina si el ataque realiza un golpe crítico.
    /// </summary>
    /// <returns>Verdadero si el ataque es crítico; de lo contrario, falso.</returns>
    private bool EsCritico()
    {
        return random.NextDouble() <= 0.1; // 10% de probabilidad
    }
}