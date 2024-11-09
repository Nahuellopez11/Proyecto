namespace Program
{
    public class AtaqueEspecial : Ataque
    {
        // Propiedad que indica el estado especial que el ataque puede causar 
        public EstadoEspecial EfectoEstado { get; private set; }

        public AtaqueEspecial(string nombre, TipoPokemon tipo, int dañoBase, double precision, EstadoEspecial efecto)
            : base(nombre, tipo, dañoBase, precision)
        {
            EfectoEstado = efecto;
        }

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