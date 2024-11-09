namespace Program
{
    public class SistemaCombate
    {
        private static Random random = new Random(); // Movido a nivel de clase

        public static void RealizarAtaqueMaquina(IPokemones pokemonActivoMaquina, IPokemones pokemonActivoJugador)
        {
            Pokemon pokemonMaquina = pokemonActivoMaquina as Pokemon;
            Pokemon pokemonJugador = pokemonActivoJugador as Pokemon;

            if (pokemonMaquina == null || pokemonJugador == null)
            {
                Console.WriteLine("Error: Los pokémon no son del tipo correcto.");
                return;
            }

            // Debug: Imprimir información antes del ataque
            Console.WriteLine($"\nLa máquina ataca con {pokemonMaquina.Nombre}");
            Console.WriteLine($"Ataques disponibles: {pokemonMaquina.AtaquesDisponibles.Count}");

            int ataqueElegido = random.Next(0, pokemonMaquina.AtaquesDisponibles.Count);
            Ataque ataqueSeleccionado = pokemonMaquina.AtaquesDisponibles[ataqueElegido];

            // Debug: Imprimir información del ataque seleccionado
            Console.WriteLine($"Ataque seleccionado: {ataqueSeleccionado.NombreHabilidad}");

            int daño = ataqueSeleccionado.CalcularDaño(pokemonMaquina, pokemonJugador);

            // Debug: Imprimir información del daño calculado
            Console.WriteLine($"Daño calculado: {daño}");

            // Asegurarnos de que la vida no baje de 0
            pokemonJugador.Vida = Math.Max(0, pokemonJugador.Vida - daño);

            Console.WriteLine($"\n¡{pokemonMaquina.Nombre} usó {ataqueSeleccionado.NombreHabilidad}!");
            Console.WriteLine($"Causó {daño} puntos de daño.");
            MostrarEstadoPokemon(pokemonJugador, "Tu");
        }

        public static void RealizarAtaqueJugador(IPokemones pokemonActivoJugador, IPokemones pokemonActivoMaquina)
        {
            Pokemon pokemonJugador = pokemonActivoJugador as Pokemon;
            Pokemon pokemonEnemigo = pokemonActivoMaquina as Pokemon;

            if (pokemonJugador == null || pokemonEnemigo == null)
            {
                Console.WriteLine("Error: Los pokémon no son del tipo correcto.");
                return;
            }

            if (!pokemonJugador.PuedeAtacar())
            {
                return;
            }

            Console.WriteLine("\nAtaques disponibles:");
            for (int i = 0; i < pokemonJugador.AtaquesDisponibles.Count; i++)
            {
                var ataque = pokemonJugador.AtaquesDisponibles[i];
                string descripcion = ataque is AtaqueEspecial ataqueEspecial
                    ? $"{ataque.NombreHabilidad} (Efecto: {ataqueEspecial.EfectoEstado})"
                    : ataque.NombreHabilidad;
                Console.WriteLine($"{i + 1}. {descripcion}");
            }


            Console.WriteLine("\nElige un ataque (número):");
            // Permite al jugador seleccionar un ataque
            if (int.TryParse(Console.ReadLine(), out int ataqueElegido) &&
                ataqueElegido >= 1 &&
                ataqueElegido <= pokemonJugador.AtaquesDisponibles.Count)
            {
                Ataque ataqueSeleccionado = pokemonJugador.AtaquesDisponibles[ataqueElegido - 1];

                int daño = ataqueSeleccionado.CalcularDaño(pokemonJugador, pokemonEnemigo);
                pokemonEnemigo.Vida = Math.Max(0, pokemonEnemigo.Vida - daño);

                Console.WriteLine($"\n¡{pokemonJugador.Nombre} usó {ataqueSeleccionado.NombreHabilidad}!");
                if (ataqueSeleccionado is AtaqueEspecial ataqueEspecial)
                {
                    Console.WriteLine($"¡El ataque puede causar estado {ataqueEspecial.EfectoEstado}!");
                }

                Console.WriteLine($"Causó {daño} puntos de daño.");
                MostrarEstadoPokemon(pokemonEnemigo, "Rival");
            }
            else
            {
                Console.WriteLine("Ataque inválido. Perdiste tu turno.");
            }
        }
        // Muestra el estado del Pokémon después de cada ataque
        private static void MostrarEstadoPokemon(Pokemon pokemon, string propietario)
        {
            Console.WriteLine($"{propietario} Pokémon: {pokemon.Nombre}");
            Console.WriteLine($"Vida actual: {pokemon.Vida}");
            if (pokemon.EstadoActual != EstadoEspecial.Normal)
            {
                Console.WriteLine($"Estado: {pokemon.EstadoActual}");
            }

            Console.WriteLine();
        }
    }
}