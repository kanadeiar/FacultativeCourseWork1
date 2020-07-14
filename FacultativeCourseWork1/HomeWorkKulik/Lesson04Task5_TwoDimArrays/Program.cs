using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultativeCourseWork1.HomeWorkKulik
{
	class Program
	{
		/// <summary>
		/// Алексей Кулик kpblc2000@yandex.ru
		/// Урок 4, задача 5
		/// а)* Реализовать библиотеку с классом для работы с двумерным массивом. 
		/// Реализовать конструктор, заполняющий массив случайными числами. 
		/// Создать методы, которые возвращают сумму всех элементов массива, 
		/// сумму всех элементов массива больше заданного, 
		/// свойство, возвращающее минимальный элемент массива, 
		/// свойство, возвращающее максимальный элемент массива, 
		/// метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
		/// б)** Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл
		/// в)** Обработать возможные исключительные ситуации при работе с файлами.
		/// </summary>
		static void Main()
		{
			Console.WriteLine("Проверка работы с двумерными массивами");
			TwoDimArray ar;

			#region Инициализация двумерного массива случайными числами
			Console.WriteLine("Инициализация двумерного массива случайными числами");
			ar = new TwoDimArray(2, 5);

			TestAllFunctionality(ar);
			#endregion

			#region Чтение массива из файла
			Console.WriteLine("Чтение массива из файла");
			ar = new TwoDimArray("..\\..\\IntArray.txt");

			TestAllFunctionality(ar);
			#endregion
			
			Console.WriteLine("Работа закончена. Нажмите любую клавишу");
			Console.ReadKey();
		}

		/// <summary>
		/// Проверка работы с массивом целых чисел
		/// </summary>
		/// <param name="ar">обрабатываемый массив</param>
		private static void TestAllFunctionality(TwoDimArray ar)
		{
			if (ar != null)
			{

				// Проверка, чем же был заполнен массив
				Console.WriteLine($"Текущее состояние массива\n{ar}");

				#region Сумма всех элементов массива
				Console.WriteLine($"Сумма элементов массива : {ar.SumAllArray}");
				#endregion

				#region Сумма элементов больше заданного
				Console.Write("Введите число для подсчета суммы элементов массива больше него : ");
				int minValue = int.Parse(Console.ReadLine());
				Console.WriteLine($"Сумма элементов массива больше {minValue} : {ar.SumArrayMoreThan(minValue)}");
				#endregion

				#region Максимальный элемент массива
				Console.WriteLine($"Максимальный элемент массива : {ar.Maximum}");
				#endregion

				#region Минимальный элемент массива
				Console.WriteLine($"Минимальный элемент массива : {ar.Minimum}");
				#endregion

				#region Индекс максимального элемента массива через out
				ar.GetIndexOfMaximumOut(out int row, out int col);
				Console.WriteLine($"Индекс максимального элемента массива через out (переменные не инициализировались) : [{row}],[{col}]");
				#endregion

				#region Индекс максимального элемента массива через ref
				int refRow = -1;
				int refCol = -1;
				Console.WriteLine($"Индекс максимального элемента массива через ref; refRow = {refRow}; refCol = {refCol}");
				ar.GetIndexOfMaximumRef(ref refRow, ref refCol);
				Console.WriteLine($"Индекс максимального элемента массива через ref : [{refRow}],[{refCol}]");
				#endregion

				#region Запись массива в файл
				Console.WriteLine("Введите путь к файлу, куда будет выполняться запись результата : ");
				string FileNameToWrite = Console.ReadLine();
				if (ar.WriteArrayToFile(FileNameToWrite))
					Console.WriteLine($"Записано в {FileNameToWrite}");
				#endregion
			}
			else
			{
				Console.WriteLine("Передан пустой массив, проверять нечего");
			}
		}
	}
}
