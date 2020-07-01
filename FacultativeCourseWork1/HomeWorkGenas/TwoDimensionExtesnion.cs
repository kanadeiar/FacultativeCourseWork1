using System;

namespace FacultativeCourseWork1.Array_s
{
    public static class TwoDimensionExtesnion
    {
        public static int[,] ExtractSubArray(this int[,] array, int lengthX, int lengthY, int startX, int startY)
        {
            // Валидация ввода
            if (lengthX <= 0 || lengthX > array.GetLength(0))
                throw new Exception("Ошибка! Введена неверная длинна подмассива!");
            if (lengthY <= 0 || lengthY > array.GetLength(1))
                throw new Exception("Ошибка! Введена неверная ширина подмассива!");
            if (startX + lengthX > array.GetLength(0) - 1)
                throw new Exception("Ошибка! Введена неверная координата X!");
            if (startY + lengthY > array.GetLength(1) - 1)
                throw new Exception("Ошибка! Введена неверная координата Y!");

            int[,] subArray = new int[lengthX, lengthY];

            // выделяем подмассив
            for (int k = startX; k < subArray.GetLength(0) + startX; k++)
            {
                for (int l = startY; l < subArray.GetLength(1) + startY; l++)
                {
                    subArray[k - startX, l - startY] = array[k, l];
                }
            }
            return subArray;
        }

        public static void PrintArray(this int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0} ", array[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void FillRandomNumbers(this int[,] array, int from, int to)
        {
            Random rand = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(from, to);
                }
            }
        }

        public static int[,] AddEnhancedArray(this int[,] array, int lengthX, int lengthY)
        {
            //validation of the entry
            if (lengthX > 5 || lengthY > 5)
                throw new Exception("Указана слишком большая размерность массива!");
            if (lengthX <= 0 || lengthY <= 0)
                throw new Exception("Указана слишком маленькая размерность массива!");

            //increase the array
            int[,] incArray = new int[lengthX + array.GetLength(0), lengthY + array.GetLength(1)];

            for (int i = 0; i < incArray.GetLength(0); i++)
            {
                for (int j = 0; j < incArray.GetLength(1); j++)
                {
                    if (array.GetLength(0) > i && j < array.GetLength(1))
                    {
                        incArray[i, j] = array[i, j];
                    }
                    else
                    {
                        incArray[i, j] = 11;
                    }
                }
            }
            return incArray;
        }

        public static bool ValidateNumberInput(this string input)
        {
            try
            {
                Convert.ToInt32(input);
                if ((Convert.ToInt32(input) < 0 || Convert.ToInt32(input) > 10))
                {
                    throw new Exception("Ошибка! Указана слишком большая или маленькая размерность массива. Повтори ввод!");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static int ValidateNumberChoice(this int numberChoice)
        {
            //validation of the entry
            bool validate = true;
            while (validate)
            {
                try
                {
                    numberChoice = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    validate = false;
                }
            }
            return numberChoice;
        }
    }
}
