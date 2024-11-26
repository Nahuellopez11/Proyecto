using System;
using System.Collections.Generic;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Services;
using System;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Iniciar el bot
            await BotLoader.LoadAsync();
        }
    }
}



    
 /*   
    public ElegirPokemon elegirPokemon = new ElegirPokemon("Jugador1","Ju");

    public static void Main(string[] args)
    {
        //DemoBot();
        ElegirPokemon elegirPokemon = new ElegirPokemon();
        Console.WriteLine("Jugador 1, selecciona tu equipo:");
        elegirPokemon.SeleccionarEquipo();
        Console.WriteLine("Jugador 2, selecciona tu equipo:");
        elegirPokemon.SeleccionarEquipo2();
        // Lógica de la batalla entre jugadores
        InicializacionBatallaContraJugador inicializarJugador = new InicializacionBatallaContraJugador(elegirPokemon);
        inicializarJugador.LogicaJuego();
    }
}
    
/*
    private static void DemoFacade()
    {
        Console.WriteLine(Facade.Instance.AddTrainerToWaitingList("player"));
        Console.WriteLine(Facade.Instance.AddTrainerToWaitingList("opponent"));
        Console.WriteLine(Facade.Instance.GetAllTrainersWaiting());
        Console.WriteLine(Facade.Instance.StartBattle("player", "opponent"));
        Console.WriteLine(Facade.Instance.GetAllTrainersWaiting());
    }

    private static void DemoBot()
    {
        BotLoader.LoadAsync().GetAwaiter().GetResult();
    }
*/


