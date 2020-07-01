using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultativeCourseWork1
{
    class HomeworkGanov_Les11
    {
        public static void Demo()
        {
            ConsoleInteraction ask = new ConsoleInteraction();
            Double real1 = ask.GetValueDouble("Введите реальную часть комплексного числа #1: ");
            Double img1 = ask.GetValueDouble("Введите мнимую часть комплексного числа #1: ");
            Double real2 = ask.GetValueDouble("Введите реальную часть комплексного числа #2: ");
            Double img2 = ask.GetValueDouble("Введите мнимую часть комплексного числа #2: ");

            ComplexClass dig1 = new ComplexClass(real1, img1);
            ComplexClass dig2 = new ComplexClass(real2, img2);
            Console.WriteLine($"\nВведены два комплексных числа: {dig1.ConvertToString()}, {dig2.ConvertToString()}");

            bool ansContinue;
            do
            {
                Console.WriteLine("\nВ программе предусмотрены следующие арифметические операции:"
                    + "\n1 - Сложение"
                    + "\n2 - Вычитание"
                    + "\n3 - Умножение"
                    + "\n4 - Деление"
                    );
                int ans = ask.GetValueInt("Выберите необходимое действие: ");

                switch (ans)
                {
                    case 1:
                        Console.WriteLine($"\nРезультат сложения: {dig1.Add(dig2).ConvertToString()}");
                        break;
                    case 2:
                        Console.WriteLine($"\nРезультат вычитания: {dig1.Substract(dig2).ConvertToString()}");
                        break;
                    case 3:
                        Console.WriteLine($"\nРезультат умножения: {dig1.Multiply(dig2).ConvertToString()}");
                        break;
                    case 4:
                        Console.WriteLine($"\nРезультат деления: {dig1.Devide(dig2).ConvertToString()}");
                        break;
                    default:
                        Console.WriteLine($"Функция с кодом \"{ans}\" отсутствует в программе");
                        break;
                }
                ansContinue = ask.AnsYesNo("Желаете выполнить еще какие-либо действия? (y/n)");
            } while (ansContinue);
        }
    }
    class ComplexClass
    {
        double re;
        double im;

        public ComplexClass()
        {
            re = 0;
            im = 0;
        }
        public ComplexClass(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public ComplexClass Add(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.re = re + x2.re;
            x3.im = im + x2.im;
            return x3;
        }
        public ComplexClass Substract(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.re = re - x2.re;
            x3.im = im - x2.im;
            return x3;
        }
        public ComplexClass Devide(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.re = (re * x2.re + im * x2.im) / (Math.Pow(x2.re, 2) + Math.Pow(x2.im, 2));
            x3.im = (x2.re * im - re * x2.im) / (Math.Pow(x2.re, 2) + Math.Pow(x2.im, 2));
            return x3;
        }
        public ComplexClass Multiply(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.re = re * x2.re - im * x2.im;
            x3.im = re * x2.im + x2.re * im;
            return x3;
        }
        public string ConvertToString()
        {
            return re + "+" + im + "i";
        }
    }
    public struct ConsoleInteraction
    {
        /// <summary>
        /// Реализует выдачу ответа "Да/Нет" на запрос пользователя
        /// </summary>
        /// <param name="question">Вопросы, выводимый пользователю</param>
        /// <returns>булево True/False</returns>
        public bool AnsYesNo(string question)
        {
            string ans;
            ans = AskUser(question).ToLower();
            while (!(ans == "y" || ans == "n"))
            {
                ans = AskUser("Введите \"y\" или \"n\", другие ответы не допускаются").ToLower();
            }
            if (ans == "y") return true; else return false;
        }
        /// <summary>
        /// Вывод запроса пользователю через консоль и возврат результата ввода
        /// </summary>
        /// <param name="str">вопрос пользователю</param>
        /// <returns>ответ пользователя</returns>
        public string AskUser(string str)
        {
            Console.Write(str + ": ");
            return Console.ReadLine();
        }
        public int GetDenominator(string str)
        {
            int den;
            do
            {
                den = GetValueInt(str);
                try
                {
                    if (den == 0) throw new Exception($"Знаменатель не может быть равен нулю, введите другое число");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            } while (den == 0);
            return den;
        }
        /// <summary>
        /// Запрос значения "Int" через консоль с проверкой на тип значения
        /// </summary>
        /// <param name="msg">Сообщение, выдаваемое пользователю</param>
        /// <returns>Введенное в консоль значение</returns>
        public int GetValueInt(string msg)
        {
            int x; bool flag;
            do
            {
                Console.Write(msg);
                flag = int.TryParse(Console.ReadLine(), out x);
            }
            while (!flag);  //  Пока false(!false=true), повторять цикл
            return x;
        }
        /// <summary>
        /// Запрос значения "Double" через консоль с проверкой на тип значения
        /// </summary>
        /// <param name="msg">Сообщение, выдаваемое пользователю</param>
        /// <returns>Введенное в консоль значение</returns>
        public double GetValueDouble(string msg)
        {
            double x; bool flag;
            do
            {
                Console.Write(msg);
                flag = double.TryParse(Console.ReadLine(), out x);
            }
            while (!flag);  //  Пока false(!false=true), повторять цикл
            return x;
        }
    }
}