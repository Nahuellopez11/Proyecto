namespace Program;

public class HabilidadesPokemon
{
    public int ValorAtaque { get; set; }
    public int ValorDefensa { get; set; }
    public string NombreHabilidad { get; set; }

    public HabilidadesPokemon(int valorAtaque, int valorDefensa, string nombreHabilidad)
    {
        this.ValorAtaque = valorAtaque;
        this.ValorDefensa = valorDefensa;
        this.NombreHabilidad = nombreHabilidad;
    }
}