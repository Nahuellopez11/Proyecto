namespace Program;


public class Revivir : IItem
{
    public string Nombre { get; set; } = "Revivir";
    public int UsosRestantes { get; set; } = 1;

    public void Usar(IPokemones pokemon)
    {
        if (UsosRestantes > 0 && pokemon.Vida == 0)
        {
            UsosRestantes--;
            pokemon.Vida = 50; // todos los pokemones tiene 100 de vida asi que reviven con 50%
            Console.WriteLine($"{Nombre} usado en {pokemon.Nombre}. HP actual después de revivir: {pokemon.Vida}");
        }
        else if (pokemon.Vida > 0)
        {
            Console.WriteLine("No se puede usar Revivir en un Pokémon que no está debilitado.");
        }
        else
        {
            Console.WriteLine("No quedan usos de Revivir.");
        }
    }
}