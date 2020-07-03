using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultativeCourseWork1
{
    class HomeWorkSamigullin
    {
        /// <summary>Метод запуска</summary>
        public static void Run()
        {
            double high, weight;
            bool flH, flW;
            do
            {
                Console.Write("Введите Ваш рост, в см: ");
                flH = double.TryParse(Console.ReadLine(), out high);
            } while (!flH);

            do
            {
                Console.Write("Введите Ваш вес, в кг: ");
                flW = double.TryParse(Console.ReadLine(), out weight);
            } while (!flW);

            Console.WriteLine();
            
            IMT(weight, high);

            Console.ReadKey();
        }

        /// <summary>
        /// Подсчет ИМТ
        /// </summary>
        /// <param name="_weight">Вес</param>
        /// <param name="_high">Рост</param>
        static void IMT(double _weight, double _high)                      
        {
            bool flNormal = false;
            //Коэффициент 10 000 используется для перевода см в метры:
            double imt = _weight * 10_000 / ((_high * _high));
            Console.WriteLine($"ИМТ человека ростом {_high} и весом {_weight} равен {imt:F2} \n");
            if (imt < 16) printColor(ConsoleColor.DarkRed, "Выраженный дефицит массы тела, надо поправиться, дрищ!");
            else if (imt >= 16 && imt < 18.5) printColor(ConsoleColor.DarkYellow, "Недостаточная масса тела, надо поднабрать, доходяга.");
            else if (imt >= 18.5 && imt <= 25) { printColor(ConsoleColor.Green, "Все в норме, так держать."); flNormal = true; }
            else if (imt > 25 && imt < 30) printColor(ConsoleColor.DarkYellow, "Избыточная масса тела. Кому-то пора меньше плюшек жрать.");
            else if (imt >= 30 && imt < 35) printColor(ConsoleColor.Red, "Ожирение. Пора худеть.");
            else if (imt >= 35 && imt < 40) printColor(ConsoleColor.Red, "Ожирение резкое. Нужна мощная диета.");
            else if (imt >= 40) printColor(ConsoleColor.DarkRed, "Очень резкое ожирение. Потрачено.");

            //добивочка - вызов метода подсчета перебора/нехватки килограмм до нормы:
            if (!flNormal)
            {
                Console.WriteLine();
                ToNormalize(imt, _weight, _high);
            }          
        }

        /// <summary>
        /// Подстчет необходимого набора/потери веса, для нормализации ИМТ.
        /// </summary>
        /// <param name="_imt">ИМТ</param>
        /// <param name="_weight">Вес</param>
        /// <param name="_high">Рост</param>
        static void ToNormalize(double _imt, double _weight, double _high)
        {
            //чтоб посчитать необходимый вес при имеющихся росте и ИМТ используем формулу w= h^2 * imt. А затем получаем разницу с текущим весом.
            //Коэффициент 10 000 используется для перевода см в метры:
            if (_imt < 18.5) Console.WriteLine("Для нормализации веса надо набрать {0:F2} кг", ((_high * _high) * 18.5 / 10000) - _weight);
            else if (_imt >= 25) Console.WriteLine("Для нормализации веса надо скинуть {0:F2} кг", _weight - ((_high * _high) * 25 / 10000));
        }

        /// <summary>
        /// Цветной вывод в консоль
        /// </summary>
        /// <param name="_color">Цвет</param>
        /// <param name="_str">Строка</param>
        public static void printColor(ConsoleColor _color, string _str)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine(_str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
