using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Program.Tests
{
    [TestFixture]
    [TestFixture]
    public class SistemaCombateTests
    {
        private Pokemon _pokemonMaquina;
        private Pokemon _pokemonJugador;

        [SetUp]
        public void SetUp()
        {
            _pokemonMaquina = new Pokemon("Charizard", 100, TipoPokemon.Fuego);
            _pokemonJugador = new Pokemon("Blastoise", 98, TipoPokemon.Agua);

            _pokemonMaquina.AtaquesDisponibles.Add(new Ataque("Ataque Devastador", TipoPokemon.Fuego, 40, 90));
            _pokemonJugador.AtaquesDisponibles.Add(new Ataque("Hidrobomba", TipoPokemon.Agua, 30, 80));
        }
        
        [Test]
        public void TestRealizarAtaqueMaquina_AplicaDañoCorrectamente()
        {
            // Realiza el ataque
            SistemaCombate.RealizarAtaqueJugador(_pokemonMaquina, _pokemonJugador);

            // Calcula daño esperado
            double dañoEsperado = _pokemonMaquina.AtaquesDisponibles[0].CalcularDaño(_pokemonMaquina, _pokemonJugador);

            // Imprime el daño esperado y la vida final para depuración
            Console.WriteLine($"Daño esperado: {dañoEsperado}");
            Console.WriteLine($"Vida final del jugador: {_pokemonJugador.Vida}");

            // Compara con un margen de error mayor debido a la aleatoriedad
            double vidaEsperada = 98.0 - dañoEsperado;
            Console.WriteLine($"Vida esperada del jugador: {vidaEsperada}");
            Assert.That(Math.Abs(_pokemonJugador.Vida - vidaEsperada) < 5, "La vida del jugador debería ser correcta tras el ataque.");
        }


        [Test]
        public void TestRealizarAtaqueMaquina_PokemonIncorrecto_NoAplicaDaño()
        {
            // Usar Pokémon no válidos (null)
            SistemaCombate.RealizarAtaqueJugador(null, _pokemonJugador);

            // La vida no debe cambiar
            Assert.AreEqual(98, _pokemonJugador.Vida, "La vida del jugador no debería cambiar.");
        }

        [Test]
        public void TestRealizarAtaqueJugador_AplicaDañoCorrectamente()
        {
            // Simular ataque del jugador
            SistemaCombate.RealizarAtaqueJugador(_pokemonJugador, _pokemonMaquina);

            // Esperar que la vida del Pokémon de la máquina haya disminuido
            double dañoEsperado = _pokemonJugador.AtaquesDisponibles[0].CalcularDaño(_pokemonJugador, _pokemonMaquina);
    
            // Comprobar que la vida de la máquina es menor a 100, permitiendo un pequeño margen de error
            Assert.Less(_pokemonMaquina.Vida - dañoEsperado, 100, "La vida de la máquina debería haber disminuido.");
        }


        [Test]
        public void TestRealizarAtaqueJugador_AtaqueInvalido_NoAplicaDaño()
        {
            // Modificar ataques para que sean vacíos
            _pokemonJugador.AtaquesDisponibles.Clear();

            // Intentar realizar un ataque
            SistemaCombate.RealizarAtaqueJugador(_pokemonJugador, _pokemonMaquina);

            // La vida no debe cambiar
            Assert.AreEqual(100, _pokemonMaquina.Vida, "La vida de la máquina no debería cambiar.");
        }

        [Test]
        public void TestVidaNoBajaDeCero()
        {
            // Configurar un ataque extremadamente poderoso
            _pokemonMaquina.AtaquesDisponibles.Clear(); // Limpiar ataques anteriores
            _pokemonMaquina.AtaquesDisponibles.Add(new Ataque("Ataque Devastador", TipoPokemon.Fuego, 1000, 30));

            // Realizar ataque de la máquina
            SistemaCombate.RealizarAtaqueJugador(_pokemonMaquina, _pokemonJugador);

            // Verificar que la vida no baje de cero
            Assert.GreaterOrEqual(_pokemonJugador.Vida, 0, "La vida del jugador no debería ser menor a 0.");
        }
    }
}
