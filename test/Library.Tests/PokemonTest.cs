using NUnit.Framework;
using Program; // Importar el espacio de nombres correcto

namespace Program.Tests
{
    [TestFixture]
    public class PokemonTests
    {
        private Pokemon pikachu;
        private Pokemon charmander;
        private Ataque ataqueFuego;

        [SetUp]
        public void Configurar()
        {
            // Crear Pokémon de prueba
            pikachu = new Pokemon("Pikachu", 100, TipoPokemon.Electrico);
            charmander = new Pokemon("Charmander", 100, TipoPokemon.Fuego);

            // Crear un ataque con el tipo correcto
            ataqueFuego = new Ataque("Llamarada", TipoPokemon.Fuego, 50, 85);
        }

        [Test]
        public void RecibirDaño_ReduceVidaCorrectamente()
        {
            // Actuar
            pikachu.RecibirDaño(30);

            // Verificar
            Assert.AreEqual(70, pikachu.Vida);
        }

        [Test]
        public void RecibirDaño_NoBajaDeCero()
        {
            // Actuar
            pikachu.RecibirDaño(150);

            // Verificar
            Assert.AreEqual(0, pikachu.Vida);
        }

        [Test]
        public void PuedeAtacar_DevuelveTrueSiNoTieneEstadoAlterado()
        {
            // Actuar
            var puedeAtacar = pikachu.PuedeAtacar();

            // Verificar
            Assert.IsTrue(puedeAtacar);
        }

        [Test]
        public void AplicarEfectoEstado_Paralizado()
        {
            // Actuar
            pikachu.AplicarEfectoEstado(EstadoEspecial.Paralizado);

            // Verificar
            Assert.AreEqual(EstadoEspecial.Paralizado, pikachu.EstadoActual);
        }

        [Test]
        public void CurarEstados_RestableceEstadoNormal()
        {
            // Configurar estado alterado
            pikachu.AplicarEfectoEstado(EstadoEspecial.Dormido);

            // Actuar
            pikachu.CurarEstados();

            // Verificar
            Assert.AreEqual(EstadoEspecial.Normal, pikachu.EstadoActual);
        }

        [Test]
        public void RealizarAtaque_ReduceVidaDelObjetivo()
        {
            // Configurar ataque
            pikachu.AtaquesDisponibles.Add(ataqueFuego);

            // Actuar
            pikachu.RealizarAtaque(0, charmander);
            // Verificar
            Assert.AreEqual(95, charmander.Vida); // 100 - 50
        }

        [Test]
        public void RealizarAtaque_NoHaceNadaSiIndiceEsInvalido()
        {
            // Actuar
            pikachu.RealizarAtaque(5, charmander);

            // Verificar
            Assert.AreEqual(100, charmander.Vida); // Vida no cambia
        }
    }
}
