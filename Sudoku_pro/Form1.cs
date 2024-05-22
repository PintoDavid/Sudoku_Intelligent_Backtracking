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
        private int gridSize;
        private int subMatrixSize;
        private int[,] tablero;
        private int[,] solucion;

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

        private void BtnGenerarSudoku_Click(object sender, EventArgs e)
        {
            GenerarSudoku();
            DibujarTablero();
            BtnSolucionSudoku.Enabled = true;
            BtnSolucionSudoku.BackColor = Color.LightCoral;
        }

        private void GenerarSudoku()
        {
            if (tipoSudoku == "Clásico")
            {
                gridSize = int.Parse(Tamaño.SelectedItem.ToString());
                subMatrixSize = (int)Math.Sqrt(gridSize); // Esto es importante para evitar dividir por cero
                tablero = new int[gridSize, gridSize];
                solucion = new int[gridSize, gridSize];
                LlenarSudokuClasico();
            }
            else if (tipoSudoku == "Submatriz")
            {
                subMatrixSize = int.Parse(Tamaño.SelectedItem.ToString());
                gridSize = subMatrixSize * subMatrixSize;
                tablero = new int[gridSize, gridSize];
                solucion = new int[gridSize, gridSize];
                LlenarSudokuSubmatriz();
            }

            // Aplicar la dificultad seleccionada
            if (Cantidad_celdas_vacias.SelectedItem != null)
            {
                string dificultad = Cantidad_celdas_vacias.SelectedItem.ToString();
                EliminarCeldasSegunDificultad(dificultad);
            }
            else
            {
                EliminarCeldasSegunDificultad("Fácil");
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

            int panelSize = Tablero.Width < Tablero.Height ? Tablero.Width : Tablero.Height;
            int cellSize = panelSize / gridSize;

            if (tipoSudoku == "Clásico")
            {
                DibujarGrillaClasica(e.Graphics, gridSize, cellSize);
            }
            else if (tipoSudoku == "Submatriz")
            {
                DibujarGrillaSubmatriz(e.Graphics, cellSize);
            }
        }

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
                    int x = j * cellSize;
                    int y = i * cellSize;

                    Rectangle rect = new Rectangle(x, y, cellSize, cellSize);
                    g.DrawRectangle(Pens.Black, rect);

                    if (tablero[i, j] != 0)
                    {
                        string numeroStr = tablero[i, j].ToString();
                        SizeF textSize = g.MeasureString(numeroStr, Font);
                        float textX = x + (cellSize - textSize.Width) / 2;
                        float textY = y + (cellSize - textSize.Height) / 2;
                        g.DrawString(numeroStr, Font, Brushes.Black, textX, textY);
                    }
                }
            }
        }

        private void DibujarGrillaSubmatriz(Graphics g, int cellSize)
        {
            if (tablero == null)
            {
                Console.WriteLine("Error: tablero es nulo en DibujarGrillaSubmatriz");
                return;
            }

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    int x = j * cellSize;
                    int y = i * cellSize;

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
                        string numeroStr = tablero[i, j].ToString();
                        SizeF textSize = g.MeasureString(numeroStr, Font);
                        float textX = x + (cellSize - textSize.Width) / 2;
                        float textY = y + (cellSize - textSize.Height) / 2;
                        g.DrawString(numeroStr, Font, Brushes.Black, textX, textY);
                    }
                }
            }
        }

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
                int newSize = Convert.ToInt32(Tamaño.SelectedItem.ToString());

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

        private void LlenarSudokuClasico()
        {
            List<int> numerosDisponibles = Enumerable.Range(1, gridSize * gridSize).ToList();
            LlenarTableroClasico(0, 0, numerosDisponibles);
            Array.Copy(tablero, solucion, tablero.Length);
        }

        private bool LlenarTableroClasico(int row, int col, List<int> numerosDisponibles)
        {
            if (row == gridSize)
            {
                return true;
            }

            int nextRow = (col == gridSize - 1) ? row + 1 : row;
            int nextCol = (col == gridSize - 1) ? 0 : col + 1;

            foreach (int number in numerosDisponibles.ToList())
            {
                if (EsValido(row, col, number))
                {
                    tablero[row, col] = number;
                    numerosDisponibles.Remove(number);
                    if (LlenarTableroClasico(nextRow, nextCol, numerosDisponibles))
                    {
                        return true;
                    }
                    tablero[row, col] = 0;
                    numerosDisponibles.Add(number);
                }
            }

            return false;
        }

        private void LlenarSudokuSubmatriz()
        {
            for (int fila = 0; fila < gridSize; fila++)
            {
                for (int columna = 0; columna < gridSize; columna++)
                {
                    bool numColocado = false;
                    for (int numero = 1; numero <= gridSize; numero++)
                    {
                        if (EsNumeroValidoSubmatriz(fila, columna, numero))
                        {
                            tablero[fila, columna] = numero;
                            solucion[fila, columna] = numero;
                            numColocado = true;
                            break;
                        }
                    }
                    if (!numColocado)
                    {
                        // Si no se puede colocar un número, limpiar y reiniciar
                        Array.Clear(tablero, 0, tablero.Length);
                        fila = 0;
                        columna = -1;
                    }
                }
            }
        }

        private bool EsNumeroValidoSubmatriz(int fila, int columna, int num)
        {
            // Verificar si el número ya está en la fila y la columna
            for (int x = 0; x < gridSize; x++)
            {
                if (tablero[fila, x] == num || tablero[x, columna] == num)
                {
                    return false;
                }
            }

            // Verificar si el número ya está en la submatriz
            int startRow = fila - (fila % subMatrixSize);
            int startCol = columna - (columna % subMatrixSize);

            for (int i = 0; i < subMatrixSize; i++)
            {
                for (int j = 0; j < subMatrixSize; j++)
                {
                    if (tablero[i + startRow, j + startCol] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool LlenarTableroSubmatriz(int fila, int columna)
        {
            if (fila == gridSize) return true;
            if (columna == gridSize) return LlenarTableroSubmatriz(fila + 1, 0);

            List<int> numeros = Enumerable.Range(1, gridSize).ToList();
            numeros = numeros.OrderBy(a => Guid.NewGuid()).ToList(); // Mezclar números aleatoriamente

            foreach (int num in numeros)
            {
                if (EsNumeroValidoSubmatriz(fila, columna, num))
                {
                    tablero[fila, columna] = num;
                    if (LlenarTableroSubmatriz(fila, columna + 1)) return true;
                    tablero[fila, columna] = 0; // Deshacer el movimiento
                }
            }
            return false;
        }

        private bool EsValido(int fila, int columna, int numero)
        {
            for (int x = 0; x < gridSize; x++)
            {
                if (tablero[fila, x] == numero || tablero[x, columna] == numero)
                {
                    return false;
                }
            }

            int startRow = fila - fila % subMatrixSize;
            int startCol = columna - columna % subMatrixSize;

            for (int i = 0; i < subMatrixSize; i++)
            {
                for (int j = 0; j < subMatrixSize; j++)
                {
                    if (tablero[i + startRow, j + startCol] == numero)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void EliminarCeldasSegunDificultad(string dificultad)
        {
            double porcentajeEliminar;

            switch (dificultad)
            {
                case "Fácil":
                    porcentajeEliminar = 0.3; // Porcentaje de celdas a eliminar para dificultad Fácil (30%)
                    break;
                case "Medio":
                    porcentajeEliminar = 0.5; // Porcentaje de celdas a eliminar para dificultad Medio (50%)
                    break;
                case "Difícil":
                    porcentajeEliminar = 0.7; // Porcentaje de celdas a eliminar para dificultad Difícil (70%)
                    break;
                default:
                    porcentajeEliminar = 0.3; // Por defecto, eliminar el 30%
                    break;
            }

            int celdasEliminar = (int)(porcentajeEliminar * gridSize * gridSize);

            Random rand = new Random();
            for (int i = 0; i < celdasEliminar; i++)
            {
                int fila, columna;
                do
                {
                    fila = rand.Next(gridSize);
                    columna = rand.Next(gridSize);
                } while (tablero[fila, columna] == 0);

                tablero[fila, columna] = 0;
            }
        }

        /*Llena en el tablero los números con backtracking*/
        private bool LlenarSudokuClasico(int fila, int columna)
        {
            List<int> numerosDisponibles = Enumerable.Range(1, gridSize * gridSize).ToList();
            numerosDisponibles = numerosDisponibles.OrderBy(a => Guid.NewGuid()).ToList(); // Mezclar números aleatoriamente

            if (fila == gridSize)
            {
                return true; // Todas las filas se han llenado, Sudoku completo
            }

            if (columna == gridSize)
            {
                return LlenarSudokuClasico(fila + 1, 0); // Pasar a la siguiente fila
            }

            foreach (int num in numerosDisponibles)
            {
                // Verificar si el número no existe en ninguna celda del tablero
                bool numeroValido = true;
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        if (tablero[i, j] == num)
                        {
                            numeroValido = false;
                            break;
                        }
                    }
                    if (!numeroValido) break; // Si ya se encontró el número en el tablero, no es necesario seguir buscando
                }

                if (numeroValido)
                {
                    tablero[fila, columna] = num;

                    if (LlenarSudokuClasico(fila, columna + 1))
                    {
                        return true; // Sudoku completado
                    }

                    tablero[fila, columna] = 0; // Deshacer el movimiento
                }
            }

            return false; // No se puede completar el Sudoku con los números disponibles
        }

        private bool LlenarSudokuSubmatriz(int fila, int columna)
        {
            if (fila == gridSize) return true;
            if (columna == gridSize) return LlenarSudokuSubmatriz(fila + 1, 0);

            List<int> numeros = Enumerable.Range(1, gridSize).ToList();
            numeros = numeros.OrderBy(a => Guid.NewGuid()).ToList(); // Mezclar números aleatoriamente

            foreach (int num in numeros)
            {
                if (EsNumeroValidoSubmatriz(fila, columna, num))
                {
                    tablero[fila, columna] = num;
                    if (LlenarSudokuSubmatriz(fila, columna + 1)) return true;
                    tablero[fila, columna] = 0; // Deshacer el movimiento
                }
            }
            return false;
        }
    }
}