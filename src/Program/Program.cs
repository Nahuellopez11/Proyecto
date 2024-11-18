using System;
using System.Collections.Generic;

namespace Program;

class Program
{
    static void Main()
    {
        Console.WriteLine("Escoge una opción");
        Console.WriteLine("1 - Jugar contra máquina");
        Console.WriteLine("2 - Jugar contra jugador");
        int opcion=Convert.ToInt32(Console.ReadLine());

        if (opcion == 1)
        {
            ElegirPokemon.SeleccionarEquipo();
            ElegirPokemon.SeleccionarEquipoMaquina();
            IncializacionBatallaContraMaquina.LogicaJuego();

        }
        else
        {
            Console.WriteLine("El Jugador1 elige equipo"); ;
            ElegirPokemon.SeleccionarEquipo();
            Console.WriteLine("El Jugador2 elige equipo");
            ElegirPokemon.SeleccionarEquipo();

        }
        
        
 ;
        // FALTA LOGICA ATAQUE (CON ATAQUES ESPECIALES Y TIPOS), ITEMS, CAMBIAR_POKEMON
        
        
    }
}

