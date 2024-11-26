using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;
namespace Program.Discord.Commands;

    public class BattleCommand : ModuleBase<SocketCommandContext>
    {
        [Command("battle")]
        [Summary(
            """
            Une al jugador que envía el mensaje con el oponente que se recibe
            como parámetro, si lo hubiera, en una batalla; si no se recibe un
            oponente, lo une con cualquiera que esté esperando para jugar.
            """
        )]
        public async Task ExecuteAsync(
            [Remainder]
            [Summary("Display name del oponente, opcional")]
            string? opponentDisplayName = null)
        {
            string displayName = CommandHelper.GetDisplayName(Context);
            SocketGuildUser? opponentUser = CommandHelper.GetUser(Context, opponentDisplayName);

            if (opponentUser != null)
            {
                // Paso 1: Crear la instancia de ElegirPokemonBot y esperar selección de equipos
                var elegirPokemon = new ElegirPokemonBot(Context.User, opponentUser, (SocketTextChannel)Context.Channel);
                await elegirPokemon.SeleccionarEquipoAsync();
                
                var equipoJugador1 = elegirPokemon.EquipoJugador1;
                var equipoJugador2 = elegirPokemon.EquipoJugador2;

                // Paso 2: Crear la instancia de InicializacionBatallaBot y comenzar la batalla
                var inicializacionBatalla = new InicializacionBatallaBot(Context.User, opponentUser, equipoJugador1, equipoJugador2, (SocketTextChannel)Context.Channel);
                await inicializacionBatalla.IniciarBatallaAsync();

                // Mensaje final (opcional)
                await Context.Channel.SendMessageAsync($"La batalla entre {displayName} y {opponentUser.DisplayName} ha terminado.");
            }
            else
            {
                await ReplyAsync($"No se ha encontrado un oponente con el nombre {opponentDisplayName}.");
            }
        }
    }
