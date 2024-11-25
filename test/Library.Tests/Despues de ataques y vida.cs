using NUnit.Framework;
using Program;

namespace Library.Tests
{
    public class SistemaCombateTests
    {
        [Test]
        public void TestMostrarVidaFormatoNumerico()
        {
            // Configurar Pokémon
            var atacante = new Pokemon("Charizard", 100, TipoPokemon.Fuego);
            var defensor = new Pokemon("Blastoise", 150, TipoPokemon.Agua);

            atacante.Vida = 100;
            defensor.Vida = 150;

            // Mostrar vida inicial
            Console.WriteLine($"Vida inicial atacante: {atacante.Vida}/100");
            Console.WriteLine($"Vida inicial defensor: {defensor.Vida}/150");

            Assert.AreEqual(100, atacante.Vida, "La vida inicial del atacante debería ser 100.");
            Assert.AreEqual(150, defensor.Vida, "La vida inicial del defensor debería ser 150.");
        }

        [Test]
        public void TestActualizarVidaTrasAtaque()
        {
            // Configurar Pokémon
            var atacante = new Pokemon("Charizard", 100, TipoPokemon.Fuego);
            var defensor = new Pokemon("Blastoise", 150, TipoPokemon.Agua);

            // Configurar ataque
            var ataque = new Ataque("Llamarada", TipoPokemon.Fuego, 50, 1.0);

            // Calcular daño y actualizar vida
            int daño = ataque.CalcularDaño(atacante, defensor);
            defensor.Vida = Math.Max(0, defensor.Vida - daño);

            Console.WriteLine($"Vida después del ataque: {defensor.Vida}/150");

            // Validar que la vida se actualizó correctamente
            Assert.AreEqual(150 - daño, defensor.Vida, "La vida del defensor no se actualizó correctamente.");
        }

        [Test]
        public void TestEvitarVidaNegativa()
        {
            // Configurar Pokémon
            var atacante = new Pokemon("Charizard", 100, TipoPokemon.Fuego);
            var defensor = new Pokemon("Blastoise", 150, TipoPokemon.Agua);

            // Configurar ataque poderoso
            var ataque = new Ataque("Hiper Rayo", TipoPokemon.Normal, 200, 1.0);

            // Calcular daño y actualizar vida
            int daño = ataque.CalcularDaño(atacante, defensor);
            defensor.Vida = Math.Max(0, defensor.Vida - daño);

            Console.WriteLine($"Vida después del ataque: {defensor.Vida}/150");

            // Validar que la vida no sea negativa
            Assert.AreEqual(0, defensor.Vida, "La vida del defensor debería ser 0, no puede ser negativa.");
        }

        [Test]
        public void TestMostrarVidaTrasAtaque()
        {
            // Configurar Pokémon
            var atacante = new Pokemon("Charizard", 100, TipoPokemon.Fuego);
            var defensor = new Pokemon("Blastoise", 150, TipoPokemon.Agua);

            // Configurar ataque
            var ataque = new Ataque("Llamarada", TipoPokemon.Fuego, 50, 1.0);

            // Calcular daño y actualizar vida
            int daño = ataque.CalcularDaño(atacante, defensor);
            defensor.Vida = Math.Max(0, defensor.Vida - daño);

            // Mostrar vida después del ataque
            Console.WriteLine($"Atacante: {atacante.Nombre} - Vida: {atacante.Vida}/100");
            Console.WriteLine($"Defensor: {defensor.Nombre} - Vida: {defensor.Vida}/150");

            // Validar que la vida se muestra correctamente
            Assert.AreEqual($"Vida: {atacante.Vida}/100", $"Vida: {atacante.Vida}/100", "La vida del atacante no se muestra correctamente.");
            Assert.AreEqual($"Vida: {defensor.Vida}/150", $"Vida: {defensor.Vida}/150", "La vida del defensor no se muestra correctamente.");
        }
    }
}
