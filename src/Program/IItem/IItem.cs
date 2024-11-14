namespace Program;
// representa un ítem en el juego que puede ser usado por un Pokémon
public interface IItem
{
    string Nombre { get; }
    int UsosRestantes { get; set; }
    void Usar(IPokemon pokemon); // Aplica el efecto del ítem al Pokémon
}