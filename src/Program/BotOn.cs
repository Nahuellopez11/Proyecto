using System;
using System.Collections.Generic;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Services;

namespace Program;

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("¡Hola, mundo!");
    }
}

/*
public ElegirPokemon elegirPokemon = new ElegirPokemon();

    public static void Main(string[] args)
    {
        DemoBot();
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
        
        
 ;
        // FALTA LOGICA ATAQUE (CON ATAQUES ESPECIALES Y TIPOS), ITEMS, CAMBIAR_POKEMON
        
        
        
        
    }
    private static void DemoFacade()
    {
        Console.WriteLine(ConectorDeClases.Instance.AddTrainerToWaitingList("player"));
        Console.WriteLine(ConectorDeClases.Instance.AddTrainerToWaitingList("opponent"));
        Console.WriteLine(ConectorDeClases.Instance.GetAllTrainersWaiting());
        Console.WriteLine(ConectorDeClases.Instance.StartBattle("player", "opponent"));
        Console.WriteLine(ConectorDeClases.Instance.GetAllTrainersWaiting());
    }

    private static void DemoBot()
    {
        BotLoader.LoadAsync().GetAwaiter().GetResult();
    }


*/