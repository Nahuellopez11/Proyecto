namespace Program;

public class ElegirPokemonMaquina
{
    // La clase tiene una única responsabilidad: seleccionar un equipo de Pokémon aleatorios para la máquina
    private static Random random = new Random();
    private static List<IPokemones> equipoMaquina = new List<IPokemones>();

    public static void SeleccionarEquipo()
    {// La clase depende de CatalogoPokemones y de la interfaz IPokemones, lo que permite que esta clase
        // sea flexible y reutilizable. No tiene acoplamientos innecesarios con otras clases.
        equipoMaquina.Clear();

        while (equipoMaquina.Count < 6)
        {
            // Generar un número aleatorio entre 1 y 16
            int seleccion = random.Next(1, 17);

            // Obtener el pokemon correspondiente al índice generado
            if (CatalogoPokemones.CatalogoPoke.TryGetValue(seleccion, out IPokemones pokemonSeleccionado))
            {
                // Verificar si el pokemon ya está en el equipo de la máquina
                if (!equipoMaquina.Any(p => p.Nombre == pokemonSeleccionado.Nombre))
                {
                    equipoMaquina.Add(pokemonSeleccionado);
                }
            }
        }
    }

    public static List<IPokemones> DevolverLista()
    {
        return equipoMaquina;
    }

   
    
/*
        Principio de OCP (Open/Closed Principle):
        La clase está abierta a la extensión, ya que si quisieras cambiar cómo se seleccionan los Pokémon
        (por ejemplo, no aleatoriamente, sino basados en ciertas características), podrías extender la clase o
        modificar su comportamiento sin alterar su estructura principal.

        Principio de DIP (Dependency Inversion Principle):
        La clase depende de abstracciones (IPokemones), lo que permite que cualquier clase que implemente
        la interfaz IPokemones pueda ser utilizada. Esto facilita la extensión y el mantenimiento del código,
        ya que las dependencias están basadas en interfaces y no en implementaciones concretas.
        */
    

  
}
