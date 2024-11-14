namespace Program
{
    public static class ClonandoListaJugador1
    {
        public static List<IPokemones> ClonarJugador1()
        {
            // Obtener la lista de pokemones del jugador 1
            List<IPokemones> pokemonesJugador = ElegirPokemon.DevolverListajugador1();

            // Crear una copia superficial de la lista
            List<IPokemones> clonPokemonJugador = new List<IPokemones>(pokemonesJugador);

            return clonPokemonJugador;
        }
    }
}