using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultativeCourseWork1
{
    class HomeworkGanov_Les13
    {
        public static void Demo()
        {
            ConsoleInteraction ask = new ConsoleInteraction();

            int num1 = ask.GetValueInt("Введите числитель дроби #1: ");
            int den1 = ask.GetDenominator("Введите знаменатель дроби #1: ");
            int num2 = ask.GetValueInt("Введите числитель дроби #2: ");
            int den2 = ask.GetDenominator("Введите знаменатель дроби #2: ");

            NaturalFraction dig1 = new NaturalFraction(num1, den1);
            NaturalFraction dig2 = new NaturalFraction(num2, den2);
            Console.WriteLine($"\nВведены две дроби: {dig1.ConvertToString(false)}, {dig2.ConvertToString(false)}");

            bool ansContinue;
            do
            {
                Console.WriteLine("\nВ программе предусмотрены следующие операции с дробями:"
                    + "\n1 - Сложение"
                    + "\n2 - Вычитание"
                    + "\n3 - Умножение"
                    + "\n4 - Деление"
                    + "\n5 - Упрощение"
                    + "\n6 - Вывод в виде десятичной дроби"
                    );
                int ans = ask.GetValueInt("Выберите необходимое действие: ");

                switch (ans)
                {
                    case 1:
                        Console.WriteLine($"\nРезультат сложения: {dig1.Add(dig2).ConvertToString(true)}");
                        break;
                    case 2:
                        Console.WriteLine($"\nРезультат вычитания: {dig1.Substract(dig2).ConvertToString(true)}");
                        break;
                    case 3:
                        Console.WriteLine($"\nРезультат умножения: {dig1.Multiply(dig2).ConvertToString(true)}");
                        break;
                    case 4:
                        Console.WriteLine($"\nРезультат деления: {dig1.Devide(dig2).ConvertToString(true)}");
                        break;
                    case 5:
                        Console.WriteLine($"\nУпрощенные дроби: {dig1.ConvertToString(true)},  {dig2.ConvertToString(true)}");
                        break;
                    case 6:
                        Console.WriteLine($"\nУпрощенные дроби: {dig1.DecimalFraction.ToString().Replace(',', '.')},  {dig2.DecimalFraction.ToString().Replace(',', '.')}");
                        break;
                    default:
                        Console.WriteLine($"Функция с кодом \"{ans}\" отсутствует в программе");
                        break;
                }
                ansContinue = ask.AnsYesNo("Желаете выполнить еще какие-либо действия? (y/n)");
            } while (ansContinue);
        }
    }
    class NaturalFraction
    {
        int num; // numerator
        int den; // denominator

        /// <summary>
        /// Значение числителя дроби
        /// </summary>
        public int Numerator
        {
            get => num;
            set => num = Numerator;
        }
        /// <summary>
        /// Значение знаменателя дроби
        /// </summary>
        public int Denominator
        {
            get => den;
            set => den = Denominator;
        }
        /// <summary>
        /// Значение знаменателя дроби
        /// </summary>
        public double DecimalFraction
        {
            get => Math.Round((double)num / den, 2);
        }

        public NaturalFraction()
        {
            num = 0;
            den = 0;
        }
        public NaturalFraction(int num, int den)
        {
            this.num = num;
            this.den = den;
        }
        public NaturalFraction Add(NaturalFraction x2)
        {
            NaturalFraction x3 = new NaturalFraction();
            if (den == x2.den)
            {
                x3.num = num + x2.num;
                x3.den = den;
                return x3;
            }
            else
            {
                x3.num = (num * x2.den + x2.num * den);
                x3.den = den * x2.den;
                return x3;
            }
        }
        public NaturalFraction Substract(NaturalFraction x2)
        {
            NaturalFraction x3 = new NaturalFraction();
            if (den == x2.den)
            {
                x3.num = num - x2.num;
                x3.den = den;
                return x3;
            }
            else
            {
                x3.num = (num * x2.den - x2.num * den);
                x3.den = den * x2.den;
                return x3;
            }
        }
        public NaturalFraction Multiply(NaturalFraction x2)
        {
            NaturalFraction x3 = new NaturalFraction();
            x3.num = x2.num * num;
            x3.den = x2.den * den;
            return x3;
        }
        public NaturalFraction Devide(NaturalFraction x2)
        {
            NaturalFraction x3 = new NaturalFraction();
            x3.num = num * x2.den;
            x3.den = den * x2.num;
            return x3;
        }
        /// <summary>
        /// Вычисляет наибольший общий делитель числителя и знаменателя
        /// </summary>
        /// <param name="num">Числитель</param>
        /// <param name="den">Знаменатель</param>
        /// <returns>НОД числителя и знаменателя</returns>
        int NOD(int num, int den)
        {
            while (num != den)
                if (num > den) num -= den; else den -= num;
            return num;
        }
        /// <summary>
        /// конвертирует дроби в стройковый формат с упрощение или без
        /// </summary>
        /// <param name="simplify">truе - упрощать, false - не упрощать</param>
        /// <returns>дробь в строковом формате</returns>
        public string ConvertToString(bool simplify)
        {
            int nod = NOD(Math.Abs(num), den);
            if (simplify && num > den)
            {
                num /= nod; den /= nod;
                if (num % den != 0) return num / den + "-" + num % den + "/" + den;
                else return (num / den).ToString();
            }
            else if (simplify && num <= den)
            {
                num /= nod; den /= nod;
                return num + "/" + den;
            }
            else return num + "/" + den;
        }
    }
}