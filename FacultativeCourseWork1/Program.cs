using FacultativeCourseWork1.Array_s;
using System;


namespace FacultativeCourseWork1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("*** Наша пробная курсовая работа ***");
            while (true)
            {
                var variants = new[]
                {
                    "Выберите домашнюю работу для показа (q-выход):",
                    "1 - Домашняя работа \"Написать программу Анкета\" (выполнил: Рассахатский)",
                    "2 - Домашняя работа \"Работа с комплексными числами\" (выполнил: Ганов)",
                    "3 - Домашняя работа \"Подсчет суммы всех положительных чисел\" (выполнил: Ганов)",
                    "4 - Домашняя работа \"Мой лучший массив\" (выполнил: Тертычный)",
                    "5 - Домашняя работа \"Натуральные дроби\" (выполнил: Ганов)",
                    "6 - Домашняя работа \"Минимальное из трех чисел\" (выполнил: Тестович)",
                    "7 - Домашняя работа \"Расчет индекса массы тела\" (выполнил: Самигуллин А.И.)",
                    "8 - Домашняя работа \"Расчет индекса массы тела\" (выполнил: Кулик А.А.)",
                    "9 - Домашняя работа \"Работа с дробями\" (выполнил: Кулик А.А.)",
                };
                Console.Clear();
                PrintVariants(variants);

                string line = Console.ReadLine();
                if (string.Equals(line, "q")) break;

                int.TryParse(line, out int numberHomeWork);
                switch (numberHomeWork)
                {
                    case 1:
                        HomeworkKanadeiar.Demo();
                        break;
                    case 2:
                        HomeworkGanov_Les11.Demo();
                        break;
                    case 3:
                        HomeworkGanov_Les12.Demo();
                        break;
                    case 4:
                        MyBestArray.CallProject();
                        break;
                    case 5:
                        HomeworkGanov_Les13.Demo();
                        break;
                    case 6:
                        HomeworkTesting.Demo();
                        break;
                    case 7:
                        HomeWorkSamigullin.Run();
                        break;
                    case 8:
                        HomeWorkKulik.Lesson02Task5_BMI.EvalBMI();
                        break;
                    case 9:
                        HomeWorkKulik.Lesson03Task3_Divides.Run();
                        break;
                    default:
                        Console.WriteLine("Нет домашней работы под таким номером!");
                        break;
                }
            }
            Console.WriteLine("Нажмите любую кнопку для выхода...");
            Console.ReadKey();
        }
        static void PrintVariants(string[] arrVariants)
        {
            foreach (var item in arrVariants)
                Console.WriteLine(item);
        }
    }
}
