using System.Collections.Generic;
namespace BezierLab.Logica
{
    // Algoritmo de De Casteljau: interpolación lineal repetida
    // P_i^r = (1 - t)·P_i^(r-1) + t·P_(i+1)^(r-1) hasta que queda un solo punto
    // Responsable: Laura Quiroz (Issue #2)
    public static class DeCasteljau
    {
        // Un punto de la curva para un t
        public static Vector2 Evaluar(Vector2[] control, double t)
        {
            Vector2.Validar(control, 2);
            return Evaluar(control, t, new Vector2[control.Length]);
        }

        // Toda la curva: "muestras" puntos con t de 0 a 1
        public static Vector2[] Muestrear(Vector2[] control, int muestras)
        {
            Vector2.Validar(control, muestras);
            Vector2[] trabajo = new Vector2[control.Length];   // se reutiliza en cada t
            Vector2[] resultado = new Vector2[muestras];
            for (int k = 0; k < muestras; k++)
                resultado[k] = Evaluar(control, Vector2.ParametroT(k, muestras), trabajo);
            return resultado;
        }

        private static Vector2 Evaluar(Vector2[] control, double t, Vector2[] p)
        {
            int n = control.Length;
            for (int i = 0; i < n; i++)
                p[i] = control[i];                    // copia: no se tocan los puntos originales

            for (int r = 1; r < n; r++)               // niveles
                for (int i = 0; i < n - r; i++)       // puntos del nivel
                    p[i] = Vector2.Lerp(p[i], p[i + 1], t);
            return p[0];
        }
        // Todos los niveles para un t (para dibujar las interpolaciones).
        // Nivel 0 = puntos de control; el último nivel tiene un solo punto = B(t).
        public static List<Vector2[]> Niveles(Vector2[] control, double t)
        {
            Vector2.Validar(control, 2);
            List<Vector2[]> niveles = new List<Vector2[]>();
            niveles.Add((Vector2[])control.Clone());
            while (niveles[niveles.Count - 1].Length > 1)
            {
                Vector2[] anterior = niveles[niveles.Count - 1];
                Vector2[] siguiente = new Vector2[anterior.Length - 1];
                for (int i = 0; i < siguiente.Length; i++)
                    siguiente[i] = Vector2.Lerp(anterior[i], anterior[i + 1], t);
                niveles.Add(siguiente);
            }
            return niveles;
        }
    }
}