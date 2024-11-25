namespace Program;
/// <summary>
/// Interfaz que define el patrón Visitor para interactuar con objetos de tipo IPokemon.
/// </summary>
public interface IVisitorPoke
{
   /// <summary>
   /// Método que define la lógica de visita para un Pokémon.
   /// </summary>
   /// <param name="pokemon">El Pokémon visitado.</param>
   public void VisitPokemon(Pokemon pokemon){}

   /// <summary>
   /// Lista de Pokémon que conforman un equipo asociado al visitante.
   /// </summary>
   public List<IPokemon> Equipo { get; } void Visit(IPokemon pokemon){}
   
   /// <summary>
   /// Propiedad para verificar si un Pokémon fue seleccionado en algún contexto.
   /// </summary>
   public bool FueElegido { get; }

 
}