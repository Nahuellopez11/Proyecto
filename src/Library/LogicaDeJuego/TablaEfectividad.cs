namespace Program;
/// <summary>
/// Clase que gestiona la tabla de efectividad entre los diferentes tipos de Pokémon.
/// Permite calcular el multiplicador de daño basado en los tipos del atacante y el defensor.
/// </summary>
public class TablaEfectividad
{
    /// <summary>
    /// Diccionario estático que define las relaciones de efectividad entre los tipos de Pokémon.
    /// Las claves son pares (tipo de ataque, tipo de defensa) y los valores representan
    /// el multiplicador de daño.
    /// </summary>
    private static readonly Dictionary<(TipoPokemon, TipoPokemon), double> efectividades = new()
    {
        // Normal
        {(TipoPokemon.Normal, TipoPokemon.Fantasma), 0},
        {(TipoPokemon.Normal, TipoPokemon.Lucha), 0.1},

            
        // Fuego
        {(TipoPokemon.Fuego, TipoPokemon.Planta), 2.0},
        {(TipoPokemon.Fuego, TipoPokemon.Hielo), 2.0},
        {(TipoPokemon.Fuego, TipoPokemon.Bicho), 2.0},
        {(TipoPokemon.Fuego, TipoPokemon.Agua), 0.1},
        {(TipoPokemon.Fuego, TipoPokemon.Roca), 0.1},
        {(TipoPokemon.Fuego, TipoPokemon.Tierra), 0.1},
            
        // Agua
        {(TipoPokemon.Agua, TipoPokemon.Fuego), 2.0},
        {(TipoPokemon.Agua, TipoPokemon.Tierra), 2.0},
        {(TipoPokemon.Agua, TipoPokemon.Roca), 2.0},
        {(TipoPokemon.Agua, TipoPokemon.Planta), 0.1},
        {(TipoPokemon.Agua, TipoPokemon.Electrico), 0.1},
            
        //Bicho
        {(TipoPokemon.Bicho, TipoPokemon.Lucha), 2.0},
        {(TipoPokemon.Bicho, TipoPokemon.Psiquico), 2.0},
        {(TipoPokemon.Bicho, TipoPokemon.Planta), 0.5},
        {(TipoPokemon.Bicho, TipoPokemon.Veneno), 2.0},
        {(TipoPokemon.Bicho, TipoPokemon.Fuego), 0.1},
        {(TipoPokemon.Bicho, TipoPokemon.Roca), 0.1},
        {(TipoPokemon.Bicho, TipoPokemon.Volador), 0.1},
        
        //Dragon
        {(TipoPokemon.Dragon, TipoPokemon.Dragon), 2.0},
        
        //Electrico
        {(TipoPokemon.Electrico, TipoPokemon.Agua), 2.0},
        {(TipoPokemon.Electrico, TipoPokemon.Volador), 2.0},
        {(TipoPokemon.Electrico, TipoPokemon.Tierra), 0.1},
        
        //Fantasma
        {(TipoPokemon.Fantasma, TipoPokemon.Psiquico), 2.0},
        {(TipoPokemon.Fantasma, TipoPokemon.Fantasma),2.0},
        
        //Hielo
        {(TipoPokemon.Hielo, TipoPokemon.Dragon),2.0},
        {(TipoPokemon.Hielo, TipoPokemon.Planta),2.0},
        {(TipoPokemon.Hielo, TipoPokemon.Tierra),2.0},
        {(TipoPokemon.Hielo, TipoPokemon.Volador),2.0},
        {(TipoPokemon.Hielo, TipoPokemon.Fuego), 0.1},
        {(TipoPokemon.Hielo, TipoPokemon.Lucha), 0.1},
        {(TipoPokemon.Hielo, TipoPokemon.Roca), 0.1},
        
        //Lucha
        {(TipoPokemon.Lucha, TipoPokemon.Hielo),2.0},
        {(TipoPokemon.Lucha, TipoPokemon.Roca),2.0},
        {(TipoPokemon.Lucha, TipoPokemon.Veneno),2.0},
        {(TipoPokemon.Lucha, TipoPokemon.Psiquico), 0.1},
        {(TipoPokemon.Lucha, TipoPokemon.Volador), 0.1},
        {(TipoPokemon.Lucha, TipoPokemon.Bicho), 0.1},
        
        //Planta
        {(TipoPokemon.Planta, TipoPokemon.Agua),2.0},
        {(TipoPokemon.Planta, TipoPokemon.Roca),2.0},
        {(TipoPokemon.Planta, TipoPokemon.Tierra),2.0},
        {(TipoPokemon.Planta, TipoPokemon.Veneno),2.0},
        {(TipoPokemon.Planta, TipoPokemon.Bicho), 0.1},
        {(TipoPokemon.Planta, TipoPokemon.Fuego), 0.1},
        {(TipoPokemon.Planta, TipoPokemon.Hielo), 0.1},
        {(TipoPokemon.Planta, TipoPokemon.Volador), 0.1},

        
        //Psiquico
        {(TipoPokemon.Psiquico, TipoPokemon.Lucha),2.0},
        {(TipoPokemon.Psiquico, TipoPokemon.Veneno),2.0},
        {(TipoPokemon.Psiquico, TipoPokemon.Bicho), 0.1},
        {(TipoPokemon.Psiquico, TipoPokemon.Fantasma), 0.1},
        
        //Roca
        {(TipoPokemon.Roca, TipoPokemon.Bicho),2.0},
        {(TipoPokemon.Roca, TipoPokemon.Fuego),2.0},
        {(TipoPokemon.Roca, TipoPokemon.Hielo),2.0},
        {(TipoPokemon.Roca, TipoPokemon.Lucha),2.0},
        {(TipoPokemon.Roca, TipoPokemon.Tierra),2.0},
        {(TipoPokemon.Roca, TipoPokemon.Volador),2.0},
        {(TipoPokemon.Roca, TipoPokemon.Agua), 0.1},
        {(TipoPokemon.Roca, TipoPokemon.Planta), 0.1},
        
        //Tierra
        {(TipoPokemon.Tierra, TipoPokemon.Electrico),2.0},
        {(TipoPokemon.Tierra, TipoPokemon.Fuego),2.0},
        {(TipoPokemon.Tierra, TipoPokemon.Roca),2.0},
        {(TipoPokemon.Tierra, TipoPokemon.Veneno),2.0},
        {(TipoPokemon.Tierra, TipoPokemon.Planta), 0.1},
        {(TipoPokemon.Tierra, TipoPokemon.Agua), 0.1},
        {(TipoPokemon.Tierra, TipoPokemon.Hielo), 0.1},

        //Veneno
        {(TipoPokemon.Veneno, TipoPokemon.Bicho),2.0},
        {(TipoPokemon.Veneno, TipoPokemon.Planta),2.0},
        {(TipoPokemon.Veneno, TipoPokemon.Tierra),2.0},
        {(TipoPokemon.Veneno, TipoPokemon.Psiquico), 0.1},
        {(TipoPokemon.Veneno, TipoPokemon.Lucha), 0.1},
        
        //Volador
        {(TipoPokemon.Volador, TipoPokemon.Bicho),2.0},
        {(TipoPokemon.Volador, TipoPokemon.Lucha),2.0},
        {(TipoPokemon.Volador, TipoPokemon.Planta),2.0},
        {(TipoPokemon.Volador, TipoPokemon.Electrico), 0.1},
        {(TipoPokemon.Volador, TipoPokemon.Hielo), 0.1},
        {(TipoPokemon.Volador, TipoPokemon.Roca), 0.1},

    



    };
    /// <summary>
    /// Obtiene el multiplicador de efectividad entre un tipo de ataque y un tipo de defensa.
    /// </summary>
    /// <param name="tipoAtaque">El tipo de Pokémon que realiza el ataque.</param>
    /// <param name="tipoDefensa">El tipo de Pokémon que recibe el ataque.</param>
    /// <returns>
    /// El multiplicador de daño:
    /// - 2.0 para daño súper efectivo.
    /// - 0.1 para daño no muy efectivo.
    /// - 0 para daño sin efecto.
    /// - 1.0 para daño normal si la relación no está definida.
    /// </returns>
    public static double ObtenerEfectividad(TipoPokemon tipoAtaque, TipoPokemon tipoDefensa)
    {
        if (efectividades.TryGetValue((tipoAtaque, tipoDefensa), out double efectividad))
        {
            return efectividad;
        }
        return 1.0; // Daño normal si no está especificado
    }
}