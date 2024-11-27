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
            Console.WriteLine("Ingrese una opción:");
            Console.WriteLine("Ingrese 1 para jugar Online (activar bot Discord)");
            Console.WriteLine("Ingrese 2 para jugar Local (jugar por Consola)");

            // Leer la opción ingresada por el usuario
            string opcion = Console.ReadLine();

            // Ejecutar según la opción seleccionada
            if (opcion == "1")
            {
                // Iniciar el bot
                Console.WriteLine("Iniciando el bot de Discord...");
                await BotLoader.LoadAsync();
            }
            else if (opcion == "2")
            {
                // Jugar juego por consola
                Console.WriteLine("Iniciando el juego por consola...");
                
                ElegirPokemon elegirPokemon = new ElegirPokemon();
                Console.WriteLine("Jugador 1, selecciona tu equipo:");
                elegirPokemon.SeleccionarEquipo();
                Console.WriteLine("Jugador 2, selecciona tu equipo:");
                elegirPokemon.SeleccionarEquipo2();
                
                // Lógica de la batalla entre jugadores
                InicializacionBatallaContraJugador inicializarJugador = new InicializacionBatallaContraJugador();
                inicializarJugador.LogicaJuego();
            }
            else
            {
                Console.WriteLine("Opción inválida. Por favor ingresa 1 o 2.");
            }
        }
    }
}
