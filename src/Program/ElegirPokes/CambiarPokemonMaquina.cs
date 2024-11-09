namespace Program;

// La maquina tiene su propia forma de cambiar pokemon
//separa la lógica de cambio de Pokémon entre el jugador y la máquina
// cumple con SRP al mantener responsabilidades específicas en clases distintas
public class CambiarPokemonMaquina
{
    public static IPokemones Cambiar(Maquina maquina, IPokemones pokemonActivoMaquina)
    {
        // Recorre la lista de Pokemones de la máquina
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