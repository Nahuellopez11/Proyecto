namespace Program;

public interface IVisitor
{
   public void VisitPokemon(Pokemon1 pokemon){}

   public List<IPokemones> Equipo { get; } void Visit(IPokemones pokemon){}
   public bool FueElegido { get; }

 
}