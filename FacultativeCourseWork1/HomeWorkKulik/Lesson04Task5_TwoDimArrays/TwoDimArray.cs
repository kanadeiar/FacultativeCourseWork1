using System;
using System.IO;
using System.Collections.Generic;

namespace FacultativeCourseWork1.HomeWorkKulik
{
	class TwoDimArray
	{
		private int[,] _array;
		private int _rows;
		private int _cols;

		/// <summary>
		/// Создание двумерного массива и заполнение его случайными числами от -100 до 100
		/// </summary>
		/// <param name="Rows">Количество строк массива. При попытке задания отрицательного значения принимается равным 1</param>
		/// <param name="Columns">Количество колонок массива. При попытке задания отрицательного значения принимается равным 1</param>
		public TwoDimArray(int Rows, int Columns)
		{
			int minValue = -100;
			int maxValue = 100;
			_cols = Math.Max(Columns, 1);
			_rows = Math.Max(Rows, 1);

			Random rnd = new Random();

			_array = new int[_rows, _cols];
			for (int i = 0; i < _rows; i++)
			{
				for (int j = 0; j < _cols; j++)
				{
					_array[i, j] = rnd.Next(minValue, maxValue);
				}
			}
		}

		/// <summary>
		/// Инициализация двумерного массива на основании существующего файла. Разделение элементов выполняется по пробелам и/или запятым
		/// </summary>
		/// <param name="FileName">Путь к файлу, включая расширение</param>
		public TwoDimArray(string FileName)
		{
			if (File.Exists(FileName))
			{
				int rowCount = 0;
				int colLen = 0;
				List<string[]> resArray = new List<string[]>();

				StreamReader sr = new StreamReader(FileName);
				while (!sr.EndOfStream)
				{
					string[] arString = sr.ReadLine().Split(new char[] { ' ', ',' });
					rowCount += 1;
					colLen = Math.Max(colLen, arString.Length);
					resArray.Add(arString);
				}
				sr.Close();

				_rows = rowCount;
				_cols = colLen;
				_array = new int[rowCount, colLen];
				for (int i = 0; i < rowCount; i++)
				{
					for (int j = 0; j < colLen; j++)
					{
						if (j >= resArray[i].Length)
						{
							_array[i, j] = 0;
						}
						else
						{
							int x;
							if (int.TryParse(resArray[i][j], out x)) _array[i, j] = x;
							else _array[i, j] = 0;
						}
					}
				}
			}
		}

		public override string ToString()
		{
			string res = "";
			for (int i = 0; i < _rows; i++)
			{
				for (int j = 0; j < _cols; j++)
				{
					res += $"{_array[i, j],4} ";
				}
				res += "\n";
			}
			return res;
		}

		/// <summary>
		/// Сумма всех элементов массива
		/// </summary>
		public int SumAllArray
		{
			get
			{
				int res = 0;
				for (int i = 0; i < _rows; i++)
				{
					for (int j = 0; j < _cols; j++)
					{
						res += _array[i, j];
					}
				}
				return res;
			}
		}

		/// <summary>
		/// Сумма элементов массива больше заданного
		/// </summary>
		/// <param name="MinimalValue">Нижняя граница. Числа меньше или равные указанному не учавствуют в подсчете</param>
		/// <returns></returns>
		public int SumArrayMoreThan(int MinimalValue)
		{
			int res = 0;
			for (int i = 0; i < _rows; i++)
			{
				for (int j = 0; j < _cols; j++)
				{
					if (_array[i, j] > MinimalValue)
					{
						res += _array[i, j];
					}
				}
			}
			return res;
		}

		/// <summary>
		/// Минимальное значение массива
		/// </summary>
		public int Minimum
		{
			get
			{
				int res = int.MaxValue;
				for (int i = 0; i < _rows; i++)
				{
					for (int j = 0; j < _cols; j++)
					{
						if (_array[i, j] < res)
						{
							res = _array[i, j];
						}
					}
				}
				return res;
			}
		}

		/// <summary>
		/// Максимальное значение массива
		/// </summary>
		public int Maximum
		{
			get
			{
				int res = int.MinValue;
				for (int i = 0; i < _rows; i++)
				{
					for (int j = 0; j < _cols; j++)
					{
						if (_array[i, j] > res)
						{
							res = _array[i, j];
						}
					}
				}
				return res;
			}
		}

		/// <summary>
		/// Получение индексов максмального значения массива.
		/// </summary>
		/// <param name="Row">Индекс строки, в которой находится максимальный элемент</param>
		/// <param name="Col">Индекс колонки, в которой находится максимальный элемент</param>
		public void GetIndexOfMaximumOut(out int Row, out int Col)
		{
			int maxVal = Maximum;
			Row = -1;
			Col = -1;

			for (int i = 0; i < _rows; i++)
			{
				for (int j = 0; j < _cols; j++)
				{
					if (_array[i, j] == maxVal)
					{
						Row = i;
						Col = j;
						break;
					}
				}
			}
		}

		/// <summary>
		/// Получение индексов максмального значения массива.
		/// Предварительное объявление и инициализация переменных обязательна
		/// </summary>
		/// <param name="Row">Индекс строки, в которой находится максимальный элемент</param>
		/// <param name="Col">Индекс колонки, в которой находится максимальный элемент</param>
		public void GetIndexOfMaximumRef(ref int Row, ref int Col)
		{
			int maxVal = Maximum;
			for (int i = 0; i < _rows; i++)
			{
				for (int j = 0; j < _cols; j++)
				{
					if (_array[i, j] == maxVal)
					{
						Row = i;
						Col = j;
						break;
					}
				}
			}
		}

		/// <summary>
		/// Запись массива в текстовый файл. С обработкой ошибок
		/// </summary>
		/// <param name="FileName">Путь к файлу, куда необходимо выполнить запись</param>
		/// <returns></returns>
		public bool WriteArrayToFile(string FileName)
		{
			bool res = false;
			try
			{
				string[] strList = new string[_rows];
				for (int i = 0; i < _rows; i++)
				{
					string s = $"{_array[i,0]}";
					for (int j = 1; j < _cols; j++)
					{
						s += $" {_array[i, j]}";
					}
					strList[i] = s;
				}
				StreamWriter sw = new StreamWriter(FileName);
				for (int i = 0; i < strList.Length; i++)
				{
					sw.WriteLine(strList[i]);
				}
				sw.Close();
				res = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при записи массива в файл : {ex}");
			}
			return res;
		}

	}
}
