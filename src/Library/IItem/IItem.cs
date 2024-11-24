namespace Program;
/// <summary>
/// Representa un ítem en el juego que puede ser usado por un Pokémon.
/// </summary>
public interface IItem
{
    /// <summary>
    /// Obtiene el nombre del ítem.
    /// </summary>
    string Nombre { get; }
    /// <summary>
    /// Obtiene o establece el número de usos restantes del ítem.
    /// </summary>
    int UsosRestantes { get; set; }
    /// <summary>
    /// Aplica el efecto del ítem al Pokémon especificado.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se le aplicará el ítem.</param>
    void Usar(IPokemon pokemon); // Aplica el efecto del ítem al Pokémon
}