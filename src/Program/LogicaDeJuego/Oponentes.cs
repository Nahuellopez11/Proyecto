namespace Program;
// oponentes tiene su propia clase con sus metodos para crearlos y seleccion del jugador de oponenente
public static class Oponentes
{

    public static List<Maquina> CrearOponentes()
    {
        return new List<Maquina>
        {
            new Maquina("Red", ElegirPokemon.DevolverListaMaquina()),
            new Maquina("Gary", ElegirPokemon.DevolverListaMaquina()),
            new Maquina("Hilbert", ElegirPokemon.DevolverListaMaquina())
        };
    }

    public static Maquina SeleccionarOponente(List<Maquina> oponentes)
    {
        Console.WriteLine("Selecciona un oponente:");
        for (int i = 0; i < oponentes.Count; i++)
        {
            //nombre
            Console.WriteLine($"{i + 1}. {oponentes[i].Nombre}");

            // lista de pokemon cada oponennte
            Console.WriteLine("Pokémon disponibles:");
            foreach (var pokemon in oponentes[i].ListaDePokemones)
            {
                Console.WriteLine($"- {pokemon.Nombre}");
            }

            Console.WriteLine(); // separacion de maquinas
        }

        int seleccion = Convert.ToInt32(Console.ReadLine()) - 1;
        return oponentes[seleccion];
    }
}