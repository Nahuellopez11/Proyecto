using System;
using System.Collections.Generic;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Services;


namespace Program;

class Program
{
    static void Main()
    {
        DemoBot();
        
        
        
 ;
        // FALTA LOGICA ATAQUE (CON ATAQUES ESPECIALES Y TIPOS), ITEMS, CAMBIAR_POKEMON
        
        
        
        
    }
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
}

