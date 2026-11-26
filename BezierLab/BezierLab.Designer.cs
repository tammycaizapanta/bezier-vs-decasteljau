namespace BezierLab
{
    partial class BezierLab
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picLienzo = new System.Windows.Forms.PictureBox();
            this.grpCurva = new System.Windows.Forms.GroupBox();
            this.lblMuestras = new System.Windows.Forms.Label();
            this.nudMuestras = new System.Windows.Forms.NumericUpDown();
            this.lblAyuda = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.grpVista = new System.Windows.Forms.GroupBox();
            this.chkBernstein = new System.Windows.Forms.CheckBox();
            this.chkCasteljau = new System.Windows.Forms.CheckBox();
            this.chkInterpolaciones = new System.Windows.Forms.CheckBox();
            this.lblTituloT = new System.Windows.Forms.Label();
            this.trkT = new System.Windows.Forms.TrackBar();
            this.lblT = new System.Windows.Forms.Label();
            this.grpPruebas = new System.Windows.Forms.GroupBox();
            this.btnValidar = new System.Windows.Forms.Button();
            this.btnPrueba = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtResultados = new System.Windows.Forms.TextBox();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLienzo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMuestras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkT)).BeginInit();
            this.grpCurva.SuspendLayout();
            this.grpVista.SuspendLayout();
            this.grpPruebas.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLienzo
            // 
            this.picLienzo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.picLienzo.BackColor = System.Drawing.Color.White;
            this.picLienzo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLienzo.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picLienzo.Location = new System.Drawing.Point(12, 12);
            this.picLienzo.Size = new System.Drawing.Size(900, 700);
            this.picLienzo.TabStop = false;
            this.picLienzo.Paint += new System.Windows.Forms.PaintEventHandler(this.picLienzo_Paint);
            this.picLienzo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLienzo_MouseDown);
            this.picLienzo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picLienzo_MouseMove);
            this.picLienzo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picLienzo_MouseUp);
            this.picLienzo.Name = "picLienzo";
            this.picLienzo.TabIndex = 0;
            // 
            // grpCurva
            // 
            this.grpCurva.Controls.Add(this.lblMuestras);
            this.grpCurva.Controls.Add(this.nudMuestras);
            this.grpCurva.Controls.Add(this.lblAyuda);
            this.grpCurva.Controls.Add(this.btnLimpiar);
            this.grpCurva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCurva.Location = new System.Drawing.Point(925, 8);
            this.grpCurva.Size = new System.Drawing.Size(320, 140);
            this.grpCurva.Text = "1. Curva";
            this.grpCurva.Name = "grpCurva";
            this.grpCurva.TabIndex = 1;
            // 
            // lblMuestras
            // 
            this.lblMuestras.AutoSize = true;
            this.lblMuestras.Location = new System.Drawing.Point(12, 31);
            this.lblMuestras.Text = "Muestras:";
            this.lblMuestras.Name = "lblMuestras";
            this.lblMuestras.TabIndex = 2;
            // 
            // nudMuestras
            // 
            this.nudMuestras.Location = new System.Drawing.Point(100, 28);
            this.nudMuestras.Size = new System.Drawing.Size(110, 22);
            this.nudMuestras.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            this.nudMuestras.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudMuestras.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudMuestras.Value = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudMuestras.ValueChanged += new System.EventHandler(this.Controles_Changed);
            this.nudMuestras.Name = "nudMuestras";
            this.nudMuestras.TabIndex = 3;
            this.tip.SetToolTip(this.nudMuestras, "Cantidad de puntos que se calculan en cada curva (2 a 100 000)");
            // 
            // lblAyuda
            // 
            this.lblAyuda.ForeColor = System.Drawing.Color.DimGray;
            this.lblAyuda.Location = new System.Drawing.Point(12, 60);
            this.lblAyuda.Size = new System.Drawing.Size(296, 40);
            this.lblAyuda.Text = "Clic izquierdo: agregar punto · Arrastrar: mover\r\nClic derecho sobre un punto: eliminar";
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.TabIndex = 4;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 102);
            this.btnLimpiar.Size = new System.Drawing.Size(296, 28);
            this.btnLimpiar.Text = "Limpiar puntos";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.TabIndex = 5;
            this.tip.SetToolTip(this.btnLimpiar, "Borra todos los puntos de control");
            // 
            // grpVista
            // 
            this.grpVista.Controls.Add(this.chkBernstein);
            this.grpVista.Controls.Add(this.chkCasteljau);
            this.grpVista.Controls.Add(this.chkInterpolaciones);
            this.grpVista.Controls.Add(this.lblTituloT);
            this.grpVista.Controls.Add(this.trkT);
            this.grpVista.Controls.Add(this.lblT);
            this.grpVista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVista.Location = new System.Drawing.Point(925, 155);
            this.grpVista.Size = new System.Drawing.Size(320, 150);
            this.grpVista.Text = "2. Visualización";
            this.grpVista.Name = "grpVista";
            this.grpVista.TabIndex = 6;
            // 
            // chkBernstein
            // 
            this.chkBernstein.Checked = true;
            this.chkBernstein.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBernstein.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkBernstein.Location = new System.Drawing.Point(12, 24);
            this.chkBernstein.Size = new System.Drawing.Size(296, 22);
            this.chkBernstein.Text = "Bernstein (azul grueso)";
            this.chkBernstein.CheckedChanged += new System.EventHandler(this.Controles_Changed);
            this.chkBernstein.Name = "chkBernstein";
            this.chkBernstein.TabIndex = 7;
            // 
            // chkCasteljau
            // 
            this.chkCasteljau.Checked = true;
            this.chkCasteljau.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCasteljau.ForeColor = System.Drawing.Color.Crimson;
            this.chkCasteljau.Location = new System.Drawing.Point(12, 47);
            this.chkCasteljau.Size = new System.Drawing.Size(296, 22);
            this.chkCasteljau.Text = "De Casteljau (rojo fino)";
            this.chkCasteljau.CheckedChanged += new System.EventHandler(this.Controles_Changed);
            this.chkCasteljau.Name = "chkCasteljau";
            this.chkCasteljau.TabIndex = 8;
            // 
            // chkInterpolaciones
            // 
            this.chkInterpolaciones.Checked = true;
            this.chkInterpolaciones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInterpolaciones.Location = new System.Drawing.Point(12, 70);
            this.chkInterpolaciones.Size = new System.Drawing.Size(296, 22);
            this.chkInterpolaciones.Text = "Interpolaciones de De Casteljau";
            this.chkInterpolaciones.CheckedChanged += new System.EventHandler(this.Controles_Changed);
            this.chkInterpolaciones.Name = "chkInterpolaciones";
            this.chkInterpolaciones.TabIndex = 9;
            // 
            // lblTituloT
            // 
            this.lblTituloT.AutoSize = true;
            this.lblTituloT.Location = new System.Drawing.Point(12, 108);
            this.lblTituloT.Text = "t:";
            this.lblTituloT.Name = "lblTituloT";
            this.lblTituloT.TabIndex = 10;
            // 
            // trkT
            // 
            this.trkT.Location = new System.Drawing.Point(30, 98);
            this.trkT.Size = new System.Drawing.Size(200, 45);
            this.trkT.Maximum = 100;
            this.trkT.TickFrequency = 10;
            this.trkT.Value = 50;
            this.trkT.ValueChanged += new System.EventHandler(this.Controles_Changed);
            this.trkT.Name = "trkT";
            this.trkT.TabIndex = 11;
            this.tip.SetToolTip(this.trkT, "Parámetro t de las interpolaciones de De Casteljau (0 a 1)");
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Location = new System.Drawing.Point(236, 108);
            this.lblT.Text = "t = 0.50";
            this.lblT.Name = "lblT";
            this.lblT.TabIndex = 12;
            // 
            // grpPruebas
            // 
            this.grpPruebas.Controls.Add(this.btnValidar);
            this.grpPruebas.Controls.Add(this.btnPrueba);
            this.grpPruebas.Controls.Add(this.btnCopiar);
            this.grpPruebas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPruebas.Location = new System.Drawing.Point(925, 312);
            this.grpPruebas.Size = new System.Drawing.Size(320, 100);
            this.grpPruebas.Text = "3. Pruebas";
            this.grpPruebas.Name = "grpPruebas";
            this.grpPruebas.TabIndex = 13;
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(12, 24);
            this.btnValidar.Size = new System.Drawing.Size(145, 30);
            this.btnValidar.Text = "Validar cúbica";
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.TabIndex = 14;
            this.tip.SetToolTip(this.btnValidar, "Evalúa la cúbica del cálculo manual con ambos métodos");
            // 
            // btnPrueba
            // 
            this.btnPrueba.Location = new System.Drawing.Point(163, 24);
            this.btnPrueba.Size = new System.Drawing.Size(145, 30);
            this.btnPrueba.Text = "Prueba completa";
            this.btnPrueba.Click += new System.EventHandler(this.btnPrueba_Click);
            this.btnPrueba.Name = "btnPrueba";
            this.btnPrueba.TabIndex = 15;
            this.tip.SetToolTip(this.btnPrueba, "Mide todas las combinaciones de grado y muestras (10 repeticiones, sin dibujar). Tarda alrededor de un minuto");
            // 
            // btnCopiar
            // 
            this.btnCopiar.Location = new System.Drawing.Point(12, 60);
            this.btnCopiar.Size = new System.Drawing.Size(296, 28);
            this.btnCopiar.Text = "Copiar resultados";
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.TabIndex = 16;
            this.tip.SetToolTip(this.btnCopiar, "Copia la tabla de resultados para pegarla en datos/resultados.txt del informe");
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstado.Location = new System.Drawing.Point(925, 420);
            this.lblEstado.Size = new System.Drawing.Size(320, 44);
            this.lblEstado.Text = "Agrega al menos 2 puntos.";
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.TabIndex = 17;
            // 
            // txtResultados
            // 
            this.txtResultados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultados.Font = new System.Drawing.Font("Consolas", 8F);
            this.txtResultados.Location = new System.Drawing.Point(925, 468);
            this.txtResultados.Multiline = true;
            this.txtResultados.ReadOnly = true;
            this.txtResultados.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultados.Size = new System.Drawing.Size(320, 244);
            this.txtResultados.WordWrap = false;
            this.txtResultados.Name = "txtResultados";
            this.txtResultados.TabIndex = 18;
            // 
            // BezierLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 724);
            this.Controls.Add(this.picLienzo);
            this.Controls.Add(this.grpCurva);
            this.Controls.Add(this.grpVista);
            this.Controls.Add(this.grpPruebas);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtResultados);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "BezierLab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BezierLab - Bernstein vs. De Casteljau";
            ((System.ComponentModel.ISupportInitialize)(this.picLienzo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMuestras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkT)).EndInit();
            this.grpCurva.ResumeLayout(false);
            this.grpCurva.PerformLayout();
            this.grpVista.ResumeLayout(false);
            this.grpVista.PerformLayout();
            this.grpPruebas.ResumeLayout(false);
            this.grpPruebas.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox picLienzo;
        private System.Windows.Forms.GroupBox grpCurva;
        private System.Windows.Forms.Label lblMuestras;
        private System.Windows.Forms.NumericUpDown nudMuestras;
        private System.Windows.Forms.Label lblAyuda;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox grpVista;
        private System.Windows.Forms.CheckBox chkBernstein;
        private System.Windows.Forms.CheckBox chkCasteljau;
        private System.Windows.Forms.CheckBox chkInterpolaciones;
        private System.Windows.Forms.Label lblTituloT;
        private System.Windows.Forms.TrackBar trkT;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.GroupBox grpPruebas;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Button btnPrueba;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtResultados;
        private System.Windows.Forms.ToolTip tip;
    }
}
