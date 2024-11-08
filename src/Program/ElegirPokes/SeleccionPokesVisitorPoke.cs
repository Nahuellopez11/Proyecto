namespace Program
{
    public class SeleccionPokesVisitorPoke : IVisitorPoke
    {
        public bool FueElegido { get; private set; }
        public List<IPokemones> Equipo { get; private set; }

        public SeleccionPokesVisitorPoke()
        {
            Equipo = new List<IPokemones>();
            FueElegido = false;
        }

        // Implementación del método VisitPokemon
        public void VisitPokemon(Pokemon pokemon)
        {
            Console.WriteLine($"Equipo actual tiene {Equipo.Count} Pokémon(s).");

            if (Equipo.Count >= 6)
            {
                Console.WriteLine("¡El equipo ya está completo!");
                FueElegido = false;
                return;
            }

            if (!Equipo.Any(p => p.Nombre == pokemon.Nombre))
            {
                Console.WriteLine($"{pokemon.Nombre} no está en el equipo, añadiéndolo...");
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


        public void Visit(IPokemones pokemon)
        {
        }
    }
}