namespace Ucu.Poo.DiscordBot.Domain
{
    using Program;
    using Discord.Commands;
    using System.Threading.Tasks;
    using System;

    public class BatallaDiscord
    {
        private Jugador jugador1;
        private Jugador jugador2;
        private Battle batalla;
        private ElegirPokemon elegirPokemon;

        public BatallaDiscord(ElegirPokemon elegirPokemon)
        {
            this.elegirPokemon = elegirPokemon;
        }

        // Método para iniciar la batalla y permitir que los jugadores elijan sus Pokémon
        public async Task IniciarBatalla(SocketCommandContext context)
        {
            await elegirPokemon.SeleccionarEquipo(); // Jugador 1 elige su equipo
            await elegirPokemon.SeleccionarEquipo2(); //Jugador 2

            // Crear los jugadores y asignar los equipos
            jugador1 = new Jugador(elegirPokemon.DevolverListajugador1());
            jugador2 = new Jugador(elegirPokemon.DevolverListajugador2());
            batalla = new Battle("Jugador 1", "Jugador 2"); // Crear la instancia de la batalla

            // Verificar que los equipos estén completos
            if (jugador1.ListaDePokemones == null || jugador1.ListaDePokemones.Count == 0)
                throw new InvalidOperationException("El equipo del Jugador 1 está vacío.");
            if (jugador2.ListaDePokemones == null || jugador2.ListaDePokemones.Count == 0)
                throw new InvalidOperationException("El equipo del Jugador 2 está vacío.");

            // Paso 2: Iniciar la batalla
            await EjecutarTurno(context, 0); // Empieza con el turno del jugador 1
        }

        // Método para ejecutar el turno de la batalla
        public async Task EjecutarTurno(SocketCommandContext context, int turno)
        {
            IPokemon pokemonActivoJugador1 = jugador1.ListaDePokemones[0];
            IPokemon pokemonActivoJugador2 = jugador2.ListaDePokemones[0];

            // Lógica de los turnos de batalla, mostrando las opciones en Discord
            if (turno == 0)
            {
                await context.Channel.SendMessageAsync($"¡Es el turno de {batalla.Player1}!");
                await MostrarMenuDeAcciones(context);
            }
            else
            {
                await context.Channel.SendMessageAsync($"¡Es el turno de {batalla.Player2}!");
                await MostrarMenuDeAcciones(context);
            }
        }

        // Mostrar el menú de acciones durante el turno
        private async Task MostrarMenuDeAcciones(SocketCommandContext context)
        {
            await context.Channel.SendMessageAsync("Selecciona una opción:");
            await context.Channel.SendMessageAsync("1. Ataque\n2. Cambiar Pokémon\n3. Usar ítem\n4. Terminar juego");
        }

        // Procesar las acciones de los jugadores durante la batalla
        public async Task ProcesarAccionJugador(string accion, SocketCommandContext context, int turno)
        {
            if (accion == "1")
            {
                // Aquí deberías llamar a la lógica de ataque
                await context.Channel.SendMessageAsync($"¡{(turno == 0 ? batalla.Player1 : batalla.Player2)} ataca!");
            }
            else if (accion == "2")
            {
                // Cambio de Pokémon
                await context.Channel.SendMessageAsync($"¡{(turno == 0 ? batalla.Player1 : batalla.Player2)} cambia su Pokémon!");
            }
            else if (accion == "3")
            {
                // Usar ítem
                await context.Channel.SendMessageAsync("¡Usando ítem!");
            }
            else if (accion == "4")
            {
                // Terminar la batalla
                await context.Channel.SendMessageAsync("¡Terminando la batalla!");
            }
        }
    }
}
