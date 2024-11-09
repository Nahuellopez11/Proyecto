namespace Program;

public static class UtilizacionItemMaquina
{
    public static bool UsarItemMaquina(Maquina maquina, IPokemones pokemonActivoMaquina)
    {
        foreach (var item in maquina.Items)
        {
            if (item.Nombre == "Súper Poción" && item.UsosRestantes > 0)
            {
                item.Usar(pokemonActivoMaquina);
                Console.WriteLine("La máquina usó una Súper Poción.");
                return true;
            }
        }
        return false;
    }
}