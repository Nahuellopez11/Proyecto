/*using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Program.Tests
{
    [TestFixture]
    public class InicializacionBatallaContraJugadorTests
    {
        private InicializacionBatallaContraJugador _batalla;
        private ElegirPokemon _elegirPokemon;

        [SetUp]
        public void SetUp()
        {
            // Crear instancia de ElegirPokemon
            _elegirPokemon = new ElegirPokemon();

            // Usar reflection para asignar manualmente equipos válidos
            var catalogoField = typeof(ElegirPokemon).GetField("catalogo", BindingFlags.Public | BindingFlags.Instance);
            var catalogo = catalogoField?.GetValue(_elegirPokemon);

            // Crear Pokémon simulados
            var equipoJugador1 = new List<IPokemon>
            {
                new Pokemon("Pikachu", 100, TipoPokemon.Electrico),
                new Pokemon("Charmander", 90, TipoPokemon.Fuego)
            };

            var equipoJugador2 = new List<IPokemon>
            {
                new Pokemon("Squirtle", 95, TipoPokemon.Agua),
                new Pokemon("Bulbasaur", 85, TipoPokemon.Planta)
            };

            // Asignar equipos directamente mediante reflection
            var obtenerEquipoActualMethod = catalogo?.GetType().GetMethod("SetEquipoActual");
            var obtenerEquipoActual2Method = catalogo?.GetType().GetMethod("SetEquipoActual2");

            obtenerEquipoActualMethod?.Invoke(catalogo, new object[] { equipoJugador1 });
            obtenerEquipoActual2Method?.Invoke(catalogo, new object[] { equipoJugador2 });

            // Inicializar batalla
            _batalla = new InicializacionBatallaContraJugador(_elegirPokemon);
        }

        [Test]
        public void TestInicializacionCorrecta()
        {
            // Asegurarse de que la batalla se inicializa correctamente
            Assert.NotNull(_batalla);
        }

        [Test]
        public void TestJugadoresInicializadosMedianteReflection()
        {
            // Usar reflection para acceder a los atributos privados jugador1 y jugador2
            var jugador1Field = typeof(InicializacionBatallaContraJugador).GetField("jugador1", BindingFlags.NonPublic | BindingFlags.Instance);
            var jugador2Field = typeof(InicializacionBatallaContraJugador).GetField("jugador2", BindingFlags.NonPublic | BindingFlags.Instance);

            var jugador1 = jugador1Field?.GetValue(_batalla);
            var jugador2 = jugador2Field?.GetValue(_batalla);

            Assert.NotNull(jugador1, "Jugador1 no debería ser nulo.");
            Assert.NotNull(jugador2, "Jugador2 no debería ser nulo.");
        }

        [Test]
        public void TestLogicaJuegoDisponible()
        {
            // Verificar que el método LogicaJuego existe y puede ser llamado
            var logicaJuegoMethod = typeof(InicializacionBatallaContraJugador).GetMethod("LogicaJuego", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(logicaJuegoMethod, "El método LogicaJuego debería estar definido.");
        }
    }
}
*/