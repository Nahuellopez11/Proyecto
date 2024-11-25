namespace Program;
  /// <summary>
  /// Representa un Pokémon en el juego, con atributos como nombre, tipo y vida.
  /// </summary>
public interface IPokemon
{
    /// <summary>
    /// Obtiene el nombre del Pokémon.
    /// </summary>
    string Nombre { get; }
    /// <summary>
    /// Obtiene el tipo del Pokémon.
    /// </summary>
    /// <remarks>
    /// Los tipos están definidos en el enumerador <see cref="TipoPokemon"/>.
    /// </remarks>
    TipoPokemon Tipo { get; }
    /// <summary>
    /// Obtiene o establece la cantidad de vida del Pokémon.
    /// </summary>
    /// <remarks>
    /// La vida del Pokémon puede variar de 0 (debilitado) al máximo permitido en el juego (por defecto, 100).
    /// </remarks>
    double Vida { get; set; }
    /// <summary>
    /// Acepta un visitante que implementa la interfaz <see cref="IVisitorPoke"/> para aplicar una operación al Pokémon.
    /// </summary>
    /// <param name="visitorPoke">El visitante que realizará una operación sobre el Pokémon.</param>
    void Accept(IVisitorPoke visitorPoke){}
    List<Ataque> AtaquesDisponibles { get; set; }
    
}



