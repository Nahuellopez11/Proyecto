
namespace Program;

public class CalcularVentaja

{

    public int PuntajeInicial = 100;
    public int NumeroPokemones = 60;
    public int ItemsDisponibles = 30;
    public int ConEstado = 10;
    public int ContadorPokemones1 = 0;
    public int ContadorPokemones2 = 0;
    public int ItemsTotales1 = 5;
    public int ItemsTotales2 = 5;
    public bool FueEnvenenado1 = false;
    public bool FueEnvenenado2 = false;

    public void IterarEquipo1()
    {
        public void MostrarEquipoFinal()
        {
            Console.WriteLine("\nTu equipo final es:");
            var equipo = catalogo.ObtenerEquipoActual();
            Console.WriteLine($"Tienes {equipo.Count} Pokémon en tu equipo.");

            for (int i = 0; i < equipo.Count; i++)
            {
                if ({
                    equipo[i].Vida
                }>0 || ContadorPokemones1 = ++)
                Console.WriteLine($"{i + 1}. {equipo[i].Nombre}  - Vida: {equipo[i].Vida}");
            }
        }
    }

    public void IterarEquipo2()
    {
        public void MostrarEquipoFinal2()
        {
            Console.WriteLine("\nTu equipo final es:");
            var equipo = catalogo.ObtenerEquipoActual();
            Console.WriteLine($"Tienes {equipo.Count} Pokémon en tu equipo.");

            for (int i = 0; i < equipo.Count; i++)
            {
                if ({
                    equipo[i].Vida
                }>0 || ContadorPokemones2 = ++)
                Console.WriteLine($"{i + 1}. {equipo[i].Nombre}  - Vida: {equipo[i].Vida}");
            }
        }
    }

    public CalcularJ1();

    resultado1 = calcularpokemones1*10 + Itemstotales1*6  

    public CalcularJ2();

    resultado2 = calcularpokemones2*10 + Itemstotales2*6  

    public int ContadorPokemones1*

}




// Como tuve problemas con el codeo por lo menos intentare dejar una guia de lo
// que hubiera hecho:

//Metodos a realizar:

// Calcular Pokemones vivos:
// Accediendo a los metodos que se encuentran en la clase ElegirPokemon.cs (MostrarEquipoFinal2() y MostrarEquipoFinal())
// realizaria una ligera modificacion solamente accediendo al nombre y a la vida dentro de la iteracion, si la vida es mayor a 0
// se agrega uno a ContadorPokemones1 y ContadorPokemones2, dependiendo de que jugador este observando.
// Esto dejara en cada contador la cantidad de pokemones vivos disponibles

// Calcular items utilizados
// Buscaria el atributo de cada uno de los items (Revivir.cs y SuperPocion.cs) USOSRESTANTES y restaria la sumatoria de ambas en 
// ItemsTotales1 y ItemsTotales2 segun corresponda

// Ver si esta afectado
// Inmediatamente se ejecutara un efecto especial por parte de el jugador, haria saltar FueEnvenenado1 o FueEnvenenado2 segun corresponda
// a verdadero

// Para implementar esto colocaria en el menu una ultima opcion que sea CALCULAR (que llame a la funcion 'CompararJugadores') y me devuelva que jugador es mas probable que gane mediante
// un string en el siguiente formato "El jugador X es el que tiene mayor probabilidad de ganar"

// Calcular Jugador 1

// ContadorPokemones1*10 + ItemsTotales1*6 + 10 si es falso o 0 si es verdadero = Porcentaje total

// Calcular Jugador 2

// ContadorPokemones2*10 + ItemsTotales2*6 + 10 si es falso o 0 si es verdadero = Porcentaje total

// Comparar jugadores y devolver resultado

// Compara Jugador 1 vs Jugador 2 y devuelve un Console.Writline ("El jugador X es el que tiene mayor probabilidad de ganar")


