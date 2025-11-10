
using System.Collections.Specialized;

internal class Program
{
	static void Main(string[] args)
	{
		

		//string fullPath = System.IO.Path.GetFullPath("..\\..\\..\\Tests\\test.0.in");

		//Console.WriteLine(fullPath);
		//Console.WriteLine(File.Exists(fullPath) == true ? "true" : "false");

		Solver solver = new Solver();
		Test test = new Test(solver.Run);
		test.Run();
		Console.ReadKey();
	}		
}
