using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultativeCourseWork1.HomeWorkKulik
{
	/// <summary>
	/// Алексей Кулик kpblc2000@yandex.ru
	/// Работа с классом для обработки натуральных дробей
	/// </summary>

	class Fraction
	{
		private int num; // числитель
		private int denom; // знаменатель
		private int delim; // максимальный общий делитель

		#region Добавить упрощение дробей.
		/// <summary>
		/// Вычисление наибольшего общего делителя. Введено в конструктор класса, а также в назначение полей класса.
		/// Возможно, это неверное решение.
		/// </summary>
		/// <param name="Value1"></param>
		/// <param name="Value2"></param>
		/// <returns></returns>
		private static int EvalDelim(int Value1, int Value2)
		{
			int val1 = Math.Abs(Value1);
			int val2 = Math.Abs(Value2);

			if (val1 == 0 || val2 == 0 || val1 == 1 || val2 == 1)
				return 1;
			else
			{
				while (val1 != val2)
				{
					if (val1 > val2)
						val1 -= val2;
					else
						val2 -= val1;
				}
				return val1;
			}
		}
		#endregion

		public Fraction()
		{
			num = 0;
			denom = 1;
		}
		public Fraction(int Numerator)
		{
			num = Numerator;
			denom = 1;
		}
		public Fraction(int Numerator, int Denominator)
		{	if (Denominator == 0)
			{
				throw new ArgumentException("Знаменатель не может быть равным 0");
			}
			else
			{
				delim = EvalDelim(Numerator, Denominator);
				num = Numerator / delim;
				denom = Denominator / delim;
				if (denom < 0)
				{
					num = -num;
					denom = -denom;
				}
			}
		}

		public int Numerator
		{
			get { return num; }
			set
			{
				int temp = value;
				int delim = EvalDelim(temp, denom);
				num = value / delim;
				denom /= delim;
			}
		}
		public int Denominator
		{
			get { return denom; }
			set
			{
				int temp = value;
				int delim = EvalDelim(num, temp);
				num /= temp;
				denom = value / delim;
			}
		}
		
		public double Value { get { return num / (double)denom; } }

		public static Fraction operator +(Fraction Value1, Fraction Value2)
		{ return new Fraction(Value1.Numerator * Value2.Denominator + Value1.Denominator * Value2.Numerator, Value1.Denominator * Value2.Denominator); }

		public static Fraction operator -(Fraction Value1, Fraction Value2)
		{ return new Fraction(Value1.Numerator * Value2.Denominator - Value1.Denominator * Value2.Numerator, Value1.Denominator * Value2.Denominator); }

		public static Fraction operator *(Fraction Value1, Fraction Value2)
		{ return new Fraction(Value1.Numerator * Value2.Numerator, Value1.Denominator * Value2.Denominator); }

		public static bool operator >(Fraction Value1, Fraction Value2)
		{ return Value1.Value > Value2.Value; }

		public static bool operator >=(Fraction Value1, Fraction Value2)
		{ return Value1.Value >= Value2.Value; }

		public static bool operator <(Fraction Value1, Fraction Value2)
		{ return Value1.Value < Value2.Value; }

		public static bool operator <=(Fraction Value1, Fraction Value2)
		{ return Value1.Value <= Value2.Value; }

		public static bool operator ==(Fraction Value1, Fraction Value2)
		{ return Value1.Value == Value2.Value; }

		public static bool operator !=(Fraction Value1, Fraction Value2)
		{ return Value1.Value != Value2.Value; }

		public bool Equals(Fraction Value1)
		{
			if (Value1 == null)
				return false;
			return Value1.Numerator == this.num && Value1.Denominator == this.denom;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			Fraction f = obj as Fraction;
			if (f as Fraction == null)
				return false;
			return f.Numerator == this.num && f.Denominator == this.denom;
		}

		public override int GetHashCode()
		{
			return num * denom;
		}


		public override string ToString()
		{
			return (num * denom < 0 ? "-" : "") + Math.Abs(num) + (denom == 1 ? "" : ("/" + Math.Abs(denom)));
		}
	}

	class Lesson03Task3_Divides
	{
		public static void Run()
		{
			Random rnd = new Random();

			Fraction[] ar = new Fraction[5]; // new Fraction[rnd.Next(20)];
			for (int i = 0; i < ar.Length; i++)
			{
				try
				{
					ar[i] = new Fraction(rnd.Next(-20, 20), rnd.Next(-20, 20));
				}
				catch
				{
					--i;
				}
			}

			double sum = 0.0;
			Fraction multi = new Fraction(1, 1);
			
			for (int i = 0; i < ar.Length; i++)
			{
				Console.WriteLine(ar[i]);
				sum += ar[i].Value;
				multi = multi * ar[i];
			}

			Console.WriteLine("Summ = {0:N4}", sum);
			Console.WriteLine("Multiple = {0}; value== {1:N4}", multi, multi.Value);

			Console.ReadKey();
		}
	}
}
