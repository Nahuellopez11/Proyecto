using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using Program;


namespace Library.Discord.Domain;

public class InicializacionBatallaBot
{
    
    private SocketUser _jugador1;
    private SocketUser _jugador2;
    private List<IPokemon> _equipoJugador1;
    private List<IPokemon> _equipoJugador2;
    private ISocketMessageChannel _channel;

    public InicializacionBatallaBot(SocketUser jugador1, SocketUser jugador2, List<IPokemon> equipoJugador1,
        List<IPokemon> equipoJugador2, ISocketMessageChannel channel)
    {
        _jugador1 = jugador1;
        _jugador2 = jugador2;
        _equipoJugador1 = equipoJugador1;
        _equipoJugador2 = equipoJugador2;
        _channel = channel;

        if (_equipoJugador1 == null || _equipoJugador1.Count == 0 || _equipoJugador2 == null ||
            _equipoJugador2.Count == 0)
        {
            throw new InvalidOperationException(
                "Ambos jugadores deben tener equipos completos para iniciar la batalla.");
        }
    }

    public async Task IniciarBatallaAsync()
    {
        var pokemonActivoJugador1 = _equipoJugador1[0];
        var pokemonActivoJugador2 = _equipoJugador2[0];
        var turno = new Random().Next(0, 2); // 0 = Jugador 1, 1 = Jugador 2

        await _channel.SendMessageAsync("¡La batalla comienza!");
        while (true)
        {
            if (turno == 0)
            {
                await MostrarOpcionesJugadorAsync(_jugador1, pokemonActivoJugador1);
                var opcion = await EsperarOpcionJugadorAsync(_jugador1);

                if (opcion == "1")  // Opción de ataque
                {
                    await _channel.SendMessageAsync($"{_jugador1.Username} eligió atacar.");

                    // Realizar el ataque usando el método asincrónico
                    await SistemaCombateBot.RealizarAtaqueJugadorAsync(pokemonActivoJugador1, pokemonActivoJugador2, _channel, _jugador1);

                    // Confirmación de ataque
                    await _channel.SendMessageAsync($"¡{pokemonActivoJugador1.Nombre} atacó a {pokemonActivoJugador2.Nombre}!");
                    await _channel.SendMessageAsync($"Vida de {pokemonActivoJugador2.Nombre}: {pokemonActivoJugador2.Vida}");

                    // Cambiar el turno al otro jugador
                    turno = 1; 
                }

                else if (opcion == "2")
                {
                    await _channel.SendMessageAsync($"{_jugador1.Username} eligió cambiar Pokémon.");
                    // Aquí implementaríamos la lógica para cambiar Pokémon
                    turno = 1;
                }
                else if (opcion == "3")
                {
                    await _channel.SendMessageAsync($"{_jugador1.Username} eligió usar un ítem.");
                    // Aquí implementaríamos la lógica para usar un ítem
                    turno = 1;
                }
                else if (opcion == "4")
                {
                    await _channel.SendMessageAsync(
                        $"{_jugador1.Username} decidió terminar el juego. ¡Fin de la batalla!");
                    break;
                }
            }
            else
            {
                await MostrarOpcionesJugadorAsync(_jugador2, pokemonActivoJugador2);
                var opcion = await EsperarOpcionJugadorAsync(_jugador2);

                if (opcion == "1")  // Opción de ataque
                {
                    await _channel.SendMessageAsync($"{_jugador2.Username} eligió atacar.");
                    // Realizar el ataque
                    SistemaCombate.RealizarAtaqueJugador(pokemonActivoJugador2, pokemonActivoJugador1);
                    await _channel.SendMessageAsync($"¡{pokemonActivoJugador2.Nombre} atacó a {pokemonActivoJugador1.Nombre}!");
                    await _channel.SendMessageAsync($"Vida de {pokemonActivoJugador1.Nombre}: {pokemonActivoJugador1.Vida}");
                    turno = 0; // Cambiar el turno al otro jugador
                }
                else if (opcion == "2")
                {
                    await _channel.SendMessageAsync($"{_jugador2.Username} eligió cambiar Pokémon.");
                    // Aquí implementaríamos la lógica para cambiar Pokémon
                    turno = 0;
                }
                else if (opcion == "3")
                {
                    await _channel.SendMessageAsync($"{_jugador2.Username} eligió usar un ítem.");
                    // Aquí implementamos la lógica de uso de ítem
                    turno = 0;
                }
                else if (opcion == "4")
                {
                    await _channel.SendMessageAsync(
                        $"{_jugador2.Username} decidió terminar el juego. ¡Fin de la batalla!");
                    break;
                }
            }
        }
    }

    private async Task MostrarOpcionesJugadorAsync(SocketUser jugador, IPokemon pokemonActivo)
    {
        await _channel.SendMessageAsync(
            $"¡Es el turno de {jugador.Username}!\n" +
            $"Tu Pokémon activo es {pokemonActivo.Nombre} con {pokemonActivo.Vida} de vida.\n" +
            "Selecciona una opción:\n" +
            "`!1` Atacar\n" +
            "`!2` Cambiar Pokémon\n" +
            "`!3` Usar ítem\n" +
            "`!4` Terminar el juego");
    }

    private async Task<string> EsperarOpcionJugadorAsync(SocketUser jugador)
    {
        while (true)
        {
            // Obtener mensajes recientes
            var mensajes = new List<SocketMessage>();
            await foreach (var messagePage in _channel.GetMessagesAsync(10))
            {
                mensajes.AddRange(messagePage.Cast<SocketMessage>());
            }

            // Buscar un mensaje válido del jugador
            var mensaje = mensajes.FirstOrDefault(m => m.Author.Id == jugador.Id && m.Content.StartsWith("!"));

            if (mensaje != null)
            {
                var opcion = mensaje.Content.Substring(1).Trim(); // Remueve el prefijo '!'

                if (new[] { "1", "2", "3", "4" }.Contains(opcion))
                {
                    return opcion;
                }

                await _channel.SendMessageAsync("Opción inválida. Por favor, selecciona una opción válida: `!1`, `!2`, `!3`, `!4`.");
            }

            await Task.Delay(1000); // Espera antes de verificar mensajes nuevamente
        }
    }
}
