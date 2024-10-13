using System;
using System.Collections.Generic;

namespace Program;

class Program
{
    static void Main()
    {
        // crear pokemones (ahora solo con Pokemon1)
        Pokemon1 squirtle = new Pokemon1("Squirtle", "Agua", 100);
        Pokemon1 charmander = new Pokemon1("Charmander", "Fuego", 90);
        Pokemon1 bulbasaur = new Pokemon1("Bulbasaur", "Planta", 80);
        Pokemon1 charizard = new Pokemon1("Charizard", "Fuego", 90);
        Pokemon1 torterra = new Pokemon1("Torterra", "Planta", 85);
        Pokemon1 mewtwo = new Pokemon1("Mewtwo", "Agua", 95);
        
        // diccionario creado con los pokemons "pokedex"
        Dictionary<int, IPokemones> pokedex = new Dictionary<int, IPokemones>
        {
            { 1, squirtle },
            { 2, charmander },
            { 3, bulbasaur },
            { 4, charizard },
            { 5, torterra },
            {6, mewtwo},
        };

        // crear jugador
        Jugador jugador = new Jugador();
        jugador.Pokemones = pokedex; // el diccionario del jugador se actualiza con los pokemones creados1
        while (jugador.ListaDePokemones.Count < 6) // loop hasta el jugador llegar a 6 pokemons
        {

            Console.WriteLine("Selecciona 6 Pokémones escribiendo su número:");
            Console.WriteLine("1. Squirtle");
            Console.WriteLine("2. Charmander");
            Console.WriteLine("3. Bulbasaur");
            Console.WriteLine("4. Charizard");
            Console.WriteLine("5. Torterra");
            Console.WriteLine("6. Mewtwo");
            

            int numero = Convert.ToInt32(Console.ReadLine());
            jugador.ElegirPokemon(numero);
            
        }
        // Crear máquina y seleccionar Pokémon aleatoriamente
        Maquina maquina = new Maquina();
        Random random = new Random();
        while (maquina.ListaDePokemones.Count < 6) // Loop hasta que la máquina llegue a 6 Pokémon
        {
            int numeroRandom = random.Next(1, pokedex.Count + 1);
            maquina.ElegirPokemon(numeroRandom);
        }

        // Establecer un Pokémon activo para cada jugador
        jugador.ElegirPokemonActivo(1);
        maquina.SeleccionarPokemonActivo();

        // Iniciar el juego
        Juego juego = new Juego(jugador, maquina);
        juego.IniciarJuego();
    }
    
}
// hay que armar el main, faltan mas clases pokemon (con alguna diferencia capaz)
// por ahora podes elegir pokemones hasta 6, no hay restricciones (podes hacer combo 6 bulbasaur)
// la maquina haria masomenos lo mismo solo que con random en la variable "numero" al elegir pokemones y sin tanto console-writeline