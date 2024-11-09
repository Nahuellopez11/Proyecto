namespace Program
{
    public class AtaqueEspecial : Ataque
    {
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
                objetivo.AplicarEfectoEstado(EfectoEstado);
            }

            return daño;
        }
    }
}