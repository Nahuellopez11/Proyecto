namespace Program;
/// <summary>
/// Clase estática que contiene métodos utilitarios para diferentes acciones
/// dentro del sistema de combate Pokémon.
/// </summary>
public static class Utilities
{
    /// <summary>
    /// Permite al jugador cambiar su Pokémon activo por otro de su equipo.
    /// </summary>
    /// <param name="jugador">El jugador que realiza el cambio.</param>
    /// <param name="pokemonActivo">El Pokémon actualmente activo.</param>
    /// <returns>El nuevo Pokémon activo seleccionado por el jugador, o el mismo si no realiza un cambio.</returns>

    public static IPokemon CambiarPokemonJugador(Jugador jugador, IPokemon pokemonActivo)
    {   
        bool cambioExitoso = false;
        IPokemon nuevoPokemon = pokemonActivo;
        // Ciclo que continúa hasta que el jugador seleccione un Pokémon válido o decida no realizar el cambio.
        while (!cambioExitoso)
        {
            Console.WriteLine("Selecciona un Pokémon para cambiar:");
            for (int i = 0; i < jugador.ListaDePokemones.Count; i++)
            {
                var pokemon = jugador.ListaDePokemones[i];
                Console.WriteLine($"{i + 1}. {pokemon.Nombre} - Vida: {pokemon.Vida}");
            }

            Console.WriteLine("0. Volver al menú anterior");
            int seleccion = Convert.ToInt32(Console.ReadLine()) - 1;

            if (seleccion == -1) // si se selecciona 0, vuelve al menú principal sin cambiar de Pokémon
            {
                Console.WriteLine("Volviendo al menú de acciones...");
                return pokemonActivo; // retorna el Pokémon actual sin cambiar
            }

            // Valida la selección del jugador y verifica que el Pokémon tenga vida
            if (seleccion >= 0 && seleccion < jugador.ListaDePokemones.Count)
            {
                nuevoPokemon = jugador.ListaDePokemones[seleccion];
                if (nuevoPokemon.Vida > 0)
                {
                    Console.WriteLine($"Has cambiado a {nuevoPokemon.Nombre}.");
                    cambioExitoso = true;
                }
                else
                {
                    Console.WriteLine("Ese Pokémon está debilitado. Elige otro.");
                }
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }

        return nuevoPokemon;
    }
    
    






    /// <summary>
    /// Permite al jugador utilizar un ítem de su inventario en uno de sus Pokémon.
    /// </summary>
    /// <param name="jugador1">El jugador que usa el ítem.</param>
    /// <param name="turno">El turno actual.</param>
    /// <returns>El nuevo turno tras usar el ítem (cambia el turno).</returns>
    public static int UsarItem(Jugador jugador1, int turno)
    {
        bool opcionValida = true; // bandera para verificar la opcion

        while (opcionValida) // esto nos permite volver para atras
        {
            Console.WriteLine("Selecciona un ítem:");

            for (int i = 0; i < jugador1.Items.Count; i++) // muestra los items en la lista 1 por 1 (i++)
            {
                var item = jugador1.Items[i];
                Console.WriteLine($"{i + 1}. {item.Nombre} (Usos restantes: {item.UsosRestantes})");
            }

            Console.WriteLine("0. Volver al menú anterior");

            int itemSeleccionado =
                Convert.ToInt32(Console.ReadLine()) - 1; // restamos 1 porque los indices de la lista empiezan en 0
            if (itemSeleccionado == -1) // si se selecciona 0 (osea -1) se vuelve al menu
            {
                opcionValida = false; // termina el bucle
                continue; // sigue el bucle del primer menu
            }

            if (itemSeleccionado >= 0 && itemSeleccionado < jugador1.Items.Count)
            {
                IItem item = jugador1.Items[itemSeleccionado];

                Console.WriteLine("Selecciona un Pokémon para usar el ítem:");
                for (int i = 0; i < jugador1.ListaDePokemones.Count; i++) // mostrar la lista de pokemones
                {
                    var pokemon = jugador1.ListaDePokemones[i];
                    Console.WriteLine($"{i + 1}. {pokemon.Nombre} - Vida: {pokemon.Vida}");
                }

                int pokemonSeleccionado =
                    Convert.ToInt32(Console.ReadLine()) -
                    1; // como antes. como es un indice le restamos uno, para que sea mas lindo y friendly para el usuario (y para mi)
                if (pokemonSeleccionado >= 0 && pokemonSeleccionado < jugador1.ListaDePokemones.Count)
                {
                    IPokemon pokemonSeleccionadoObj = jugador1.ListaDePokemones[pokemonSeleccionado];
                    item.Usar(pokemonSeleccionadoObj); // usar item en pokemonseleccionado (objeto Ipokemon)

                    turno = 1; // despues de usar el item se cambia el turno
                    opcionValida = false; // termina el bucle una vez seleccionado el item
                }
                else
                {
                    Console.WriteLine("Opción de Pokémon inválida.");
                }
            }
            else
            {
                Console.WriteLine("Opción de ítem inválida.");
            }
        }

        return turno; // devuelve el turno
    }


    
    /// <summary>
    /// Verifica si todos los Pokémon en una lista están debilitados.
    /// </summary>
    /// <param name="listaPokemones">Lista de Pokémon a verificar.</param>
    /// <returns>True si todos los Pokémon están debilitados (vida total = 0), de lo contrario False.</returns>

    public static bool VerificarFinBatalla(List<IPokemon> listaPokemones)
    {
        double vidaTotal = 0;
        foreach (var pokemon in listaPokemones)
        {
            vidaTotal += pokemon.Vida;
        }

        return vidaTotal <= 0;
    }


}
