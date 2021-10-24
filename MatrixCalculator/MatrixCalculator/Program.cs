using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MatrixCalculator
{
    class Program
    {
        /// <summary>Нахождение следа матрицы, с консольной работой с пользователем.</summary>
        /// <returns>Истинность того, что программу не нужно завершать.</returns>
        static public bool ConsoleMatrixTrace()
        {
            Calculations calc = new Calculations();
            Matrix matrix = new Matrix();
            int ans;
            Console.WriteLine("Введите матрицу для нахождения следа");
            matrix.ReadMatrix();
            if (!calc.MatrixTrace(matrix, out ans))
            {
                Console.WriteLine("Некорректная матрица");
                return true;
            }

            Console.WriteLine("След матрицы: " + ans);
            return true;
        }

        /// <summary>Нахождение транспонированная матрицы, с консольной работой с пользователем.</summary>
        /// <returns>Истинность того, что программу не нужно завершать.</returns>
        static public bool ConsoleMatrixTransposition()
        {
            Calculations calc = new Calculations();
            Matrix matrix = new Matrix();
            Console.WriteLine("Введите матрицу для транспортирования");
            matrix = new Matrix();
            matrix.ReadMatrix();
            Matrix transMatrix = new Matrix();
            if (!calc.MatrixTransposition(matrix, ref transMatrix))
            {
                Console.WriteLine("Некорректная матрица");
                return true;
            }
            Console.WriteLine("Транспонированная матрица:");
            transMatrix.PrintMatrix();
            return true;
        }

        /// <summary>Нахождение суммы двух матриц, с консольной работой с пользователем.</summary>
        /// <returns>Истинность того, что программу не нужно завершать.</returns>
        static public bool ConsoleMatrixSum()
        {
            Calculations calc = new Calculations();
            Matrix matrix = new Matrix();
            Matrix matrix2 = new Matrix();
            Matrix matrix3 = new Matrix();
            Console.WriteLine("Введите первую матрицу");
            matrix.ReadMatrix();
            Console.WriteLine("Введите вторую матрицу");
            matrix2.ReadMatrix();
            if (!calc.MatrixSum(matrix, matrix2, out matrix3))
            {
                Console.WriteLine("Некорректные матрицы для операции суммы");
                return true;
            }
            Console.WriteLine("Сумма:");
            matrix3.PrintMatrix();
            return true;
        }

        /// <summary>Нахождение разности двух матриц, с консольной работой с пользователем.</summary>
        /// <returns>Истинность того, что программу не нужно завершать.</returns>
        static public bool ConsoleMatrixDif()
        {
            Calculations calc = new Calculations();
            Matrix matrix = new Matrix();
            Matrix matrix2 = new Matrix();
            Matrix matrix3 = new Matrix();
            Console.WriteLine("Введите первую матрицу");
            matrix.ReadMatrix();
            Console.WriteLine("Введите вторую матрицу");
            matrix2.ReadMatrix();
            if (!calc.MatrixSum(matrix, -matrix2, out matrix3))
            {
                Console.WriteLine("Некорректная матрицы для операции вычитания");
                return true;
            }

            Console.WriteLine("Разность:");
            matrix3.PrintMatrix();
            return true;
        }

        /// <summary>Нахождение произведения двух матриц, с консольной работой с пользователем.</summary>
        /// <returns>Истинность того, что программу не нужно завершать.</returns>
        static public bool ConsoleMatrixMultiplication()
        {
            Calculations calc = new Calculations();
            Matrix matrix = new Matrix();
            Matrix matrix2 = new Matrix();
            Matrix matrix3 = new Matrix();
            Console.WriteLine("Введите первую матрицу");
            matrix.ReadMatrix();
            Console.WriteLine("Введите вторую матрицу");
            matrix2.ReadMatrix();
            if (!calc.MatrixMultiplication(matrix, matrix2, out matrix3))
            {
                Console.WriteLine("Некорректная матрицы для операции произведения");
                return true;
            }

            Console.WriteLine("Произведение:");
            matrix3.PrintMatrix();
            return true;
        }

        /// <summary>Нахождение произведения матрицы и числа, с консольной работой с пользователем.</summary>
        /// <returns>Истинность того, что программу не нужно завершать.</returns>
        static public bool ConsoleMatrixIntMult()
        {
            Matrix matrix = new Matrix();
            Console.WriteLine("Введите матрицу");
            matrix.ReadMatrix();
            Console.WriteLine("Введите число на которое нужно умножить матрицу");
            int coef;
            while (!int.TryParse(Console.ReadLine(), out coef))
            {
                Console.WriteLine("Неверный ввод");
                Console.WriteLine("Введите число на которое нужно умножить матрицу");
            }

            Console.WriteLine("Произведение:");
            (matrix * coef).PrintMatrix();
            return true;
        }

        /// <summary>Нахождение определителя матрицы, с консольной работой с пользователем.</summary>
        /// <returns>Истинность того, что программу не нужно завершать.</returns>
        static public bool ConsoleMatrixDeterminant()
        {
            Calculations calc = new Calculations();
            Matrix matrix = new Matrix();
            int ans;
            Console.WriteLine("Введите матрицу");
            matrix.ReadMatrix();
            if (!calc.MatrixDeterminant(matrix, out ans))
            {
                Console.WriteLine("Некорректная матрица для вычисления определителя");
                return true;
            }
            
            Console.WriteLine("Определитель: " + ans);
            return true;
        }

        /// <summary>Вывод шаблона выбора функции для пользователя.</summary>
        static public void CalcPrint()
        {
            Console.WriteLine("Выведите номер желаемой операции.");
            Console.WriteLine("1.Нахождение следа матрицы.");
            Console.WriteLine("2.Транспортирование матрицы.");
            Console.WriteLine("3.Сумма двух матриц.");
            Console.WriteLine("4.Разность двух матриц.");
            Console.WriteLine("5.Произведение двух матриц.");
            Console.WriteLine("6.Умножение матрицы на число.");
            Console.WriteLine("7.Нахождение определителя матрицы.");
            Console.WriteLine("8.Решение СЛАУ методом Крамера.");
            Console.WriteLine("9.Завершение программы.");
        }

        /// <summary>Объединение функций калькудятора, обрабатывает одну выбранную операцию.</summary>
        /// <returns>Истинность того, что программу не нужно завершать.</returns>
        static public bool Calculator()
        {
            CalcPrint();
            int operation;
            if (!int.TryParse(Console.ReadLine(), out operation))
            {
                Console.WriteLine("Некорректный ввод");
                return true;
            }

            switch (operation)
            {
                case 1:
                    return ConsoleMatrixTrace();
                case 2:
                    return ConsoleMatrixTransposition();
                case 3:
                    return ConsoleMatrixSum();
                case 4:
                    return ConsoleMatrixDif();
                case 5:
                    return ConsoleMatrixMultiplication();
                case 6:
                    return ConsoleMatrixIntMult();
                case 7:
                    return ConsoleMatrixDeterminant();
                case 8:
                    new Calculations().SystemOfEquations();
                    return true;
                case 9:
                    return false;
                default:
                    Console.WriteLine("Неверный ввод");
                    return true;
            }
        }

        static void Main(string[] args)
        {
            //повторение выполнения операций с матрицами до того, как пользователь решит завершить программу.
            while (Calculator())
            {
                Console.WriteLine("Нажмите клавишу Enter, чтобы продолжить.");
                while (Console.ReadKey().Key != ConsoleKey.Enter) ;
                Console.Clear();
            }
        }
    }
}