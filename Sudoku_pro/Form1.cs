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
        private float removalPercentage = 0;
        private int cellstoremove = 0;
        private static Random random = new Random();
        
        public Form1()
        {
            InitializeComponent();
            Tiposudoku.SelectedIndexChanged += Tiposudoku_SelectedIndexChanged;
            Tiposudoku.SelectedIndex = Tiposudoku.FindStringExact("Nada");

            // Inicializar la matriz del tablero con el tamaño 3x3 (tamaño inicial del Sudoku)






        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //////////////////////////////////////////////////////////////////////////////////////

        /*Generación de números con backtracking*/
        private void GenerarSudoku()
        {
            if (tablero == null)
            {
                return; // Evitar generar Sudoku si el tablero no está inicializado
            }

            if (tipoSudoku == "Clásico")
            {

                LlenarSudokuClasico(0, 0);
            }
            else if (tipoSudoku == "Submatriz")
            {
                LlenarSudokuSubmatriz(0, 0);
            }
            // Verificar si Cantidad_celdas_vacias.SelectedItem no es null
            if (Cantidad_celdas_vacias.SelectedItem != null)
            {
                string dificultad = Cantidad_celdas_vacias.SelectedItem.ToString();
                // Llamar a la función para eliminar celdas según la dificultad
                EliminarCeldasSegunDificultad(dificultad);
            }
            else
            {
                // Manejar el caso en que no se haya seleccionado ninguna dificultad
                // Por ejemplo, podrías asignar una dificultad predeterminada
                EliminarCeldasSegunDificultad("Fácil"); // o "Medio" o "Difícil"
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

        private bool EsNumeroValidoSubmatriz(int fila, int columna, int num)
        {
            // Verificar fila
            for (int i = 0; i < gridSize; i++)
            {
                if (tablero[fila, i] == num) return false;
            }

            // Verificar columna
            for (int i = 0; i < gridSize; i++)
            {
                if (tablero[i, columna] == num) return false;
            }

            // Verificar submatriz
            int subMatrixRowStart = (fila / subMatrixSize) * subMatrixSize;
            int subMatrixColStart = (columna / subMatrixSize) * subMatrixSize;

            for (int i = 0; i < subMatrixSize; i++)
            {
                for (int j = 0; j < subMatrixSize; j++)
                {
                    if (tablero[subMatrixRowStart + i, subMatrixColStart + j] == num) return false;
                }
            }

            return true;
        }






        ////////////////////////////////////////////////////////////////////////////////////

        private void ActualizarTamañoClasico(int newSize)
        {
            if (newSize <= 0) return; // Evitar tamaños no válidos

            gridSize = newSize;

            // Inicializar el tablero con el tamaño correcto
            tablero = new int[gridSize, gridSize];

            // Generar un nuevo Sudoku
            GenerarSudoku();

            // Volver a dibujar la grilla clásica con el nuevo tamaño
            if (Tiposudoku.SelectedItem.ToString() == "Clásico")
            {
                Tablero.Invalidate(); // Esto dispara el evento Paint del Panel "tablero"
            }
        }



        private void DibujarGrillaClasica(Graphics g, int gridSize, int cellSize)
        {
            if (tablero == null)
            {
                // Tablero no inicializado, salir de la función
                return;
            }

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    int x = j * cellSize; // Posición horizontal de la celda
                    int y = i * cellSize; // Posición vertical de la celda

                    Rectangle rect = new Rectangle(x, y, cellSize, cellSize);
                    g.DrawRectangle(Pens.Black, rect); // Dibuja el borde de la celda

                    // Dibuja el número del tablero en la celda
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


        private int[,] tablero;
        private int gridSize = 3; // Tamaño inicial de la cuadrícula
        private void ActualizarTamañoSubmatriz(int newSize)
        {
            if (newSize <= 0) return; // Evitar tamaños no válidos

            subMatrixSize = newSize;

            // Actualizar gridSize según el tamaño de la submatriz
            if (subMatrixSize == 3)
            {
                gridSize = 9;
            }
            else if (subMatrixSize == 2)
            {
                gridSize = 4;
            }
            else if (subMatrixSize == 4)
            {
                gridSize = 16;
            }

            // Inicializar el tablero con el tamaño correcto
            tablero = new int[gridSize, gridSize];

            // Generar un nuevo Sudoku
            GenerarSudoku();

            // Agregar una declaración de depuración para verificar si se está llamando correctamente
            Console.WriteLine("ActualizarTamañoSubmatriz llamado. Tamaño del tablero: " + gridSize);

            // Volver a dibujar la grilla de submatriz con el nuevo tamaño
            if (Tiposudoku.SelectedItem.ToString() == "Submatriz")
            {
                Tablero.Invalidate(); // Esto dispara el evento Paint del Panel "tablero"
            }
        }

        private int subMatrixSize = 1; // Para dividir las submatrices
        private void DibujarGrillaSubmatriz(Graphics g, int cellSize)
        {
            // Verificar si tablero es nulo
            if (tablero == null)
            {
                // Si es nulo, mostrar un mensaje de error y salir del método
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
                    g.DrawRectangle(Pens.Black, rect); // Dibuja el borde de la celda

                    // Dibuja líneas adicionales para las submatrices
                    if ((j + 1) % subMatrixSize == 0 && j + 1 < gridSize)
                    {
                        // Dibuja una línea más gruesa para resaltar la división horizontal de la submatriz
                        g.DrawLine(new Pen(Color.Black, 2), x + cellSize, y, x + cellSize, y + cellSize);
                    }
                    if ((i + 1) % subMatrixSize == 0 && i + 1 < gridSize)
                    {
                        // Dibuja una línea más gruesa para resaltar la división vertical de la submatriz
                        g.DrawLine(new Pen(Color.Black, 2), x, y + cellSize, x + cellSize, y + cellSize);
                    }

                    // Dibuja el número en el centro de la celda si no es 0
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

        private void Tablero_Paint(object sender, PaintEventArgs e)
        {
            if (gridSize <= 0)
            {
                // Mostrar el mensaje de bienvenida cuando no se ha seleccionado un tipo de sudoku
                string welcomeMessage = "Bienvenido, escoja el tipo de sudoku";
                SizeF textSize = e.Graphics.MeasureString(welcomeMessage, Font);

                float x = (Tablero.Width - textSize.Width) / 2;
                float y = (Tablero.Height - textSize.Height) / 2;

                e.Graphics.DrawString(welcomeMessage, Font, Brushes.Black, x, y);
            }
            else
            {
                // Dibujar la cuadrícula según el tamaño seleccionado
                int cellSize = Math.Min(Tablero.Width / gridSize - 1, Tablero.Height / gridSize - 1); // Tamaño de cada celda

                Graphics g = e.Graphics;

                if (Tiposudoku.SelectedItem != null)
                {
                    string selectedValue = Tiposudoku.SelectedItem.ToString();

                    if (selectedValue == "Clásico")
                    {
                        // Generar un nuevo Sudoku si aún no se ha generado
                        if (tablero == null)
                        {
                            GenerarSudoku();
                        }

                        DibujarGrillaClasica(g, gridSize, cellSize);
                    }
                    else if (selectedValue == "Submatriz")
                    {
                        // Generar un nuevo Sudoku si aún no se ha generado
                        if (tablero == null)
                        {
                            GenerarSudoku();
                        }

                        DibujarGrillaSubmatriz(g, cellSize);
                    }
                }

                // Llamar a la función para determinar el tipo de matriz
                DeterminarTipoMatriz();
            }
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }



        private void Tamaño_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                // Obtener el valor seleccionado del ComboBox
                string selectedValue = comboBox.SelectedItem.ToString();

                // Convertir el valor seleccionado a un número (puede ser un try-catch si hay posibilidad de error)
                int newSize = Convert.ToInt32(selectedValue);

                // Llamar al método correspondiente para actualizar el tamaño de la cuadrícula
                if (Tiposudoku.SelectedItem.ToString() == "Clásico")
                {
                    ActualizarTamañoClasico(newSize);
                }
                else if (Tiposudoku.SelectedItem.ToString() == "Submatriz")
                {
                    ActualizarTamañoSubmatriz(newSize);
                }
            }
        }


        private string tipoSudoku = "Nada"; // Por defecto, el tipo es "Nada"

        // Manejar la selección del tipo de Sudoku
        private void Tiposudoku_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tiposudoku.SelectedItem != null)
            {
                tipoSudoku = Tiposudoku.SelectedItem.ToString();

                if (tipoSudoku == "Clásico")
                {
                    gridSize = 2; // Tamaño típico para Sudoku clásico
                    Rinfo.Text = " Clásico";
                }
                else if (tipoSudoku == "Submatriz")
                {
                    gridSize = 4; // Tamaño ejemplo para una submatriz 2x2
                    subMatrixSize = 2; // Tamaño de la submatriz
                    Rinfo.Text = " Submatriz";
                }
                else if (tipoSudoku == "Nada")
                {
                    gridSize = 0;
                    Rinfo.Text = " Nada";
                }

                // Inicializar el tablero con el tamaño correcto
                if (gridSize > 0)
                {
                    tablero = new int[gridSize, gridSize];
                    GenerarSudoku();
                }

                // Volver a dibujar la grilla con la nueva configuración
                Tablero.Invalidate();

                // Determinar el tipo de matriz y actualizar el Label Rinfo2
                DeterminarTipoMatriz();
            }
        }


        private int CalcularTotalCeldas()
        {
            if (Tiposudoku.SelectedItem.ToString() == "Clásico")
            {
                return gridSize * gridSize;
            }
            else if (Tiposudoku.SelectedItem.ToString() == "Submatriz")
            {
                // Cada submatriz cuenta como una sola celda
                return gridSize * gridSize;
            }
            else
            {
                return 0; // Otra opción no válida
            }
        }
        private void DeterminarTipoMatriz()
        {
            int totalCeldas = CalcularTotalCeldas(); // Calcula el total de celdas según el tipo de sudoku

            string tipoMatriz = ""; // Variable para almacenar el tipo de matriz

            // Determina el tipo de matriz según el número total de celdas
            if (Tiposudoku.SelectedItem.ToString() == "Clásico")
            {
                if (totalCeldas == 4)
                {
                    tipoMatriz = "Matriz 2x2";
                }
                else if (totalCeldas == 9)
                {
                    tipoMatriz = "Matriz 3x3";
                }
                else if (totalCeldas == 16)
                {
                    tipoMatriz = "Matriz 4x4";
                }
            }
            else if (Tiposudoku.SelectedItem.ToString() == "Submatriz")
            {
                if (totalCeldas == 16)
                {
                    tipoMatriz = "Matriz 2x2";
                }
                else if (totalCeldas == 81)
                {
                    tipoMatriz = "Matriz 3x3";
                }
                else if (totalCeldas == 256)
                {
                    tipoMatriz = "Matriz 4x4";
                }
            }

            // Actualiza el texto del Label Rinfo2 con el tipo de matriz
            Rinfo2.Text = tipoMatriz;
        }

        /*Eliminación de numeros en celdas*/
       private void Cantidad_celdas_vacias_SelectedIndexChanged_1(object sender, EventArgs e)
{
    if (Cantidad_celdas_vacias.SelectedItem != null)
    {  
        string dificultad = Cantidad_celdas_vacias.SelectedItem.ToString();

        if (dificultad == "Fácil")
        {
            RInfo3.Text = "Dificultad " + dificultad;
        }
        else if (dificultad == "Medio")
        {
            RInfo3.Text = "Dificultad " + dificultad;
        }
        else if (dificultad == "Difícil")
        {
            RInfo3.Text = "Dificultad " + dificultad;
        }

        // Llamar a la función para eliminar celdas según la dificultad
        EliminarCeldasSegunDificultad(dificultad);
    }
}

        private void EliminarCeldasSegunDificultad(string dificultad)
        {
            // Determinar el porcentaje de celdas a eliminar según la dificultad
            float removalPercentage = 0;
            switch (dificultad)
            {
                case "Fácil":
                    removalPercentage = 0.4F;
                    break;
                case "Medio":
                    removalPercentage = 0.6F;
                    break;
                case "Difícil":
                    removalPercentage = 0.8F;
                    break;
                default:
                    // Si la dificultad no está definida, no eliminamos ninguna celda
                    return;
            }

            // Calcular el número de celdas a eliminar
            int totalCeldas = gridSize * gridSize;
            int celdasAEliminar = (int)(totalCeldas * removalPercentage);

            Random random = new Random();
            while (celdasAEliminar > 0)
            {
                int fila = random.Next(0, gridSize);
                int columna = random.Next(0, gridSize);

                // Eliminar solo si la celda no está ya vacía
                if (tablero[fila, columna] != 0)
                {
                    tablero[fila, columna] = 0;
                    celdasAEliminar--;
                }
            }

            // Opcional: Puedes agregar mensajes de depuración para verificar el número de celdas eliminadas
            Console.WriteLine($"Celdas eliminadas: {totalCeldas - celdasAEliminar}, Celdas restantes: {celdasAEliminar}");
        }

        /*7777777777777777777777777777777777777777777777777777777777777777777777*/


        private void Rinfo_Click(object sender, EventArgs e)
            {

            }

        private void RInfo3_Click(object sender, EventArgs e)
        {

        }
    }
    }
