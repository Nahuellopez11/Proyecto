using System.Diagnostics;
using Program;

namespace Library.Tests;

public class TestDefensaProbabilidadDeGanar
{
    public Jugador jugador1;
    private Revivir revivir;
    private SuperPocion superPocion;
    private InicializacionBatallaContraJugador nuevaBatallaContraJugador;
    private ElegirPokemon _elegirPokemon;
    
    [SetUp]
    public void SetUp()
    {
        jugador1 = new Jugador(ListaTestJugador1.ListaPokeTest);
        _elegirPokemon = new ElegirPokemon(CatalogoPokemones.CrearPokemon());
        revivir = new Revivir();
        superPocion = new SuperPocion();
        nuevaBatallaContraJugador = new InicializacionBatallaContraJugador(_elegirPokemon);

    }

    [Test]
    public void CalcularPromedioJ1()
    {
        ListaTestJugador1.ListaPokeTest[0].FueAfectado = true;
        revivir.Usar(jugador1.ListaDePokemones[0]);
        int puntos1 = nuevaBatallaContraJugador.CalcularProbabilidadGanarJ1(jugador1);
        
        Assert.That(60,Is.EqualTo(puntos1));
        
    }

   
}
//el test no funciona pero el codigo si