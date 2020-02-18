using System;

namespace Курсова
{
    class Program
    {


        static double[,] Multiplication(double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            double[,] r = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }
        static void Print ( double [,] a)
        {
           // Console.WriteLine("your matrix is");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"{a[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        static double[,] Transponation (double[,] a)
        {
            double[,] result = new double[a.GetLength(1), a.GetLength(0)];

            for (int i = 0; i < a.GetLength(1); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    result[i, j] = a[j, i];
                }
            }

            return result;
        }

        private static double DetRec(double[,] matrix)
        {
            if (matrix.Length == 4)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            double sign = 1, result = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                double[,] minor = GetMinor(matrix, i);
                result += sign * matrix[0, i] * DetRec(minor);
                sign = -sign;
            }
            return result;
        }

        private static double[,] GetMinor(double[,] matrix, int n)
        {
            double[,] result = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0, col = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == n)
                        continue;
                    result[i - 1, col] = matrix[i, j];
                    col++;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine("This is a calculator that performs such actions on matrix");
                Console.Write("List:\n 1 - add and subtract matrix\n 2 - transposition of matrix\n 3 - multiplication of matrix\n 4 - rise of the matrix to the degree\n 5 - Determinant of matrix\nYour answer is ");
                int Operations;
                while ((!int.TryParse(Console.ReadLine(), out Operations)) || Operations < 1 || Operations > 5)
                {
                    Console.Write("Inccorrect input, choose operations -> ");

                }
                switch (Operations)
                {
                    case 1://add and subtract matrix
                        {
                            int rawsAmount;
                            Console.Write("Enter the amount of raws -> ");
                            while ((!int.TryParse(Console.ReadLine(), out rawsAmount)) || rawsAmount < 1 || rawsAmount > 10)
                            {
                                Console.Write("Enter correct amount of raws -> ");

                            }
                            int colomsAmount;
                            Console.Write("Enter the amount of coloms -> ");
                            while ((!int.TryParse(Console.ReadLine(), out colomsAmount)) || colomsAmount < 1 || colomsAmount > 10)
                            {
                                Console.Write("Enter correct amount of coloms -> ");
                            }
                            double[,] array1 = new double[rawsAmount, colomsAmount];
                            double[,] array2 = new double[rawsAmount, colomsAmount];
                            double[,] result = new double[rawsAmount, colomsAmount];
                            Console.WriteLine("Enter first matrix");
                            for (int i = 0; i < rawsAmount; i++)
                            {
                                for (int j = 0; j < colomsAmount; j++)
                                {
                                    Console.Write($"mas[{i + 1},{j + 1}] = ");
                                    while ((!double.TryParse(Console.ReadLine(), out array1[i, j])))
                                    {
                                        Console.Write($"Unncorect input, mas[{i + 1},{j} + 1] = ");
                                    }
                                }
                            }

                            Console.WriteLine("Enter second matrix");
                            for (int i = 0; i < rawsAmount; i++)
                            {
                                for (int j = 0; j < colomsAmount; j++)
                                {
                                    Console.Write($"mas[{i + 1},{j + 1}] = ");
                                    while ((!double.TryParse(Console.ReadLine(), out array2[i, j])))
                                    {
                                        Console.Write($"Unncorect input, mas[{i + 1},{j + 1}] = ");
                                    }
                                }
                            }

                            Console.Write("What do you want to do\n 1 - Add or 2 - Subtract ?\nYour answer is ");
                            int AddOrSubtract;
                            while ((!int.TryParse(Console.ReadLine(), out AddOrSubtract)) || AddOrSubtract < 1 || AddOrSubtract > 2)
                            {
                                Console.Write("Inccorrect input, choose operations -> ");

                            }

                            switch (AddOrSubtract)
                            {
                                case 1:
                                    {
                                        for (int i = 0; i < rawsAmount; i++)
                                        {
                                            for (int j = 0; j < colomsAmount; j++)
                                            {
                                                result[i, j] = array1[i, j] + array2[i, j];
                                            }
                                        }

                                    } break;

                                case 2:
                                    {
                                        for (int i = 0; i < rawsAmount; i++)
                                        {
                                            for (int j = 0; j < colomsAmount; j++)
                                            {
                                                result[i, j] = array1[i, j] - array2[i, j];
                                            }
                                        }
                                    } break;
                            }

                            Console.WriteLine("Result is");
                            for (int i = 0; i < rawsAmount; i++)
                            {
                                for (int j = 0; j < colomsAmount; j++)
                                {
                                    Console.WriteLine($" mas[{i + 1},{j + 1}] = {result[i,j]}");
                                }
                            }
                        } break;
                    case 2://transponation
                        {
                            int rawsAmount;
                            Console.Write("Enter the amount of raws -> ");
                            while ((!int.TryParse(Console.ReadLine(), out rawsAmount)) || rawsAmount < 1 || rawsAmount > 10)
                            {
                                Console.Write("Enter correct amount of raws -> ");

                            }
                            int colomsAmount;
                            Console.Write("Enter the amount of coloms -> ");
                            while ((!int.TryParse(Console.ReadLine(), out colomsAmount)) || colomsAmount < 1 || colomsAmount > 10)
                            {
                                Console.Write("Enter correct amount of coloms -> ");
                            }

                            double[,] array1 = new double[rawsAmount, colomsAmount];

                            Console.WriteLine("Enter matrix");
                            for (int i = 0; i < rawsAmount; i++)
                            {
                                for (int j = 0; j < colomsAmount; j++)
                                {
                                    Console.Write($"mas[{i + 1},{j + 1}] = ");
                                    while ((!double.TryParse(Console.ReadLine(), out array1[i, j])))
                                    {
                                        Console.Write($"Unncorect input, mas[{i + 1},{j} + 1] = ");
                                    }
                                }
                            }
                            
                            Console.WriteLine("Your matrix is ");
                            Print(array1);

                            double[,] transp = Transponation(array1);

                            Console.WriteLine("Result is");
                            Print(transp);


                        } break;

                    case 3://muttiplay
                        {

                            int rawsAmount1;
                            Console.Write("Enter the amount of raws first matrix -> ");
                            while ((!int.TryParse(Console.ReadLine(), out rawsAmount1)) || rawsAmount1 < 1 || rawsAmount1 > 10)
                            {
                                Console.Write("Enter correct amount of raws -> ");

                            }
                            int colomsAmount1;
                            Console.Write("Enter the amount of coloms first matrix -> ");
                            while ((!int.TryParse(Console.ReadLine(), out colomsAmount1)) || colomsAmount1 < 1 || colomsAmount1 > 10)
                            {
                                Console.Write("Enter correct amount of coloms -> ");
                            }

                            int rawsAmount2;
                            Console.Write("Enter the amount of raws second matrix -> ");
                            while ((!int.TryParse(Console.ReadLine(), out rawsAmount2)) || rawsAmount2 < 1 || rawsAmount2 > 10)
                            {
                                Console.Write("Enter correct amount of raws second matrix-> ");

                            }
                            int colomsAmount2;
                            Console.Write("Enter the amount of coloms second matrix -> ");
                            while ((!int.TryParse(Console.ReadLine(), out colomsAmount2)) || colomsAmount2 < 1 || colomsAmount2 > 10)
                            {
                                Console.Write("Enter correct amount of coloms second matrix -> ");
                            }
                            if ( colomsAmount1 != rawsAmount2)
                            {
                                Console.WriteLine("Can`t calculate");
                                break;
                            }
                            double[,] array1 = new double[rawsAmount1, colomsAmount1];
                            double[,] array2 = new double[rawsAmount2, colomsAmount2];
                            
                            Console.WriteLine("Enter first matrix");
                            for (int i = 0; i < rawsAmount1; i++)
                            {
                                for (int j = 0; j < colomsAmount1; j++)
                                {
                                    Console.Write($"mas[{i + 1},{j + 1}] = ");
                                    while ((!double.TryParse(Console.ReadLine(), out array1[i, j])))
                                    {
                                        Console.Write($"Unncorect input, mas[{i + 1},{j} + 1] = ");
                                    }
                                }
                            }

                            Console.WriteLine("Enter second matrix");
                            for (int i = 0; i < rawsAmount2; i++)
                            {
                                for (int j = 0; j < colomsAmount2; j++)
                                {
                                    Console.Write($"mas[{i + 1},{j + 1}] = ");
                                    while ((!double.TryParse(Console.ReadLine(), out array2[i, j])))
                                    {
                                        Console.Write($"Unncorect input, mas[{i + 1},{j + 1}] = ");
                                    }
                                }
                            }

                            double[,] res = Multiplication(array1, array2);
                            Print(res);

                        } break;


                    case 4://Degree
                        {
                            int sizeOfMatrix;
                            Console.Write("Enter the size of matrix -> ");
                            while ((!int.TryParse(Console.ReadLine(), out sizeOfMatrix)) || sizeOfMatrix < 1 || sizeOfMatrix > 10)
                            {
                                Console.Write("Enter correct size of of raws -> ");

                            }

                            double[,] array1 = new double[sizeOfMatrix, sizeOfMatrix];

                            Console.WriteLine("Enter the matrix");
                            for (int i = 0; i < sizeOfMatrix; i++)
                            {
                                for (int j = 0; j < sizeOfMatrix; j++)
                                {
                                    Console.Write($"mas[{i + 1},{j + 1}] = ");
                                    while ((!double.TryParse(Console.ReadLine(), out array1[i, j])))
                                    {
                                        Console.Write($"Unncorect input, mas[{i + 1},{j} + 1] = ");
                                    }
                                }
                            }

                            int degree;
                            Console.Write("Enter the degree -> ");
                            while ((!int.TryParse(Console.ReadLine(), out degree)) || degree < 2 || degree > 10)
                            {
                                Console.Write("Enter the degree -> ");

                            }

                            double[,] result = (double[,])array1.Clone();

                            for (int i = 0; i < degree-1; i++)
                            {
                                result = Multiplication(array1, result);
                                Console.WriteLine($"Degree is {i + 2}, Result is ");
                                Print(result);
                            }
                            

                        } break;

                    case 5://determinant
                        {

                            int sizeOfMatrix;
                            Console.Write("Enter the size of matrix -> ");
                            while ((!int.TryParse(Console.ReadLine(), out sizeOfMatrix)) || sizeOfMatrix < 1 || sizeOfMatrix > 10)
                            {
                                Console.Write("Enter correct size of of raws -> ");

                            }

                            double[,] array1 = new double[sizeOfMatrix, sizeOfMatrix];

                            Console.WriteLine("Enter the matrix");
                            for (int i = 0; i < sizeOfMatrix; i++)
                            {
                                for (int j = 0; j < sizeOfMatrix; j++)
                                {
                                    Console.Write($"mas[{i + 1},{j + 1}] = ");
                                    while ((!double.TryParse(Console.ReadLine(), out array1[i, j])))
                                    {
                                        Console.Write($"Unncorect input, mas[{i + 1},{j} + 1] = ");
                                    }
                                }
                            }
                            Console.WriteLine("Your matrix is");
                            Print(array1);

                            double det = DetRec(array1);

                            Console.WriteLine($"Your result is {det}");

                        } break;
                }

                Console.WriteLine("If you want to continue press any key, to Exit press Escape");
                key = Console.ReadKey().Key;
            } while (key != ConsoleKey.Escape);

        }
    }
}
