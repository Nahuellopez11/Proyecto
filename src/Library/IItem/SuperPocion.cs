namespace Program;
/// <summary>
/// Representa el ítem "Súper poción", que cura la vida de un Pokémon.
/// </summary>
public class SuperPocion : IItem
{
    /// <summary>
    /// Obtiene o establece el nombre del ítem.
    /// </summary>
    public string Nombre { get; set; }= "Súper poción";
    
    /// <summary>
    /// Obtiene o establece el número de usos restantes del ítem.
    /// </summary>
    public int UsosRestantes { get; set; } = 4;

    /// <summary>
    /// Aplica el efecto del ítem al Pokémon especificado.
    /// Cura 70 puntos de vida del Pokémon sin exceder el máximo de 100.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se aplicará la Súper poción.</param>
    /// <remarks>
    /// - Si hay usos disponibles, la vida del Pokémon se incrementa en 70 puntos o 
    ///   hasta alcanzar el máximo de 100.
    /// - Si no quedan usos restantes, se muestra un mensaje indicando que el ítem está agotado.
    /// </remarks>
    public void Usar(IPokemon pokemon)
    {
        if (UsosRestantes > 0)
        {
            UsosRestantes--;
            pokemon.Vida = Math.Min(pokemon.Vida + 70, 100); // cura 70 de hp no se puede pasar de 100 por el .Min
            Console.WriteLine($"{Nombre} usada en {pokemon.Nombre}. HP actual: {pokemon.Vida}");
        }
        else
        {
            Console.WriteLine("No quedan pociones.");
        }
    }
}