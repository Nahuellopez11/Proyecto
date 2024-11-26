using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Program;

namespace Ucu.Poo.DiscordBot.Domain
{
    public class InicializacionBatallaBot
    {
        private readonly DiscordSocketClient _client;
        private readonly SocketTextChannel _channel;
        private readonly SocketUser _player1;
        private readonly SocketUser _player2;
        private SocketUser _currentPlayer; // Control del turno
        public bool IsActive { get; private set; } = true; // Para indicar si la batalla sigue activa

        // Equipos de los jugadores (cada uno tiene una lista de Pokémon)
        private List<IPokemon> _equipoJugador1;
        private List<IPokemon> _equipoJugador2;

        private bool comandoEjecutado = false; // Control para evitar la repetición de comandos

        public InicializacionBatallaBot(
            SocketUser player1,
            SocketUser player2,
            List<IPokemon> equipoJugador1,
            List<IPokemon> equipoJugador2,
            SocketTextChannel channel,
            DiscordSocketClient client)
        {
            _client = client;
            _channel = channel;
            _player1 = player1;
            _player2 = player2;
            _equipoJugador1 = equipoJugador1;
            _equipoJugador2 = equipoJugador2;
            _currentPlayer = _player1; // El jugador 1 comienza
            IsActive = true;

            // Registrar el evento de escucha de mensajes
            _client.MessageReceived -= OnMessageReceivedAsync; // Evitar duplicados
            _client.MessageReceived += OnMessageReceivedAsync;

            // Mensaje inicial
            _channel.SendMessageAsync($"¡La batalla ha comenzado entre {_player1.Username} y {_player2.Username}!");
            _channel.SendMessageAsync($"Es el turno de {_currentPlayer.Username}. Usa 'ataque', 'cambiar' o 'item' para jugar.");
        }

        private async Task OnMessageReceivedAsync(SocketMessage message)
        {
            // Validar condiciones básicas
            if (message.Author.IsBot || message.Channel.Id != _channel.Id || !IsActive) return;

            string comando = message.Content.ToLowerInvariant().Trim();

            // Solo procesar comandos válidos ('ataque', 'cambiar', 'item')
            if (comando != "ataque" && comando != "cambiar" && comando != "item")
            {
                await _channel.SendMessageAsync($"{message.Author.Username}, por favor elige un comando válido: 'ataque', 'cambiar' o 'item'.");
            }
            else
            {
                // Verificar si es el turno del jugador que envió el mensaje
                if (message.Author.Id != _currentPlayer.Id)
                {
                    await _channel.SendMessageAsync($"{message.Author.Username}, no es tu turno.");
                }
                else
                {
                    // Si ya se ejecutó un comando, no procesar más
                    if (comandoEjecutado) return;

                    // Procesar el comando del jugador en turno
                    if (comando == "ataque")
                    {
                        await ManejarAtaqueAsync(message.Author);
                    }
                    else if (comando == "cambiar")
                    {
                        await ManejarCambioAsync(message.Author);
                    }
                    else if (comando == "item")
                    {
                        await ManejarUsoItemAsync(message.Author);
                    }

                    // Cambiar de turno después de ejecutar el comando
                    CambiarTurno();
                }
            }
        }

        private async Task ManejarAtaqueAsync(SocketUser jugador)
        {
            // Mostrar los ataques disponibles
            await _channel.SendMessageAsync($"¡Es el turno de {jugador.Username}! Elige un ataque:");
            await _channel.SendMessageAsync("1. Ascuas\n2. Lanzallamas\n3. Giro Fuego (Efecto: Quemado)\n4. Llamarada (Efecto: Quemado)");

            // Esperar la respuesta del jugador
            var opcionSeleccionada = await EsperarOpcionJugadorAsync(_channel, jugador, _client, 4); // Esperar un número entre 1 y 4

            // Validar la opción seleccionada
            if (int.TryParse(opcionSeleccionada, out int opcion) && opcion >= 1 && opcion <= 4)
            {
                // Seleccionar Pokémon activos de manera robusta
                IPokemon pokemonActivoJugador = ObtenerPokemonActivo(_currentPlayer.Id);
                IPokemon pokemonActivoRival = ObtenerPokemonActivo(_currentPlayer.Id == _player1.Id ? _player2.Id : _player1.Id);

                // Aquí seleccionamos el ataque basado en la opción del jugador
                var ataqueElegido = pokemonActivoJugador.AtaquesDisponibles[opcion - 1]; // El índice es 0 basado

                // Realizar el ataque
                await SistemaCombateBot.RealizarAtaqueJugadorAsync(pokemonActivoJugador, pokemonActivoRival, _channel, jugador, _client);
            }
            else
            {
                await _channel.SendMessageAsync($"{jugador.Username}, opción inválida, por favor elige un número entre 1 y 4.");
            }
        }



        private async Task ManejarCambioAsync(SocketUser jugador)
        {
            // Implementar lógica para cambio de Pokémon
        }

        private async Task ManejarUsoItemAsync(SocketUser jugador)
        {
            // Implementar lógica para uso de ítem
        }

        private void CambiarTurno()
        {
            _currentPlayer = _currentPlayer.Id == _player1.Id ? _player2 : _player1;
        }

        private IPokemon ObtenerPokemonActivo(ulong playerId)
        {
            // Suponiendo que el primer Pokémon en la lista es el activo
            return playerId == _player1.Id ? _equipoJugador1.FirstOrDefault() : _equipoJugador2.FirstOrDefault();
        }

        private async Task<string> EsperarOpcionJugadorAsync(ISocketMessageChannel channel, IUser jugador, DiscordSocketClient client, int maxOpciones)
        {
            var tcs = new TaskCompletionSource<string>();

            // Declaramos el Handler como un Func<Task> para que sea compatible con el evento MessageReceived
            Func<SocketMessage, Task> Handler = null;

            // Asignamos el Handler al delegado adecuado
            Handler = async (SocketMessage message) =>
            {
                // Comprobamos que el mensaje es del jugador correcto y que la opción está dentro del rango
                if (message.Author.Id == jugador.Id && int.TryParse(message.Content, out int opcion) && opcion >= 1 && opcion <= maxOpciones)
                {
                    tcs.SetResult(message.Content); // Establecemos la respuesta del jugador
                    client.MessageReceived -= Handler; // Removemos el handler después de recibir el mensaje
                }
            };

            // Añadimos el Handler al evento MessageReceived
            client.MessageReceived += Handler;

            // Esperamos a que el jugador responda
            await tcs.Task;
    
            // Devolvemos la opción seleccionada
            return tcs.Task.Result;
        }


    }
}
