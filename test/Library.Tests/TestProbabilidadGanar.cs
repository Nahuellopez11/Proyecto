using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Program.Tests
{
    [TestFixture]
    public class TestProbabilidadGanar
    {
        private IJugador jugador;
        private IJugador jugador2;
        private Pokemon pikachu;
        private Pokemon charmander;
        private Pokemon bulbasaur;
        private Pokemon venusaur;
        private Pokemon gengar;
        private Pokemon pidgeot;
        private Pokemon pidgeot1;
        private Pokemon pidgeot2;
        private Pokemon pidgeot3;
        private Pokemon pidgeot4;
        private Pokemon pidgeot5;
        private Pokemon pidgeot6;

        [SetUp]
        public void ConfigurarEscenario()
        {
            pikachu = new Pokemon("Pikachu", 100, TipoPokemon.Electrico);
            charmander = new Pokemon("Charmander", 100, TipoPokemon.Fuego);
            bulbasaur = new Pokemon("Bulbasaur", 100, TipoPokemon.Agua);
            venusaur = new Pokemon("Venusaur", 100, TipoPokemon.Planta);
            gengar = new Pokemon("Gengar", 100, TipoPokemon.Fantasma);
            pidgeot = new Pokemon("Pidgeot", 100, TipoPokemon.Volador);
            pidgeot1 = new Pokemon("Pidgeot", 0, TipoPokemon.Volador); // este pokemon esta muerto
            pidgeot2 = new Pokemon("Pidgeot", 0, TipoPokemon.Volador); // este pokemon esta muerto
            pidgeot3 = new Pokemon("Pidgeot", 0, TipoPokemon.Volador); // este pokemon esta muerto
            pidgeot4 = new Pokemon("Pidgeot", 0, TipoPokemon.Volador); // este pokemon esta muerto
            pidgeot5 = new Pokemon("Pidgeot", 0, TipoPokemon.Volador); // este pokemon esta muerto
            pidgeot6 = new Pokemon("Pidgeot", 0, TipoPokemon.Volador); // este pokemon esta muerto
            pidgeot1.EstadoActual = EstadoEspecial.Dormido;
            pidgeot2.EstadoActual = EstadoEspecial.Dormido;
            pidgeot3.EstadoActual = EstadoEspecial.Dormido;
            pidgeot4.EstadoActual = EstadoEspecial.Dormido;
            pidgeot5.EstadoActual = EstadoEspecial.Dormido;
            pidgeot6.EstadoActual = EstadoEspecial.Dormido;
            

            List<IPokemon> listaDePokemones = new List<IPokemon> { pikachu, charmander, bulbasaur, venusaur, gengar, pidgeot };
            List<IPokemon> listaDePokemones2 = new List<IPokemon> { pidgeot1, pidgeot2, pidgeot3, pidgeot4, pidgeot5, pidgeot6};
            jugador = new Jugador(listaDePokemones, 0);
            jugador2 = new Jugador(listaDePokemones2, 0);
            jugador2.Items = new List<IItem>();

        }

        // Tests para CambiarPokemonJugador
        [Test]
        public void ProbabilidadGanarFuncionaBienEnJugador1()
        {
            int resultado = Utilities.CalcularProbabilidadGanar(jugador);
            Assert.That(resultado, Is.EqualTo(100), "No esta bien");
        }
        
        [Test]
        public void ProbabilidadGanarFuncionaBienEnJugador2()
        {
            int resultado2 = Utilities.CalcularProbabilidadGanar(jugador2);
            Assert.That(resultado2, Is.EqualTo(0), "No esta bien"); // el jugador 2 no tiene ni items, ni pokemones vivos y tiene estados
        }

    }

}
