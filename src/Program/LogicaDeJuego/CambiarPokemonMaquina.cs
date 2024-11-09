namespace Program;

// La maquina tiene su propia forma de cambiar pokemon
public class CambiarPokemonMaquina
{
    public static IPokemones Cambiar(Maquina maquina, IPokemones pokemonActivoMaquina)
    {
        foreach (var pokemon in maquina.ListaDePokemones)
        {
            if (pokemon.Vida > 0) // busca los pokemones con vida en la lista de pokemones maquina
            {
                Console.WriteLine($"La máquina ha cambiado a {pokemon.Nombre}.");
                return pokemon; // retorna el primer pokemon que tenga vida
            }
        }
        
        return pokemonActivoMaquina;
    }
}