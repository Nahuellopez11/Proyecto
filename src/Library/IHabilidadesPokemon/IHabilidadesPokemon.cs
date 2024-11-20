namespace Program;
// La interfaz tiene una única responsabilidad: definir las propiedades relacionadas con las habilidades de un Pokémon
public interface IHabilidadesPokemon
{
    public int ValorAtaque { get; set; }
    public string NombreHabilidad { get; set; }

 
}