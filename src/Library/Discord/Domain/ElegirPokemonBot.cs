using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Program;

namespace Ucu.Poo.DiscordBot.Domain
{
    public class ElegirPokemonBot
    {
        private readonly CatalogoPokemones catalogo = new CatalogoPokemones();
        private readonly SocketTextChannel _channel;
        private readonly SocketUser _jugador1;
        private readonly SocketUser _jugador2;
        private List<IPokemon> equipoJugador1 = new List<IPokemon>();
        private List<IPokemon> equipoJugador2 = new List<IPokemon>();
        private readonly HashSet<ulong> mensajesProcesados = new();

        public ElegirPokemonBot(SocketUser jugador1, SocketUser jugador2, SocketTextChannel channel)
        {
            _jugador1 = jugador1;
            _jugador2 = jugador2;
            _channel = channel;
        }

        public async Task SeleccionarEquipoAsync()
        {
            await _channel.SendMessageAsync("¡Bienvenidos al Selector de Equipo Pokémon!");
            await _channel.SendMessageAsync($"{_jugador1.Username}, selecciona 6 Pokémon para tu equipo.");

            var embed = CrearCatalogoEmbed();
            await _channel.SendMessageAsync(embed: embed);

            var seleccionJugador1 = await EsperarSeleccionAsync(_jugador1);
            equipoJugador1 = seleccionJugador1;

            await _channel.SendMessageAsync($"{_jugador2.Username}, ahora es tu turno de seleccionar 6 Pokémon.");
            await _channel.SendMessageAsync(embed: embed);

            var seleccionJugador2 = await EsperarSeleccionAsync(_jugador2);
            equipoJugador2 = seleccionJugador2;

            await MostrarEquipoFinalAsync();
        }

        public List<IPokemon> EquipoJugador1 => equipoJugador1;
        public List<IPokemon> EquipoJugador2 => equipoJugador2;

        private Embed CrearCatalogoEmbed()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Catálogo de Pokémons Disponibles")
                .WithDescription("Selecciona un Pokémon para agregarlo a tu equipo.");

            foreach (var pokemon in catalogo.CatalogoPoke.Values)
            {
                builder.AddField(pokemon.Nombre, $"Tipo: {pokemon.Tipo} - Vida: {pokemon.Vida}");
            }

            return builder.Build();
        }

        private async Task<List<IPokemon>> EsperarSeleccionAsync(SocketUser jugador)
        {
            var seleccionados = new List<IPokemon>();

            while (seleccionados.Count < 6)
            {
                var mensajes = await _channel.GetMessagesAsync(10).FlattenAsync();
                var mensaje = mensajes.FirstOrDefault(m =>
                    m.Author.Id == jugador.Id &&
                    m.Content.StartsWith("!seleccion") &&
                    !mensajesProcesados.Contains(m.Id));

                if (mensaje != null)
                {
                    Console.WriteLine($"Mensaje recibido de {jugador.Username}: {mensaje.Content}");
                    mensajesProcesados.Add(mensaje.Id);

                    var pokemonesSeleccionados = ParsearSeleccion(mensaje.Content);
                    if (pokemonesSeleccionados != null)
                    {
                        foreach (var pokemon in pokemonesSeleccionados)
                        {
                            if (seleccionados.Contains(pokemon))
                            {
                                await _channel.SendMessageAsync(
                                    $"¡Ya has seleccionado a {pokemon.Nombre}! Elige otro.");
                            }
                            else
                            {
                                seleccionados.Add(pokemon);
                                await _channel.SendMessageAsync($"¡{pokemon.Nombre} ha sido seleccionado!");
                            }
                        }
                    }
                    else
                    {
                        await _channel.SendMessageAsync("No se pudo procesar tu selección. Asegúrate de usar el formato correcto.");
                    }
                }

                await Task.Delay(1000);
            }

            return seleccionados;
        }

        private List<IPokemon> ParsearSeleccion(string seleccion)
        {
            var seleccionados = new List<IPokemon>();
            var partes = seleccion.Split(' ');

            foreach (var parte in partes.Skip(1)) // Saltar el comando "!seleccion"
            {
                if (int.TryParse(parte, out int indice) && catalogo.CatalogoPoke.ContainsKey(indice))
                {
                    seleccionados.Add(catalogo.CatalogoPoke[indice]);
                }
                else
                {
                    Console.WriteLine($"Error de selección: {parte} no es un índice válido.");
                }
            }

            return seleccionados;
        }

        public async Task MostrarEquipoFinalAsync()
        {
            await _channel.SendMessageAsync($"Equipo de {_jugador1.Username}:");
            foreach (var pokemon in equipoJugador1)
            {
                await _channel.SendMessageAsync($"- {pokemon.Nombre} (Vida: {pokemon.Vida}, Tipo: {pokemon.Tipo})");
            }

            await _channel.SendMessageAsync($"Equipo de {_jugador2.Username}:");
            foreach (var pokemon in equipoJugador2)
            {
                await _channel.SendMessageAsync($"- {pokemon.Nombre} (Vida: {pokemon.Vida}, Tipo: {pokemon.Tipo})");
            }
        }
    }
}
