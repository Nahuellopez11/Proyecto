namespace Program;

public class Jugador : IJugadores
{
    public Dictionary<int, IPokemones> Pokemones { get; set; } = new Dictionary<int, IPokemones>();
    public List<IPokemones> ListaDePokemones { get; set; } = new List<IPokemones>();
    public IPokemones pokemonActivo { get; set; }
    
    public void ElegirPokemon(int unNum)
    {
        IPokemones pokemonElegido = Pokemones[unNum];
        ListaDePokemones.Add(pokemonElegido);
        Console.WriteLine($"Has elegido a {pokemonElegido.Nombre}");
    }

    public void ElegirPokemonActivo(int unNum)
    {
        if (Pokemones.ContainsKey(unNum))
        {
            pokemonActivo = Pokemones[unNum];
            ((Pokemon1)pokemonActivo).MarcarComoActivo(); // Marca como activo el Pokémon elegido
            Console.WriteLine($"Has elegido a {pokemonActivo.Nombre}");
        }
        else
        {
            Console.WriteLine("Número de Pokémon no válido.");
        }
    }

    public void CambiarPokemonActivo(int unNum)
    {
        if (Pokemones.ContainsKey(unNum) && Pokemones[unNum].EstaVivo)
        {
            // Desmarcar el Pokémon activo anterior
            if (pokemonActivo != null)
            {
                ((Pokemon1)pokemonActivo).Desmarcar();
            }

            pokemonActivo = Pokemones[unNum];
            ((Pokemon1)pokemonActivo).MarcarComoActivo(); // Marca el nuevo Pokémon como activo
            Console.WriteLine($"Has cambiado a {pokemonActivo.Nombre}");
        }
        else
        {
            Console.WriteLine("No puedes cambiar a ese Pokémon.");
        }

    public string NombrePokemonActivo
            {
                 get
            {
            if (Pokemones.ContainsKey(pokemonActivo))
            {
                return Pokemones[pokemonActivo].Nombre; // Devuelve el nombre del Pokémon activo
            }
            return "No hay Pokémon activo"; // Mensaje en caso de que no haya un Pokémon activo
            }
    }
        
    }
    
    
    
    
    
    

}
    



