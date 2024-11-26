using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Program.Discord.Commands
{
    public class BattleCommand : ModuleBase<SocketCommandContext>
    {
        private static readonly HashSet<(ulong, ulong)> batallasActivas = new();
        private static readonly SemaphoreSlim semaphore = new(1, 1);

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
            await semaphore.WaitAsync();

            try
            {
                await ExecuteBattleLogicAsync(opponentDisplayName);
            }
            finally
            {
                semaphore.Release();
            }
        }

        private async Task ExecuteBattleLogicAsync(string? opponentDisplayName)
        {
            string displayName = CommandHelper.GetDisplayName(Context);
            SocketGuildUser? opponentUser = CommandHelper.GetUser(Context, opponentDisplayName);

            if (opponentUser != null)
            {
                if (batallasActivas.Contains((Context.User.Id, opponentUser.Id)) || 
                    batallasActivas.Contains((opponentUser.Id, Context.User.Id)))
                {
                    await ReplyAsync("¡Ya estás en una batalla con este jugador!");
                    return;
                }

                batallasActivas.Add((Context.User.Id, opponentUser.Id));

                try
                {
                    var elegirPokemon = new ElegirPokemonBot(Context.User, opponentUser, (SocketTextChannel)Context.Channel);
                    await elegirPokemon.SeleccionarEquipoAsync();

                    var equipoJugador1 = elegirPokemon.EquipoJugador1;
                    var equipoJugador2 = elegirPokemon.EquipoJugador2;

                    var client = (DiscordSocketClient)Context.Client;
                    var inicializacionBatalla = new InicializacionBatallaBot(
                        Context.User,
                        opponentUser,
                        equipoJugador1,
                        equipoJugador2,
                        (SocketTextChannel)Context.Channel,
                        client);

                    await Context.Channel.SendMessageAsync(
                        $"¡La batalla entre {displayName} y {opponentUser.DisplayName} ha comenzado! Usa 'ataque' o 'cambiar' en el chat para jugar.");
                }
                finally
                {
                    batallasActivas.Remove((Context.User.Id, opponentUser.Id));
                }
            }
            else
            {
                await ReplyAsync($"No se ha encontrado un oponente con el nombre {opponentDisplayName}.");
            }
        }
    }
}
