namespace Program;
/// <summary>
/// Representa a un jugador en el juego, que tiene una lista de Pokémon y una colección de ítems.
/// </summary>
public class Jugador : IJugador
{
    /// <summary>
    /// Obtiene o establece el identificador único del jugador.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Obtiene o establece la lista de Pokémon que posee el jugador.
    /// </summary>
    public List<IPokemon> ListaDePokemones { get; set; } = new List<IPokemon>();
    /// <summary>
    /// Obtiene o establece la lista de ítems disponibles para el jugador.
    /// </summary>
    /// <remarks>
    /// Por defecto, incluye instancias de los ítems <see cref="SuperPocion"/> y <see cref="Revivir"/>.
    /// Nuevos ítems pueden ser añadidos a esta lista.
    /// </remarks>
    public List<IItem> Items { get; set; } = new List<IItem>
    {
        new SuperPocion(),
        new Revivir(),
        //aqui se agrega el otro item

    };
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Jugador"/> con una lista específica de Pokémon.
    /// </summary>
    /// <param name="listaDePokemones">La lista de Pokémon inicial del jugador.</param>
    public Jugador(List<IPokemon> listaDePokemones)
    {
        this.ListaDePokemones = listaDePokemones;
    }
    /// <summary>
    /// Selecciona el primer Pokémon de la lista de Pokémon del jugador.
    /// </summary>
    /// <returns>El primer Pokémon de la lista.</returns>
    /// <remarks>
    /// Asume que la lista de Pokémon no está vacía. Si no hay Pokémon en la lista, 
    /// podría generar una excepción de índice fuera de rango.
    /// </remarks>
    public IPokemon ElegirPrimerPokemon()
    {

        return ListaDePokemones[0];
    }

}


