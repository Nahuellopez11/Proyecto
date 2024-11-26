using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Program.Tests
{
    [TestFixture]
    public class PruebasDeElegirPokemon
    {
        private ElegirPokemon elegirPokemon;

        [SetUp]
        public void Configurar()
        {
            // Inicializar la clase ElegirPokemon antes de cada test
            //elegirPokemon = new ElegirPokemon();
        }

        [Test]
        public void SeleccionarEquipo_AñadePokemonCorrectamente()
        {
            // Simular la selección de 6 Pokémon válidos
            var entradas = new StringReader("1\n2\n3\n4\n5\n6\n");
            Console.SetIn(entradas);

            elegirPokemon.SeleccionarEquipo();

            var equipo = elegirPokemon.DevolverListajugador1();

            // Verificar que el equipo tiene exactamente 6 Pokémon
            Assert.AreEqual(6, equipo.Count);
            Assert.AreEqual("Charizard", equipo[0].Nombre); // Verificar el primer Pokémon seleccionado
            Assert.AreEqual("Machamp", equipo[5].Nombre);   // Verificar el sexto Pokémon seleccionado
        }

        [Test]
        public void SeleccionarEquipo_NoAñadePokemonInvalido()
        {
            // Simular entradas inválidas y válidas
            var entradas = new StringReader("99\n-1\n1\n2\n3\n4\n5\n6\n");
            Console.SetIn(entradas);

            elegirPokemon.SeleccionarEquipo();

            var equipo = elegirPokemon.DevolverListajugador1();

            // Verificar que el equipo tiene exactamente 6 Pokémon (válidos)
            Assert.AreEqual(6, equipo.Count);
        }

        [Test]
        public void SeleccionarEquipo2_AñadePokemonCorrectamente()
        {
            // Simular la selección de 6 Pokémon válidos para el segundo jugador
            var entradas = new StringReader("7\n8\n9\n10\n11\n12\n");
            Console.SetIn(entradas);

            elegirPokemon.SeleccionarEquipo2();

            var equipo = elegirPokemon.DevolverListajugador2();

            // Verificar que el equipo tiene exactamente 6 Pokémon
            Assert.AreEqual(6, equipo.Count);
            Assert.AreEqual("Pidgeot", equipo[0].Nombre); // Verificar el primer Pokémon seleccionado
            Assert.AreEqual("Alakazam", equipo[5].Nombre); // Verificar el sexto Pokémon seleccionado
        }

        [Test]
        public void DevolverListajugador1_DevuelveEquipoCorrecto()
        {
            // Simular la selección de Pokémon
            var entradas = new StringReader("1\n2\n3\n4\n5\n6\n");
            Console.SetIn(entradas);

            elegirPokemon.SeleccionarEquipo();

            var equipo = elegirPokemon.DevolverListajugador1();

            // Verificar que el equipo contiene los Pokémon seleccionados
            Assert.AreEqual(6, equipo.Count);
            Assert.AreEqual("Charizard", equipo[0].Nombre);
        }

        [Test]
        public void DevolverListajugador2_DevuelveEquipoCorrecto()
        {
            // Simular la selección de Pokémon para el segundo jugador
            var entradas = new StringReader("7\n8\n9\n10\n11\n12\n");
            Console.SetIn(entradas);

            elegirPokemon.SeleccionarEquipo2();

            var equipo = elegirPokemon.DevolverListajugador2();

            // Verificar que el equipo contiene los Pokémon seleccionados
            Assert.AreEqual(6, equipo.Count);
            Assert.AreEqual("Pidgeot", equipo[0].Nombre);
        }

        [Test]
        public void MostrarEquipoFinal_ImprimeCorrectamente()
        {
            // Simular la selección de Pokémon
            var entradas = new StringReader("1\n2\n3\n4\n5\n6\n");
            Console.SetIn(entradas);

            elegirPokemon.SeleccionarEquipo();

            // Redirigir la salida estándar para capturar el texto impreso
            var salida = new StringBuilder();
            Console.SetOut(new StringWriter(salida));

            elegirPokemon.MostrarEquipoFinal();

            // Verificar que los nombres de los Pokémon se imprimieron correctamente
            StringAssert.Contains("Charizard", salida.ToString());
            StringAssert.Contains("Blastoise", salida.ToString());
            StringAssert.Contains("Machamp", salida.ToString());
        }

        [Test]
        public void MostrarEquipoFinal2_ImprimeCorrectamente()
        {
            // Simular la selección de Pokémon para el segundo jugador
            var entradas = new StringReader("7\n8\n9\n10\n11\n12\n");
            Console.SetIn(entradas);

            elegirPokemon.SeleccionarEquipo2();

            // Redirigir la salida estándar para capturar el texto impreso
            var salida = new StringBuilder();
            Console.SetOut(new StringWriter(salida));

            elegirPokemon.MostrarEquipoFinal2();

            // Verificar que los nombres de los Pokémon se imprimieron correctamente
            StringAssert.Contains("Pidgeot", salida.ToString());
            StringAssert.Contains("Alakazam", salida.ToString());
        }
    }
}
