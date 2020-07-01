using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FacultativeCourseWork1
{
    class HomeworkKanadeiar
    {
        public static void Demo()
        {
            WriteLine("Данное домашнее задание выполнил: Рассахатский");

            string surname = getStringFromConsole("Введите фамилию человека");
            string name = getStringFromConsole("Введите имя человека");
            int age = getIntFromConsole("Введите возраст человека");
            int growth = getIntFromConsole("Введите рост человека (см)");
            int weight = getIntFromConsole("Введите вес человека (кг)");
            WriteLine("\n\nВывод информации:\n");
            WriteLine("Используя склеивание:");
            WriteLine("Фамилия: " + surname + " Имя: " + name + " Возраст: " + age + " лет Рост: " + growth + " см Вес: " + weight + " кг.");
            WriteLine("\nИспользуя форматированный вывод:");
            WriteLine("Фамилия: {0} Имя: {1} Возраст: {2} лет Рост: {3} см Вес: {4} кг.", surname, name, age, growth, weight);
            WriteLine("\nИспользуя вывод со знаком $:");
            WriteLine($"Фамилия: {surname} Имя: {name} Возраст: {age} лет Рост: {growth} см Вес: {weight} кг.");

            Console.ReadKey();
        }
        /// <summary>
        /// Получение строки с консоли
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string getStringFromConsole(string message)
        {
            Write($"{message}:>");
            return ReadLine();
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
