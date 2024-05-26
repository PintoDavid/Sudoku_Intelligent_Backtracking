
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
            this.LbEstadoPrograma = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Rinfo2
            // 
            this.Rinfo2.AutoSize = true;
            this.Rinfo2.Location = new System.Drawing.Point(206, 40);
            this.Rinfo2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Rinfo2.Name = "Rinfo2";
            this.Rinfo2.Size = new System.Drawing.Size(10, 13);
            this.Rinfo2.TabIndex = 1;
            this.Rinfo2.Text = "-";
            // 
            // Rinfo3
            // 
            this.Rinfo3.AutoSize = true;
            this.Rinfo3.Location = new System.Drawing.Point(341, 40);
            this.Rinfo3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Rinfo3.Name = "Rinfo3";
            this.Rinfo3.Size = new System.Drawing.Size(10, 13);
            this.Rinfo3.TabIndex = 2;
            this.Rinfo3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(456, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo de Sudoku";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tamaño del Sudoku";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Dificultad del Sudoku";
            // 
            // BtnSolucionSudoku
            // 
            this.BtnSolucionSudoku.BackColor = System.Drawing.Color.LightGray;
            this.BtnSolucionSudoku.Enabled = false;
            this.BtnSolucionSudoku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSolucionSudoku.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSolucionSudoku.Location = new System.Drawing.Point(480, 206);
            this.BtnSolucionSudoku.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSolucionSudoku.Name = "BtnSolucionSudoku";
            this.BtnSolucionSudoku.Size = new System.Drawing.Size(137, 37);
            this.BtnSolucionSudoku.TabIndex = 7;
            this.BtnSolucionSudoku.Text = "Solución con IA";
            this.BtnSolucionSudoku.UseVisualStyleBackColor = false;
            this.BtnSolucionSudoku.Click += new System.EventHandler(this.BtnSolucionSudoku_Click_1);
            // 
            // Tiposudoku
            // 
            this.Tiposudoku.FormattingEnabled = true;
            this.Tiposudoku.Items.AddRange(new object[] {
            "Ninguno",
            "Clásico",
            "Submatriz"});
            this.Tiposudoku.Location = new System.Drawing.Point(540, 53);
            this.Tiposudoku.Margin = new System.Windows.Forms.Padding(2);
            this.Tiposudoku.Name = "Tiposudoku";
            this.Tiposudoku.Size = new System.Drawing.Size(92, 21);
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
            this.Tamaño.Location = new System.Drawing.Point(540, 82);
            this.Tamaño.Margin = new System.Windows.Forms.Padding(2);
            this.Tamaño.Name = "Tamaño";
            this.Tamaño.Size = new System.Drawing.Size(92, 21);
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
            "Difícil"});
            this.Cantidad_celdas_vacias.Location = new System.Drawing.Point(540, 110);
            this.Cantidad_celdas_vacias.Margin = new System.Windows.Forms.Padding(2);
            this.Cantidad_celdas_vacias.Name = "Cantidad_celdas_vacias";
            this.Cantidad_celdas_vacias.Size = new System.Drawing.Size(92, 21);
            this.Cantidad_celdas_vacias.TabIndex = 13;
            // 
            // Tablero
            // 
            this.Tablero.Location = new System.Drawing.Point(22, 81);
            this.Tablero.Margin = new System.Windows.Forms.Padding(2);
            this.Tablero.Name = "Tablero";
            this.Tablero.Size = new System.Drawing.Size(392, 425);
            this.Tablero.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(455, 381);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tiempo en hallar la solución";
            // 
            // LbTiempoTranscurrido
            // 
            this.LbTiempoTranscurrido.AutoSize = true;
            this.LbTiempoTranscurrido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTiempoTranscurrido.Location = new System.Drawing.Point(521, 401);
            this.LbTiempoTranscurrido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LbTiempoTranscurrido.Name = "LbTiempoTranscurrido";
            this.LbTiempoTranscurrido.Size = new System.Drawing.Size(65, 20);
            this.LbTiempoTranscurrido.TabIndex = 16;
            this.LbTiempoTranscurrido.Text = "0.00 ms";
            // 
            // BtnReiniciarSudoku
            // 
            this.BtnReiniciarSudoku.BackColor = System.Drawing.Color.LightGray;
            this.BtnReiniciarSudoku.Enabled = false;
            this.BtnReiniciarSudoku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReiniciarSudoku.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.BtnReiniciarSudoku.Location = new System.Drawing.Point(480, 260);
            this.BtnReiniciarSudoku.Margin = new System.Windows.Forms.Padding(2);
            this.BtnReiniciarSudoku.Name = "BtnReiniciarSudoku";
            this.BtnReiniciarSudoku.Size = new System.Drawing.Size(137, 37);
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
            this.label10.Location = new System.Drawing.Point(496, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 18);
            this.label10.TabIndex = 18;
            this.label10.Text = "Configuración";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(137, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Tablero de Sudoku";
            // 
            // Rinfo
            // 
            this.Rinfo.AutoSize = true;
            this.Rinfo.Location = new System.Drawing.Point(78, 40);
            this.Rinfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Rinfo.Name = "Rinfo";
            this.Rinfo.Size = new System.Drawing.Size(10, 13);
            this.Rinfo.TabIndex = 21;
            this.Rinfo.Text = "-";
            // 
            // BtnGenerarSudoku
            // 
            this.BtnGenerarSudoku.BackColor = System.Drawing.Color.LightGray;
            this.BtnGenerarSudoku.Enabled = false;
            this.BtnGenerarSudoku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerarSudoku.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerarSudoku.Location = new System.Drawing.Point(480, 155);
            this.BtnGenerarSudoku.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGenerarSudoku.Name = "BtnGenerarSudoku";
            this.BtnGenerarSudoku.Size = new System.Drawing.Size(137, 37);
            this.BtnGenerarSudoku.TabIndex = 22;
            this.BtnGenerarSudoku.Text = "Generar Sudoku";
            this.BtnGenerarSudoku.UseVisualStyleBackColor = false;
            // 
            // LbEstadoPrograma
            // 
            this.LbEstadoPrograma.AutoSize = true;
            this.LbEstadoPrograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbEstadoPrograma.Location = new System.Drawing.Point(88, 63);
            this.LbEstadoPrograma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LbEstadoPrograma.Name = "LbEstadoPrograma";
            this.LbEstadoPrograma.Size = new System.Drawing.Size(263, 16);
            this.LbEstadoPrograma.TabIndex = 26;
            this.LbEstadoPrograma.Text = "Sudoku no generado. Configura su Sudoku";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(673, 525);
            this.Controls.Add(this.LbEstadoPrograma);
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
            this.Controls.Add(this.BtnSolucionSudoku);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Rinfo3);
            this.Controls.Add(this.Rinfo2);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Label LbEstadoPrograma;
    }
}

