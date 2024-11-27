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
            // Mostrar opciones al usuario


            // Leer la opción ingresada por el usuario


            
                // Jugar juego por consola
                Console.WriteLine("Iniciando el juego por consola...");
                
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
}
