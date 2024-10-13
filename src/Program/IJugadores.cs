namespace Program;

public interface IJugadores
{
    Dictionary<int, IPokemones> Pokemones { get; set; } 
    IPokemones pokemonActivo { get; set; }




    
}