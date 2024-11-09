namespace Program;

public class Armar
{
    public IPokemones CrearPokemon(string nombre, int vida, TipoPokemon tipo, List<IHabilidadesPokemon> habilidadesPokemons)
    {
        return new Pokemon(nombre, vida, tipo);
    }
}


