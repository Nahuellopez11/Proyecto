using NUnit.Framework;
using Program;
using System.Collections.Generic;

namespace Library.Tests
{
    public class listamanipuladamaquina
    {
        [SetUp]
        public void Setup()
        {
            ListaTestMaquina.GenerarEquipoMaquina();
        }

        [Test]
        public void TestGenerarEquipoMaquina()
        {
            // Verificar que la lista tenga exactamente 6 Pokémon
            Assert.AreEqual(6, ListaTestMaquina.ListaPokeMaquina.Count);

            // Verificar que no haya Pokémon duplicados
            var nombres = ListaTestMaquina.ListaPokeMaquina.Select(p => p.Nombre).ToList();
            Assert.AreEqual(nombres.Count, nombres.Distinct().Count());

            TestContext.WriteLine("Prueba de generación del equipo de la máquina exitosa.");
        }
    }
}