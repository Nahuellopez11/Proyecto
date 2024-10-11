namespace Program;

public interface IJugadores
{
    Dictionary<int, IPokemones> Pokemones { get; set; } 
    void ElegirPokemon(int unNum);






    //faltan los metodos elegir pokemon, cambiar pokemon, tiene vida y terminar juego
}