namespace Program;

public interface IPokemones
{
    string Nombre { get; }
    TipoPokemon Tipo { get; }
    double Vida { get; set; }
    void Accept(IVisitorPoke visitorPoke){}
    
}



