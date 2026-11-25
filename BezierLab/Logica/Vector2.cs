using System;
using System.Globalization;

namespace BezierLab.Logica
{
    // Punto 2D en doble precisión. Lo usan los dos métodos y la medición.
    public struct Vector2
    {
        public double X;
        public double Y;

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Interpolación lineal: (1 - t)·a + t·b
        public static Vector2 Lerp(Vector2 a, Vector2 b, double t)
        {
            double u = 1.0 - t;
            return new Vector2(u * a.X + t * b.X, u * a.Y + t * b.Y);
        }

        // Distancia euclidiana entre dos puntos
        public double Distancia(Vector2 otro)
        {
            double dx = X - otro.X;
            double dy = Y - otro.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Parámetro t de la muestra k cuando hay "muestras" puntos: t = k / (muestras - 1)
        public static double ParametroT(int k, int muestras)
        {
            return (double)k / (muestras - 1);
        }

        // Revisa los datos de entrada (los dos métodos fallan igual)
        public static void Validar(Vector2[] control, int muestras)
        {
            if (control == null || control.Length < 2)
                throw new ArgumentException("Se necesitan al menos 2 puntos de control.");
            if (muestras < 2)
                throw new ArgumentException("Se necesitan al menos 2 muestras.");
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "({0:0.######}, {1:0.######})", X, Y);
        }
    }
}
