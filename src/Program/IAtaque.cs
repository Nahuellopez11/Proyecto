namespace Program
{
    public interface IAtaque
    {
        // Propiedad que representa la habilidad utilizada en el ataque
        HabilidadesPokemon Habilidad { get; }

        // Método para ejecutar el ataque en un objetivo, implementando la lógica de daño
        int EjecutarAtaque(IPokemones objetivo);

        // STRING POR AHORA (DEBERIA CAMBIAR A UN TIPO)
        double CalcularEfectividad(Tipo tipoObjetivo);
    }
}