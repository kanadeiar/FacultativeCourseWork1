using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultativeCourseWork1.HomeWorkKulik
{
	/// <summary>
	/// Алексей Кулик kpblc2000@yandex.ru
	/// Подсчет индекса массы тела
	/// </summary>
	static class Lesson02Task5_BMI
	{
		enum BMI
		{
			Buchenvald,
			Slim,
			Normal,
			SomeFat,
			Fat,
			Pig,
			FatPig
		}

		public static void EvalBMI()
		{

			double mass, height;
			Console.WriteLine("Расчет индекса массы тела");
			Console.Write("Введите свой вес, кг: ");
			mass = double.Parse(Console.ReadLine().Replace(',', '.'));
			Console.Write("Введите свой рост, см: ");
			height = double.Parse(Console.ReadLine().Replace(',', '.'));
			height /= 100;

			BMI res = EvaluateBMI(mass, height);

			switch (res)
			{
				case BMI.Buchenvald:
					Console.WriteLine("У вас выраженный недобор веса. Обратитесь к врачу!");
					break;
				case BMI.Slim:
					Console.WriteLine("У Вас недобор веса.");
					break;
				case BMI.Normal:
					Console.WriteLine("У Вас все в норме, поздравляем!");
					break;
				case BMI.SomeFat:
					Console.WriteLine("У Вас небольшой избыток массы, рекомендуем похудеть.");
					break;
				case BMI.Fat:
					Console.WriteLine("У Вас можно диагностировать ожирение. Рекомендуем заняться спортом.");
					break;
				case BMI.Pig:
					Console.WriteLine("У Вас можно диагностировать резкое ожирение. Рекомендуем обратиться к врачу.");
					break;
				case BMI.FatPig:
					Console.WriteLine("У Вас можно диагностировать очень резкое ожирение. Обязательно обратитесь к врачу.");
					break;
				default:
					Console.WriteLine("У Вас избыток массы, рекомендуем похудеть.");
					break;
			}

			#region Задача б
			if (res != BMI.Normal)
			{
				double minWeight = Math.Abs(18.5 * Math.Pow(height, 2) - mass);
				double maxWeight = Math.Abs(25 * Math.Pow(height, 2) - mass);
				switch (res)
				{
					case BMI.Buchenvald:
					case BMI.Slim:
						Console.WriteLine("Вам необходимо набрать от {0:N2} до {1:N2} кг веса", minWeight, maxWeight);
						break;
					default:
						Console.WriteLine("Вам необходимо сбросить от {0:N2} до {1:N2} кг веса", maxWeight, minWeight);
						break;
				}
			}
			#endregion

			Console.WriteLine("Нажмите любую клавишу");
			Console.ReadKey();
		}

		static BMI EvaluateBMI(double Mass, double Height)
		{
			double idx = Mass / Math.Pow(Height, 2);
			BMI res;
			if (idx < 16)
				res = BMI.Buchenvald;
			else
				if (idx < 18.5)
				res = BMI.Slim;
			else
					if (idx < 25)
				res = BMI.Normal;
			else
						if (idx < 30)
				res = BMI.SomeFat;
			else
							if (idx < 35)
				res = BMI.Fat;
			else
							if (idx < 40)
				res = BMI.Pig;
			else
				res = BMI.FatPig;
			return res;
		}
	}
}
