using System;
using System.Diagnostics;
using DataStructures_Algorithms.Week02;

namespace Runner
{
	public class Runer_Lecture02 : IRunner
	{
		public Runer_Lecture02()
		{
		}

		public void Run(string[] args)
		{
			
			if (args.Length < 1)
			{
				Console.WriteLine("input file name is missing");
				return;
			}
			Vector<int> vector = null;

			string inputFileName = args[0];
			string outputFileName = "S_1H.txt";
			DataSerializer<int>.LoadVectorFromTextFile(inputFileName, ref vector);

			if (vector == null)
			{
				Console.WriteLine("Failed to load data from input file");
				return;
			}

			//let's check the capacity & count now
			Console.WriteLine("Vector Capacity is {0}", vector.Capacity);
			Console.WriteLine("Vector Count is {0}", vector.Count);

			Stopwatch s = new Stopwatch();
			s.Start();
			vector.SortBubble();
			s.Stop();
			Console.WriteLine("time to sort {0}", s.Elapsed.TotalMilliseconds);


			Console.Read();

		}


}
}

