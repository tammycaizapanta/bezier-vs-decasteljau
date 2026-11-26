using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

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

        // Diferencia máxima y promedio (distancia euclidiana) entre los puntos de ambos métodos.
        // Si un método desborda (NaN o infinito), la diferencia es infinita.
        public static void Diferencias(Vector2[] a, Vector2[] b, out double maxima, out double promedio)
        {
            maxima = 0;
            double suma = 0;
            for (int i = 0; i < a.Length; i++)
            {
                double d = a[i].Distancia(b[i]);
                if (double.IsNaN(d) || double.IsInfinity(d))
                {
                    maxima = promedio = double.PositiveInfinity;
                    return;
                }
                suma += d;
                if (d > maxima) maxima = d;
            }
            promedio = suma / a.Length;
        }

        // Puntos de control reproducibles: con la misma semilla todos obtienen los mismos puntos
        public static Vector2[] PuntosAleatorios(int cantidad)
        {
            Random r = new Random(42);
            Vector2[] p = new Vector2[cantidad];
            for (int i = 0; i < cantidad; i++)
                p[i] = new Vector2(r.Next(50, 751), r.Next(50, 551));
            return p;
        }

        // Número con punto decimal (formato que lee LaTeX); "inf" si un método desbordó
        private static string Num(double x, string formato)
        {
            if (double.IsNaN(x) || double.IsInfinity(x)) return "inf";
            return x.ToString(formato, CultureInfo.InvariantCulture);
        }

        // Una fila de la tabla: grado, muestras, tiempos y diferencias (separado por tabulaciones)
        public static string Fila(Vector2[] control, int muestras)
        {
            double desvB, desvC, difMax, difProm;
            double tB = Medir(Bernstein.Muestrear, control, muestras, out desvB);
            double tC = Medir(DeCasteljau.Muestrear, control, muestras, out desvC);
            Diferencias(Bernstein.Muestrear(control, muestras),
                        DeCasteljau.Muestrear(control, muestras), out difMax, out difProm);
            return (control.Length - 1) + "\t" + muestras + "\t" +
                   Num(tB, "0.0000") + "\t" + Num(desvB, "0.0000") + "\t" +
                   Num(tC, "0.0000") + "\t" + Num(desvC, "0.0000") + "\t" +
                   Num(difMax, "0.00E+00") + "\t" + Num(difProm, "0.00E+00");
        }

        // Encabezado sin espacios: el informe en Overleaf lee este archivo tal cual
        public const string Encabezado =
            "Grado\tMuestras\tBernstein\tDesvB\tCasteljau\tDesvC\tDifMax\tDifProm";

        // Prueba completa del informe. Se copia el resultado en datos/resultados.txt del informe.
        public static string PruebaCompleta()
        {
            int[] grados = { 3, 5, 10, 20, 50 };
            int[] muestras = { 100, 1000, 10000, 100000 };
            int[] extremos = { 100, 500, 1100 };   // casos extremos con 1000 muestras

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Encabezado);
            foreach (int g in grados)
                foreach (int m in muestras)
                    sb.AppendLine(Fila(PuntosAleatorios(g + 1), m));
            foreach (int g in extremos)
                sb.AppendLine(Fila(PuntosAleatorios(g + 1), 1000));
            return sb.ToString();
        }
    }
}
