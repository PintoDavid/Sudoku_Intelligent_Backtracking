
namespace Sudoku_pro
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Rinfo2 = new System.Windows.Forms.Label();
            this.Rinfo3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnSolucionSudoku = new System.Windows.Forms.Button();
            this.BtnMovimientosSudoku = new System.Windows.Forms.Button();
            this.Tiposudoku = new System.Windows.Forms.ComboBox();
            this.Tamaño = new System.Windows.Forms.ComboBox();
            this.Cantidad_celdas_vacias = new System.Windows.Forms.ComboBox();
            this.Tablero = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.LbTiempoTranscurrido = new System.Windows.Forms.Label();
            this.BtnReiniciarSudoku = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Rinfo = new System.Windows.Forms.Label();
            this.BtnGenerarSudoku = new System.Windows.Forms.Button();
            this.textBoxMovimientos = new System.Windows.Forms.TextBox();
            this.labelMovimientos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Rinfo2
            // 
            this.Rinfo2.AutoSize = true;
            this.Rinfo2.Location = new System.Drawing.Point(271, 66);
            this.Rinfo2.Name = "Rinfo2";
            this.Rinfo2.Size = new System.Drawing.Size(13, 17);
            this.Rinfo2.TabIndex = 1;
            this.Rinfo2.Text = "-";
            // 
            // Rinfo3
            // 
            this.Rinfo3.AutoSize = true;
            this.Rinfo3.Location = new System.Drawing.Point(455, 66);
            this.Rinfo3.Name = "Rinfo3";
            this.Rinfo3.Size = new System.Drawing.Size(13, 17);
            this.Rinfo3.TabIndex = 2;
            this.Rinfo3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(613, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo de Sudoku";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(587, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tamaño del Sudoku";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(579, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Dificultad del Sudoku";
            // 
            // BtnSolucionSudoku
            // 
            this.BtnSolucionSudoku.BackColor = System.Drawing.Color.LightGray;
            this.BtnSolucionSudoku.Enabled = false;
            this.BtnSolucionSudoku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSolucionSudoku.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSolucionSudoku.Location = new System.Drawing.Point(645, 352);
            this.BtnSolucionSudoku.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSolucionSudoku.Name = "BtnSolucionSudoku";
            this.BtnSolucionSudoku.Size = new System.Drawing.Size(183, 46);
            this.BtnSolucionSudoku.TabIndex = 7;
            this.BtnSolucionSudoku.Text = "Solución con IA";
            this.BtnSolucionSudoku.UseVisualStyleBackColor = false;
            this.BtnSolucionSudoku.Click += new System.EventHandler(this.BtnSolucionSudoku_Click_1);
            // 
            // BtnMovimientosSudoku
            // 
            this.BtnMovimientosSudoku.BackColor = System.Drawing.Color.LightGray;
            this.BtnMovimientosSudoku.Enabled = false;
            this.BtnMovimientosSudoku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMovimientosSudoku.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMovimientosSudoku.Location = new System.Drawing.Point(645, 558);
            this.BtnMovimientosSudoku.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnMovimientosSudoku.Name = "BtnMovimientosSudoku";
            this.BtnMovimientosSudoku.Size = new System.Drawing.Size(183, 55);
            this.BtnMovimientosSudoku.TabIndex = 10;
            this.BtnMovimientosSudoku.Text = "Movimientos hechos";
            this.BtnMovimientosSudoku.UseVisualStyleBackColor = false;
            this.BtnMovimientosSudoku.Click += new System.EventHandler(this.BtnMovimientosSudoku_Click);
            // 
            // Tiposudoku
            // 
            this.Tiposudoku.FormattingEnabled = true;
            this.Tiposudoku.Items.AddRange(new object[] {
            "Ninguno",
            "Clásico",
            "Submatriz"});
            this.Tiposudoku.Location = new System.Drawing.Point(725, 164);
            this.Tiposudoku.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tiposudoku.Name = "Tiposudoku";
            this.Tiposudoku.Size = new System.Drawing.Size(121, 24);
            this.Tiposudoku.TabIndex = 11;
            this.Tiposudoku.SelectedIndexChanged += new System.EventHandler(this.Tiposudoku_SelectedIndexChanged);
            // 
            // Tamaño
            // 
            this.Tamaño.BackColor = System.Drawing.Color.LightGray;
            this.Tamaño.Enabled = false;
            this.Tamaño.FormattingEnabled = true;
            this.Tamaño.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.Tamaño.Location = new System.Drawing.Point(725, 199);
            this.Tamaño.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tamaño.Name = "Tamaño";
            this.Tamaño.Size = new System.Drawing.Size(121, 24);
            this.Tamaño.TabIndex = 12;
            this.Tamaño.SelectedIndexChanged += new System.EventHandler(this.Tamaño_SelectedIndexChanged);
            // 
            // Cantidad_celdas_vacias
            // 
            this.Cantidad_celdas_vacias.BackColor = System.Drawing.Color.LightGray;
            this.Cantidad_celdas_vacias.Enabled = false;
            this.Cantidad_celdas_vacias.FormattingEnabled = true;
            this.Cantidad_celdas_vacias.Items.AddRange(new object[] {
            "Fácil",
            "Medio",
            "Dificíl"});
            this.Cantidad_celdas_vacias.Location = new System.Drawing.Point(725, 234);
            this.Cantidad_celdas_vacias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cantidad_celdas_vacias.Name = "Cantidad_celdas_vacias";
            this.Cantidad_celdas_vacias.Size = new System.Drawing.Size(121, 24);
            this.Cantidad_celdas_vacias.TabIndex = 13;
            // 
            // Tablero
            // 
            this.Tablero.Location = new System.Drawing.Point(29, 100);
            this.Tablero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tablero.Name = "Tablero";
            this.Tablero.Size = new System.Drawing.Size(523, 523);
            this.Tablero.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(612, 490);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(254, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tiempo en hallar la solución";
            // 
            // LbTiempoTranscurrido
            // 
            this.LbTiempoTranscurrido.AutoSize = true;
            this.LbTiempoTranscurrido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTiempoTranscurrido.Location = new System.Drawing.Point(699, 519);
            this.LbTiempoTranscurrido.Name = "LbTiempoTranscurrido";
            this.LbTiempoTranscurrido.Size = new System.Drawing.Size(81, 25);
            this.LbTiempoTranscurrido.TabIndex = 16;
            this.LbTiempoTranscurrido.Text = "0.00 ms";
            // 
            // BtnReiniciarSudoku
            // 
            this.BtnReiniciarSudoku.BackColor = System.Drawing.Color.LightGray;
            this.BtnReiniciarSudoku.Enabled = false;
            this.BtnReiniciarSudoku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReiniciarSudoku.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.BtnReiniciarSudoku.Location = new System.Drawing.Point(645, 418);
            this.BtnReiniciarSudoku.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnReiniciarSudoku.Name = "BtnReiniciarSudoku";
            this.BtnReiniciarSudoku.Size = new System.Drawing.Size(183, 46);
            this.BtnReiniciarSudoku.TabIndex = 17;
            this.BtnReiniciarSudoku.Text = "Reiniciar Sudoku";
            this.BtnReiniciarSudoku.UseVisualStyleBackColor = false;
            this.BtnReiniciarSudoku.Click += new System.EventHandler(this.BtnReiniciarSudoku_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkCyan;
            this.label10.Location = new System.Drawing.Point(669, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 23);
            this.label10.TabIndex = 18;
            this.label10.Text = "Configuración";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(199, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 25);
            this.label11.TabIndex = 19;
            this.label11.Text = "Tablero de Sudoku";
            // 
            // Rinfo
            // 
            this.Rinfo.AutoSize = true;
            this.Rinfo.Location = new System.Drawing.Point(105, 66);
            this.Rinfo.Name = "Rinfo";
            this.Rinfo.Size = new System.Drawing.Size(13, 17);
            this.Rinfo.TabIndex = 21;
            this.Rinfo.Text = "-";
            // 
            // BtnGenerarSudoku
            // 
            this.BtnGenerarSudoku.BackColor = System.Drawing.Color.LightGray;
            this.BtnGenerarSudoku.Enabled = false;
            this.BtnGenerarSudoku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerarSudoku.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerarSudoku.Location = new System.Drawing.Point(645, 289);
            this.BtnGenerarSudoku.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnGenerarSudoku.Name = "BtnGenerarSudoku";
            this.BtnGenerarSudoku.Size = new System.Drawing.Size(183, 46);
            this.BtnGenerarSudoku.TabIndex = 22;
            this.BtnGenerarSudoku.Text = "Generar Sudoku";
            this.BtnGenerarSudoku.UseVisualStyleBackColor = false;
            // 
            // textBoxMovimientos
            // 
            this.textBoxMovimientos.Location = new System.Drawing.Point(915, 63);
            this.textBoxMovimientos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMovimientos.Multiline = true;
            this.textBoxMovimientos.Name = "textBoxMovimientos";
            this.textBoxMovimientos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMovimientos.Size = new System.Drawing.Size(443, 496);
            this.textBoxMovimientos.TabIndex = 23;
            this.textBoxMovimientos.Visible = false;
            // 
            // labelMovimientos
            // 
            this.labelMovimientos.AutoSize = true;
            this.labelMovimientos.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMovimientos.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelMovimientos.Location = new System.Drawing.Point(1005, 23);
            this.labelMovimientos.Name = "labelMovimientos";
            this.labelMovimientos.Size = new System.Drawing.Size(242, 23);
            this.labelMovimientos.TabIndex = 24;
            this.labelMovimientos.Text = "Movimientos Realizados";
            this.labelMovimientos.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(984, 564);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 50);
            this.label1.TabIndex = 25;
            this.label1.Text = "Se demora un poco más\r\npor la impresión de movimientos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(897, 646);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMovimientos);
            this.Controls.Add(this.textBoxMovimientos);
            this.Controls.Add(this.BtnGenerarSudoku);
            this.Controls.Add(this.Rinfo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BtnReiniciarSudoku);
            this.Controls.Add(this.LbTiempoTranscurrido);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Tablero);
            this.Controls.Add(this.Cantidad_celdas_vacias);
            this.Controls.Add(this.Tamaño);
            this.Controls.Add(this.Tiposudoku);
            this.Controls.Add(this.BtnMovimientosSudoku);
            this.Controls.Add(this.BtnSolucionSudoku);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Rinfo3);
            this.Controls.Add(this.Rinfo2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku Solver & Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Rinfo2;
        private System.Windows.Forms.Label Rinfo3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnSolucionSudoku;
        private System.Windows.Forms.Button BtnMovimientosSudoku;
        private System.Windows.Forms.ComboBox Tiposudoku;
        private System.Windows.Forms.ComboBox Tamaño;
        private System.Windows.Forms.ComboBox Cantidad_celdas_vacias;
        private System.Windows.Forms.Panel Tablero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LbTiempoTranscurrido;
        private System.Windows.Forms.Button BtnReiniciarSudoku;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Rinfo;
        private System.Windows.Forms.Button BtnGenerarSudoku;
        private System.Windows.Forms.TextBox textBoxMovimientos;
        private System.Windows.Forms.Label labelMovimientos;
        private System.Windows.Forms.Label label1;
    }
}

