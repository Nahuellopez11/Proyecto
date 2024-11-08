namespace Program;

public interface IItem
{
    string Nombre { get; }
    int UsosRestantes { get; set; }
    void Usar(IPokemones pokemon); // Aplica el efecto del ítem al Pokémon
}