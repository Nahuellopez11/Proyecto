using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Program;

namespace Ucu.Poo.DiscordBot.Domain
{
    public class SistemaCombateBot
    {
        private static Random random = new Random();

        // Método principal de ataque
        public static async Task RealizarAtaqueJugadorAsync(IPokemon pokemonActivoJugador, IPokemon pokemonActivoRival,
            ISocketMessageChannel channel, IUser jugador, DiscordSocketClient client, string nombreAtaqueEsperado = "")
        {
            Pokemon pokemonJugador = pokemonActivoJugador as Pokemon;
            Pokemon pokemonRival = pokemonActivoRival as Pokemon;

            if (pokemonJugador == null || pokemonRival == null)
            {
                await channel.SendMessageAsync("Error: Los Pokémon no son del tipo correcto.");
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
            await channel.SendMessageAsync("Escribe el nombre del ataque que deseas usar:");

            // Esperar la opción del jugador, ahora con el nombre del ataque
            string opcion = await EsperarOpcionJugadorAsync(channel, jugador, client, pokemonJugador.AtaquesDisponibles.Count);

            // Validar la opción seleccionada por nombre
            var ataqueSeleccionado = pokemonJugador.AtaquesDisponibles.FirstOrDefault(a => a.NombreHabilidad.Equals(opcion, StringComparison.OrdinalIgnoreCase));

            if (ataqueSeleccionado != null)
            {
                // Si se ha encontrado el ataque por nombre, realizamos el ataque
                int daño = ataqueSeleccionado.CalcularDaño(pokemonJugador, pokemonRival);
                pokemonRival.Vida = Math.Max(0, pokemonRival.Vida - daño);

                await channel.SendMessageAsync(
                    $"**{pokemonJugador.Nombre}** usó **{ataqueSeleccionado.NombreHabilidad}** y causó **{daño} puntos de daño**.");

                // Si el Pokémon rival está derrotado, finalizamos la batalla
                if (pokemonRival.Vida <= 0)
                {
                    await channel.SendMessageAsync(
                        $"¡{pokemonRival.Nombre} ha sido derrotado! {pokemonJugador.Nombre} gana la batalla.");
                    return; // Batalla terminada
                }
            }
            else
            {
                await channel.SendMessageAsync("Opción no válida. Por favor, escribe el nombre de un ataque válido.");
                // Volver a preguntar si la opción no es válida
                await RealizarAtaqueJugadorAsync(pokemonActivoJugador, pokemonActivoRival, channel, jugador, client, nombreAtaqueEsperado);
            }
        }

        // Método para esperar la opción del jugador
        public static async Task<string> EsperarOpcionJugadorAsync(ISocketMessageChannel channel, IUser jugador, DiscordSocketClient client, int maxOpciones)
        {
            var tcs = new TaskCompletionSource<string>();
            // Cambié 'void' por 'async Task'
            async Task Handler(SocketMessage message)
            {
                // Verificar que el mensaje es del jugador correcto
                if (message.Author.Id == jugador.Id && int.TryParse(message.Content, out int opcion) && opcion >= 1 && opcion <= maxOpciones)
                {
                    tcs.SetResult(message.Content); // Establecer la respuesta del jugador
                    client.MessageReceived -= Handler; // Remover el manejador después de recibir el mensaje
                }
            }

            client.MessageReceived += Handler;
            await tcs.Task; // Esperar la respuesta del jugador
            return tcs.Task.Result;
        }

    }
}
