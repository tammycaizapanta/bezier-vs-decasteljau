namespace BezierLab.Logica
{
    // Evaluación directa con polinomios de Bernstein:
    //   B(t) = Σ C(n,i) · t^i · (1 - t)^(n-i) · P_i
    // Responsable: Tammy Caizapanta (Issue #1)
    public static class Bernstein
    {
        // Coeficientes binomiales C(n,0) ... C(n,n) con la fórmula multiplicativa
        //   C(n,i) = C(n,i-1) · (n - i + 1) / i
        // (sin factoriales, que desbordan muy pronto)
        public static double[] Binomiales(int n)
        {
            double[] c = new double[n + 1];
            c[0] = 1.0;
            for (int i = 1; i <= n; i++)
                c[i] = c[i - 1] * (n - i + 1) / i;
            return c;
        }

        // Un punto de la curva para un t
        public static Vector2 Evaluar(Vector2[] control, double t)
        {
            Vector2.Validar(control, 2);
            return Evaluar(control, t, Binomiales(control.Length - 1));
        }

        // Toda la curva: "muestras" puntos con t de 0 a 1
        public static Vector2[] Muestrear(Vector2[] control, int muestras)
        {
            Vector2.Validar(control, muestras);
            double[] c = Binomiales(control.Length - 1); // se calculan una sola vez
            Vector2[] resultado = new Vector2[muestras];
            for (int k = 0; k < muestras; k++)
                resultado[k] = Evaluar(control, Vector2.ParametroT(k, muestras), c);
            return resultado;
        }

        private static Vector2 Evaluar(Vector2[] control, double t, double[] c)
        {
            int n = control.Length - 1;
            double x = 0, y = 0;
            for (int i = 0; i <= n; i++)
            {
                double b = c[i] * System.Math.Pow(t, i) * System.Math.Pow(1 - t, n - i);
                x += b * control[i].X;
                y += b * control[i].Y;
            }
            return new Vector2(x, y);
        }
    }
}
