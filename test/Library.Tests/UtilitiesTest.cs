using NUnit.Framework;
using System.Collections.Generic;

namespace Program.Tests
{
    [TestFixture]
    public class PruebasDeUtilities
    {
        private Jugador jugador;
        private IPokemon pikachu;
        private IPokemon charmander;

        [SetUp]
        public void ConfigurarEscenario()
        {
            pikachu = new Pokemon("Pikachu", 100, TipoPokemon.Electrico);
            charmander = new Pokemon("Charmander", 0, TipoPokemon.Fuego);

            var listaDePokemones = new List<IPokemon> { pikachu, charmander };
            jugador = new Jugador(listaDePokemones);
        }

        // CambiarPokemonJugador Tests

        [Test]
        public void CambiarPokemonDevuelveElMismoPokemonSiSeleccionEsInvalida()
        {
            // Simular entrada inválida (-1)
            System.Console.SetIn(new System.IO.StringReader("-1\n"));

            var resultado = Utilities.CambiarPokemonJugador(jugador, pikachu);

            // Verificar que no cambia el Pokémon
            Assert.AreEqual(pikachu, resultado);
        }

        [Test]
        public void CambiarPokemonDevuelveElMismoPokemonSiSeleccionEsUnPokemonDebilitado()
        {
            // Simular entrada del usuario (elige al segundo Pokémon que está debilitado)
            System.Console.SetIn(new System.IO.StringReader("2\n"));

            var resultado = Utilities.CambiarPokemonJugador(jugador, pikachu);

            // Verificar que no cambia el Pokémon porque Charmander está debilitado
            Assert.AreEqual(pikachu, resultado);
        }

        [Test]
        public void CambiarPokemonDevuelveOtroPokemonSiSeleccionEsValidaYConVida()
        {
            // Simular entrada del usuario (elige al primer Pokémon, que tiene vida)
            System.Console.SetIn(new System.IO.StringReader("1\n"));

            var resultado = Utilities.CambiarPokemonJugador(jugador, charmander);

            // Verificar que el cambio se realiza correctamente
            Assert.AreEqual(pikachu, resultado);
        }

        // UsarItem Tests

        [Test]
        public void UsarItemCambiaTurnoDespuesDeUsarUnItemExitosamente()
        {
            // Agregar un ítem al jugador
            jugador.Items = new List<IItem> { new SuperPocion() };

            // Simular entrada del usuario (elige el ítem y aplica a Pikachu)
            System.Console.SetIn(new System.IO.StringReader("1\n1\n"));

            var turno = Utilities.UsarItem(jugador, 0);

            // Verificar que el turno cambia
            Assert.AreEqual(1, turno);
            Assert.AreEqual(150, pikachu.Vida); // SuperPoción aumenta la vida en 50
        }

        [Test]
        public void UsarItemDevuelveTurnoSinCambioSiSeleccionEsInvalida()
        {
            // Simular entrada del usuario (opción inválida para ítem)
            System.Console.SetIn(new System.IO.StringReader("0\n"));

            var turno = Utilities.UsarItem(jugador, 0);

            // Verificar que el turno no cambia
            Assert.AreEqual(0, turno);
        }

        [Test]
        public void UsarItemNoHaceNadaSiNoHayItems()
        {
            // Vaciar lista de ítems del jugador
            jugador.Items.Clear();

            // Simular entrada del usuario
            System.Console.SetIn(new System.IO.StringReader("1\n"));

            var turno = Utilities.UsarItem(jugador, 0);

            // Verificar que el turno no cambia
            Assert.AreEqual(0, turno);
        }

        // VerificarFinBatalla Tests (ya cubierto, pero con casos adicionales)

        [Test]
        public void VerificarFinDeBatallaDevuelveFalseSiTodosLosPokemonesTienenVida()
        {
            // Configurar ambos Pokémon con vida
            pikachu.Vida = 100;
            charmander.Vida = 50;

            var resultado = Utilities.VerificarFinBatalla(jugador.ListaDePokemones);

            // Verificar que la batalla no termina
            Assert.IsFalse(resultado);
        }

        [Test]
        public void VerificarFinDeBatallaDevuelveTrueSiListaDePokemonesEstaVacia()
        {
            // Configurar lista vacía
            jugador.ListaDePokemones.Clear();

            var resultado = Utilities.VerificarFinBatalla(jugador.ListaDePokemones);

            // Verificar que la batalla termina
            Assert.IsTrue(resultado);
        }
    }
}

