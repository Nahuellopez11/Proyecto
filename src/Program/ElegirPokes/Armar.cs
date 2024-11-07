namespace Program;

public class Armar
{
    public IPokemones CrearPokemon(string nombre, int vida, string tipo)
    {
        return new Pokemon1(nombre, vida, tipo);
    }


}