

namespace Lesson8
{
    class Switch
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("1.Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива");
                Console.WriteLine("2.Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
                Console.WriteLine("3.Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
                Console.WriteLine("4.Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.");
                Console.WriteLine("5.Напишите программу, которая заполнит спирально массив 4 на 4.");

                Console.Write("Выбери номер задания:");
                if (TryGetUserInput(out int value))
                {
                    switch (value)
                    {
                        case 1: Task54.Task54Main(); break;
                        case 2: Task56.Task56Main(); break;
                        case 3: Task58.Task58Main(); break;
                        case 4: Task60.Task60Main(); break;
                        case 5: Task62.Task62Main(); break;
                        default: Console.WriteLine("Извини, такой задачи нет :(. Попробуй еще раз!"); break;
                    }
                }
            }

        }

        private static bool IsString(string input)
        {
            return !int.TryParse(input, out _);
        }

        private static bool TryGetUserInput(out int value)
        {
            string input = Console.ReadLine();
            if (IsString(input))
            {
                value = 0;
                Console.WriteLine("Введи число, а не букву!");
                return false;
            }

            else
            {
                value = int.Parse(input);
                return true;
            }
        }
    }

    //Задайте двумерный массив.
    //54.Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива
    class Task54
    {
        public static void Task54Main()
        {
            Console.Write("Введите кол-во колонок: ");
            int columns = int.Parse(Console.ReadLine()!);

            Console.Write("Введите кол-во рядов: ");
            int rows = int.Parse(Console.ReadLine()!);

            int[,] randomArray = CreateRandomArray(rows, columns);
            SortEveryRow(randomArray);
            Print2DArray(randomArray);


        }

        private static int[,] CreateRandomArray(int columns, int rows)
        {
            int[,] array = new int[columns, rows];
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(1, 10);
                }
            }
            return array;
        }

        private static void SortEveryRow(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int[] rowArray = GetRow(array, i);
                Array.Sort(rowArray);
                Array.Reverse(rowArray);
                SetRow(array, i, rowArray);
            }
        }

        private static int[] GetRow(int[,] array, int row)
        {
            int[] rowArray = new int[array.GetLength(1)];
            for (int i = 0; i < array.GetLength(1); i++)
            {
                rowArray[i] = array[row, i];
            }
            return rowArray;
        }

        private static void SetRow(int[,] array, int row, int[] rowArray)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                array[row, i] = rowArray[i];
            }
        }

        private static void Print2DArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.Write("\n");
            }
        }


    }

    //Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.


    class Task56
    {
        public static void Task56Main()
        {
            Console.Write("Введите кол-во колонок: ");
            int columns = int.Parse(Console.ReadLine()!);

            Console.Write("Введите кол-во рядов: ");
            int rows = int.Parse(Console.ReadLine()!);

            int[,] randomArray = CreateRandomArray(rows, columns);
            Print2DArray(randomArray);
            MinRow(randomArray);

        }

        private static void MinRow(int[,] randomArray)
        {
            int minRow = 0;
            int min = int.MaxValue;

            for (int i = 0; i < randomArray.GetLength(0); i++)
            {
                int sum = 0;

                for (int j = 0; j < randomArray.GetLength(1); j++)
                {
                    sum = sum + randomArray[i, j];
                }

                if (sum < min)
                {
                    min = sum;
                    minRow = i + 1;
                }
            }

            Console.WriteLine($"Номер строки с минимальной суммой: {minRow}");
        }
        private static void Print2DArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.Write("\n");
            }
        }

        private static int[,] CreateRandomArray(int columns, int rows)
        {
            int[,] array = new int[columns, rows];
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(1, 10);
                }
            }
            return array;
        }

        private static int[] GetRow(int[,] array, int row)
        {
            int[] rowArray = new int[array.GetLength(1)];
            for (int i = 0; i < array.GetLength(1); i++)
            {
                rowArray[i] = array[row, i];
            }
            return rowArray;
        }
    }




    //Задача 58: Задайте две матрицы.Напишите программу, которая будет находить произведение двух матриц.


    class Task58
    {
        public static void Task58Main()
        {
            Console.WriteLine("Введите размеры матриц и диапазон случайных значений:");
            int m = InputNumbers("Введите число строк 1-й матрицы: ");
            int n = InputNumbers("Введите число столбцов 1-й матрицы (и строк 2-й): ");
            int p = InputNumbers("Введите число столбцов 2-й матрицы: ");
            int range = InputNumbers("Введите диапазон случайных чисел: от 1 до ");

            int[,] firstMartrix = new int[m, n];
            CreateArray(firstMartrix, range);
            Console.WriteLine($"Первая матрица:");
            WriteArray(firstMartrix);

            int[,] secondMatrix = new int[n, p];
            CreateArray(secondMatrix, range);
            Console.WriteLine($"Вторая матрица:");
            WriteArray(secondMatrix);

            int[,] resultMatrix = new int[m, p];

            MultiplyMatrix(firstMartrix, secondMatrix, resultMatrix);
            Console.WriteLine($"Произведение первой и второй матриц:");
            WriteArray(resultMatrix);
        }

        private static void MultiplyMatrix(int[,] firstMartrix, int[,] secondMatrix, int[,] resultMatrix)
        {
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    int sum = 0;
                    for (int k = 0; k < firstMartrix.GetLength(1); k++)
                    {
                        sum += firstMartrix[i, k] * secondMatrix[k, j];
                    }
                    resultMatrix[i, j] = sum;
                }
            }
        }

        private static int InputNumbers(string input)
        {
            Console.Write(input);
            int output = Convert.ToInt32(Console.ReadLine());
            return output;
        }

        private static void CreateArray(int[,] array, int range)
        {
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(range);
                }
            }
        }

        private static void WriteArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
    //Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

    class Task60
    {
        public static void Task60Main()
        {
            Console.WriteLine($"Введите размер массива X x Y x Z: ");
            int x = InputNumbers("Введите X: ");
            int y = InputNumbers("Введите Y: ");
            int z = InputNumbers("Введите Z: ");
            Console.WriteLine($"");

            int[,,] array3D = new int[x, y, z];
            CreateArray(array3D);
            WriteArray(array3D);
        }


        private static int InputNumbers(string input)
        {
            Console.Write(input);
            int output = Convert.ToInt32(Console.ReadLine());
            return output;
        }

        private static void WriteArray(int[,,] array3D)
        {
            for (int i = 0; i < array3D.GetLength(0); i++)
            {
                for (int j = 0; j < array3D.GetLength(1); j++)
                {
                    Console.Write($"X({i}) Y({j}) ");
                    for (int k = 0; k < array3D.GetLength(2); k++)
                    {
                        Console.Write($"Z({k})={array3D[i, j, k]}; ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        private static void CreateArray(int[,,] array3D)
        {
            int[] temp = new int[array3D.GetLength(0) * array3D.GetLength(1) * array3D.GetLength(2)];
            int number;
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                temp[i] = new Random().Next(10, 100);
                number = temp[i];
                if (i >= 1)
                {
                    for (int j = 0; j < i; j++)
                    {
                        while (temp[i] == temp[j])
                        {
                            temp[i] = new Random().Next(10, 100);
                            j = 0;
                            number = temp[i];
                        }
                        number = temp[i];
                    }
                }
            }
            int count = 0;
            for (int x = 0; x < array3D.GetLength(0); x++)
            {
                for (int y = 0; y < array3D.GetLength(1); y++)
                {
                    for (int z = 0; z < array3D.GetLength(2); z++)
                    {
                        array3D[x, y, z] = temp[count];
                        count++;
                    }
                }
            }
        }

    }
    //Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.

    class Task62
    {
        public static void Task62Main()
        {
            int n = 4;
            int[,] sqareMatrix = new int[n, n];

            int temp = 1;
            int i = 0;
            int j = 0;

            while (temp <= sqareMatrix.GetLength(0) * sqareMatrix.GetLength(1))
            {
                sqareMatrix[i, j] = temp;
                temp++;
                if (i <= j + 1 && i + j < sqareMatrix.GetLength(1) - 1)
                    j++;
                else if (i < j && i + j >= sqareMatrix.GetLength(0) - 1)
                    i++;
                else if (i >= j && i + j > sqareMatrix.GetLength(1) - 1)
                    j--;
                else
                    i--;
            }

            WriteArray(sqareMatrix);

        }


        private static void WriteArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] / 10 <= 0)
                        Console.Write($" {array[i, j]} ");

                    else Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
