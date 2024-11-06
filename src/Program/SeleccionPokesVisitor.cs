namespace Program;

public class SeleccionPokesVisitor : IVisitor
{
    private const int EquipoMax = 6;
    public bool FueElegido { get; private set; }
    public List<IPokemones> Equipo { get; private set; }

    public SeleccionPokesVisitor()
    {
        Equipo = new List<IPokemones>();
        FueElegido = false;
    }

    public void VisitPokemon(Pokemon1 pokemon)
    {
        if (Equipo.Count >= EquipoMax)
        {
            Console.WriteLine("¡El equipo ya está completo!");
            FueElegido = false;
            return;
        }

        if (!Equipo.Contains(pokemon))
        {
            Equipo.Add(pokemon);
            FueElegido = true;
            Console.WriteLine($"{pokemon.Nombre} ha sido añadido al equipo. ({Equipo.Count}/6)");
        }
        else
        {
            Console.WriteLine($"{pokemon.Nombre} ya está en tu equipo.");
            FueElegido = false;
        }
    }
}