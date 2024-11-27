namespace Program;

/// <summary>
/// Representa el ítem "Revivir", que permite revivir a un Pokémon debilitado.
/// </summary>
public class Revivir : IItem
{
    /// <summary>
    /// Obtiene o establece el nombre del ítem.
    /// </summary>
    public string Nombre { get; set; } = "Revivir";
    
    /// <summary>
    /// Obtiene o establece el número de usos restantes del ítem.
    /// </summary>
    public int UsosRestantes { get; set; } = 1;

    public int UsosIniciales { get; set; } = 1;

    /// <summary>
    /// Aplica el efecto del ítem al Pokémon especificado.
    /// Revive al Pokémon si está debilitado (vida = 0) y hay usos disponibles.
    /// </summary>
    /// <param name="pokemon">El Pokémon al que se aplicará el ítem.</param>
    /// <remarks>
    /// - Si el Pokémon está debilitado y hay usos restantes, este ítem restaura 
    ///   su vida al 50% de su máximo.
    /// - Si el Pokémon no está debilitado, no se puede usar este ítem.
    /// - Si no quedan usos, se muestra un mensaje indicando que el ítem está agotado.
    /// </remarks>
    public void Usar(IPokemon pokemon)
    {
        if (UsosRestantes > 0 && pokemon.Vida == 0)
        {
            UsosRestantes--;
            pokemon.Vida = 50; 
            Console.WriteLine($"{Nombre} usado en {pokemon.Nombre}. HP actual después de revivir: {pokemon.Vida}");
        }
        
        else if (pokemon.Vida > 0)
        {
            Console.WriteLine("No se puede usar Revivir en un Pokémon que no está debilitado.");
        }
        
        else
        {
            Console.WriteLine("No quedan usos de Revivir.");
        }
    }
}