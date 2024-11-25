namespace Program;

public interface IPokemon
{
    string Nombre { get; }
    TipoPokemon Tipo { get; }
    double Vida { get; set; }
    void Accept(IVisitorPoke visitorPoke){}
    List<Ataque> AtaquesDisponibles { get; set; }
    
}



