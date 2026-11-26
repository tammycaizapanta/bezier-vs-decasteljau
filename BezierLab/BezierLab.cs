using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BezierLab.Logica;

namespace BezierLab
{
    // Ventana principal. Aquí solo se leen los controles y se dibuja.
    // Todos los cálculos están en la carpeta Logica.
    // Responsable: Bernardo Suárez (Issue #5)
    public partial class BezierLab : Form
    {
        private List<Vector2> puntos = new List<Vector2>();
        private int arrastrando = -1;          // índice del punto que se mueve (-1 = ninguno)
        private int resaltado = -1;            // punto bajo el mouse (se dibuja resaltado)
        private const float Radio = 6f;

        private static readonly Color[] ColoresNivel =
        {
            Color.MediumSeaGreen, Color.Orange, Color.MediumPurple, Color.Teal, Color.Goldenrod
        };

        public BezierLab()
        {
            InitializeComponent();
        }

        private int Muestras
        {
            get { return (int)nudMuestras.Value; }
        }

        private double T
        {
            get { return trkT.Value / 100.0; }
        }

        private static PointF[] APantalla(Vector2[] p)
        {
            PointF[] r = new PointF[p.Length];
            for (int i = 0; i < p.Length; i++)
                r[i] = new PointF((float)p[i].X, (float)p[i].Y);
            return r;
        }

        private void Redibujar()
        {
            lblT.Text = "t = " + T.ToString("0.00");
            picLienzo.Invalidate();
            ActualizarEstado();
        }

        // Grado, muestras y diferencia entre ambos métodos para la curva actual
        private void ActualizarEstado()
        {
            if (puntos.Count < 2)
            {
                lblEstado.Text = "Agrega al menos 2 puntos.";
                return;
            }
            Vector2[] control = puntos.ToArray();
            double max, prom;
            Medicion.Diferencias(Bernstein.Muestrear(control, Muestras),
                                 DeCasteljau.Muestrear(control, Muestras), out max, out prom);
            lblEstado.Text = "Grado " + (puntos.Count - 1) + "  ·  " + Muestras + " muestras\r\n" +
                             "Dif. máx: " + max.ToString("E2") + " px   Dif. prom: " + prom.ToString("E2") + " px";
        }

        // ------------------------------------------------------------
        //  Mouse: agregar, mover y eliminar puntos
        // ------------------------------------------------------------

        private int BuscarPunto(Point p)
        {
            for (int i = puntos.Count - 1; i >= 0; i--)
            {
                double dx = puntos[i].X - p.X, dy = puntos[i].Y - p.Y;
                if (dx * dx + dy * dy <= (Radio + 3) * (Radio + 3)) return i;
            }
            return -1;
        }

        private void picLienzo_MouseDown(object sender, MouseEventArgs e)
        {
            int i = BuscarPunto(e.Location);
            if (e.Button == MouseButtons.Left)
            {
                if (i >= 0) arrastrando = i;                       // mover
                else puntos.Add(new Vector2(e.X, e.Y));            // agregar
            }
            else if (e.Button == MouseButtons.Right && i >= 0)
            {
                puntos.RemoveAt(i);                                // eliminar
                resaltado = -1;
            }
            Redibujar();
        }

        private void picLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrando < 0)
            {
                // Sin arrastrar: indicar con el cursor y un aro si hay un punto debajo
                int i = BuscarPunto(e.Location);
                picLienzo.Cursor = i >= 0 ? Cursors.Hand : Cursors.Cross;
                if (i != resaltado)
                {
                    resaltado = i;
                    picLienzo.Invalidate();
                }
                return;
            }
            int x = Math.Max(0, Math.Min(e.X, picLienzo.Width - 1));
            int y = Math.Max(0, Math.Min(e.Y, picLienzo.Height - 1));
            puntos[arrastrando] = new Vector2(x, y);
            Redibujar();
        }

        private void picLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrando = -1;
        }

        // ------------------------------------------------------------
        //  Dibujo: solo líneas entre los puntos que calculan nuestros métodos
        //  (no se usa DrawBezier, DrawCurve ni AddBezier)
        // ------------------------------------------------------------

        private void picLienzo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (puntos.Count == 0)
            {
                g.DrawString("Haz clic aquí para agregar el primer punto de control.",
                             Font, Brushes.Gray, 10, 10);
                return;
            }

            Vector2[] control = puntos.ToArray();

            if (control.Length >= 2)
            {
                using (Pen pen = new Pen(Color.LightGray, 1f))
                {
                    pen.DashStyle = DashStyle.Dash;
                    g.DrawLines(pen, APantalla(control));             // polígono de control
                }

                if (chkBernstein.Checked)
                    using (Pen pen = new Pen(Color.FromArgb(140, Color.RoyalBlue), 6f))
                        g.DrawLines(pen, APantalla(Bernstein.Muestrear(control, Muestras)));

                if (chkCasteljau.Checked)
                    using (Pen pen = new Pen(Color.Crimson, 1.5f))
                        g.DrawLines(pen, APantalla(DeCasteljau.Muestrear(control, Muestras)));

                if (chkInterpolaciones.Checked)
                    DibujarInterpolaciones(g, control);
            }

            for (int i = 0; i < control.Length; i++)
            {
                float x = (float)control[i].X, y = (float)control[i].Y;
                g.FillEllipse(Brushes.Black, x - Radio, y - Radio, Radio * 2, Radio * 2);
                if (i == resaltado || i == arrastrando)
                    using (Pen aro = new Pen(Color.Orange, 2f))
                        g.DrawEllipse(aro, x - Radio - 4, y - Radio - 4, Radio * 2 + 8, Radio * 2 + 8);
                g.DrawString("P" + i, Font, Brushes.Black, x + 8, y - 18);
            }
        }

        private void DibujarInterpolaciones(Graphics g, Vector2[] control)
        {
            List<Vector2[]> niveles = DeCasteljau.Niveles(control, T);
            for (int r = 1; r < niveles.Count; r++)
            {
                Color color = ColoresNivel[(r - 1) % ColoresNivel.Length];
                if (niveles[r].Length >= 2)
                    using (Pen pen = new Pen(color, 1.2f))
                        g.DrawLines(pen, APantalla(niveles[r]));
                using (SolidBrush brush = new SolidBrush(color))
                    foreach (Vector2 p in niveles[r])
                        g.FillEllipse(brush, (float)p.X - 3, (float)p.Y - 3, 6, 6);
            }
            Vector2 bt = niveles[niveles.Count - 1][0];
            g.FillEllipse(Brushes.Black, (float)bt.X - 5, (float)bt.Y - 5, 10, 10);
            g.DrawString("B(" + T.ToString("0.00") + ")", Font, Brushes.Black, (float)bt.X + 8, (float)bt.Y + 4);
        }

        // ------------------------------------------------------------
        //  Controles
        // ------------------------------------------------------------

        private void Controles_Changed(object sender, EventArgs e)
        {
            Redibujar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            puntos.Clear();
            txtResultados.Clear();
            Redibujar();
        }

        // Todas las combinaciones del informe: 10 repeticiones cada una, sin dibujar.
        // Corre en segundo plano (Task.Run) para que la ventana no se congele.
        private async void btnPrueba_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "La prueba completa mide todas las combinaciones de grado y muestras " +
                "(10 repeticiones cada una) y tarda alrededor de un minuto.\r\n\r\n¿Continuar?",
                "Prueba completa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            grpPruebas.Enabled = false;
            Cursor = Cursors.WaitCursor;
            lblEstado.Text = "Ejecutando la prueba completa... no cierre la ventana.";
            string resultado = await Task.Run(() => Medicion.PruebaCompleta());
            txtResultados.Text = resultado;
            Cursor = Cursors.Default;
            grpPruebas.Enabled = true;
            lblEstado.Text = "Prueba terminada. Use \"Copiar resultados\" y péguelos en datos/resultados.txt.";
        }

        // Copia la tabla para pegarla en el informe
        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (txtResultados.Text.Length == 0)
            {
                MessageBox.Show("Todavía no hay resultados. Ejecute primero una prueba.", "BezierLab");
                return;
            }
            Clipboard.SetText(txtResultados.Text);
            lblEstado.Text = "Resultados copiados al portapapeles.";
        }

        // Cúbica del cálculo manual: P0(0,0) P1(1,2) P2(3,3) P3(4,0)
        private void btnValidar_Click(object sender, EventArgs e)
        {
            Vector2[] c = { new Vector2(0, 0), new Vector2(1, 2), new Vector2(3, 3), new Vector2(4, 0) };
            double[] ts = { 0.25, 0.5, 0.75 };
            StringBuilder sb = new StringBuilder("t\tBernstein\tDe Casteljau\r\n");
            foreach (double t in ts)
                sb.AppendLine(t.ToString("0.00") + "\t" + Bernstein.Evaluar(c, t) + "\t" + DeCasteljau.Evaluar(c, t));
            sb.AppendLine("Esperado: (0.90625, 1.265625) · (2, 1.875) · (3.09375, 1.546875)");
            txtResultados.Text = sb.ToString();
            lblEstado.Text = "Validación lista: compare con la sección 3 del informe.";
        }
    }
}
