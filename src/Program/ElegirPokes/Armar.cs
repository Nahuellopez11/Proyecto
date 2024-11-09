namespace Program;

public class Armar
{
    //Funciona como una fábrica para crear instancias de Pokemon
    // El método CrearPokemon crea y retorna una instancia de IPokemones (Pokemon)
    // Este método sigue el principio de SRP, ya que se centra únicamente en la creación de un Pokémon.
    public IPokemones CrearPokemon(string nombre, int vida, TipoPokemon tipo, List<IHabilidadesPokemon> habilidadesPokemons)
    {
        return new Pokemon(nombre, vida, tipo);
    }
}


