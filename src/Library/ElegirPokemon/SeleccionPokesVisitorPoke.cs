namespace Program
{
    /// <summary>
    /// Implementa el patrón Visitor para gestionar la selección de Pokémon en un equipo.
    /// Controla la lógica de añadir Pokémon al equipo, verificando duplicados y límites.
    /// </summary>
    public class SeleccionPokesVisitorPoke : IVisitorPoke
    {
        /// <summary>
        /// Obtiene un valor que indica si el último intento de selección fue exitoso.
        /// </summary>
        /// <value>
        /// true si el Pokémon fue añadido exitosamente al equipo;
        /// false si el equipo está lleno o el Pokémon ya estaba en el equipo.
        /// </value>
        public bool FueElegido { get; private set; }
        
        /// <summary>
        /// Lista que contiene los Pokémon seleccionados para el equipo.
        /// </summary>
        /// <value>
        /// Colección de Pokémon que forman parte del equipo actual.
        /// Máximo 6 Pokémon permitidos.
        public List<IPokemon> Equipo { get; private set; }
        
        /// <summary>
        /// Constructor de la clase. Inicializa una nueva instancia del visitor de selección.
        /// Crea una lista vacía para el equipo y establece FueElegido en false.
        /// </summary>
        public SeleccionPokesVisitorPoke()
        {
            Equipo = new List<IPokemon>();
            FueElegido = false;
        }

        /// <summary>
        /// Implementa la lógica de visita para un Pokémon específico.
        /// Verifica si el Pokémon puede ser añadido al equipo y lo añade si es posible.
        /// </summary>
        /// <param name="pokemon">El Pokémon que se intenta añadir al equipo.</param>
        /// <remarks>
        /// El método verifica:
        /// - Si el equipo ya tiene 6 Pokémon
        /// - Si el Pokémon ya existe en el equipo
        /// - Actualiza FueElegido según el resultado de la operación
        /// </remarks>
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

        /// <summary>
        /// Implementación base del método Visit de la interfaz IVisitorPoke.
        /// </summary>
        /// <param name="pokemon">El Pokémon a visitar.</param>
        /// <remarks>
        /// Este método está vacío ya que la lógica principal se implementa en VisitPokemon.
        /// </remarks>
        public void Visit(IPokemon pokemon)
        {
        }
    }
}