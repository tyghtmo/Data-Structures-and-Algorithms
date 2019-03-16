using System;
using System.Diagnostics;
using DataStructures_Algorithms;
using DataStructures_Algorithms.Project1;

namespace Runner
{
	public class Project01_Task01 : IRunner
	{
		public Project01_Task01()
		{
		}

		public void Run(string[] args)
		{
			string inputFilename = "../../Data/Project01/" + args[0];
			string bubbleSortOutputFilename = "../../Data/Project01/" + "BubbleSort_" + args[0];
            string quickSortOutputFilename = "../../Data/Project01/" + "QuickSort_" + args[0];

            Vector<int> vector = null;
            DataSerializer<int>.LoadVectorFromTextFile(inputFilename, ref vector);

            if (vector == null)
			{
				Console.WriteLine("Failed to load data from input file");
				return;
			}

			//let's check the capacity & count now
			Console.WriteLine("Vector Capacity is {0}", vector.Capacity);
			Console.WriteLine("Vector Count is {0}", vector.Count);

            //Let's sort Vector in ascending order using Bubble Sort algorithm
			var memBefore1 = Process.GetCurrentProcess().WorkingSet64;
			Stopwatch s1 = new Stopwatch();
			s1.Start();

            Vector<int> bubbleSortedIndices = vector.BubbleSortIndex();

			s1.Stop();
			var memAfter1 = Process.GetCurrentProcess().WorkingSet64;
			Console.WriteLine("execution time of Bubble Sort = " + s1.ElapsedMilliseconds + ", and memory =" + (memAfter1 - memBefore1) / 1024.0);

            // write the sorted indices to file
            Console.WriteLine("Data has been sorted using Bubble Sort algorithm");
            DataSerializer<int>.SaveVectorToTextFile(bubbleSortOutputFilename, bubbleSortedIndices);
            Console.WriteLine(string.Format("Result of Bubble Sort algorithm has been stored to {0}", bubbleSortOutputFilename));

            //Let's sort Vector in ascending order using Quick Sort algorithm
            var memBefore2 = Process.GetCurrentProcess().WorkingSet64;
            Stopwatch s2 = new Stopwatch();
            s2.Start();

            Vector<int> quickSortedIndices = vector.QuickSortIndex();

            s2.Stop();
            var memAfter2 = Process.GetCurrentProcess().WorkingSet64;
            Console.WriteLine("execution time of Quick Sort = " + s2.ElapsedMilliseconds + ", and memory =" + (memAfter2 - memBefore2) / 1024.0);

            // write the sorted indices to file
            Console.WriteLine("Data has been sorted using Quick Sort algorithm");
            DataSerializer<int>.SaveVectorToTextFile(quickSortOutputFilename, quickSortedIndices);
            Console.WriteLine(string.Format("Result of Quick Sort algorithm has been stored to {0}", quickSortOutputFilename));

            Console.Read();
        }
    }
}