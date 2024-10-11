namespace Program;

class Program
{
    static void Main()
    {
        // crear pokemones (ahora solo con Pokemon1)
        Pokemon1 squirtle = new Pokemon1("Squirtle", "Agua", 100);
        Pokemon1 charmander = new Pokemon1("Charmander", "Fuego", 90);
        Pokemon1 bulbasaur = new Pokemon1("Bulbasaur", "Planta", 80);
        
        // diccionario creado con los pokemons "pokedex"
        Dictionary<int, IPokemones> pokedex = new Dictionary<int, IPokemones>
        {
            { 1, squirtle },
            { 2, charmander },
            { 3, bulbasaur }
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

            int numero = Convert.ToInt32(Console.ReadLine());
            jugador.ElegirPokemon(numero);
        }
    }
}
// hay que armar el main, faltan mas clases pokemon (con alguna diferencia capaz)
// por ahora podes elegir pokemones hasta 6, no hay restricciones (podes hacer combo 6 bulbasaur)
// la maquina haria masomenos lo mismo solo que con random en la variable "numero" al elegir pokemones y sin tanto console-writeline