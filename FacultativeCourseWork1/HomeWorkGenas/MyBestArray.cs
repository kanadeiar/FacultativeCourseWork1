using System;

namespace FacultativeCourseWork1.Array_s
{
    public class MyBestArray
    {
       public static int[,] arrayUser = new int[0, 0];
       public static int firstDimension = 0;
       public static int secondDimension = 0;
       public static int ValidateNumberLine()
        {
            string numberLine;
            do
            {
                Console.Write("Введите кол-во строк: ");
                numberLine = Console.ReadLine();
            }
            while (!numberLine.ValidateNumberInput());

            int number = Convert.ToInt32(numberLine);
            return number;
        }

        public static int ValidateNumberColumn()
        {
            string numberColumn;
            do
            {
                Console.Write("Введите кол-во стобцов: ");
                numberColumn = Console.ReadLine();
            }
            while (!numberColumn.ValidateNumberInput());

            int number = Convert.ToInt32(numberColumn);
            return number;
        }

        //name 
        public static void PrintNameProgramme()
        {
            Console.Title = "Двумерные массивы";
            Console.WriteLine("\t\tВас приветствует программа \"Двумерные массивы\"!");
            Console.WriteLine("     Для начала работы в программе укажите размерность двумерного массива.");
            WriteLineColor("\t   Матрица может состоять максимум из 10 строк и 10 столбцов!", ConsoleColor.Green);
        }

        // input new array
        public static int[,] CreateArray(int[,] newArrayUser, int mainLineArray, int mainColumnArray)
        {
            newArrayUser = new int[mainLineArray, mainColumnArray];
            newArrayUser.FillRandomNumbers(10, 50);
            newArrayUser.PrintArray();
            WriteLineColor("----------------------", ConsoleColor.Green);
            return newArrayUser;
        }

        public static int[,] PrintedArray(int[,] newArrayUser, int mainLineArray, int mainColumnArray)
        {
            DropLine();
            Console.WriteLine("\t\tВаш массив [{0}, {1}] состоит из [{2}] элементов: ", mainLineArray, mainColumnArray,
                mainLineArray * mainColumnArray);
            DropLine();
            WriteLineColor("----------------------", ConsoleColor.Green);
            newArrayUser.PrintArray();
            WriteLineColor("----------------------", ConsoleColor.Green);
            return newArrayUser;
        }
        //проверка на минимальное и максимальное значение в матрице 
        public static void PrintMinMax(int[,] newArrayUser)
        {
            int min = int.MaxValue;
            int max = 0;
            for (int i = 0; i < newArrayUser.GetLength(0); i++)
            {
                for (int j = 0; j < newArrayUser.GetLength(1); j++)
                {
                    if (newArrayUser[i, j] < min)
                    {
                        min = newArrayUser[i, j];
                    }
                    if (newArrayUser[i, j] > max)
                    {
                        max = newArrayUser[i, j];
                    }
                }
            }
            Console.WriteLine("Минимальное значение матрицы равно: " + min);
            Console.WriteLine("Максимальное значение матрицы равно: " + max);
        }

        // проверка на чётность
        public static void PrintEvenOddEven(int[,] newArrayUser)
        {
            for (int i = 0; i < newArrayUser.GetLength(0); i++)
            {
                for (int j = 0; j < newArrayUser.GetLength(1); j++)
                {
                    if (newArrayUser[i, j] % 2 == 0)
                    {
                        Console.WriteLine(newArrayUser[i, j] + " число чётное. ");
                    }
                    else
                    {
                        Console.WriteLine(newArrayUser[i, j] + " число нечётное. ");
                    }
                }
            }
        }

        //Пузырь по возрастанию
        public static void PrintBubbleSort(int[,] newArrayUser)
        {
            int temp = 0;
            for (int i = 0; i < newArrayUser.GetLength(0); i++)
            {
                for (int j = 0; j < newArrayUser.GetLength(1); j++)
                {
                    for (int k = i; k < newArrayUser.GetLength(0); k++)
                    {
                        for (int m = (k == i) ? j : 0; m < newArrayUser.GetLength(1); m++)
                        {
                            if (newArrayUser[i, j] > newArrayUser[k, m])
                            {
                                temp = newArrayUser[i, j];
                                newArrayUser[i, j] = newArrayUser[k, m];
                                newArrayUser[k, m] = temp;
                            }
                        }
                    }
                    Console.Write(newArrayUser[i, j] + " ");
                }
                DropLine();
            }
        }

        //Сумма элементов матрицы
        public static void PrintSum(int[,] newArrayUser)
        {
            int sum = 0;
            for (int i = 0; i < newArrayUser.GetLength(0); i++)
            {
                for (int j = 0; j < newArrayUser.GetLength(1); j++)
                {
                    sum += newArrayUser[i, j];
                }
            }
            Console.WriteLine("Сумма элементов матрицы равна " + sum);
        }


        //Среднее арифмитическое матрицы
        public static void PrintSredneeArith(int[,] newArrayUser, int startLine, int startColumn)
        {
            int sum = 0;
            for (int i = 0; i < newArrayUser.GetLength(0); i++)
            {
                for (int j = 0; j < newArrayUser.GetLength(1); j++)
                {
                    sum += newArrayUser[i, j];
                }
            }
            Console.WriteLine("Среднее арифмитическое матрицы равно {0}", sum /= startLine * startColumn);
        }

        //Массив в обратном порядке
        public static void PrintRevers(int[,] newArrayUser, int startLine, int startColumn)
        {
            int temp = 0;
            int temp1 = 0;
            int[,] arrayRevers = new int[startLine, startColumn];
            Console.WriteLine("Матрица в обратном порядке:");
            WriteLineColor("---------------------", ConsoleColor.Green);
            for (int i = newArrayUser.GetLength(0) - 1; i >= 0; i--, temp++)
            {
                for (int j = newArrayUser.GetLength(1) - 1; j >= 0; j--, temp1++)
                {
                    if (temp1 >= newArrayUser.GetLength(1))
                    {
                        temp1 = 0;
                    }
                    arrayRevers[temp, temp1] = newArrayUser[i, j];
                    Console.Write(arrayRevers[temp, temp1] + " ");
                }
                DropLine();
            }
            WriteLineColor("---------------------", ConsoleColor.Green);
        }

        //Подмассив
        public static void SubArray(int[,] newArrayUser)
        {
            int startLine, startColumn, lineSubArray, columnSubArray;

            while (true)
            {
                try
                {
                    Console.WriteLine("\t\t     Введите размерность подмассива: ");
                    Console.Write("Введите кол-во строк: ");
                    lineSubArray = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите кол-вл столбцов: ");
                    columnSubArray = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\t\t  Укажите точку вывода двумерного массива.");
                    Console.Write("Введите номер строки: ");
                    startLine = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите номер столбца: ");
                    startColumn = Convert.ToInt32(Console.ReadLine());
                    var newSubArray = newArrayUser.ExtractSubArray(lineSubArray, columnSubArray, startLine, startColumn);
                    newSubArray.PrintArray();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void WriteLineColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void DropLine()
        {
            char emptyLine = '\n';
            Console.Write(emptyLine);
        }

        //increase array
        public static void TheIncreaseOfDimension(int[,] newArrayUser)
        {
            while (true)
            {
                try
                {
                    WriteLineColor("\t\t   Максимиальное увелечение на 5 строк!", ConsoleColor.Green);
                    Console.Write("Введите кол-во строк: ");
                    int line = Convert.ToInt32(Console.ReadLine());
                    WriteLineColor("\t\t Максимиальное увелечение на и 5 столбцов!", ConsoleColor.Green);
                    Console.Write("Введите кол-во столбцов: ");
                    int column = Convert.ToInt32(Console.ReadLine());
                    var newIncreasArray = newArrayUser.AddEnhancedArray(line, column);
                    newIncreasArray.PrintArray();
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static int InputChoiceOfOption(int numberOfChoice)
        {
            var numberChoice = numberOfChoice.ValidateNumberChoice();
            return numberChoice;
        }

        public static void ReturnToMenu()
        {
            WriteLineColor("\t\tЖелаете продолжить работу c опциями программы?", ConsoleColor.White);
            WriteLineColor("\t\t\t   \"y\" - да, \"n\" - нет.", ConsoleColor.Green);
            ConsoleKey a = Console.ReadKey(true).Key;
            while (a != ConsoleKey.Y && a != ConsoleKey.N)
            {
                a = Console.ReadKey(true).Key;
            }
            if (a == ConsoleKey.Y)
            {
                Console.Clear();
                ShowMenuV2();
            }
            if (a == ConsoleKey.N)
            {
                //Environment.Exit(0);
                goToMainMenu = true;
            }
        }

        private static bool goToMainMenu = false;
        public static void ShowMenuV2()
        {
            int option = 0;
            string[] consoleOption = new string[]
            {
                "Show the minimum and maximum of an array.",
                "Show odd and even numbers.",
                "Show values of array is sorted by bubble ascending.",
                "Show the sum of all values in the array.",
                "Show the arithmetic mean value of the array.",
                "Show the inverted array.",
                "Show the subarray.",
                "Show large array.",
                "Exit."
            };
            while (!goToMainMenu)
            {
                Console.CursorVisible = false;
                Console.Clear();
                arrayUser = PrintedArray(arrayUser, firstDimension, secondDimension);
                Console.WriteLine("\t\t\t\tВыберите опцию: ");
                for (int i = 0; i < consoleOption.Length; i++)
                {
                    if (option == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine("{0}. {1}", i, consoleOption[i]);
                    if (option == i)
                    {
                        Console.ResetColor();
                    }
                }
                var keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (option != consoleOption.Length - 1)
                    {
                        option++;
                    }
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    if (option != 0)
                    {
                        option--;
                    }
                }
                if (keyPressed.Key == ConsoleKey.Enter)
                {
                    switch (option)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("\t\t  Show the minimum and maximum of an array.");
                            PrintMinMax(arrayUser);
                            ReturnToMenu();
                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\t\t\tShow odd and even numbers.");
                            PrintEvenOddEven(arrayUser);
                            ReturnToMenu();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("\t      Show values of array is sorted by bubble ascending.");
                            PrintBubbleSort(arrayUser);
                            ReturnToMenu();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("\t\t\tShow the sum of all values in the array.");
                            PrintSum(arrayUser);
                            ReturnToMenu();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("\t\t Show the arithmetic mean value of the array.");
                            PrintSredneeArith(arrayUser, firstDimension, secondDimension);
                            ReturnToMenu();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("\t\t\t  Show the inverted array.");
                            PrintRevers(arrayUser, firstDimension, secondDimension);
                            ReturnToMenu();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("\t\t\t    Show the subarray.");
                            SubArray(arrayUser);
                            ReturnToMenu();
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("\t\t\t     Show large array.");
                            TheIncreaseOfDimension(arrayUser);
                            ReturnToMenu();
                            break;
                        case 8:
                            Environment.Exit(0);
                            break;
                        default:
                            WriteLineColor("введён некорректный номер опции! повтори ввод!", ConsoleColor.Green);
                            break;
                    }
                }
            }
        }
    }
}
