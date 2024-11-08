namespace Program;

public interface IPokemones
{
    string Nombre { get; }
    string Tipo { get; }
    double Vida { get; set; }
    void Accept(IVisitorPoke visitorPoke){}
    
}



/* 
    bool EstaVivo { get; set; }
    List<HabilidadesPokemon> Habilidades { get; set; }
    void AgregarHabilidad(HabilidadesPokemon habilidad);
    void QuitarHabilidad(HabilidadesPokemon habilidad);
    void Atacar(IPokemones defensor, HabilidadesPokemon habilidadUsada);


    //falta lo de atacar (no se si ya lo vamos a hacer en base a los tipos de pokemones)
    // falta reibir daño, ver vida
    /*
    
    //Dictionary<int, IPokemones> Pokemones { get; set; } 
    //IPokemones pokemonActivo { get; set; }*/