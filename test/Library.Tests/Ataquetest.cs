/*
using NUnit.Framework;
using Program;

namespace Library.Tests
{
    public class AtaqueTests
    {
        private Pokemon atacanteUsuario;
        private Pokemon objetivoMaquina;
        private Ataque ataqueUsuario;

        [SetUp]
        public void Setup()
        {
            // Inicializar Pokémon de prueba
            atacanteUsuario = (Pokemon)ListaTestUsuario.ListaPokeTest[0]; // Charizard (Fuego)
            objetivoMaquina = (Pokemon)ListaTestMaquina.ListaPokeMaquina[0]; // Machamp (Lucha)

            // Crear un ataque de prueba
            ataqueUsuario = new Ataque("Llamarada", TipoPokemon.Fuego, 100, 0.9);
        }

        [Test]
        public void TestAtaqueEntreUsuarioYMaquina()
        {
            // Act: Calcular el daño del ataque
            int daño = ataqueUsuario.CalcularDaño(atacanteUsuario, objetivoMaquina);

            // Assert: Verificar que el daño sea mayor que 0
            Assert.IsTrue(daño > 0, "El ataque debería causar daño.");
            TestContext.WriteLine($"Daño causado por Charizard a Machamp: {daño}");
        }

        [Test]
        public void TestAtaqueFallaPorPrecision()
        {
            // Crear un ataque con baja precisión
            var ataqueFallido = new Ataque("Fuego Fatuo", TipoPokemon.Fuego, 50, 0.1);

            // Act: Calcular el daño (esperamos que falle debido a la baja precisión)
            int daño = ataqueFallido.CalcularDaño(atacanteUsuario, objetivoMaquina);

            // Assert: Verificar que el daño sea 0 si falla el ataque
            Assert.AreEqual(0, daño, "El ataque debería fallar debido a la baja precisión.");
        }
    }
}
*/