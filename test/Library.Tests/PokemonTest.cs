using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Program.Tests
{
    [TestFixture]
    public class PokemonTest
    {
        private Jugador jugador;
        private Pokemon pikachu;
        private Pokemon charmander;

        [SetUp]
        public void ConfigurarEscenario()
        {
            pikachu = new Pokemon("Pikachu", 100, TipoPokemon.Electrico);
            charmander = new Pokemon("Charmander", 0, TipoPokemon.Fuego);

            var listaDePokemones = new List<IPokemon> { pikachu, charmander };
            jugador = new Jugador(listaDePokemones, 0);
        }

        // Tests para CambiarPokemonJugador
        [Test]
        public void CambiarPokemonDevuelveElMismoPokemonSiSeleccionEsInvalida()
        {
            System.Console.SetIn(new StringReader("-1\n"));
            var resultado = Utilities.CambiarPokemonJugador(jugador, pikachu);
            Assert.AreEqual(pikachu, resultado);
        }

        [Test]
        public void CambiarPokemonDevuelveElMismoPokemonSiSeleccionEsUnPokemonDebilitado()
        {
            System.Console.SetIn(new StringReader("2\n"));
            var resultado = Utilities.CambiarPokemonJugador(jugador, pikachu);
            Assert.AreEqual(pikachu, resultado);
        }

        [Test]
        public void CambiarPokemonDevuelveOtroPokemonSiSeleccionEsValidaYConVida()
        {
            System.Console.SetIn(new StringReader("1\n"));
            var resultado = Utilities.CambiarPokemonJugador(jugador, charmander);
            Assert.AreEqual(pikachu, resultado);
        }

        // Tests para UsarItem
        [Test]
        public void UsarItemCambiaTurnoDespuesDeUsarUnItemExitosamente()
        {
            jugador.Items = new List<IItem> { new SuperPocion() };
            System.Console.SetIn(new StringReader("1\n1\n"));
            var turno = Utilities.UsarItem(jugador, 0);
            Assert.AreEqual(1, turno);
            Assert.AreEqual(100, pikachu.Vida);
        }

        [Test]
        public void UsarItemDevuelveTurnoSinCambioSiSeleccionEsInvalida()
        {
            System.Console.SetIn(new StringReader("0\n"));
            var turno = Utilities.UsarItem(jugador, 0);
            Assert.AreEqual(0, turno);
        }

        [Test]
        public void UsarItemNoHaceNadaSiNoHayItems()
        {
            jugador.Items.Clear();
            System.Console.SetIn(new StringReader("1\n"));
            var turno = Utilities.UsarItem(jugador, 0);
            Assert.AreEqual(0, turno);
        }

        [Test]
        public void VerificarFinDeBatallaDevuelveFalseSiTodosLosPokemonesTienenVida()
        {
            pikachu.Vida = 100;
            charmander.Vida = 50;
            var resultado = Utilities.VerificarFinBatalla(jugador.ListaDePokemones);
            Assert.IsFalse(resultado);
        }

        [Test]
        public void VerificarFinDeBatallaDevuelveTrueSiListaDePokemonesEstaVacia()
        {
            jugador.ListaDePokemones.Clear();
            var resultado = Utilities.VerificarFinBatalla(jugador.ListaDePokemones);
            Assert.IsTrue(resultado);
        }
        [Test]
        public void AplicarEfectoEstado_AplicaEstadoNormal()
        {
            pikachu.AplicarEfectoEstado(EstadoEspecial.Normal);
            Assert.AreEqual(EstadoEspecial.Normal, pikachu.EstadoActual);
        }

        [Test]
        public void PuedeAtacar_NoPuedeCuandoEstaDormido()
        {
            pikachu.AplicarEfectoEstado(EstadoEspecial.Dormido);
            Assert.IsFalse(pikachu.PuedeAtacar());
        }

        [Test]
        public void PuedeAtacar_TieneProbabilidadCuandoEstaParalizado()
        {
            pikachu.AplicarEfectoEstado(EstadoEspecial.Paralizado);
            Assert.DoesNotThrow(() => pikachu.PuedeAtacar());
        }

        [Test]
        public void AplicarEfectosFinTurno_ReduceVidaPorEnvenenamiento()
        {
            pikachu.AplicarEfectoEstado(EstadoEspecial.Envenenado);
            pikachu.AplicarEfectosFinTurno();
            Assert.AreEqual(95, pikachu.Vida); // 5% de daño por envenenamiento
        }

        [Test]
        public void AplicarEfectosFinTurno_ReduceVidaPorQuemadura()
        {
            pikachu.AplicarEfectoEstado(EstadoEspecial.Quemado);
            pikachu.AplicarEfectosFinTurno();
            Assert.AreEqual(90, pikachu.Vida); // 10% de daño por quemadura
        }
    }

    [TestFixture]
    public class PokemonTests
    {
        private Pokemon pikachu;
        private Pokemon charmander;
        private Ataque ataqueFuego;

        [SetUp]
        public void Configurar()
        {
            pikachu = new Pokemon("Pikachu", 100, TipoPokemon.Electrico);
            charmander = new Pokemon("Charmander", 100, TipoPokemon.Fuego);
            ataqueFuego = new Ataque("Llamarada", TipoPokemon.Fuego, 50, 85);
        }

        [Test]
        public void RecibirDaño_ReduceVidaCorrectamente()
        {
            pikachu.RecibirDaño(30);
            Assert.AreEqual(70, pikachu.Vida);
        }

        [Test]
        public void CurarEstados_RestableceEstadoNormal()
        {
            pikachu.AplicarEfectoEstado(EstadoEspecial.Dormido);
            pikachu.CurarEstados();
            Assert.AreEqual(EstadoEspecial.Normal, pikachu.EstadoActual);
        }

        [Test]
        public void AprenderAtaque_NoAprendeMasDeCuatro()
        {
            pikachu.AprenderAtaque(new Ataque("Impactrueno", TipoPokemon.Electrico, 40, 90));
            pikachu.AprenderAtaque(new Ataque("Rayo", TipoPokemon.Electrico, 50, 85));
            pikachu.AprenderAtaque(new Ataque("Trueno", TipoPokemon.Electrico, 90, 80));
            pikachu.AprenderAtaque(new Ataque("Voltio Cruel", TipoPokemon.Electrico, 130, 75));
            pikachu.AprenderAtaque(new Ataque("Placaje", TipoPokemon.Normal, 35, 100));
            Assert.AreEqual(4, pikachu.AtaquesDisponibles.Count);
        }

        [Test]
        public void RealizarAtaque_ReduceVidaDelObjetivo()
        {
            pikachu.AtaquesDisponibles.Add(ataqueFuego);
            pikachu.RealizarAtaque(0, charmander);
            Assert.AreEqual(95, charmander.Vida); 
        }
        [Test]
        public void AplicarEfectoEstado_NoSobrescribeEstadoExistente()
        {
            // Aplicar un estado
            pikachu.AplicarEfectoEstado(EstadoEspecial.Dormido);

            // Intentar aplicar un nuevo estado
            pikachu.AplicarEfectoEstado(EstadoEspecial.Paralizado);

            // Verificar que el estado no cambia
            Assert.AreEqual(EstadoEspecial.Dormido, pikachu.EstadoActual);
        }

        [Test]
        public void PuedeAtacar_DevuelveFalseSiDormidoYSeDespierta()
        {
            // Aplicar estado dormido
            pikachu.AplicarEfectoEstado(EstadoEspecial.Dormido);

            // Simular turnos hasta que se despierte
            while (pikachu.PuedeAtacar() == false)
            {
                // Pokémon sigue dormido
            }

            // Verificar que se despierta y puede atacar
            Assert.AreEqual(EstadoEspecial.Normal, pikachu.EstadoActual);
            Assert.IsTrue(pikachu.PuedeAtacar());
        }

        [Test]
        public void AplicarEfectosFinTurno_ReduceVidaPorEnvenenamiento()
        {
            // Aplicar estado de envenenamiento
            pikachu.AplicarEfectoEstado(EstadoEspecial.Envenenado);

            // Aplicar efectos de fin de turno
            pikachu.AplicarEfectosFinTurno();

            // Verificar que la vida se reduce un 5%
            Assert.AreEqual(95, pikachu.Vida); // 100 - 5%
        }

        [Test]
        public void AplicarEfectosFinTurno_ReduceVidaPorQuemadura()
        {
            // Aplicar estado de quemadura
            pikachu.AplicarEfectoEstado(EstadoEspecial.Quemado);

            // Aplicar efectos de fin de turno
            pikachu.AplicarEfectosFinTurno();

            // Verificar que la vida se reduce un 10%
            Assert.AreEqual(90, pikachu.Vida); // 100 - 10%
        }

        [Test]
        public void AplicarEfectosFinTurno_NoHaceNadaSiEstadoNormal()
        {
            // Asegurar que el estado es normal
            pikachu.CurarEstados();

            // Aplicar efectos de fin de turno
            pikachu.AplicarEfectosFinTurno();

            // Verificar que la vida no cambia
            Assert.AreEqual(100, pikachu.Vida);
        }

        [Test]
        public void Equals_DevuelveTrueSiPokemonesIguales()
        {
            var otroPikachu = new Pokemon("Pikachu", 100, TipoPokemon.Electrico);

            // Verificar que Equals devuelve true
            Assert.IsTrue(pikachu.Equals(otroPikachu));
        }

        [Test]
        public void Equals_DevuelveFalseSiPokemonesDiferentes()
        {
            var otroPokemon = new Pokemon("Charmander", 100, TipoPokemon.Fuego);

            // Verificar que Equals devuelve false
            Assert.IsFalse(pikachu.Equals(otroPokemon));
        }

        [Test]
        public void GetHashCode_IgualParaPokemonesIguales()
        {
            var otroPikachu = new Pokemon("Pikachu", 100, TipoPokemon.Electrico);

            // Verificar que el hash es igual
            Assert.AreEqual(pikachu.GetHashCode(), otroPikachu.GetHashCode());
        }

        [Test]
        public void GetHashCode_DiferenteParaPokemonesDiferentes()
        {
            var otroPokemon = new Pokemon("Charmander", 100, TipoPokemon.Fuego);

            // Verificar que el hash es diferente
            Assert.AreNotEqual(pikachu.GetHashCode(), otroPokemon.GetHashCode());
        }
        [Test]
        public void Propiedades_SonAsignadasCorrectamente()
        {
            // Verificar que las propiedades se asignaron correctamente
            Assert.AreEqual("Pikachu", pikachu.Nombre);
            Assert.AreEqual(TipoPokemon.Electrico, pikachu.Tipo);
            Assert.AreEqual(100, pikachu.Vida);
        }

        [Test]
        public void Vida_SePuedeModificar()
        {
            // Reducir la vida
            pikachu.Vida -= 50;
            Assert.AreEqual(50, pikachu.Vida);

            // Aumentar la vida
            pikachu.Vida += 20;
            Assert.AreEqual(70, pikachu.Vida);
        }
        

// Clase auxiliar para probar el visitor
        public class TestVisitor : IVisitorPoke
        {
            public List<IPokemon> Equipo { get; private set; } = new List<IPokemon>();
            public bool FueElegido { get; private set; } = false;

            public void VisitPokemon(IPokemon pokemon)
            {
                // Simular lógica de visitante
                FueElegido = true;
                Equipo.Add(pokemon);
            }
        }
    }

}
