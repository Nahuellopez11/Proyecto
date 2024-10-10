namespace Program;

public class HablilidadesPokemon
{
    public int ValorAtaque { get; set; }
    public int ValorDefensa { get; set; }
    public string NombreHabilidad { get; set; }

    public HablilidadesPokemon(int valorAtaque, int valorDefensa, string nombreHabilidad)
    {
        this.ValorAtaque = valorAtaque;
        this.ValorDefensa = valorDefensa;
        this.NombreHabilidad = nombreHabilidad;
    }
}