using System;
using System.Collections.Generic;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Services;

namespace Program;

using System;

class Program
{
    public static void Main(string[] args)
    {
        //DemoBot();

        // Crear selector de equipo
        SelectorEquipoPokemon selectorEquipo = new SelectorEquipoPokemon();

        Console.WriteLine("Jugador 1, selecciona tu equipo:");
        List<IPokemon> equipoJugador1 = selectorEquipo.SeleccionarEquipo();

        Console.WriteLine("Jugador 2, selecciona tu equipo:");
        List<IPokemon> equipoJugador2 = selectorEquipo.SeleccionarEquipo();

        // Inicializar batalla con los equipos seleccionados
        InicializacionBatallaContraJugador inicializarJugador = 
            new InicializacionBatallaContraJugador(equipoJugador1, equipoJugador2);
        
        inicializarJugador.LogicaJuego();
    }

    private static void DemoFacade()
    {
        Console.WriteLine(ConectorDeClases.Instance.AddTrainerToWaitingList("player"));
        Console.WriteLine(ConectorDeClases.Instance.AddTrainerToWaitingList("opponent"));
        Console.WriteLine(ConectorDeClases.Instance.GetAllTrainersWaiting());
        Console.WriteLine(ConectorDeClases.Instance.StartBattle("player", "opponent"));
        Console.WriteLine(ConectorDeClases.Instance.GetAllTrainersWaiting());
    }

   /* private static void DemoBot()
    {
        BotLoader.LoadAsync().GetAwaiter().GetResult();
    }
*/
}
        

            
            
            
            
    
        



/*


*/