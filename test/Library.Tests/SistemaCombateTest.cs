using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Program.Tests
{
    [TestFixture]
    public class SistemaCombateTests
    {
        private Pokemon _pokemonMaquina;
        private Pokemon _pokemonJugador;

        [SetUp]
        public void SetUp()
        {
            // Usar Pokémon de prueba desde ListaTestJugador1
            _pokemonMaquina = ListaTestJugador1.ListaPokeTest[0] as Pokemon; // Charizard
            _pokemonJugador = ListaTestJugador1.ListaPokeTest[1] as Pokemon; // Blastoise

            // Agregar ataques directamente a través de la lista
            _pokemonMaquina.AtaquesDisponibles.Add(new Ataque("Ataque Devastador", TipoPokemon.Fuego, 100, 90));
            _pokemonJugador.AtaquesDisponibles.Add(new Ataque("Hidrobomba", TipoPokemon.Agua, 60, 80));
        }

        [Test]
        public void TestRealizarAtaqueMaquina_AplicaDañoCorrectamente()
        {
            // Realizar ataque de la máquina al jugador
            SistemaCombate.RealizarAtaqueJugador(_pokemonMaquina, _pokemonJugador);

            // Verificar que se aplicó daño
            Assert.Less(_pokemonJugador.Vida, 98, "La vida del jugador debería haber disminuido.");
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

            // Verificar que se aplicó daño
            Assert.Less(_pokemonMaquina.Vida, 100, "La vida de la máquina debería haber disminuido.");
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
            _pokemonMaquina.AtaquesDisponibles.Add(new Ataque("Ataque Devastador", TipoPokemon.Fuego,1000 , 30));

            // Realizar ataque de la máquina
            SistemaCombate.RealizarAtaqueJugador(_pokemonMaquina, _pokemonJugador);

            // Verificar que la vida no baje de cero
            Assert.AreEqual(0, _pokemonJugador.Vida, "La vida del jugador no debería ser menor a 0.");
        }
    }
}
