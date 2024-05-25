using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sudoku_pro
{
    public partial class Form1 : Form
    {
        private string tipoSudoku;
        public int gridSize;
        public int subMatrixSize;
        public int[,] tablero;
        private int[,] solucion;
        private int[,] primeraSubmatrizRecortada;
        private int newSize;
        private int panelSize;
        private int cellSize;
        private int x, y;
        private string numeroStr;
        private SizeF textSize;
        float textX;
        float textY;
        List<int> numeros;
        int startRow;
        int startCol;
        Random rand = new Random();
        int fila, columna;
        private double porcentajeEliminar;
        private int celdasEliminar;
        private bool sudokuGenerado = false;
        public bool sudokuAnswered = false;
        private bool movimientosVisibles = false;
        private const int aumentoAncho = 357;
        private double pesoVariable = 1;

        Stopwatch stopwatch;
        SudokuSolver solver;

        /*77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
        INICIO DE PANTALLA CON BOTONES Y CONBOBOXES CONTROLADOS
        77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777*/
        public Form1()
        {
            InitializeComponent();

            this.Width = 689;
            this.Height = 564;

            Tiposudoku.SelectedIndexChanged += Tiposudoku_SelectedIndexChanged;
            Tamaño.SelectedIndexChanged += Tamaño_SelectedIndexChanged;
            Cantidad_celdas_vacias.SelectedIndexChanged += Cantidad_celdas_vacias_SelectedIndexChanged;
            BtnGenerarSudoku.Click += BtnGenerarSudoku_Click;

            Tablero.Paint += Tablero_Paint;

            Tiposudoku.SelectedIndex = Tiposudoku.FindStringExact("Ninguno");
        }

        /*77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
        CONBOBOXES CONFIGURACION DE SUDOKU
        77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777*/
        private void Tiposudoku_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tiposudoku.SelectedItem != null)
            {
                tipoSudoku = Tiposudoku.SelectedItem.ToString();

                if (tipoSudoku == "Clásico")
                {
                    Rinfo.Text = " Clásico";
                }
                else if (tipoSudoku == "Submatriz")
                {
                    Rinfo.Text = " Submatriz";
                }
                else if (tipoSudoku == "Ninguno")
                {
                    Rinfo.Text = " Ninguno";
                }

                if (tipoSudoku != "Ninguno")
                {
                    LbEstadoPrograma.Text = "Configurando Sudoku";
                    Tamaño.Enabled = true;
                    Tamaño.BackColor = Color.White;
                }
                else
                {
                    Tamaño.Enabled = false;
                    Tamaño.BackColor = Color.LightGray;
                }
            }
        }

        private void Tamaño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tamaño.SelectedItem != null)
            {
                newSize = Convert.ToInt32(Tamaño.SelectedItem.ToString());

                if (tipoSudoku == "Clásico")
                {
                    gridSize = newSize;
                    subMatrixSize = (int)Math.Sqrt(newSize);
                }
                else if (tipoSudoku == "Submatriz")
                {
                    subMatrixSize = newSize;
                    gridSize = newSize * newSize;
                }

                Rinfo2.Text = "Tamaño " + newSize + "x" + newSize;

                Cantidad_celdas_vacias.Enabled = true;
                Cantidad_celdas_vacias.BackColor = Color.White;
            }
        }

        private void Cantidad_celdas_vacias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cantidad_celdas_vacias.SelectedItem != null)
            {
                Rinfo3.Text = "Dificultad " + Cantidad_celdas_vacias.SelectedItem.ToString();

                BtnGenerarSudoku.Enabled = true;
                BtnGenerarSudoku.BackColor = Color.Gold;
            }
        }

        private void ReiniciarComboBoxes()
        {
            if (Tiposudoku.Items.Count > 0)
            {
                Tiposudoku.SelectedIndex = 0;
                Rinfo.Text = Tiposudoku.SelectedItem.ToString();
            }

            if (Tamaño.Items.Count > 0)
            {
                Tamaño.SelectedIndex = -1;
                Rinfo2.Text = "-";
            }

            if (Cantidad_celdas_vacias.Items.Count > 0)
            {
                Cantidad_celdas_vacias.SelectedIndex = -1;
                Rinfo3.Text = "-";
            }

            pesoVariable = 1;
            porcentajeEliminar = 0;
        }

        /*77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
        BOTONES DE GENERACIÓN U SOLUCIONADOR INTELIGENTE
        77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777*/
        private void BtnGenerarSudoku_Click(object sender, EventArgs e)
        {
            GenerarSudoku();
            Tablero.Invalidate();
            sudokuGenerado = true;
            sudokuAnswered = false;

            LbEstadoPrograma.Text = "Sudoku generado";

            Tiposudoku.Enabled = false;
            Tamaño.Enabled = false;
            Cantidad_celdas_vacias.Enabled = false;
            
            BtnSolucionSudoku.Enabled = true;
            BtnSolucionSudoku.BackColor = Color.LightCoral;
            BtnReiniciarSudoku.Enabled = true;
            BtnReiniciarSudoku.BackColor = Color.YellowGreen;
            BtnGenerarSudoku.Enabled = false;
            BtnGenerarSudoku.BackColor = Color.LightGray;

            MessageBox.Show("El Sudoku ha sido generado correctamente. Ya puedes probar la inteligencia para resolverlo.", "Sudoku generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void BtnSolucionSudoku_Click_1(object sender, EventArgs e)
        {
            solver = new SudokuSolver(tablero, gridSize, subMatrixSize, Tablero);
            solver.MovimientoRealizado += Solver_MovimientoRealizado;
            stopwatch = new Stopwatch();

            if (sudokuAnswered == false)
            {
                BtnMovimientosSudoku.Enabled = true;
                BtnMovimientosSudoku.BackColor = Color.White;

                if (await solver.ResolverSudoku())
                {
                    stopwatch.Start();

                    LbEstadoPrograma.Text = "Por favor, espere. Buscando solución.";
                    tablero = solver.ObtenerSolucion();

                    stopwatch.Stop();

                    Tablero.Invalidate();

                    LbTiempoTranscurrido.Text = $"{stopwatch.Elapsed.TotalMilliseconds} ms";

                    LbEstadoPrograma.Text = "El Sudoku está resuelto.";

                    MessageBox.Show("El Sudoku ha sido resuelto.","Sudoku resuelto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sudokuAnswered = true;
                }
                else
                {
                    MessageBox.Show("No se puede resolver el Sudoku.", "Error - Sudoku no resuelto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El Sudoku ya está resuelto.", "Sudoku resuelto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnReiniciarSudoku_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro que quiere reiniciar la configuración del Sudoku? ¡Perderá el Sudoku actual generado!",
                "Confirmar Reinicio",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes && sudokuGenerado == true)
            {
                sudokuGenerado = false;
                sudokuAnswered = false;

                LimpiarTablero();

                Tiposudoku.Enabled = true;

                BtnReiniciarSudoku.Enabled = false;
                BtnReiniciarSudoku.BackColor = Color.LightGray;
                BtnMovimientosSudoku.Enabled = false;
                BtnMovimientosSudoku.BackColor = Color.LightGray;
                BtnSolucionSudoku.Enabled = false;
                BtnSolucionSudoku.BackColor = Color.LightGray;

                LbTiempoTranscurrido.Text = "0.00 ms";
                LbEstadoPrograma.Text = "Sudoku no generado. Configura su Sudoku";

                labelMovimientos.Visible = false;
                textBoxMovimientos.Visible = false;

                if(this.Width != 689)
                {
                    this.Width -= aumentoAncho;
                }
                CenterToScreen();
            }
        }

        private void BtnMovimientosSudoku_Click(object sender, EventArgs e)
        {
            movimientosVisibles = !movimientosVisibles;
            if (movimientosVisibles)
            {
                labelMovimientos.Visible = true;
                textBoxMovimientos.Visible = true;
                this.Width += aumentoAncho;
            }
            else
            {
                labelMovimientos.Visible = false;
                textBoxMovimientos.Visible = false;
                this.Width -= aumentoAncho;
            }
            CenterToScreen();
        }

        private void Solver_MovimientoRealizado(object sender, string e)
        {
            textBoxMovimientos.AppendText(e + Environment.NewLine);
        }

        /*77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
        GENERACION DE SUDOKUS - DIBUJO DE TABLERO - LIMPIEZA DE TABLERO
        77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777*/
        private void GenerarSudoku()
        {
            subMatrixSize = int.Parse(Tamaño.SelectedItem.ToString());
            gridSize = subMatrixSize * subMatrixSize;
            tablero = new int[gridSize, gridSize];
            solucion = new int[gridSize, gridSize];
            LlenarSudokuSubmatriz();

            if (Cantidad_celdas_vacias.SelectedItem != null)
            {
                EliminarCeldasSegunDificultad(Cantidad_celdas_vacias.SelectedItem.ToString());
            }
            else
            {
                EliminarCeldasSegunDificultad("Fácil");
            }

            if (tipoSudoku == "Clásico")
            {
                RecortarPrimeraSubmatriz();
            }

            Tablero.Invalidate();
        }

        private void Tablero_Paint(object sender, PaintEventArgs e)
        {
            if (gridSize <= 0)
            {
                return;
            }

            panelSize = Tablero.Width < Tablero.Height ? Tablero.Width : Tablero.Height;
            cellSize = panelSize / gridSize;

            if (tipoSudoku == "Clásico")
            {
                DibujarGrillaClasica(e.Graphics, subMatrixSize, cellSize);
            }
            else if (tipoSudoku == "Submatriz")
            {
                DibujarGrillaSubmatriz(e.Graphics, cellSize);
            }
        }

        private void LimpiarTablero()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    tablero[i, j] = 0;
                }
            }

            gridSize = 0;
            subMatrixSize = 0;

            Tablero.Invalidate();

            ReiniciarComboBoxes();
        }

        /*77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
        DIBUJADO DE GRILLAS PARA SUDOKUS
        77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777*/
        private void DibujarGrillaClasica(Graphics g, int gridSize, int cellSize)
        {
            if (tablero == null)
            {
                return;
            }

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    x = j * cellSize;
                    y = i * cellSize;

                    Rectangle rect = new Rectangle(x, y, cellSize, cellSize);
                    g.DrawRectangle(Pens.Black, rect);

                    if (tablero[i, j] != 0)
                    {
                        numeroStr = tablero[i, j].ToString();
                        textSize = g.MeasureString(numeroStr, Font);
                        textX = x + (cellSize - textSize.Width) / 2;
                        textY = y + (cellSize - textSize.Height) / 2;
                        g.DrawString(numeroStr, Font, Brushes.Black, textX, textY);
                    }
                }
            }
        }

        private void DibujarGrillaSubmatriz(Graphics g, int cellSize)
        {
            if (tablero == null)
            {
                return;
            }

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    x = j * cellSize;
                    y = i * cellSize;

                    Rectangle rect = new Rectangle(x, y, cellSize, cellSize);
                    g.DrawRectangle(Pens.Black, rect);

                    if ((j + 1) % subMatrixSize == 0 && j + 1 < gridSize)
                    {
                        g.DrawLine(new Pen(Color.Black, 2), x + cellSize, y, x + cellSize, y + cellSize);
                    }
                    if ((i + 1) % subMatrixSize == 0 && i + 1 < gridSize)
                    {
                        g.DrawLine(new Pen(Color.Black, 2), x, y + cellSize, x + cellSize, y + cellSize);
                    }

                    if (tablero[i, j] != 0)
                    {
                        numeroStr = tablero[i, j].ToString();
                        textSize = g.MeasureString(numeroStr, Font);
                        textX = x + (cellSize - textSize.Width) / 2;
                        textY = y + (cellSize - textSize.Height) / 2;
                        g.DrawString(numeroStr, Font, Brushes.Black, textX, textY);
                    }
                }
            }
        }

        /*77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
        LLENADO DE SUDOKU ANTES DE RESOLVER
        77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777*/
        
        //SUDOKU CLASICO
        private void RecortarPrimeraSubmatriz()
        {
            primeraSubmatrizRecortada = new int[subMatrixSize, subMatrixSize];

            for (int i = 0; i < subMatrixSize; i++)
            {
                for (int j = 0; j < subMatrixSize; j++)
                {
                    primeraSubmatrizRecortada[i, j] = tablero[i, j];
                }
            }
        }

        //SUDOKU POR SUBMATRICES
        private void LlenarSudokuSubmatriz()
        {
            tablero = new int[gridSize, gridSize];
            solucion = new int[gridSize, gridSize];

            if (LlenarTableroSubmatriz(0, 0))
            {
                Array.Copy(tablero, solucion, tablero.Length);
            }
            else
            {
                MessageBox.Show("No se pudo generar un Sudoku válido.");
            }
        }

        private bool LlenarTableroSubmatriz(int fila, int columna)
        {
            if (fila == gridSize)
                return true;

            if (columna == gridSize)
                return LlenarTableroSubmatriz(fila + 1, 0);

            numeros = Enumerable.Range(1, gridSize).OrderBy(a => Guid.NewGuid()).ToList();

            foreach (int numero in numeros)
            {
                if (EsNumeroValidoSubmatriz(fila, columna, numero))
                {
                    tablero[fila, columna] = numero;

                    if (LlenarTableroSubmatriz(fila, columna + 1))
                        return true;

                    tablero[fila, columna] = 0;
                }
            }

            return false;
        }

        private bool EsNumeroValidoSubmatriz(int fila, int columna, int num)
        {
            for (int x = 0; x < gridSize; x++)
            {
                if (tablero[fila, x] == num)
                    return false;
            }

            for (int x = 0; x < gridSize; x++)
            {
                if (tablero[x, columna] == num)
                    return false;
            }

            startRow = fila - (fila % subMatrixSize);
            startCol = columna - (columna % subMatrixSize);

            for (int i = 0; i < subMatrixSize; i++)
            {
                for (int j = 0; j < subMatrixSize; j++)
                {
                    if (tablero[startRow + i, startCol + j] == num)
                        return false;
                }
            }

            return true;
        }

        /*77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
        CONTROL DE CELDAS VACÍAS
        77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777*/
        private void EliminarCeldasSegunDificultad(string dificultad)
        {
            switch (dificultad)
            {
                case "Medio":
                    pesoVariable = 1;
                    break;
                case "Difícil":
                    pesoVariable = 3;
                    break;
                default:
                    pesoVariable = 1;
                    break;
            }
            switch (dificultad)
            {
                case "Medio":
                    porcentajeEliminar = 0.50 * pesoVariable; // 0.50 * 1 = 0.50 * 16 = 8
                    break;
                case "Difícil":
                    porcentajeEliminar = 0.25 * pesoVariable; // 0.25 * 3 = 0.75 * 16 = 12
                    break;
                default:
                    porcentajeEliminar = 0.25 * pesoVariable; // 0.25 * 1 = 0.25 * 16 =  4 
                    break;
            }

            celdasEliminar = (int)(porcentajeEliminar * gridSize * gridSize);

            for (int i = 0; i < celdasEliminar; i++)
            {
                /*
                 do
                {
                    fila    = rand.Next(gridSize);
                    columna = rand.Next(gridSize);

                    if (tablero[fila, columna] > 0)
                    {
                        tablero[fila, columna] = 0;
                    }

                } while (tablero[fila, columna] == 0);
                 */
                do
                {
                    fila    = (int)rand.Next ( gridSize );
                    columna = (int)rand.Next ( gridSize );
                } while (tablero[fila, columna] == 0);

                if (tablero[fila, columna] > 0)
                {
                    tablero[fila, columna] = 0;
                }
            }
        }
    }

        /*77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
        SOLUCIONADOR DE SUDOKU CON BACKTRACKING INTELIGENTE
        77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777*/
    public class SudokuSolver
    {
        private int[,] tablero;
        private int gridSize;
        private int subMatrixSize;
        private int startRow;
        private int startCol;
        private Panel tableroPanel;

        public event EventHandler<string> MovimientoRealizado;

        private void NotificarMovimiento(string mensaje)
        {
            MovimientoRealizado?.Invoke(this, mensaje);
        }

        public SudokuSolver(int[,] tablero, int gridSize, int subMatrixSize, Panel tableroPanel)
        {
            this.tablero = tablero;
            this.gridSize = gridSize;
            this.subMatrixSize = subMatrixSize;
            this.tableroPanel = tableroPanel;
        }

        public async Task<bool> ResolverSudoku()
        {
            return await Resolver(0, 0);
        }

        private async Task<bool> Resolver(int row, int col)
        {
            if (row == gridSize)
                return true;
            if (col == gridSize)
                return await Resolver(row + 1, 0);
            if (tablero[row, col] != 0)
                return await Resolver(row, col + 1);

            for (int num = 1; num <= gridSize; num++)
            {
                if (EsValido(row, col, num))
                {
                    tablero[row, col] = num;
                    NotificarMovimiento($"Se colocó {num} en la celda ({row},{col})");
                    // tableroPanel.Invalidate();
                    await Task.Delay(50);
                    /*if (num % 10 == 0)
                    {
                        await Task.Delay(50);
                    }*/
                    if (await Resolver(row, col + 1))
                        return true;
                    tablero[row, col] = 0;
                }
            }
            //await Task.Delay(50);

            return false;
        }

        private bool EsValido(int row, int col, int num)
        {
            for (int x = 0; x < gridSize; x++)
            {
                if (tablero[row, x] == num || tablero[x, col] == num)
                {
                    NotificarMovimiento($"El número {num} no es válido en la fila o columna ({row},{col})");
                    return false;
                }
            }

            startRow = row - row % subMatrixSize;
            startCol = col - col % subMatrixSize;
            for (int i = 0; i < subMatrixSize; i++)
            {
                for (int j = 0; j < subMatrixSize; j++)
                {
                    if (tablero[i + startRow, j + startCol] == num)
                    {
                        NotificarMovimiento($"El número {num} no es válido en la submatriz ({row},{col})");
                        return false;
                    }
                }
            }

            NotificarMovimiento($"El número {num} es válido en la celda ({row},{col})");
            return true;
        }

        public int[,] ObtenerSolucion()
        {
            return tablero;
        }
    }
}