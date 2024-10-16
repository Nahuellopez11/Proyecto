namespace Program;

public class Maquina : IJugadores
{
    public Dictionary<int, IPokemones> Pokemones { get; set; } = new Dictionary<int, IPokemones>();
    public List<IPokemones> ListaDePokemones { get; set; } = new List<IPokemones>();
    public IPokemones pokemonActivo { get; set; }

    public void ElegirPokemon(int unNum)
    {
        IPokemones pokemonElegido = Pokemones[unNum];
        ListaDePokemones.Add(pokemonElegido);
    }

    public void AccionAutomatica(Jugador jugador)
    {
        int eleccion = new Random().Next(1, 3);
        if (eleccion == 1)
        {
            // Atacar
            HabilidadesPokemon habilidadUsada = pokemonActivo.Habilidades[0]; // Ejemplo de habilidad
            pokemonActivo.Atacar(jugador.pokemonActivo, habilidadUsada);
            Console.WriteLine($"{pokemonActivo.Nombre} ha atacado al Pokémon del jugador.");
        }
        else
        {
            // Cambiar Pokémon
            ElegirPokemon(new Random().Next(1, Pokemones.Count + 1)); // Cambia a un Pokémon aleatorio
        }
    }

    public void SeleccionarPokemonActivo()
    {
        if (ListaDePokemones.Count > 0)
        {
            int indiceAleatorio = new Random().Next(0, ListaDePokemones.Count);
            pokemonActivo = ListaDePokemones[indiceAleatorio];
            Console.WriteLine($"La máquina ha seleccionado a {pokemonActivo.Nombre} como su Pokémon activo.");
        }
    }
    public void CambiarPokemonActivo(int index)
    {
        if (ListaDePokemones.Count > index)
        {
            pokemonActivo = ListaDePokemones[index]; // Asumiendo que ListaDePokemones es una lista de IPokemones
        }
        else
        {
            Console.WriteLine("Índice de Pokémon inválido.");
        }
    }


}

// hace lo mismo que Jugador solo que sin escribir (sino te spamea mal)