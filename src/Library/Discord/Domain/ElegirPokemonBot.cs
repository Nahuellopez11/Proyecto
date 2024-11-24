using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Program
{
    public class ElegirPokemonBot
    {
        private readonly CatalogoPokemones catalogo = new CatalogoPokemones();
        private readonly SocketTextChannel _channel;
        private readonly SocketUser _jugador1;
        private readonly SocketUser _jugador2;
        private List<IPokemon> equipoJugador1 = new List<IPokemon>();
        private List<IPokemon> equipoJugador2 = new List<IPokemon>();

        // Constructor que acepta los jugadores y el canal de Discord
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

            // Mostrar catálogo de Pokémon con botones de selección
            var embed = CrearCatalogoEmbed();
            var mensajeCatalogo = await _channel.SendMessageAsync(embed: embed);

            // Añadir botones de selección
            var botones = CrearBotonesParaSeleccion();
            await mensajeCatalogo.AddReactionsAsync(botones);

            // Esperar selección de Pokémon de jugador 1
            var seleccionJugador1 = await EsperarSeleccionAsync(_jugador1);
            equipoJugador1 = seleccionJugador1;

            await _channel.SendMessageAsync($"{_jugador2.Username}, ahora es tu turno de seleccionar 6 Pokémon.");
            var mensajeCatalogo2 = await _channel.SendMessageAsync(embed: embed);
            await mensajeCatalogo2.AddReactionsAsync(botones);

            // Esperar selección de Pokémon de jugador 2
            var seleccionJugador2 = await EsperarSeleccionAsync(_jugador2);
            equipoJugador2 = seleccionJugador2;

            // Mostrar equipos finales
            MostrarEquipoFinalAsync();
        }

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

        private List<IEmote> CrearBotonesParaSeleccion()
        {
            List<IEmote> botones = new List<IEmote>();

            // Crear botones con los índices de los Pokémon (puedes usar emotes personalizados o números)
            for (int i = 1; i <= catalogo.CatalogoPoke.Count; i++)
            {
                botones.Add(new Emoji(i.ToString())); // Asumimos que se usan números del 1 al N
            }

            return botones;
        }

        private async Task<List<IPokemon>> EsperarSeleccionAsync(SocketUser jugador)
        {
            var seleccionados = new List<IPokemon>();
            var filtro = new Func<IUserMessage, bool>(message =>
                message.Author.Id == jugador.Id && message.Content.StartsWith("!seleccion")
            );

            // Esperar hasta que el jugador haya hecho una selección
            await foreach (var mensaje in _channel.GetMessagesAsync())
            {
                var userMessage = mensaje.OfType<IUserMessage>().FirstOrDefault(m => filtro(m));
                if (userMessage != null)
                {
                    var seleccion = ParsearSeleccion(userMessage.Content);
                    foreach (var pokemon in seleccion)
                    {
                        seleccionados.Add(pokemon);
                    }
                    break;  // Si quieres solo el primer mensaje, de lo contrario omite esta línea.
                }
            }


            return seleccionados;
        }

        private List<IPokemon> ParsearSeleccion(string seleccion)
        {
            // Parsear el mensaje y devolver la lista de Pokémon seleccionados
            List<IPokemon> seleccionados = new List<IPokemon>();

            // Aquí necesitarás la lógica para transformar la selección (números o texto)
            // En una lista de Pokémon que se han elegido por el jugador

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
