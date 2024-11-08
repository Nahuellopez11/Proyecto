// DESPUES LO HAGO PARA LA MAQUINA
// Separe la logica para que cumpla con SRP y también para que no quede super largo InicializacionBatalla

namespace Program;

public class UtilizacionItem
{
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

            int itemSeleccionado = Convert.ToInt32(Console.ReadLine()) - 1; // restamos 1 porque los indices de la lista empiezan en 0
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

                int pokemonSeleccionado = Convert.ToInt32(Console.ReadLine()) - 1; // como antes. como es un indice le restamos uno, para que sea mas lindo y friendly para el usuario (y para mi)
                if (pokemonSeleccionado >= 0 && pokemonSeleccionado < jugador1.ListaDePokemones.Count)
                {
                    IPokemones pokemonSeleccionadoObj = jugador1.ListaDePokemones[pokemonSeleccionado];
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

        return turno; // devuelve el turno y cambia a 
    }
}
