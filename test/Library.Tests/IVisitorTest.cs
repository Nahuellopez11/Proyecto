using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Program;
namespace Library.Tests;

public class IVisitorTest
{
    private IVisitorPoke CreateVisitor()
    {
        return new SeleccionPokesVisitorPoke();
    }

    [Test]
    public void EquipoDebeIniciarComoLista()
    {
        var visitor = CreateVisitor();
        Assert.NotNull(visitor.Equipo);
    }

    [Test]
    public void FueElegidoDebeEmpezarComoFalso()
    {
        var visitor = CreateVisitor();
        Assert.False(visitor.FueElegido);
    }

    [Test]
    public void VisitorDebeAceptarIPokemon()
    {
        var visitor = CreateVisitor();
        var pokemon = new Pokemon("Test", 100, TipoPokemon.Fuego);

        visitor.Visit(pokemon);
    }
}