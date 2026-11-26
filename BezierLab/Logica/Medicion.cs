using System;
using System.Diagnostics;

namespace BezierLab.Logica
{
    // Mide tiempos con Stopwatch y calcula diferencias numéricas.
    // Aquí nunca se dibuja: el tiempo de representación gráfica queda fuera.
    // Responsable: Julio Sánchez (Issue #4)
    public static class Medicion
    {
        public const int Repeticiones = 10;

        // Firma común de Bernstein.Muestrear y DeCasteljau.Muestrear
        public delegate Vector2[] Metodo(Vector2[] control, int muestras);

        // Ejecuta 1 vez de calentamiento (no cuenta) y luego 10 veces con Stopwatch.
        // Devuelve el promedio en ms y, por "desviacion", la desviación estándar.
        public static double Medir(Metodo metodo, Vector2[] control, int muestras, out double desviacion)
        {
            metodo(control, muestras); // calentamiento (compilación JIT)

            double[] tiempos = new double[Repeticiones];
            Stopwatch sw = new Stopwatch();
            for (int r = 0; r < Repeticiones; r++)
            {
                sw.Restart();
                metodo(control, muestras);   // solo el cálculo
                sw.Stop();
                tiempos[r] = sw.Elapsed.TotalMilliseconds;
            }

            double promedio = 0;
            foreach (double x in tiempos) promedio += x;
            promedio /= Repeticiones;

            double suma = 0;
            foreach (double x in tiempos) suma += (x - promedio) * (x - promedio);
            desviacion = Math.Sqrt(suma / (Repeticiones - 1));
            return promedio;
        }
    }
}
