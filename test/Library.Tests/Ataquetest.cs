using NUnit.Framework;
using Program;

namespace Library.Tests
{
    public class AtaqueTests
    {
        private Pokemon atacanteJugador1; // Pokémon atacante del jugador 1 
        private Pokemon recibeJugador2; // Pokémon receptor del jugador 2
        private Ataque ataqueUsuario; // Ataque de prueba

        [SetUp]
        public void Setup()
        {
            // Inicializar Pokémon de prueba
            atacanteJugador1 = (Pokemon)ListaTestJugador1.ListaPokeTest[0]; // Charizard (Fuego)
            recibeJugador2 = (Pokemon)ListaTestUsuario2.ListaPokeTest2[1]; // Alakazam (Psíquico)

            // Crear un ataque con precisión alta para asegurar consistencia
            ataqueUsuario = new Ataque("Llamarada", TipoPokemon.Fuego, 100, 1.0); // 100% precisión
        }

        [Test]
        public void TestAtaqueExitoso()
        {
            // Act: Calcular el daño del ataque
            int daño = ataqueUsuario.CalcularDaño(atacanteJugador1, recibeJugador2);

            // Assert: Verificar que el daño sea mayor a 0
            Assert.IsTrue(daño > 0, $"El ataque debería causar daño. Daño calculado: {daño}");
            TestContext.WriteLine($"Daño causado por {atacanteJugador1.Nombre} a {recibeJugador2.Nombre}: {daño}");
        }

        [Test]
        public void TestAtaqueFallaPorPrecision()
        {
            // Crear un ataque con baja precisión
            var ataqueFallido = new Ataque("Fuego Fatuo", TipoPokemon.Fuego, 50, 0.0); // 0% precisión

            // Act: Calcular el daño del ataque
            int daño = ataqueFallido.CalcularDaño(atacanteJugador1, recibeJugador2);

            // Assert: Verificar que el daño sea 0 debido a la falla
            Assert.AreEqual(0, daño, "El ataque debería fallar debido a la baja precisión.");
            TestContext.WriteLine(" falló como se esperaba.");
        }

        [Test]
        public void TestAtaqueConEfectividad()
        {
            // Cambiar el receptor a un tipo que sea débil contra Fuego (por ejemplo, Planta)
            recibeJugador2 = (Pokemon)ListaTestUsuario2.ListaPokeTest2[5]; // Bulbasaur (Planta)

            // Act: Calcular el daño
            int daño = ataqueUsuario.CalcularDaño(atacanteJugador1, recibeJugador2);

            // Assert: Verificar que el daño sea mayor que el daño base debido a la efectividad
            Assert.IsTrue(daño > ataqueUsuario.DañoBase, $"El daño debería ser mayor debido a la efectividad. Daño calculado: {daño}");
            TestContext.WriteLine($"Daño causado por {atacanteJugador1.Nombre} a {recibeJugador2.Nombre} con efectividad: {daño}");
        }
    }
}
