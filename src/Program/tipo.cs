namespace Program
{
    public class Tipo
    {
        public string Name { get; set; }

        public Tipo(string name)
        {
            this.Name = name;
        }

        // Listas de efectividades por tipo
        private static readonly List<(string tipo, List<string> debilContra, List<string> resistenteContra, List<string> inmuneContra)> efectividades =
            new List<(string, List<string>, List<string>, List<string>)>
            {
                ("Agua", new List<string> { "Eléctrico", "Planta" }, new List<string> { "Agua", "Fuego", "Hielo" }, new List<string>()),
                ("Bicho", new List<string> { "Fuego", "Roca", "Volador", "Veneno" }, new List<string> { "Lucha", "Planta", "Tierra" }, new List<string>()),
                ("Dragón", new List<string> { "Dragón", "Hielo" }, new List<string> { "Agua", "Eléctrico", "Fuego", "Planta" }, new List<string>()),
                ("Eléctrico", new List<string> { "Tierra" }, new List<string> { "Volador" }, new List<string> { "Eléctrico" }),
                ("Fantasma", new List<string> { "Fantasma" }, new List<string> { "Veneno", "Lucha", "Normal" }, new List<string>()),
                ("Fuego", new List<string> { "Agua", "Roca", "Tierra" }, new List<string> { "Bicho", "Fuego", "Planta" }, new List<string>()),
                ("Hielo", new List<string> { "Fuego", "Lucha", "Roca" }, new List<string> { "Hielo" }, new List<string>()),
                ("Lucha", new List<string> { "Psíquico", "Volador", "Bicho", "Roca" }, new List<string>(), new List<string>()),
                ("Normal", new List<string> { "Lucha" }, new List<string>(), new List<string> { "Fantasma" }),
                ("Planta", new List<string> { "Bicho", "Fuego", "Hielo", "Veneno", "Volador" }, new List<string> { "Agua", "Eléctrico", "Planta", "Tierra" }, new List<string>()),
                ("Psíquico", new List<string> { "Bicho", "Lucha", "Fantasma" }, new List<string>(), new List<string>()),
                ("Roca", new List<string> { "Agua", "Lucha", "Planta", "Tierra" }, new List<string> { "Fuego", "Normal", "Veneno", "Volador" }, new List<string>()),
                ("Tierra", new List<string> { "Agua", "Hielo", "Planta", "Roca", "Veneno" }, new List<string> { "Eléctrico" }, new List<string>()),
                ("Veneno", new List<string> { "Bicho", "Psíquico", "Tierra", "Lucha", "Planta" }, new List<string> { "Planta", "Veneno" }, new List<string>()),
                ("Volador", new List<string> { "Eléctrico", "Hielo", "Roca" }, new List<string> { "Bicho", "Lucha", "Planta", "Tierra" }, new List<string>()),
            };

        // Método que calcula el multiplicador de daño entre dos tipos
        public static double CalcularMultiplicador(string tipoAtaque, string tipoDefensor)
        {
            // Variable para almacenar la efectividad del tipo defensor, inicializada con listas vacías
            (List<string> debilContra, List<string> resistenteContra, List<string> inmuneContra) efectividad =
                (debilContra: new List<string>(), resistenteContra: new List<string>(), inmuneContra: new List<string>());

            // Búsqueda manual del tipo defensor en la lista de efectividades
            foreach (var tipo in efectividades)
            {
                if (tipo.tipo == tipoDefensor)
                {
                    efectividad = (tipo.debilContra, tipo.resistenteContra, tipo.inmuneContra);
                    break; // Salir del bucle una vez encontrado el tipo defensor
                }
            }

            // Si no se encontró el tipo defensor, retornar daño neutral
            if (efectividad.debilContra.Count == 0 && efectividad.resistenteContra.Count == 0 && efectividad.inmuneContra.Count == 0)
            {
                return 1.0;
            }

            // Verificar si el tipo de ataque está en las listas de inmunidad, debilidad o resistencia
            if (efectividad.inmuneContra.Contains(tipoAtaque))
                return 0.0; // Inmune al ataque
            if (efectividad.debilContra.Contains(tipoAtaque))
                return 2.0; // Débil al ataque
            if (efectividad.resistenteContra.Contains(tipoAtaque))
                return 0.5; // Resistente al ataque

            // Daño neutral si no hay relación especial
            return 1.0;
        }
    }
}
