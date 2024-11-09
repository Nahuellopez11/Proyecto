using System.Collections.Generic;
using System;
using System.Collections.Generic;

namespace Program
{
    public static class HabilidadesPorTipo
    {
        private static readonly Dictionary<TipoPokemon, List<Ataque>> AtaquesPorTipo = new()
        {
            {
                TipoPokemon.Normal, new List<Ataque>
                {
                    new Ataque("Placaje", TipoPokemon.Normal, 40, 1.0),
                    new Ataque("Golpe Cuerpo", TipoPokemon.Normal, 85, 0.8),
                    new Ataque("Corte", TipoPokemon.Normal, 50, 0.95),
                    new Ataque("Hiper Rayo", TipoPokemon.Normal, 150, 0.9)
                }
            },
            {
                TipoPokemon.Fuego, new List<Ataque>
                {
                    new Ataque("Ascuas", TipoPokemon.Fuego, 40, 1.0),
                    new Ataque("Lanzallamas", TipoPokemon.Fuego, 90, 0.85),
                    new Ataque("Giro Fuego", TipoPokemon.Fuego, 35, 0.85),
                    new Ataque("Llamarada", TipoPokemon.Fuego, 110, 0.85)
                }
            },
            {
                TipoPokemon.Agua, new List<Ataque>
                {
                    new Ataque("Pistola Agua", TipoPokemon.Agua, 40, 1.0),
                    new Ataque("Hidro Pulso", TipoPokemon.Agua, 60, 0.9),
                    new Ataque("Surf", TipoPokemon.Agua, 90, 0.85),
                    new Ataque("Hidro Bomba", TipoPokemon.Agua, 110, 0.8)
                }
            },
            {
                TipoPokemon.Planta, new List<Ataque>
                {
                    new Ataque("Látigo Cepa", TipoPokemon.Planta, 45, 1.0),
                    new Ataque("Hoja Afilada", TipoPokemon.Planta, 55, 0.95),
                    new Ataque("Bomba Germen", TipoPokemon.Planta, 80, 0.85),
                    new Ataque("Rayo Solar", TipoPokemon.Planta, 120, 0.75)
                }
            },
            {
                TipoPokemon.Electrico, new List<Ataque>
                {
                    new Ataque("Impactrueno", TipoPokemon.Electrico, 40, 1.0),
                    new Ataque("Onda Trueno", TipoPokemon.Electrico, 60, 0.9),
                    new Ataque("Rayo", TipoPokemon.Electrico, 90, 0.85),
                    new Ataque("Trueno", TipoPokemon.Electrico, 110, 0.7)
                }
            },
            {
                TipoPokemon.Hielo, new List<Ataque>
                {
                    new Ataque("Viento Helado", TipoPokemon.Hielo, 40, 0.95),
                    new Ataque("Rayo Hielo", TipoPokemon.Hielo, 90, 0.85),
                    new Ataque("Ventisca", TipoPokemon.Hielo, 110, 0.7),
                    new Ataque("Granizo", TipoPokemon.Hielo, 55, 0.95)
                }
            },
            {
                TipoPokemon.Lucha, new List<Ataque>
                {
                    new Ataque("Golpe Kárate", TipoPokemon.Lucha, 50, 1.0),
                    new Ataque("Patada Baja", TipoPokemon.Lucha, 65, 0.9),
                    new Ataque("Golpe Cruz", TipoPokemon.Lucha, 100, 0.8),
                    new Ataque("Patada Salto", TipoPokemon.Lucha, 85, 0.95)
                }
            },
            {
                TipoPokemon.Veneno, new List<Ataque>
                {
                    new Ataque("Picotazo", TipoPokemon.Veneno, 35, 1.0),
                    new Ataque("Ácido", TipoPokemon.Veneno, 40, 1.0),
                    new Ataque("Bomba Lodo", TipoPokemon.Veneno, 90, 0.85),
                    new Ataque("Residuos", TipoPokemon.Veneno, 65, 0.95)
                }
            },
            {
                TipoPokemon.Tierra, new List<Ataque>
                {
                    new Ataque("Bofetón Lodo", TipoPokemon.Tierra, 40, 1.0),
                    new Ataque("Excavar", TipoPokemon.Tierra, 80, 0.9),
                    new Ataque("Terremoto", TipoPokemon.Tierra, 100, 0.85),
                    new Ataque("Fisura", TipoPokemon.Tierra, 200, 0.3)
                }
            },
            {
                TipoPokemon.Volador, new List<Ataque>
                {
                    new Ataque("Tornado", TipoPokemon.Volador, 40, 1.0),
                    new Ataque("Ataque Ala", TipoPokemon.Volador, 60, 0.95),
                    new Ataque("Pájaro Osado", TipoPokemon.Volador, 120, 0.8),
                    new Ataque("Tajo Aéreo", TipoPokemon.Volador, 75, 0.95)
                }
            },
            {
                TipoPokemon.Psiquico, new List<Ataque>
                {
                    new Ataque("Confusión", TipoPokemon.Psiquico, 50, 1.0),
                    new Ataque("Psicorrayo", TipoPokemon.Psiquico, 65, 0.95),
                    new Ataque("Psíquico", TipoPokemon.Psiquico, 90, 0.85),
                    new Ataque("Premonición", TipoPokemon.Psiquico, 120, 0.85)
                }
            },
            {
                TipoPokemon.Bicho, new List<Ataque>
                {
                    new Ataque("Picadura", TipoPokemon.Bicho, 40, 1.0),
                    new Ataque("Pin Misil", TipoPokemon.Bicho, 25, 0.95),
                    new Ataque("Tijera X", TipoPokemon.Bicho, 80, 0.9),
                    new Ataque("Zumbido", TipoPokemon.Bicho, 90, 0.85)
                }
            },
            {
                TipoPokemon.Roca, new List<Ataque>
                {
                    new Ataque("Lanza Rocas", TipoPokemon.Roca, 50, 0.9),
                    new Ataque("Tumba Rocas", TipoPokemon.Roca, 60, 0.95),
                    new Ataque("Avalancha", TipoPokemon.Roca, 75, 0.9),
                    new Ataque("Roca Afilada", TipoPokemon.Roca, 100, 0.8)
                }
            },
            {
                TipoPokemon.Fantasma, new List<Ataque>
                {
                    new Ataque("Lengüetazo", TipoPokemon.Fantasma, 30, 1.0),
                    new Ataque("Tinieblas", TipoPokemon.Fantasma, 40, 1.0),
                    new Ataque("Bola Sombra", TipoPokemon.Fantasma, 80, 0.9),
                    new Ataque("Puño Sombra", TipoPokemon.Fantasma, 60, 0.95)
                }
            },
            {
                TipoPokemon.Dragon, new List<Ataque>
                {
                    new Ataque("Furia Dragón", TipoPokemon.Dragon, 40, 1.0),
                    new Ataque("Cola Dragón", TipoPokemon.Dragon, 60, 0.9),
                    new Ataque("Pulso Dragón", TipoPokemon.Dragon, 85, 0.9),
                    new Ataque("Cometa Draco", TipoPokemon.Dragon, 130, 0.85)
                }
            },
            {
                TipoPokemon.Acero, new List<Ataque>
                {
                    new Ataque("Garra Metal", TipoPokemon.Acero, 50, 0.95),
                    new Ataque("Cola Férrea", TipoPokemon.Acero, 100, 0.75),
                    new Ataque("Cabeza de Hierro", TipoPokemon.Acero, 80, 0.9),
                    new Ataque("Puño Meteoro", TipoPokemon.Acero, 90, 0.9)
                }

            },
        };

        public static List<IHabilidadesPokemon> ObtenerAtaquesPorTipo(TipoPokemon tipo)
        {
            if (AtaquesPorTipo.TryGetValue(tipo, out var ataques))
            {
                // La lista de Ataques se convierte explícitamente a IHabilidadesPokemon
                return ataques.Cast<IHabilidadesPokemon>().ToList();
            }

            return new List<IHabilidadesPokemon>();  // En caso de no encontrar ataques para el tipo
        }

    }
}

    

