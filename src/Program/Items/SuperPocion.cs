namespace Program;

public class SuperPocion : IItem
{
    //clave para identificar el ítem
    public string Nombre { get; set; }= "Súper poción";
    public int UsosRestantes { get; set; } = 4;

    // La Súper poción cura 70 puntos de vida del Pokémon sin exceder el máximo de 100 de vida
    public void Usar(IPokemones pokemon)
    {
        if (UsosRestantes > 0)
        {
            UsosRestantes--;
            pokemon.Vida = Math.Min(pokemon.Vida + 70, 100); // cura 70 de hp no se puede pasar de 100 por el .Min
            Console.WriteLine($"{Nombre} usada en {pokemon.Nombre}. HP actual: {pokemon.Vida}");
        }
        else
        {
            Console.WriteLine("No quedan pociones.");
        }
    }
}