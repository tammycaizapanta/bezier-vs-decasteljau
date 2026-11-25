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
    }
}