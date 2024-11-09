namespace Program;

public class TablaEfectividad
{
    private static readonly Dictionary<(TipoPokemon, TipoPokemon), double> efectividades = new()
    {
        // Normal
        {(TipoPokemon.Normal, TipoPokemon.Roca), 0.5},
        {(TipoPokemon.Normal, TipoPokemon.Acero), 0.5},
        {(TipoPokemon.Normal, TipoPokemon.Fantasma), 0},
            
        // Fuego
        {(TipoPokemon.Fuego, TipoPokemon.Planta), 2.0},
        {(TipoPokemon.Fuego, TipoPokemon.Hielo), 2.0},
        {(TipoPokemon.Fuego, TipoPokemon.Bicho), 2.0},
        {(TipoPokemon.Fuego, TipoPokemon.Acero), 2.0},
        {(TipoPokemon.Fuego, TipoPokemon.Agua), 0.5},
        {(TipoPokemon.Fuego, TipoPokemon.Roca), 0.5},
        {(TipoPokemon.Fuego, TipoPokemon.Dragon), 0.5},
            
        // Agua
        {(TipoPokemon.Agua, TipoPokemon.Fuego), 2.0},
        {(TipoPokemon.Agua, TipoPokemon.Tierra), 2.0},
        {(TipoPokemon.Agua, TipoPokemon.Roca), 2.0},
        {(TipoPokemon.Agua, TipoPokemon.Planta), 0.5},
        {(TipoPokemon.Agua, TipoPokemon.Dragon), 0.5},
            
        
    };

    public static double ObtenerEfectividad(TipoPokemon tipoAtaque, TipoPokemon tipoDefensa)
    {
        if (efectividades.TryGetValue((tipoAtaque, tipoDefensa), out double efectividad))
        {
            return efectividad;
        }
        return 1.0; // Daño normal si no está especificado
    }
}