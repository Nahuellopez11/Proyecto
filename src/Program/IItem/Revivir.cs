namespace Program;


public class Revivir : IItem
{
    // clave para identificar el ítem
    public string Nombre { get; set; } = "Revivir";
    public int UsosRestantes { get; set; } = 1;

    // Revive al Pokémon si está debilitado (vida = 0) y tiene usos restantes
    public void Usar(IPokemon pokemon)
    {
        if (UsosRestantes > 0 && pokemon.Vida == 0)
        {
            UsosRestantes--;
            pokemon.Vida = 50; // todos los pokemones tiene 100 de vida asi que reviven con 50%
            Console.WriteLine($"{Nombre} usado en {pokemon.Nombre}. HP actual después de revivir: {pokemon.Vida}");
        }
        // Si el Pokémon no está debilitado, no se puede usar el ítem
        else if (pokemon.Vida > 0)
        {
            Console.WriteLine("No se puede usar Revivir en un Pokémon que no está debilitado.");
        }
        // Si no quedan usos, muestra un mensaje de que el ítem ya está agotado
        else
        {
            Console.WriteLine("No quedan usos de Revivir.");
        }
    }
}