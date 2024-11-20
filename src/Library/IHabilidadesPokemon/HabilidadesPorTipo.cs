using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    // Clase responsable de manejar y obtener ataques por tipo de Pokémon
    // Esta clase usa un diccionario para guardar los ataques disponibles según el tipo de Pokémon
    public static class HabilidadesPorTipo
    {
        private static readonly Dictionary<TipoPokemon, List<Ataque>> AtaquesPorTipo = new()
        {
            {
                TipoPokemon.Normal, new List<Ataque>
                {
                    new Ataque("Placaje", TipoPokemon.Normal, 10, 1.0),
                    new Ataque("Golpe Cuerpo", TipoPokemon.Normal, 20, 0.8),
                    new Ataque("Corte", TipoPokemon.Normal, 15, 0.95),
                    new Ataque("Hiper Rayo", TipoPokemon.Normal, 25, 0.9)
                }
            },
            {
                TipoPokemon.Fuego, new List<Ataque>
                {
                    new Ataque("Ascuas", TipoPokemon.Fuego, 10, 1.0),
                    new Ataque("Lanzallamas", TipoPokemon.Fuego, 15, 0.85),
                    new AtaqueEspecial("Giro Fuego", TipoPokemon.Fuego, 5, 0.85, EstadoEspecial.Quemado),
                    new AtaqueEspecial("Llamarada", TipoPokemon.Fuego, 20, 0.85, EstadoEspecial.Quemado)
                }
            },
            {
                TipoPokemon.Agua, new List<Ataque>
                {
                    new Ataque("Pistola Agua", TipoPokemon.Agua, 10, 1.0),
                    new Ataque("Hidro Pulso", TipoPokemon.Agua, 25, 0.9),
                    new Ataque("Surf", TipoPokemon.Agua, 15, 0.85),
                    new Ataque("Hidro Bomba", TipoPokemon.Agua, 10, 0.8)
                }
            },
            {
                TipoPokemon.Planta, new List<Ataque>
                {
                    new Ataque("Látigo Cepa", TipoPokemon.Planta, 10, 1.0),
                    new Ataque("Hoja Afilada", TipoPokemon.Planta, 5, 0.95),
                    new Ataque("Bomba Germen", TipoPokemon.Planta, 20, 0.85),
                    new Ataque("Rayo Solar", TipoPokemon.Planta, 15, 0.75)
                }
            },
            {
                TipoPokemon.Electrico, new List<Ataque>
                {
                    new Ataque("Impactrueno", TipoPokemon.Electrico, 5, 1.0),
                    new AtaqueEspecial("Onda Trueno", TipoPokemon.Electrico, 15, 0.9, EstadoEspecial.Paralizado),
                    new Ataque("Rayo", TipoPokemon.Electrico, 20, 0.85),
                    new AtaqueEspecial("Trueno", TipoPokemon.Electrico, 10, 0.7, EstadoEspecial.Paralizado)
                }
            },
            {
                TipoPokemon.Hielo, new List<Ataque>
                {
                    new Ataque("Viento Helado", TipoPokemon.Hielo, 10, 0.95),
                    new Ataque("Rayo Hielo", TipoPokemon.Hielo, 15, 0.85),
                    new Ataque("Ventisca", TipoPokemon.Hielo, 20, 0.7),
                    new Ataque("Granizo", TipoPokemon.Hielo, 10, 0.95)
                }
            },
            {
                TipoPokemon.Lucha, new List<Ataque>
                {
                    new Ataque("Golpe Kárate", TipoPokemon.Lucha, 10, 1.0),
                    new Ataque("Patada Baja", TipoPokemon.Lucha, 15, 0.9),
                    new Ataque("Golpe Cruz", TipoPokemon.Lucha, 20, 0.8),
                    new Ataque("Patada Salto", TipoPokemon.Lucha, 10, 0.95)
                }
            },
            {
                TipoPokemon.Veneno, new List<Ataque>
                {
                    new Ataque("Picotazo", TipoPokemon.Veneno, 10, 1.0),
                    new AtaqueEspecial("Ácido", TipoPokemon.Veneno, 5, 1.0, EstadoEspecial.Envenenado),
                    new AtaqueEspecial("Bomba Lodo", TipoPokemon.Veneno, 20, 0.85, EstadoEspecial.Envenenado),
                    new Ataque("Residuos", TipoPokemon.Veneno, 15, 0.95)
                }
            },
            {
                TipoPokemon.Tierra, new List<Ataque>
                {
                    new Ataque("Bofetón Lodo", TipoPokemon.Tierra, 10, 1.0),
                    new Ataque("Excavar", TipoPokemon.Tierra, 15, 0.9),
                    new Ataque("Terremoto", TipoPokemon.Tierra, 10, 0.85),
                    new Ataque("Fisura", TipoPokemon.Tierra, 20, 0.3)
                }
            },
            {
                TipoPokemon.Volador, new List<Ataque>
                {
                    new Ataque("Tornado", TipoPokemon.Volador, 10, 1.0),
                    new Ataque("Ataque Ala", TipoPokemon.Volador, 5, 0.95),
                    new Ataque("Pájaro Osado", TipoPokemon.Volador, 20, 0.8),
                    new Ataque("Tajo Aéreo", TipoPokemon.Volador, 15, 0.95)
                }
            },
            {
                TipoPokemon.Psiquico, new List<Ataque>
                {
                    new AtaqueEspecial("Confusión", TipoPokemon.Psiquico, 10, 1.0, EstadoEspecial.Dormido),
                    new Ataque("Psicorrayo", TipoPokemon.Psiquico, 15, 0.95),
                    new AtaqueEspecial("Psíquico", TipoPokemon.Psiquico, 5, 0.85, EstadoEspecial.Dormido),
                    new Ataque("Premonición", TipoPokemon.Psiquico, 10, 0.85)
                }
            },
            {
                TipoPokemon.Bicho, new List<Ataque>
                {
                    new Ataque("Picadura", TipoPokemon.Bicho, 5, 1.0),
                    new Ataque("Pin Misil", TipoPokemon.Bicho, 20, 0.95),
                    new Ataque("Tijera X", TipoPokemon.Bicho, 10, 0.9),
                    new Ataque("Zumbido", TipoPokemon.Bicho, 15, 0.85)
                }
            },
            {
                TipoPokemon.Roca, new List<Ataque>
                {
                    new Ataque("Lanza Rocas", TipoPokemon.Roca, 15, 0.9),
                    new Ataque("Tumba Rocas", TipoPokemon.Roca, 10, 0.95),
                    new Ataque("Avalancha", TipoPokemon.Roca, 20, 0.9),
                    new Ataque("Roca Afilada", TipoPokemon.Roca, 10, 0.8)
                }
            },
            {
                TipoPokemon.Fantasma, new List<Ataque>
                {
                    new Ataque("Lengüetazo", TipoPokemon.Fantasma, 10, 1.0),
                    new Ataque("Tinieblas", TipoPokemon.Fantasma, 15, 1.0),
                    new Ataque("Bola Sombra", TipoPokemon.Fantasma, 20, 0.9),
                    new Ataque("Puño Sombra", TipoPokemon.Fantasma, 20, 0.95)
                }
            },
            {
                TipoPokemon.Dragon, new List<Ataque>
                {
                    new Ataque("Furia Dragón", TipoPokemon.Dragon, 10, 1.0),
                    new Ataque("Cola Dragón", TipoPokemon.Dragon, 15, 0.9),
                    new Ataque("Pulso Dragón", TipoPokemon.Dragon, 10, 0.9),
                    new Ataque("Cometa Draco", TipoPokemon.Dragon, 15, 0.85)
                }
            }
        };
        // Método que devuelve una lista de ataques disponibles para un tipo de Pokémon específico
        // Si el tipo no tiene ataques registrados, se devuelve una lista vacía
        public static List<IHabilidadesPokemon> ObtenerAtaquesPorTipo(TipoPokemon tipo)
        {
            if (AtaquesPorTipo.TryGetValue(tipo, out var ataques))
            {
                return ataques.Cast<IHabilidadesPokemon>().ToList();
            }

            return new List<IHabilidadesPokemon>();
        }
    }
}