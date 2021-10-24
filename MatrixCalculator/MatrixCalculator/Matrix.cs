using System;
using System.Data;
using System.IO;
using System.Threading;

namespace MatrixCalculator
{
    /// <summary>Класс матрица.</summary>
    public class Matrix
    {
        //размерности матрицы.
        public int sizeN, sizeM;
        //значения элементов матрицы.
        public int[,] matrix;

        //переопределение некоторых операторов для матриц.
        public static Matrix operator +(Matrix a) => a;

        public static Matrix operator -(Matrix a)
        {
            Matrix b = new Matrix(a.sizeN, a.sizeM);
            for (int i = 0; i < a.sizeN; ++i)
            {
                for (int j = 0; j < a.sizeM; ++j)
                {
                    b.matrix[i, j] = -a.matrix[i, j];
                }
            }

            return b;
        }

        public static Matrix operator *(Matrix a, int c)
        {
            Matrix b = new Matrix(a.sizeN, a.sizeM);
            for (int i = 0; i < a.sizeN; ++i)
            {
                for (int j = 0; j < a.sizeM; ++j)
                {
                    b.matrix[i, j] = a.matrix[i, j] * c;
                }
            }

            return b;
        }

        public static Matrix operator *(int c, Matrix a)
        {
            Matrix b = new Matrix(a.sizeN, a.sizeM);
            for (int i = 0; i < a.sizeN; ++i)
            {
                for (int j = 0; j < a.sizeM; ++j)
                {
                    b.matrix[i, j] = a.matrix[i, j] * c;
                }
            }

            return b;
        }

        /// <summary>Ввод матрицы с консоли.</summary>
        /// <returns>Корректность ввода.</returns>
        public bool ConsoleReadMatrix()
        {
            string readLine = Console.ReadLine();
            string[] stringArray = readLine.Split(' ');
            if (stringArray.Length != 2)
                return false;
            if (!int.TryParse(stringArray[0], out sizeN) || sizeN < 0 || sizeN > 1000)
                return false;
            if (!int.TryParse(stringArray[1], out sizeM) || sizeM < 0 || sizeM > 1000)
                return false;
            int[,] newMatrix = new int[sizeN, sizeM];
            for (int i = 0; i < sizeN; ++i)
            {
                readLine = Console.ReadLine();
                stringArray = readLine.Split();
                int[] intArray = new int[stringArray.Length];
                if (stringArray.Length != sizeM)
                    return false;
                for (int j = 0; j < sizeM; ++j)
                {
                    if (!int.TryParse(stringArray[j], out intArray[j]))
                        return false;
                    newMatrix[i, j] = intArray[j];
                }
            }

            matrix = newMatrix;
            return true;
        }

        /// <summary>Ввод матрицы из файла.</summary>
        /// <param name="filename">Путь к файлу.</param>
        /// <returns>Корректность ввода.</returns>
        public bool FileReadMatrix(string filename)
        {
            if (!File.Exists(filename))
                return false;
            StreamReader sr = new StreamReader(filename, System.Text.Encoding.UTF8);
            string readLine;
            if ((readLine = sr.ReadLine()) == null)
            {
                return false;
            }

            string[] stringArray = readLine.Split(' ');
            if (stringArray.Length != 2)
                return false;
            if (!int.TryParse(stringArray[0], out sizeN) || sizeN < 0 || sizeN > 1000)
                return false;
            if (!int.TryParse(stringArray[1], out sizeM) || sizeM < 0 || sizeM > 1000)
                return false;

            int[,] newMatrix = new int[sizeN, sizeM];
            for (int i = 0; i < sizeN; ++i)
            {
                if ((readLine = sr.ReadLine()) == null)
                {
                    return false;
                }

                stringArray = readLine.Split();
                int[] intArray = new int[stringArray.Length];
                if (stringArray.Length != sizeM)
                    return false;
                for (int j = 0; j < sizeM; ++j)
                {
                    if (!int.TryParse(stringArray[j], out intArray[j]))
                        return false;
                    newMatrix[i, j] = intArray[j];
                }
            }

            if ((readLine = sr.ReadLine()) != null)
            {
                return false;
            }

            matrix = newMatrix;
            return true;
        }

        /// <summary>Рандомизированная генерация матрицы с заданными с консоли границами.</summary>
        /// <returns>Корректность ввода.</returns>
        public bool GenerateMatrix()
        {
            Thread.Sleep(1);
            Random rand = new Random();
            string readLine = Console.ReadLine();
            string[] stringArray = readLine.Split(' ');
            int left, right;
            if (stringArray.Length != 4)
                return false;
            if (!int.TryParse(stringArray[0], out sizeN) || sizeN < 0 || sizeN > 1000)
                return false;
            if (!int.TryParse(stringArray[1], out sizeM) || sizeM < 0 || sizeM > 1000)
                return false;
            if (!int.TryParse(stringArray[2], out left))
                return false;
            if (!int.TryParse(stringArray[3], out right))
                return false;
            if (left > right)
            {
                return false;
            }

            int[,] newMatrix = new int[sizeN, sizeM];
            for (int i = 0; i < sizeN; ++i)
            {
                for (int j = 0; j < sizeM; ++j)
                {
                    newMatrix[i, j] = rand.Next(left, right + 1);
                }
            }

            matrix = newMatrix;
            Console.WriteLine("Сгенерированная матрица:");
            PrintMatrix();
            return true;
        }
        
        /// <summary>Консольное взаимодействие для ввода матрицы из файла.</summary>
        /// <returns>Корректность ввода.</returns>
        public bool ReadMatrixFile()
        {
            Console.WriteLine("Введите путь к текстовому файлу, где находится матрица.");
            string filename;
            filename = Console.ReadLine();
            if (!File.Exists(filename))
            {
                Console.WriteLine("Неверный путь к файлу.");
                return true;
            }

            if (!FileReadMatrix(filename))
            {
                Console.WriteLine("Некорректный ввод, проверьте соответствие формату из файла ReadMe.");
                return true;
            }

            return false;
        }

        /// <summary>Ввод матрицы выбираемым способом.</summary>
        public void ReadMatrix()
        {
            while (true)
            {
                Console.WriteLine("Выберите формат ввода матрицы.");
                Console.WriteLine("Для консольного ввода выведите '1'.");
                Console.WriteLine("Для файлового ввода выведите '2'.");
                Console.WriteLine("Для автоматической генерации выведите '3'.");
                string s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        Console.WriteLine("Введите матрицу согласно формату, описанному в файле ReadMe.");
                        if (!ConsoleReadMatrix())
                        {
                            Console.WriteLine("Некорректный ввод, проверьте соответствие формату из файла ReadMe.");
                            break;
                        }

                        return;
                    case "2":
                        if (ReadMatrixFile())
                            break;
                        return;
                    case "3":
                        Console.WriteLine("Введите размеры матрицы и границы генерации для чисел внутри.");
                        if (!GenerateMatrix())
                        {
                            Console.WriteLine("Некорректный ввод, проверьте соответствие формату из файла ReadMe.");
                            break;
                        }

                        return;
                    default:
                        Console.WriteLine("Некорректный ввод варианта ввода.");
                        break;
                }
            }
        }

        /// <summary>Вывод матрицы в консоль.</summary>
        public void PrintMatrix()
        {
            Console.WriteLine(sizeN + " " + sizeM);
            for (int i = 0; i < sizeN; ++i)
            {
                for (int j = 0; j < sizeM; ++j)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        //Конструктор матрицы.
        public Matrix()
        {
            sizeM = 0;
            sizeN = 0;
            matrix = new int[0, 0];
        }

        
        //Конструктор матрицы по размерам.
        public Matrix(int userN, int userM)
        {
            sizeM = userM;
            sizeN = userN;
            matrix = new int[sizeN, sizeM];
        }
    }
}