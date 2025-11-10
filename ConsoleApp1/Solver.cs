using System;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.InteropServices;

internal class Solver
{
	public string Run(string[] args)
	{
		int n = int.Parse(args[0]);
		return Tickets(n).ToString();
	}

	private long Tickets(int n)
	{
		long tickets = 0;
		for (int i = 0; i <= n*9; i++) {
			tickets += (long)Math.Pow(GetSumm(n, i), 2);
		}

		return tickets;
	}

	/**
	 * n - n значное число
	 * k - Сумма цифр числа
	 * x - Последняя цифра числа с одной стороны
	 */
	static private long GetSumm(int n, int k)
	{
	
		if (n == 0)
		{
			return 0;
		}
		/** 
		 * При n = 1, - сумма чисел с одной стороны равна той же цифре,
		 * соответственно всегда 1, если k <= (макс. возможная сумма чисел т.е. 9)
		 */
		if (n == 1)
		{
			return k <= 9 ? 1 : 0;
		}

		long sum = 0;
		Console.WriteLine((n * 9) - 9);

		/** 
		 * Проходим по каждой колонке из таблицы и находим сумму чисел в каждой ячейке
		 * "Срезаем" начальынй угол до суммы 9
		 */
		if (k < 9)
		{
			/**
			 * В соответствии с таблицей в материалах домашней работы,
			 * выполняем перебор последниx чисел от 0 до значения представленной в k.
			 * Т.к. сумма цифр числа, при последней цифре x > k равна 0, соответственно не учитываем;
			 * Другими словами, "Срезаем углы"
			 */
			for (int x = 0; x <= k; x++)
			{
				sum += GetSumm(n - 1, k - x);
			} 
		}
		 // Попытка срезать конечный угол. Незакончено
		else if (k >= (n * 9) - 9) 
		{
			// >= 9
			for (int x = 0; x >= (n * 9) - k; x++)
			{
				sum += GetSumm(n - 1, k - x);
			}
		}
		else 
		{
			for (int x = 0; x <= 9; x++)
			{
				sum += GetSumm(n - 1, k - x);
			}
		}

		return sum;
	}
}
