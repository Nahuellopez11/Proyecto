
namespace Program
{
    public class SistemaCombate
    {
        public static void RealizarAtaqueJugador(IPokemones pokemonActivoJugador, IPokemones pokemonActivoMaquina)
        {
            Pokemon pokemonJugador = pokemonActivoJugador as Pokemon;
            Pokemon pokemonEnemigo = pokemonActivoMaquina as Pokemon;

            if (pokemonJugador == null || pokemonEnemigo == null)
            {
                Console.WriteLine("Error: Los pokémon no son del tipo correcto.");
                return;
            }

            Console.WriteLine("\nAtaques disponibles:");
            for (int i = 0; i < pokemonJugador.AtaquesDisponibles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokemonJugador.AtaquesDisponibles[i].NombreHabilidad}");
            }

            Console.WriteLine("\nElige un ataque (número):");
            if (int.TryParse(Console.ReadLine(), out int ataqueElegido) && 
                ataqueElegido >= 1 && 
                ataqueElegido <= pokemonJugador.AtaquesDisponibles.Count)
            {
                Ataque ataqueSeleccionado = pokemonJugador.AtaquesDisponibles[ataqueElegido - 1];
                
                int daño = ataqueSeleccionado.CalcularDaño(pokemonJugador, pokemonEnemigo);
                pokemonEnemigo.Vida -= daño;

                Console.WriteLine($"\n¡{pokemonJugador.Nombre} usó {ataqueSeleccionado.NombreHabilidad}!");
                Console.WriteLine($"Causó {daño} puntos de daño.");
                MostrarEstadoPokemon(pokemonEnemigo, "Rival");
            }
            else
            {
                Console.WriteLine("Ataque inválido. Perdiste tu turno.");
            }
        }

        public static void RealizarAtaqueMaquina(IPokemones pokemonActivoMaquina, IPokemones pokemonActivoJugador)
        {
            Pokemon pokemonMaquina = pokemonActivoMaquina as Pokemon;
            Pokemon pokemonJugador = pokemonActivoJugador as Pokemon;

            if (pokemonMaquina == null || pokemonJugador == null)
            {
                Console.WriteLine("Error: Los pokémon no son del tipo correcto.");
                return;
            }

            Random random = new Random();
            int ataqueElegido = random.Next(0, pokemonMaquina.AtaquesDisponibles.Count);
            Ataque ataqueSeleccionado = pokemonMaquina.AtaquesDisponibles[ataqueElegido];

            int daño = ataqueSeleccionado.CalcularDaño(pokemonMaquina, pokemonJugador);
            pokemonJugador.Vida -= daño;

            Console.WriteLine($"\n¡{pokemonMaquina.Nombre} usó {ataqueSeleccionado.NombreHabilidad}!");
            Console.WriteLine($"Causó {daño} puntos de daño.");
            MostrarEstadoPokemon(pokemonJugador, "Tu");
        }

        private static void MostrarEstadoPokemon(IPokemones pokemon, string propietario)
        {
            Console.WriteLine($"{propietario} Pokémon: {pokemon.Nombre}");
            Console.WriteLine($"Vida actual: {pokemon.Vida}");
            Console.WriteLine();
        }
    }
}