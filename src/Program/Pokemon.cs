namespace Program;

public class Pokemon
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Vida { get; set; }
    public bool EstaVivo { get; set; }
    public List<object> Hablilidades { get; set; }

    public Pokemon(string nombre, string tipo, int vida, bool estaVivo)
    {
        this.Nombre = nombre;
        this.Tipo = tipo;
        this.Vida = vida;
        EstaVivo = true;
        Hablilidades = new List<object>();
    }

    public void AgregarHabilidad(object habilidad)
    {
        Hablilidades.Add(habilidad);
    }

    public void QuitarHabilidad(object habilidad)
    {
        Hablilidades.Remove(habilidad);
    }

    public string MostrarHabilidades()
    {
        return  $"Las habilidades de {Nombre} son {string.Join(",",Hablilidades)}";
    }
}
    //falta lo de atacar (no se si ya lo vamos a hacer en base a los tipos de pokemones)
    // falta reibir daño, ver vida