using System;
using System.Collections.Generic;
namespace Program;
/*

public class Juego
{
    private Jugador jugador1;
    private Maquina maquina; // Cambiado de jugador2 a maquina
    private bool esTurnoJugador1;

    public Juego(Jugador jugador1, Maquina maquina)
    {
        this.jugador1 = jugador1;
        this.maquina = maquina;
        this.esTurnoJugador1 = true; 
    }

    public void IniciarJuego()
    {
        while (true)
        {
            MostrarEstado();
            MostrarAcciones();

            int eleccion = ObtenerEleccionDelJugador();
            if (!EjecutarAccion(eleccion))
            {
                Console.WriteLine("Opción inválida, intenta de nuevo.");
            }

            // Comprobar si el juego debe terminar
            if (!jugador1.pokemonActivo.EstaVivo || !maquina.pokemonActivo.EstaVivo)
            {
                MostrarResultado();
                break; // Termina el juego
            }

            CambiarTurno(); // Cambia el turno al siguiente jugador
        }
    }

    private void MostrarAcciones()
    {
        Console.WriteLine("Acciones disponibles:");
        Console.WriteLine("1. Atacar Pokémon");
        Console.WriteLine("2. Cambiar Pokémon");
        Console.WriteLine("3. Mostrar Vida");
        Console.WriteLine("4. Salir");
    }

    private void MostrarEstado()
    {
        Console.WriteLine($"Estado del juego:");
        Console.WriteLine($"Jugador: {jugador1.pokemonActivo.Nombre} - Vida: {jugador1.pokemonActivo.Vida}");
        Console.WriteLine($"Máquina: {maquina.pokemonActivo.Nombre} - Vida: {maquina.pokemonActivo.Vida}");
    }

    private int ObtenerEleccionDelJugador()
    {
        Console.Write("Selecciona una acción (1-4): ");
        return int.TryParse(Console.ReadLine(), out int eleccion) ? eleccion : -1; // Maneja entradas inválidas
    }
    
    private bool EjecutarAccion(int eleccion)
    {
        var acciones = new Dictionary<int, Action>
        {
            { 1, AtacarJugador }, // Atacar a la máquina
            { 2, CambiarPokemonJugador },
            { 3, MostrarVidaJugador },
            { 4, Salir }
        };

        if (acciones.ContainsKey(eleccion))
        {
            acciones[eleccion].Invoke();
            return true; 
        }

        return false; 
    }

    private void AtacarJugador()
    {
        var atacante = esTurnoJugador1 ? jugador1.pokemonActivo : maquina.pokemonActivo;
        var defensor = esTurnoJugador1 ? maquina.pokemonActivo : jugador1.pokemonActivo;

        Console.WriteLine($"{atacante.Nombre} va a atacar.");
        var habilidadUsada = atacante.Habilidades[0]; // Ejemplo: usando la primera habilidad disponible
        atacante.Atacar(defensor, habilidadUsada);

        if (!defensor.EstaVivo)
        {
            Console.WriteLine($"{defensor.Nombre} ha sido derrotado.");
        }
    }

    private void CambiarPokemonJugador()
    {
        Console.WriteLine($"elige un Pokémon para cambiar:");


        foreach (var pokemon in jugador1.Pokemones)
        {
            Console.WriteLine($"Número: {pokemon.Key} - Nombre: {pokemon.Value.Nombre} (Vida: {pokemon.Value.Vida})");
        }

  
        Console.Write("Ingresa el número del Pokémon que deseas elegir: ");
        if (int.TryParse(Console.ReadLine(), out int numeroPokemon))
        {
            jugador1.CambiarPokemonActivo(numeroPokemon); 
        }
        else
        {
            Console.WriteLine("Número inválido, intenta de nuevo.");
        }

    }

    private void MostrarVidaJugador()
    {
        Console.WriteLine($"Vida actual de {jugador1.pokemonActivo.Nombre}: {jugador1.pokemonActivo.Vida}");
        Console.WriteLine($"Vida actual de {maquina.pokemonActivo.Nombre}: {maquina.pokemonActivo.Vida}");
    }
    
    private void MostrarResultado()
    {
        if (!jugador1.pokemonActivo.EstaVivo)
        {
            Console.WriteLine("¡La máquina ha ganado!");
        }
        else if (!maquina.pokemonActivo.EstaVivo)
        {
            Console.WriteLine("¡Jugador ha ganado!");
        }
    }
    private void Salir()
    {
        Console.WriteLine("Saliendo del juego...");
        Environment.Exit(0); // Finaliza la aplicación
    }
    
    private void CambiarTurno()
    {
        esTurnoJugador1 = !esTurnoJugador1;
    }
}
*/