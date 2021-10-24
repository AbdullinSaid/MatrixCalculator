using System;
using System.Xml;

namespace MatrixCalculator
{
    /// <summary>Класc, содержащий различные операции с матрицами.</summary>
    public class Calculations
    {
        /// <summary>Нахождение следа матрицы.</summary>
        /// <param name="userMatrix">Входная матрица.</param>
        /// <param name="traceAns">Переменная, в которую будет записан след.</param>
        /// <returns>Корректность матрицы для нахождения следа в ней.</returns>
        public bool MatrixTrace(Matrix userMatrix, out int traceAns)
        {
            if (userMatrix.sizeN != userMatrix.sizeM)
            {
                traceAns = -1;
                return false;
            }

            traceAns = 0;
            for (int i = 0; i < userMatrix.sizeN; ++i)
            {
                traceAns += userMatrix.matrix[i, i];
            }

            return true;
        }

        /// <summary>Транспонирование матрицы.</summary>
        /// <param name="userMatrix">Входная матрица.</param>
        /// <param name="transMatrix">Транспонированная матрица.</param>
        /// <returns>Корректность матрицы для ее транспонирования.</returns>
        public bool MatrixTransposition(Matrix userMatrix, ref Matrix transMatrix)
        {
            transMatrix = new Matrix(userMatrix.sizeM, userMatrix.sizeN);
            int[,] newMatrix = new int[userMatrix.sizeM, userMatrix.sizeN];
            for (int i = 0; i < userMatrix.sizeN; ++i)
            {
                for (int j = 0; j < userMatrix.sizeM; ++j)
                {
                    newMatrix[j, i] = userMatrix.matrix[i, j];
                }
            }

            transMatrix.matrix = newMatrix;

            return true;
        }


        /// <summary>Нахождение суммы матриц.</summary>
        /// <param name="userMatrix1, userMatrix2">Входные суммируемые матрицы.</param>
        /// <param name="sum">Матрица суммы.</param>
        /// <returns>Корректность матриц для нахождения суммы.</returns>
        public bool MatrixSum(Matrix userMatrix1, Matrix userMatrix2, out Matrix sum)
        {
            if (userMatrix1.sizeN != userMatrix2.sizeN || userMatrix1.sizeM != userMatrix2.sizeM)
            {
                sum = new Matrix();
                return false;
            }

            sum = new Matrix(userMatrix1.sizeN, userMatrix2.sizeM);
            for (int i = 0; i < userMatrix1.sizeN; ++i)
            {
                for (int j = 0; j < userMatrix1.sizeM; ++j)
                {
                    sum.matrix[i, j] = userMatrix1.matrix[i, j] + userMatrix2.matrix[i, j];
                }
            }

            return true;
        }

        /// <summary>Нахождение результата перемножения матриц.</summary>
        /// <param name="userMatrix1, userMatrix2">Входные перемножаемые матрицы.</param>
        /// <param name="sum">Матрица произведения.</param>
        /// <returns>Корректность матриц для нахождения произведения.</returns>
        public bool MatrixMultiplication(Matrix userMatrix1, Matrix userMatrix2, out Matrix sum)
        {
            if (userMatrix1.sizeM != userMatrix2.sizeN)
            {
                sum = new Matrix();
                return false;
            }

            sum = new Matrix(userMatrix1.sizeN, userMatrix2.sizeM);
            for (int i = 0; i < userMatrix1.sizeN; ++i)
            {
                for (int j = 0; j < userMatrix2.sizeM; ++j)
                {
                    for (int h = 0; h < userMatrix1.sizeM; ++h)
                    {
                        sum.matrix[i, j] += userMatrix1.matrix[i, h] * userMatrix2.matrix[h, j];
                    }
                }
            }

            return true;
        }

        /// <summary>Нахождение определителя матрицы.</summary>
        /// <param name="userMatrix">Входная матрица.</param>
        /// <param name="det">Значение определителя матрицы.</param>
        /// <returns>Корректность матрицы для нахождения определителя.</returns>
        public bool MatrixDeterminant(Matrix userMatrix, out int det)
        {
            if (userMatrix.sizeN != userMatrix.sizeM)
            {
                det = 0;
                return false;
            }

            det = 0;
            if (userMatrix.sizeN == 1)
            {
                det = userMatrix.matrix[0, 0];
                return true;
            }

            //нахождение определителя происходит через рекурсивную формулу и минорные элементы. 
            for (int i = 0; i < userMatrix.sizeN; ++i)
            {
                Matrix newMatrix = new Matrix(userMatrix.sizeN - 1, userMatrix.sizeN - 1);
                for (int j = 0; j < i; ++j)
                {
                    for (int h = 1; h < userMatrix.sizeN; ++h)
                    {
                        newMatrix.matrix[h - 1, j] = userMatrix.matrix[h, j];
                    }
                }

                for (int j = i + 1; j < userMatrix.sizeN; ++j)
                {
                    for (int h = 1; h < userMatrix.sizeN; ++h)
                    {
                        newMatrix.matrix[h - 1, j - 1] = userMatrix.matrix[h, j];
                    }
                }

                int newDet;
                MatrixDeterminant(newMatrix, out newDet);
                det += userMatrix.matrix[0, i] * (int) Math.Pow(-1, i) * newDet;
            }

            return true;
        }

        /// <summary>Построение матриц и нахождение их определителей в методе Крамера.</summary>
        /// <param name="equation">Матрица уравнения.</param>
        /// <param name="det">Массив определителей.</param>
        public void KramerMatrix(Matrix equation, ref int[] det)
        {
            Matrix kramerMatrix = new Matrix(equation.sizeN, equation.sizeN);
            for (int i = 0; i < equation.sizeM; ++i)
            {
                for (int j = 0; j < equation.sizeN; ++j)
                {
                    for (int h = 0; h < equation.sizeN; ++h)
                        kramerMatrix.matrix[h, j] = equation.matrix[h, j];
                }

                if (i != equation.sizeN)
                {
                    for (int h = 0; h < equation.sizeN; ++h)
                        kramerMatrix.matrix[h, i] = equation.matrix[h, equation.sizeN];
                }

                MatrixDeterminant(kramerMatrix, out det[i]);
            }
        }

        /// <summary>Решение системы уравнений методом Крамера.</summary>
        public void SystemOfEquations()
        {
            Console.WriteLine("Введите уравнение в виде матрицы N на N + 1, где N - число неизвестных");
            Console.WriteLine("(Ввод матрицы согласно формату, описанному в ReadMe)");
            Matrix equation = new Matrix();
            equation.ReadMatrix();
            while (equation.sizeN + 1 != equation.sizeM)
            {
                Console.WriteLine("Неверные размеры матрицы, введите матрицу снова");
                equation.ReadMatrix();
            }

            double[] ans = new double[equation.sizeN];
            int[] det = new int[equation.sizeN + 1];
            KramerMatrix(equation, ref det);
            if (det[equation.sizeN] == 0)
            {
                Console.WriteLine("Решений нет или их несколько");
                return;
            }

            for (int i = 0; i < equation.sizeN; ++i)
            {
                ans[i] = (double) det[i] / det[equation.sizeN];
            }

            Console.WriteLine("Ответы:");
            for (int i = 0; i < equation.sizeN; ++i)
            {
                Console.Write(ans[i] + " ");
            }

            Console.WriteLine();
        }
    }
}