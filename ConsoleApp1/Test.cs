using System;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

internal class Test
{
	private Func<string[], string> run;

	public Test(Func<string[], string> run)
	{
		this.run = run;
	}
	public void Run()
	{
		int iter = 0;
		while (true)
		{
			string fileIn = $"..\\..\\..\\Tests\\test.{iter}.in";
			string fileOut = $"..\\..\\..\\Tests\\test.{iter}.out";

			if (!File.Exists(fileIn) || !File.Exists(fileOut))
				return;

			string[] input = File.ReadAllLines(fileIn);
			string[] output = File.ReadAllLines(fileOut);
			var watch = System.Diagnostics.Stopwatch.StartNew();
			string x = run(input);
			watch.Stop();
			var elapsedMs = watch.ElapsedMilliseconds;

			if (x == output[0])
			{
				Console.WriteLine("Тест " + iter + " OK: " + x + " (Exec. time: ~" + elapsedMs / 1000 + "." + elapsedMs % 1000 + " sec.)");
			}
			else
			{
				Console.WriteLine("Тест " + iter + " ошибка: " + x +
								  " ожидалось: " + output[0] + " (Exec. time: ~" + elapsedMs / 1000 + "." + elapsedMs % 1000 + "sec.)");
			}
			iter++;

		}
	}
}
