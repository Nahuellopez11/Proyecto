namespace Program;

public interface IJugadores
{
    Dictionary<int, IPokemones> Pokemones { get; set; } 
    void ElegirPokemon(int unNum);
    void CambiarPokemon(int unNum);
    bool TieneVida();
    bool TerminarJuego();




    
}