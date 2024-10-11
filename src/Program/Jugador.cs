namespace Program;

public class Jugador : IJugadores
{
    public Dictionary<int, IPokemones> Pokemones { get; set; } = new Dictionary<int, IPokemones>();
    public List<IPokemones> ListaDePokemones { get; set; } = new List<IPokemones>();
    public int pokemonActivo;

    public void ElegirPokemon(int unNum)
    {
        IPokemones pokemonElegido = Pokemones[unNum];
        ListaDePokemones.Add(pokemonElegido);
        Console.WriteLine($"Has elegido a {pokemonElegido.Nombre}");
    }

    public void ElegirPokemonActivo(int unNum)
    {
        if (Pokemones.ContainsKey(unNum) && Pokemones[unNum].EstaVivo)
        {
            pokemonActivo = unNum;
            Console.WriteLine($"Elegiste a {Pokemones[unNum].Nombre} como Pokemon activo");
        }
        else
        {
            Console.WriteLine("No es posible seleccionar ese Pokemon");
        }
    }

    public void CambiarPokemonActivo(int unNum)
    {
        if (Pokemones.ContainsKey(unNum) && Pokemones[unNum].EstaVivo)
        {
            pokemonActivo = unNum;
            Console.WriteLine($"Haz cambiado el pokemon activo por {Pokemones[unNum].Nombre}");
        }
    }

    
    
    
    

}
    



