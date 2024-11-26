using Discord;
using Discord.WebSocket;
using Program;

namespace Ucu.Poo.DiscordBot.Domain;

public class SistemaCombateBot
    {
        private static Random random = new Random();

        // Modificamos para que `client` sea pasado solo en el método que lo necesita
        public static async Task RealizarAtaqueJugadorAsync(IPokemon pokemonActivoJugador, IPokemon pokemonActivoRival, ISocketMessageChannel channel, IUser jugador)
        {
            Pokemon pokemonJugador = pokemonActivoJugador as Pokemon;
            Pokemon pokemonRival = pokemonActivoRival as Pokemon;

            if (pokemonJugador == null || pokemonRival == null)
            {
                await channel.SendMessageAsync("Error: Los pokémon no son del tipo correcto.");
                return;
            }

            if (!pokemonJugador.PuedeAtacar())
            {
                await channel.SendMessageAsync($"¡{pokemonJugador.Nombre} no puede atacar en este turno!");
                return;
            }

            // Mostrar ataques disponibles
            string ataquesMensaje = "**Ataques disponibles:**\n";
            for (int i = 0; i < pokemonJugador.AtaquesDisponibles.Count; i++)
            {
                var ataque = pokemonJugador.AtaquesDisponibles[i];
                string descripcion = ataque is AtaqueEspecial ataqueEspecial
                    ? $"{ataque.NombreHabilidad} (Efecto: {ataqueEspecial.EfectoEstado})"
                    : ataque.NombreHabilidad;
                ataquesMensaje += $"{i + 1}. {descripcion}\n";
            }

            await channel.SendMessageAsync(ataquesMensaje);
            await channel.SendMessageAsync("Escribe el número del ataque que deseas usar:");

            // Usar la función alternativa para esperar la opción del jugador
            string opcion = await EsperarOpcionJugadorAsync(channel, jugador);

            if (int.TryParse(opcion, out int ataqueElegido) &&
                ataqueElegido >= 1 &&
                ataqueElegido <= pokemonJugador.AtaquesDisponibles.Count)
            {
                Ataque ataqueSeleccionado = pokemonJugador.AtaquesDisponibles[ataqueElegido - 1];

                // Calcular el daño y aplicar
                int daño = ataqueSeleccionado.CalcularDaño(pokemonJugador, pokemonRival);
                pokemonRival.Vida = Math.Max(0, pokemonRival.Vida - daño);

                await channel.SendMessageAsync($"**{pokemonJugador.Nombre}** usó **{ataqueSeleccionado.NombreHabilidad}** y causó **{daño} puntos de daño**.");
                await MostrarEstadoPokemon(pokemonRival, "Rival", channel);
            }
            else
            {
                await channel.SendMessageAsync("Ataque inválido. Perdiste tu turno.");
            }
        }

        private static async Task MostrarEstadoPokemon(Pokemon pokemon, string propietario, ISocketMessageChannel channel)
        {
            string estado = $"{propietario} Pokémon: {pokemon.Nombre}\nVida actual: {pokemon.Vida}";
            if (pokemon.EstadoActual != EstadoEspecial.Normal)
            {
                estado += $"\nEstado: {pokemon.EstadoActual}";
            }

            await channel.SendMessageAsync(estado);
        }

        // Método para esperar la opción del jugador, ahora recibe `client` como parámetro
        private static async Task<string> EsperarOpcionJugadorAsync(ISocketMessageChannel channel, IUser jugador)
        {
            // TCS para esperar la opción del jugador
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();

            // Evento para capturar el mensaje del jugador
            async Task Handler(SocketMessage message)
            {
                if (message.Channel.Id == channel.Id && message.Author.Id == jugador.Id)
                {
                    tcs.SetResult(message.Content);
                }
            }

            // Suscribirse al evento MessageReceived
            var client = (DiscordSocketClient)channel; // Convertimos el canal para obtener acceso al cliente
            client.MessageReceived += Handler;

            // Esperar 30 segundos o hasta recibir el mensaje
            var delayTask = Task.Delay(TimeSpan.FromSeconds(30));
            var completedTask = await Task.WhenAny(tcs.Task, delayTask);

            if (completedTask == delayTask)
            {
                client.MessageReceived -= Handler;
                return null; // Tiempo vencido
            }

            client.MessageReceived -= Handler;

            return await tcs.Task;
        }
    }

