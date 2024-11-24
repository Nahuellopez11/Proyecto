namespace Program;
/// <summary>
/// Define las propiedades básicas relacionadas con las habilidades de un Pokémon.
/// </summary>
/// <interface>
/// IHabilidadesPokemon proporciona un contrato para implementar las características básicas
/// de las habilidades de un Pokémon.
/// </interface>
/// <remarks>
/// Esta interfaz implementa el principio de responsabilidad única (SRP) del SOLID,
/// enfocándose exclusivamente en las propiedades que definen las habilidades de un Pokémon.
/// </remarks>
public interface IHabilidadesPokemon
{
    // <summary>
    /// Obtiene o establece el valor numérico del ataque de la habilidad.
    /// </summary>
    /// <value>
    /// Un valor entero que representa la cantidad de daño que puede infligir la habilidad.
    /// </value>
    public int ValorAtaque { get; set; }
    /// <summary>
    /// Obtiene o establece el nombre de la habilidad del Pokémon.
    /// </summary>
    /// <value>
    /// Una cadena de texto que representa el identificador de la habilidad.
    /// </value>

    public string NombreHabilidad { get; set; }

 
}