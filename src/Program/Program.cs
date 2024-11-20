using System;
using System.Collections.Generic;

namespace Program;

using System;

using System;

class Program
{
    public static void Main(string[] args)
    {
        // Crear la instancia para elegir los Pokémon
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



