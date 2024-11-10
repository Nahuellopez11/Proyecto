using NUnit.Framework;
using Program;
using System.Collections.Generic;

namespace Library.Tests
{
    public class CatalogoPokemonesTests
    {
        [SetUp]
        public void Setup()
        {
            // Limpiar el catálogo antes de cada prueba
            CatalogoPokemones.CatalogoPoke.Clear();
        }

        [Test]
        public void TestAgregarPokemonesDesdeListaTest()
        {
            // Arrange: Obtener la lista de prueba desde ListaTest
            var listaDePrueba = ListaTestUsuario.ListaPokeTest;

            // Act: Agregar cada Pokémon de la lista de prueba al catálogo
            foreach (var pokemon in listaDePrueba)
            {
                CatalogoPokemones.CatalogoPoke.Add(pokemon.Nombre.GetHashCode(), pokemon);
            }

            // Assert: Verificar que el catálogo tenga exactamente 6 Pokémon
            Assert.AreEqual(6, CatalogoPokemones.CatalogoPoke.Count);

            // Verificar que los Pokémon se agregaron correctamente usando sus nombres
            Assert.IsTrue(CatalogoPokemones.CatalogoPoke.ContainsKey(listaDePrueba[0].Nombre.GetHashCode()));
            Assert.IsTrue(CatalogoPokemones.CatalogoPoke.ContainsKey(listaDePrueba[5].Nombre.GetHashCode()));

            // Mensaje en el contexto de prueba
            TestContext.WriteLine("Prueba de agregar Pokémon desde ListaTest exitosa.");
        }

        [Test]
        public void TestSeleccionarPokemonDelCatalogo()
        {
            // Arrange: Agregar Pokémon al catálogo
            CatalogoPokemones.AgregarPokemonesCatalogo();

            // Act: Intentar seleccionar un Pokémon válido (ejemplo: índice 1 para Charizard)
            bool resultadoSeleccion = CatalogoPokemones.SeleccionarPokemon(1);

            // Assert: Verificar que la selección fue exitosa
            Assert.IsTrue(resultadoSeleccion);
            TestContext.WriteLine("Prueba de selección de Pokémon exitosa.");
        }
    }
}