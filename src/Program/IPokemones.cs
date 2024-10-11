namespace Program;

public interface IPokemones
{
    string Nombre { get; set; }
    string Tipo { get; set; }
    int Vida { get; set; }
    bool EstaVivo { get; set; }
    List<HabilidadesPokemon> Habilidades { get; set; }
    void AgregarHabilidad(HabilidadesPokemon habilidad);
    void QuitarHabilidad(HabilidadesPokemon habilidad);
    


}
    //falta lo de atacar (no se si ya lo vamos a hacer en base a los tipos de pokemones)
    // falta reibir daño, ver vida