
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
            this.RInfo3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Tiposudoku = new System.Windows.Forms.ComboBox();
            this.Tamaño = new System.Windows.Forms.ComboBox();
            this.Cantidad_celdas_vacias = new System.Windows.Forms.ComboBox();
            this.Tablero = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Rinfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Rinfo2
            // 
            this.Rinfo2.AutoSize = true;
            this.Rinfo2.Location = new System.Drawing.Point(270, 103);
            this.Rinfo2.Name = "Rinfo2";
            this.Rinfo2.Size = new System.Drawing.Size(13, 17);
            this.Rinfo2.TabIndex = 1;
            this.Rinfo2.Text = "-";
            this.Rinfo2.Click += new System.EventHandler(this.label2_Click);
            // 
            // RInfo3
            // 
            this.RInfo3.AutoSize = true;
            this.RInfo3.Location = new System.Drawing.Point(454, 103);
            this.RInfo3.Name = "RInfo3";
            this.RInfo3.Size = new System.Drawing.Size(13, 17);
            this.RInfo3.TabIndex = 2;
            this.RInfo3.Text = "-";
            this.RInfo3.Click += new System.EventHandler(this.RInfo3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(640, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo de sudoku";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(621, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tamaño del sudoku";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(791, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "# de celdas vacías";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(621, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Dificultad";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(669, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "Solución con IA";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(857, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Historial";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Tiposudoku
            // 
            this.Tiposudoku.FormattingEnabled = true;
            this.Tiposudoku.Items.AddRange(new object[] {
            "Nada",
            "Clásico",
            "Submatriz"});
            this.Tiposudoku.Location = new System.Drawing.Point(752, 201);
            this.Tiposudoku.Name = "Tiposudoku";
            this.Tiposudoku.Size = new System.Drawing.Size(121, 24);
            this.Tiposudoku.TabIndex = 11;
            this.Tiposudoku.SelectedIndexChanged += new System.EventHandler(this.Tiposudoku_SelectedIndexChanged);
            // 
            // Tamaño
            // 
            this.Tamaño.FormattingEnabled = true;
            this.Tamaño.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.Tamaño.Location = new System.Drawing.Point(624, 319);
            this.Tamaño.Name = "Tamaño";
            this.Tamaño.Size = new System.Drawing.Size(121, 24);
            this.Tamaño.TabIndex = 12;
            this.Tamaño.SelectedIndexChanged += new System.EventHandler(this.Tamaño_SelectedIndexChanged);
            // 
            // Cantidad_celdas_vacias
            // 
            this.Cantidad_celdas_vacias.FormattingEnabled = true;
            this.Cantidad_celdas_vacias.Items.AddRange(new object[] {
            "Fácil",
            "Medio",
            "Dificíl"});
            this.Cantidad_celdas_vacias.Location = new System.Drawing.Point(795, 319);
            this.Cantidad_celdas_vacias.Name = "Cantidad_celdas_vacias";
            this.Cantidad_celdas_vacias.Size = new System.Drawing.Size(121, 24);
            this.Cantidad_celdas_vacias.TabIndex = 13;
            this.Cantidad_celdas_vacias.SelectedIndexChanged += new System.EventHandler(this.Cantidad_celdas_vacias_SelectedIndexChanged_1);
            // 
            // Tablero
            // 
            this.Tablero.Location = new System.Drawing.Point(28, 137);
            this.Tablero.Name = "Tablero";
            this.Tablero.Size = new System.Drawing.Size(523, 523);
            this.Tablero.TabIndex = 14;
            this.Tablero.Paint += new System.Windows.Forms.PaintEventHandler(this.Tablero_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(613, 587);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tiempo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(674, 587);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "0:00:00";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.YellowGreen;
            this.button5.Location = new System.Drawing.Point(775, 579);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(119, 33);
            this.button5.TabIndex = 17;
            this.button5.Text = "Reiniciar juego";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkCyan;
            this.label10.Location = new System.Drawing.Point(696, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 23);
            this.label10.TabIndex = 18;
            this.label10.Text = "Configuración";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(270, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "Tablero";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // Rinfo
            // 
            this.Rinfo.AutoSize = true;
            this.Rinfo.Location = new System.Drawing.Point(104, 103);
            this.Rinfo.Name = "Rinfo";
            this.Rinfo.Size = new System.Drawing.Size(13, 17);
            this.Rinfo.TabIndex = 21;
            this.Rinfo.Text = "-";
            this.Rinfo.Click += new System.EventHandler(this.Rinfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1023, 781);
            this.Controls.Add(this.Rinfo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Tablero);
            this.Controls.Add(this.Cantidad_celdas_vacias);
            this.Controls.Add(this.Tamaño);
            this.Controls.Add(this.Tiposudoku);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RInfo3);
            this.Controls.Add(this.Rinfo2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Rinfo2;
        private System.Windows.Forms.Label RInfo3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox Tiposudoku;
        private System.Windows.Forms.ComboBox Tamaño;
        private System.Windows.Forms.ComboBox Cantidad_celdas_vacias;
        private System.Windows.Forms.Panel Tablero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Rinfo;
    }
}

