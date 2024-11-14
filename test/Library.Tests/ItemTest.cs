using NUnit.Framework;
using Program;

namespace Library.Tests
{
    public class ItemTests
    {
        private IPokemon pokemon;
        private Revivir revivir;
        private SuperPocion superPocion;

        [SetUp]
        public void Setup()
        {
            // Inicializar un Pokémon para las pruebas
            pokemon = new Pokemon("Pikachu", 100, TipoPokemon.Electrico);
            revivir = new Revivir();
            superPocion = new SuperPocion();
        }

        [Test]
        public void TestRevivir_UsarEnPokemonDebilitado()
        {
            // Debilitar al Pokémon
            pokemon.Vida = 0;

            // Act: Usar Revivir
            revivir.Usar(pokemon);

            // Assert: Verificar que el Pokémon revivió con 50 de vida
            Assert.AreEqual(50, pokemon.Vida);
            Assert.AreEqual(0, revivir.UsosRestantes);
        }

        [Test]
        public void TestRevivir_UsarEnPokemonConVida()
        {
            // Act: Usar Revivir en un Pokémon con vida
            revivir.Usar(pokemon);

            // Assert: Verificar que no se usó el ítem y no se cambió la vida
            Assert.AreEqual(100, pokemon.Vida);
            Assert.AreEqual(1, revivir.UsosRestantes);
        }

        [Test]
        public void TestSuperPocion_UsarConExito()
        {
            // Reducir la vida del Pokémon
            pokemon.Vida = 50;

            // Act: Usar SuperPocion
            superPocion.Usar(pokemon);

            // Assert: Verificar que la vida del Pokémon aumentó a 100
            Assert.AreEqual(100, pokemon.Vida);
            Assert.AreEqual(3, superPocion.UsosRestantes);
        }

        [Test]
        public void TestSuperPocion_NoSuperaVidaMaxima()
        {
            // Act: Usar SuperPocion en un Pokémon con vida completa
            superPocion.Usar(pokemon);

            // Assert: Verificar que la vida no supera el máximo
            Assert.AreEqual(100, pokemon.Vida);
            Assert.AreEqual(3, superPocion.UsosRestantes);
        }

        [Test]
        public void TestSuperPocion_SinUsosDisponibles()
        {
            // Usar SuperPocion 4 veces
            superPocion.Usar(pokemon);
            superPocion.Usar(pokemon);
            superPocion.Usar(pokemon);
            superPocion.Usar(pokemon);

            // Act: Intentar usar SuperPocion sin usos disponibles
            superPocion.Usar(pokemon);

            // Assert: Verificar que no se puede usar y que los usos restantes son 0
            Assert.AreEqual(0, superPocion.UsosRestantes);
        }
    }
}
