using NUnit.Framework;
using Program;

namespace Library.Tests
{
    public class ElegirPokemonTests
    {
        private CatalogoPokemones catalogo;

        [SetUp]
        public void Setup()
        {
            catalogo = new CatalogoPokemones();

        }
        [Test]
        public void TestSeleccionarEquipoJugador1()
        {
            // Simular selección de equipo para el jugador 1
            Assert.IsTrue(catalogo.SeleccionarPokemon(1), "El primer Pokémon debería seleccionarse correctamente.");
            Assert.IsTrue(catalogo.SeleccionarPokemon(2), "El segundo Pokémon debería seleccionarse correctamente.");
            Assert.IsTrue(catalogo.SeleccionarPokemon(3), "El tercer Pokémon debería seleccionarse correctamente.");
            Assert.IsTrue(catalogo.SeleccionarPokemon(4), "El cuarto Pokémon debería seleccionarse correctamente.");
            Assert.IsTrue(catalogo.SeleccionarPokemon(5), "El quinto Pokémon debería seleccionarse correctamente.");
            Assert.IsTrue(catalogo.SeleccionarPokemon(6), "El sexto Pokémon debería seleccionarse correctamente.");

            // Obtener el equipo del jugador 1
            var equipoJugador1 = catalogo.ObtenerEquipoActual();

            // Validar que el equipo contiene exactamente 6 Pokémon
            Assert.AreEqual(6, equipoJugador1.Count, "El equipo del jugador 1 debería tener 6 Pokémon.");

            // Validar los nombres de los Pokémon seleccionados
            Assert.AreEqual("Charizard", equipoJugador1[0].Nombre, "El primer Pokémon debería ser Charizard.");
            Assert.AreEqual("Blastoise", equipoJugador1[1].Nombre, "El segundo Pokémon debería ser Blastoise.");
            Assert.AreEqual("Venusaur", equipoJugador1[2].Nombre, "El tercer Pokémon debería ser Venusaur.");
            Assert.AreEqual("Pikachu", equipoJugador1[3].Nombre, "El cuarto Pokémon debería ser Pikachu.");
            Assert.AreEqual("Gengar", equipoJugador1[4].Nombre, "El quinto Pokémon debería ser Gengar.");
            Assert.AreEqual("Machamp", equipoJugador1[5].Nombre, "El sexto Pokémon debería ser Machamp.");

            // Mostrar el equipo seleccionado en consola
            TestContext.WriteLine("Equipo final del jugador 1:");
            foreach (var pokemon in equipoJugador1)
            {
                TestContext.WriteLine($"{pokemon.Nombre} - Tipo: {pokemon.Tipo} - Vida: {pokemon.Vida}");
            }
        }


        [Test]
        public void TestSeleccionarEquipoJugador2()
        {
            // Simular selección de equipo para el jugador 2
            Assert.IsTrue(catalogo.SeleccionarPokemon2(1), "El primer Pokémon debería seleccionarse correctamente.");
            Assert.IsTrue(catalogo.SeleccionarPokemon2(2), "El segundo Pokémon debería seleccionarse correctamente.");
            Assert.IsTrue(catalogo.SeleccionarPokemon2(3), "El tercer Pokémon debería seleccionarse correctamente.");
            Assert.IsTrue(catalogo.SeleccionarPokemon2(4), "El cuarto Pokémon debería seleccionarse correctamente.");
            Assert.IsTrue(catalogo.SeleccionarPokemon2(5), "El quinto Pokémon debería seleccionarse correctamente.");
            Assert.IsTrue(catalogo.SeleccionarPokemon2(6), "El sexto Pokémon debería seleccionarse correctamente.");

            // Obtener el equipo del jugador 2
            var equipoJugador2 = catalogo.ObtenerEquipoActual2();

            // Validar que el equipo contiene exactamente 6 Pokémon
            Assert.AreEqual(6, equipoJugador2.Count, "El equipo del jugador 2 debería tener 6 Pokémon.");

            // Validar los nombres de los Pokémon seleccionados
            Assert.AreEqual("Charizard", equipoJugador2[0].Nombre, "El primer Pokémon debería ser Charizard.");
            Assert.AreEqual("Blastoise", equipoJugador2[1].Nombre, "El segundo Pokémon debería ser Blastoise.");
            Assert.AreEqual("Venusaur", equipoJugador2[2].Nombre, "El tercer Pokémon debería ser Venusaur.");
            Assert.AreEqual("Pikachu", equipoJugador2[3].Nombre, "El cuarto Pokémon debería ser Pikachu.");
            Assert.AreEqual("Gengar", equipoJugador2[4].Nombre, "El quinto Pokémon debería ser Gengar.");
            Assert.AreEqual("Machamp", equipoJugador2[5].Nombre, "El sexto Pokémon debería ser Machamp.");

            // Mostrar el equipo seleccionado en consola
            TestContext.WriteLine("Equipo final del jugador 2:");
            foreach (var pokemon in equipoJugador2)
            {
                TestContext.WriteLine($"{pokemon.Nombre} - Tipo: {pokemon.Tipo} - Vida: {pokemon.Vida}");
            }
        }
    }
}
