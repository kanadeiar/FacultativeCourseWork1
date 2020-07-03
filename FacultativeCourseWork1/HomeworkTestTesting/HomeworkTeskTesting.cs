using System;
using static System.Console;

namespace FacultativeCourseWork1
{
    class HomeworkTesting
    {
        /// <summary>
        /// Демонтрация домашней работы
        /// <summary>
        public static void Demo()
        {
            WriteLine("Данное домашнее задание выполнил: Тестовый Тест");
            WriteLine("Задача 1. Написать метод, возвращающий минимальное из трёх чисел.");
            ///////////////////////////////////////////////////////////////////////////////////
            int num1 = getIntFromConsole("Введите первое число (int)");
            int num2 = getIntFromConsole("Введите второе число (int)");
            int num3 = getIntFromConsole("Введите третье число (int)");
            int numMininmal = GetMinimalFromThreeNumbers(num1, num2, num3); //нахождение минимального числа из трех
            WriteLine($"Минимальное число это - {numMininmal}");
            Console.ReadKey();
        }
        /// <summary>
        /// Нахождение минимального числа из трех
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <param name="n3"></param>
        /// <returns></returns>
        private static int GetMinimalFromThreeNumbers(int n1, int n2, int n3)
        {
            if (n1 < n2 && n1 < n3)
            {
                return n1;
            }
            if (n2 < n3)
            {
                return n2;
            }
            return n3;
        }
        /// <summary>
        /// Получение числа с консоли
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static int getIntFromConsole(string message)
        {
            while (true)
            {
                Write($"{message}:>");
                if (int.TryParse(ReadLine(), out int number))
                {
                    return number;
                }
                WriteLine("Ошибка! Введен неверный формат целого числа!");
                Beep(500,500);
            }
        }
    }
}
