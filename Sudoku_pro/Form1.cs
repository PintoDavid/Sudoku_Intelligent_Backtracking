using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        SudokuSolverSubmatriz solver;

        /*77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
        INICIO DE PANTALLA CON BOTONES Y CONBOBOXES CONTROLADOS
        77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777*/
        public Form1()
        {
            InitializeComponent();

            // Inicialmente, solo habilitar Tiposudoku
            Tiposudoku.Enabled = true;
            Tamaño.Enabled = false;
            Cantidad_celdas_vacias.Enabled = false;
            BtnGenerarSudoku.Enabled = false;
            BtnSolucionSudoku.Enabled = false;

            Tamaño.BackColor = Color.LightGray;
            Cantidad_celdas_vacias.BackColor = Color.LightGray;
            BtnGenerarSudoku.BackColor = Color.LightGray;
            BtnSolucionSudoku.BackColor = Color.LightGray;

            BtnGenerarSudoku.FlatStyle = FlatStyle.Flat;
            BtnGenerarSudoku.FlatAppearance.BorderSize = 0;

            BtnSolucionSudoku.FlatStyle = FlatStyle.Flat;
            BtnSolucionSudoku.FlatAppearance.BorderSize = 0;

            Tiposudoku.SelectedIndexChanged += Tiposudoku_SelectedIndexChanged;
            Tamaño.SelectedIndexChanged += Tamaño_SelectedIndexChanged;
            Cantidad_celdas_vacias.SelectedIndexChanged += Cantidad_celdas_vacias_SelectedIndexChanged;
            BtnGenerarSudoku.Click += BtnGenerarSudoku_Click;

            // Asocia el evento Paint del panel Tablero
            Tablero.Paint += Tablero_Paint;

            Tiposudoku.SelectedIndex = Tiposudoku.FindStringExact("Nada");
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
                else if (tipoSudoku == "Nada")
                {
                    Rinfo.Text = " Nada";
                }

                // Habilitar el ComboBox Tamaño
                if (tipoSudoku != "Nada")
                {
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

                // Actualizar variables internas sin generar Sudoku aún
                if (tipoSudoku == "Clásico")
                {
                    gridSize = newSize;
                    subMatrixSize = (int)Math.Sqrt(newSize); // Esto es importante para evitar dividir por cero
                }
                else if (tipoSudoku == "Submatriz")
                {
                    subMatrixSize = newSize;
                    gridSize = newSize * newSize;
                }

                Rinfo2.Text = "Tamaño " + newSize + "x" + newSize;

                // Habilitar el ComboBox Cantidad_celdas_vacias
                Cantidad_celdas_vacias.Enabled = true;
                Cantidad_celdas_vacias.BackColor = Color.White;
            }
        }

        /*77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
        BOTONES DE GENERACIÓN U SOLUCIONADOR INTELIGENTE
        77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777*/
        private void BtnGenerarSudoku_Click(object sender, EventArgs e)
        {
            GenerarSudoku();
            DibujarTablero();
            BtnSolucionSudoku.Enabled = true;
            BtnSolucionSudoku.BackColor = Color.LightCoral;
        }
        private void BtnSolucionSudoku_Click_1(object sender, EventArgs e)
        {
            solver = new SudokuSolverSubmatriz(tablero, gridSize, subMatrixSize);
            if (solver.ResolverSudoku())
            {
                tablero = solver.ObtenerSolucion();
                DibujarTablero();
            }
            else
            {
                MessageBox.Show("No se puede resolver el Sudoku.");
            }
        }

        /*77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
        GENERACION DE SUDOKUS - DIBUJO DE TABLERO
        77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777*/
        private void GenerarSudoku()
        {
            subMatrixSize = int.Parse(Tamaño.SelectedItem.ToString());
            gridSize = subMatrixSize * subMatrixSize;
            tablero = new int[gridSize, gridSize];
            solucion = new int[gridSize, gridSize];
            LlenarSudokuSubmatriz(); // Llenar usando la lógica de submatriz

            // Aplicar la dificultad seleccionada
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
                RecortarPrimeraSubmatriz(); // Recortar la primera submatriz de tamaño nxn
            }

            // Redibujar el tablero después de generar el Sudoku
            Tablero.Invalidate();
        }

        private void DibujarTablero()
        {
            Tablero.Invalidate();
        }

        private void Tablero_Paint(object sender, PaintEventArgs e)
        {
            // Verificar si gridSize tiene un valor válido
            if (gridSize <= 0)
            {
                // Salir del método si gridSize no es válido
                return;
            }

            panelSize = Tablero.Width < Tablero.Height ? Tablero.Width : Tablero.Height;
            cellSize = panelSize / gridSize;

            if (tipoSudoku == "Clásico")
            {
                DibujarGrillaClasica(e.Graphics, subMatrixSize, cellSize); // Dibujar la primera submatriz recortada
            }
            else if (tipoSudoku == "Submatriz")
            {
                DibujarGrillaSubmatriz(e.Graphics, cellSize);
            }
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
            // Inicializar el tablero y la solución
            tablero = new int[gridSize, gridSize];
            solucion = new int[gridSize, gridSize];

            // Intentar llenar el tablero utilizando backtracking
            if (LlenarTableroSubmatriz(0, 0))
            {
                // Si se llena correctamente, copiar la solución
                Array.Copy(tablero, solucion, tablero.Length);
            }
            else
            {
                Console.WriteLine("No se pudo generar un Sudoku válido.");
            }
        }

        private bool LlenarTableroSubmatriz(int fila, int columna)
        {
            // Si hemos llenado todas las filas, el tablero está completo
            if (fila == gridSize)
                return true;

            // Si hemos llegado al final de una fila, pasar a la siguiente fila
            if (columna == gridSize)
                return LlenarTableroSubmatriz(fila + 1, 0);

            // Generar una lista de números aleatorios del 1 al gridSize
            numeros = Enumerable.Range(1, gridSize).OrderBy(a => Guid.NewGuid()).ToList();

            foreach (int numero in numeros)
            {
                // Verificar si el número es válido en la posición actual
                if (EsNumeroValidoSubmatriz(fila, columna, numero))
                {
                    // Colocar el número en el tablero
                    tablero[fila, columna] = numero;

                    // Intentar llenar el resto del tablero
                    if (LlenarTableroSubmatriz(fila, columna + 1))
                        return true;

                    // Si no se puede continuar, deshacer el movimiento
                    tablero[fila, columna] = 0;
                }
            }

            // Si no se puede colocar ningún número válido, retornar falso
            return false;
        }

        private bool EsNumeroValidoSubmatriz(int fila, int columna, int num)
        {
            // Verificar si el número ya está en la fila
            for (int x = 0; x < gridSize; x++)
            {
                if (tablero[fila, x] == num)
                    return false;
            }

            // Verificar si el número ya está en la columna
            for (int x = 0; x < gridSize; x++)
            {
                if (tablero[x, columna] == num)
                    return false;
            }

            // Verificar si el número ya está en la submatriz
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
        private void Cantidad_celdas_vacias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cantidad_celdas_vacias.SelectedItem != null)
            {
                Rinfo3.Text = "Dificultad " + Cantidad_celdas_vacias.SelectedItem.ToString();

                // Habilitar el botón BtnGenerarSudoku
                BtnGenerarSudoku.Enabled = true;
                BtnGenerarSudoku.BackColor = Color.Gold;
            }
        }

        private void EliminarCeldasSegunDificultad(string dificultad)
        {
            switch (dificultad)
            {
                case "Fácil":
                    porcentajeEliminar = 0.25; // Porcentaje de celdas a eliminar para dificultad Fácil (25%)
                    break;
                case "Medio":
                    porcentajeEliminar = 0.5; // Porcentaje de celdas a eliminar para dificultad Medio (50%)
                    break;
                case "Difícil":
                    porcentajeEliminar = 0.75; // Porcentaje de celdas a eliminar para dificultad Difícil (75%)
                    break;
                default:
                    porcentajeEliminar = 0.25; // Por defecto, eliminar el 25%
                    break;
            }

            celdasEliminar = (int)(porcentajeEliminar * gridSize * gridSize);

            for (int i = 0; i < celdasEliminar; i++)
            {
                do
                {
                    fila = rand.Next(gridSize);
                    columna = rand.Next(gridSize);
                } while (tablero[fila, columna] == 0);

                tablero[fila, columna] = 0;
            }
        }
    }

        /*77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777
        SOLUCIONADOR DE SUDOKU CON BACKTRACKING INTELIGENTE
        77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777*/
    public class SudokuSolverSubmatriz
    {
        private int[,] tablero;
        private int gridSize;
        private int subMatrixSize;
        private int startRow;
        private int startCol;

        public SudokuSolverSubmatriz(int[,] tablero, int gridSize, int subMatrixSize)
        {
            this.tablero = tablero;
            this.gridSize = gridSize;
            this.subMatrixSize = subMatrixSize;
        }

        public bool ResolverSudoku()
        {
            return Resolver(0, 0);
        }

        private bool Resolver(int row, int col)
        {
            if (row == gridSize)
                return true;
            if (col == gridSize)
                return Resolver(row + 1, 0);
            if (tablero[row, col] != 0)
                return Resolver(row, col + 1);

            for (int num = 1; num <= gridSize; num++)
            {
                if (EsValido(row, col, num))
                {
                    tablero[row, col] = num;
                    if (Resolver(row, col + 1))
                        return true;
                    tablero[row, col] = 0;
                }
            }

            return false;
        }

        private bool EsValido(int row, int col, int num)
        {
            for (int x = 0; x < gridSize; x++)
            {
                if (tablero[row, x] == num || tablero[x, col] == num)
                    return false;
            }

            startRow = row - row % subMatrixSize;
            startCol = col - col % subMatrixSize;
            for (int i = 0; i < subMatrixSize; i++)
            {
                for (int j = 0; j < subMatrixSize; j++)
                {
                    if (tablero[i + startRow, j + startCol] == num)
                        return false;
                }
            }

            return true;
        }

        public int[,] ObtenerSolucion()
        {
            return tablero;
        }
    }
}