namespace Program;
/// <summary>
/// Representa a un jugador en el juego, que tiene una lista de Pokémon y un identificador único.
/// </summary>

public interface IJugador
{
    /// <summary>
    /// Obtiene o establece la lista de Pokémon del jugador.
    /// </summary>
    public List<IPokemon> ListaDePokemones { get; set; }
    /// <summary>
    /// Obtiene o establece el identificador único del jugador.
    /// </summary>
    public int Id { get; set; }

}