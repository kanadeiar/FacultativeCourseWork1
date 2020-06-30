using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultativeCourseWork1
{
    class HomeworkTestov
    {
        /// <summary>
        /// Задача 1.
        /// Написать программу «Анкета».
        /// Выполнил: Тестов
        /// </summary>
        public static void Demo()
        {
            Console.WriteLine("Данное домашнее задание выполнил: Тестов Тест Тестович");
            Console.WriteLine("Задача 1. Написать программу «Анкета».");
            string surname = getStringFromConsole("Введите фамилию человека");
            Console.WriteLine("\n\nВывод информации:\n");
            Console.WriteLine("Используя склеивание:");
            Console.WriteLine("Фамилия: " + surname);
            Console.WriteLine("Нажмите любую кнопку для продолжения...");
            Console.ReadKey();
        }
        /// <summary> Получение строки с консоли </summary>
        private static string getStringFromConsole(string message)
        {
            Console.Write($"{message}:>");
            return Console.ReadLine();
        }
        /// <summary> Получение числа с консоли </summary>
        private static int getIntFromConsole(string message)
        {
            while (true)
            {
                Console.Write($"{message}:>");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    return number;
                }
                Console.WriteLine("Ошибка! Введен неверный формат целого числа!");
                Console.Beep(500,500);
            }
        }
    }
}
