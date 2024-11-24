using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ucu.Poo.DiscordBot.Domain;

namespace Program.Discord.Commands;

/// <summary>
/// Esta clase implementa el comando 'battle' del bot. Este comando une al
/// jugador que envía el mensaje con el oponente que se recibe como parámetro,
/// si lo hubiera, en una batalla; si no se recibe un oponente, lo une con
/// cualquiera que esté esperando para jugar.
/// </summary>
// ReSharper disable once UnusedType.Global
public class BattleCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'battle'. Este comando une al jugador que envía el
    /// mensaje a la lista de jugadores esperando para jugar.
    /// </summary>
    [Command("battle")]
    [Summary(
        """
        Une al jugador que envía el mensaje con el oponente que se recibe
        como parámetro, si lo hubiera, en una batalla; si no se recibe un
        oponente, lo une con cualquiera que esté esperando para jugar.
        """)]
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("Display name del oponente, opcional")]
        string? opponentDisplayName = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        
        // Obtener al oponente por el nombre mostrado (si se proporciona)
        SocketGuildUser? opponentUser = CommandHelper.GetUser(Context, opponentDisplayName);

        string result;

        // Verifica si hay un oponente disponible
        if (opponentUser != null)
        {
            // Crear la instancia de ElegirPokemon con los jugadores
            ElegirPokemon elegirPokemon = new ElegirPokemon(displayName, opponentUser.DisplayName);

            // Esperar a que ambos jugadores elijan sus Pokémon
            await elegirPokemon.SeleccionarEquipo();  // Jugador 1 elige su equipo
            await elegirPokemon.SeleccionarEquipo2(); // Jugador 2 elige su equipo

            // Crear la batalla utilizando la lógica adaptada con los equipos elegidos
            BatallaDiscord batallaDiscord = new BatallaDiscord(elegirPokemon);

            // Mostrar mensaje inicial de la batalla
            result = $"¡La batalla entre {displayName} y {opponentUser.DisplayName} ha comenzado!";
            
            await Context.Message.Author.SendMessageAsync(result);
            await opponentUser.SendMessageAsync(result);

            // Iniciar el primer turno de la batalla
            await batallaDiscord.EjecutarTurno(Context, 0);  // 0 sería el primer turno para el jugador1
        }
        else
        {
            result = $"No se ha encontrado un oponente con el nombre {opponentDisplayName}.";
            await ReplyAsync(result);
        }
    }
};


