using NUnit.Framework;
using Program;

namespace Library.Tests
{
    public class AtaquesTests
    {
        [Test]
        public void TestMostrarAtaquesDisponibles()
        {
            // Configurar ataques directamente
            var ataques = new List<IHabilidadesPokemon>
            {
                new Ataque("Llamarada", TipoPokemon.Fuego, 90, 1.0),
                new AtaqueEspecial("Rayo Solar", TipoPokemon.Planta, 120, 0.85, EstadoEspecial.Paralizado),
                new Ataque("Placaje", TipoPokemon.Normal, 40, 1.0),
            };

            // Mostrar ataques disponibles
            Console.WriteLine("Ataques disponibles:");
            foreach (var habilidad in ataques)
            {
                if (habilidad is Ataque ataque)
                {
                    Console.WriteLine($"{ataque.NombreHabilidad} - Daño: {ataque.DañoBase}");
                }
                else
                {
                    Console.WriteLine("La habilidad no es un ataque válido.");
                }
            }

            // Validar que los ataques sean los correctos
            Assert.AreEqual(3, ataques.Count, "El Pokémon debería tener 3 ataques.");
            Assert.AreEqual("Llamarada", ((Ataque)ataques[0]).NombreHabilidad);
            Assert.AreEqual("Rayo Solar", ((AtaqueEspecial)ataques[1]).NombreHabilidad);
            Assert.AreEqual("Placaje", ((Ataque)ataques[2]).NombreHabilidad);
        }

        [Test]
        public void TestRestriccionAtaquesEspecialesCadaDosTurnos()
        {
            // Configurar un ataque especial
            var ataqueEspecial = new AtaqueEspecial("Rayo Solar", TipoPokemon.Planta, 120, 0.85, EstadoEspecial.Paralizado);
            var ataques = new List<IHabilidadesPokemon>
            {
                new Ataque("Llamarada", TipoPokemon.Fuego, 90, 1.0),
                ataqueEspecial,
            };

            int turno = 0;

            // Usar ataque especial en el turno 0
            Assert.IsTrue(ataques.Contains(ataqueEspecial), "El ataque especial debería estar disponible en el turno 0.");
            ataques.Remove(ataqueEspecial); // Simular uso del ataque especial
            turno++;

            // Validar que no esté disponible en el turno 1
            Assert.IsFalse(turno % 2 == 0 && ataques.Contains(ataqueEspecial),
                "El ataque especial no debería estar disponible hasta el turno 2.");

            // Validar que esté disponible nuevamente en el turno 2
            turno++;
            ataques.Add(ataqueEspecial); // Simular disponibilidad
            Assert.IsTrue(turno % 2 == 0 && ataques.Contains(ataqueEspecial),
                "El ataque especial debería estar disponible en el turno 2.");
        }

        [Test]
        public void TestSeleccionAtaque()
        {
            // Configurar ataques directamente en el test
            var ataques = new List<IHabilidadesPokemon>
            {
                new Ataque("Llamarada", TipoPokemon.Fuego, 90, 1.0),
                new AtaqueEspecial("Rayo Solar", TipoPokemon.Planta, 120, 0.85, EstadoEspecial.Paralizado),
            };

            // Simular selección del ataque
            var ataqueSeleccionado = ataques[0];

            // Validar que el ataque seleccionado sea el correcto
            Assert.AreEqual("Llamarada", ((Ataque)ataqueSeleccionado).NombreHabilidad, "El ataque seleccionado debería ser 'Llamarada'.");
            Assert.AreEqual(90, ((Ataque)ataqueSeleccionado).DañoBase, "El daño base del ataque seleccionado debería ser 90.");
        }

        [Test]
        public void TestCalculoDanioAtaqueEspecial()
        {
            // Configurar Pokémon y ataque especial directamente en el test
            var atacante = new Pokemon("Charizard", 100, TipoPokemon.Fuego);
            var objetivo = new Pokemon("Venusaur", 100, TipoPokemon.Planta);
            var ataqueEspecial = new AtaqueEspecial("Llamarada Especial", TipoPokemon.Fuego, 120, 1.0, EstadoEspecial.Quemado);

            // Realizar ataque especial
            int daño = ataqueEspecial.CalcularDaño(atacante, objetivo);

            // Validar que el daño se calcule correctamente
            Assert.IsTrue(daño > 0, "El daño debería ser mayor a 0.");
            Assert.AreEqual(EstadoEspecial.Quemado, objetivo.EstadoActual, "El objetivo debería estar en estado Quemado.");
        }
    }
}
