namespace Program;

public class IVisitor
{
   public void VisitPokemon(IPokemones pokemon){}
   public bool IsSelected { get; }
   public List<IPokemones> Equipo { get; } void Visit(IPokemones pokemon){}
   public bool FueElegido { get; }
   public List<IPokemones> EquipoElegido { get; }
 
}