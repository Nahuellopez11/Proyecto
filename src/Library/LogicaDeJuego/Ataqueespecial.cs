namespace Program
{
    /// <summary>
    /// Representa un ataque especial que puede infligir daño y aplicar un estado especial al objetivo.
    /// </summary>
    public class AtaqueEspecial : Ataque
    {
        /// <summary>
        /// Obtiene el efecto de estado especial que el ataque puede causar en el objetivo.
        /// </summary>
        public EstadoEspecial EfectoEstado { get; private set; }
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AtaqueEspecial"/>.
        /// </summary>
        /// <param name="nombre">El nombre del ataque.</param>
        /// <param name="tipo">El tipo del ataque.</param>
        /// <param name="dañoBase">El daño base del ataque.</param>
        /// <param name="precision">La precisión del ataque (valor entre 0 y 1).</param>
        /// <param name="efecto">El efecto de estado especial que el ataque puede causar.</param>
        public AtaqueEspecial(string nombre, TipoPokemon tipo, int dañoBase, double precision, EstadoEspecial efecto)
            : base(nombre, tipo, dañoBase, precision)
        {
            EfectoEstado = efecto;
        }
        /// <summary>
        /// Calcula el daño infligido por este ataque especial al objetivo, y aplica un efecto de estado si corresponde.
        /// </summary>
        /// <param name="atacante">El Pokémon que realiza el ataque.</param>
        /// <param name="objetivo">El Pokémon objetivo del ataque.</param>
        /// <returns>La cantidad de daño infligido.</returns>
        public override int CalcularDaño(Pokemon atacante, Pokemon objetivo)
        {
            int daño = base.CalcularDaño(atacante, objetivo);

            if (daño > 0 || DañoBase == 0) // Si el ataque conectó o es un ataque sin daño
            {
                objetivo.AplicarEfectoEstado(EfectoEstado); // Aplica el efecto de estado al objetivo (Ej. envenenamiento, parálisis)
            }

            return daño;
        }
    }
}