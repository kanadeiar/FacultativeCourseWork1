using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultativeCourseWork1
{
    class HomeworkGanov_Les12
    {
        public static void Demo()
        {
            double digit;
            double sum = 0;
            List<double> lst = new List<double>();
            ConsoleInteraction ask;

            do
            {
                digit = ask.GetValueDouble("Введите любое число: ");
                if (digit % 2 != 0 && digit > 0)
                {
                    lst.Add(digit);
                    sum += digit;
                }
            } while (digit != 0);
            if (sum > 0)
            {
                Console.WriteLine($"Сумма нечетных положительных чисел: {sum}");
                Console.WriteLine($"Были введены следующие числа: ");
                foreach (double lstItem in lst) Console.WriteLine(lstItem);
            }
            else Console.WriteLine("Вы не ввели ни одно нечетное положительное число");
            Console.ReadLine();
        }
    }
}