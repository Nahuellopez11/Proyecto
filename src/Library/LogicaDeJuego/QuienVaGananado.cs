namespace Program;

public class QuienVaGananado
{
    
    private Jugador jugador1;
    private Jugador jugador2;

    
    
    public static void Quiengana(List<IPokemon> listaPokemones1,List<IPokemon> listaPokemones2, List<IItem> itemsjugador1, List<IItem> itemsjugador2)
    {
        int sumatotal1 = 0;
        int sumatotal2 = 0;
        int estadointerno1 = 0;
        int estadointerno2 = 0;
        int contador1 = 0;
        int contador2 = 0;
        
        //contador de pokemones
        
        foreach (var pokemon1 in listaPokemones1)
        {
            if (pokemon1.Vida > 0)
            {
                
                sumatotal1 = sumatotal1 + 10;
            }
        }
        foreach (var pokemon2 in listaPokemones2)
        {
            if (pokemon2.Vida > 0)
            {
                sumatotal2 = sumatotal2 + 10;
            }
        }
        
        //contador de items
        
        
        foreach (var item1 in itemsjugador1)
        {
            if (item1.UsosRestantes > 0)
            {
                sumatotal1 = sumatotal1 + 6;
            }
        }
        foreach (var item2 in itemsjugador2)
        {
            if (item2.UsosRestantes > 0)
            {
                sumatotal2 = sumatotal2 + 6;
            }
        }
        //Estado pokemones
        
        
        foreach (var pokemon1 in listaPokemones1)
        {

            contador1 = contador1 + 1;
            if (pokemon1.Estado == "Normal")
            {
                estadointerno1 = estadointerno1 + 1;
            }
        }
        foreach (var pokemon2 in listaPokemones2)
        {
            contador2 = contador2 + 1;
            if (pokemon2.Vida > 0)
            {
                estadointerno2 = estadointerno2 + 1;
            }
        }

        if (contador1 == estadointerno1)
        {
            sumatotal1 = sumatotal1 + 10;
        }
        if (contador2 == estadointerno2)
        {
            sumatotal2 = sumatotal2 + 10;
        }
        
        
        //Resultado
        
        if (sumatotal1==sumatotal2)
        {
            Console.WriteLine("Van Empatados!");
        }else if (sumatotal1<sumatotal2)
        {
            
            Console.WriteLine("El jugador 1 va Ganando");
        }
        else
        {
            Console.WriteLine("El jugador 2 va Ganando");
        }
    }
}


