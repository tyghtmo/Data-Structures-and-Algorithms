using System;
using DataStructures_Algorithms;
using DataStructures_Algorithms.Project1;

namespace Runner
{
	public class Project01_Task02 : IRunner
	{
		public Project01_Task02()
		{
		}

        private SetClass<int> loadIntSet(string fileName)
        {
            Vector<int> setData = null;
            DataSerializer<int>.LoadVectorFromTextFile(fileName, ref setData);
            if (setData == null)
            {
                return null;
            }
            return new SetClass<int>(setData);
        }

		public void Run(string[] args)
		{
			if (args.Length != 4)
			{
				Console.WriteLine("Four params are expected!");
                Console.ReadLine();
				return;
			}

			string setAFileName = "../../Data/Project01/" + args[0];
            string setBFileName = "../../Data/Project01/" + args[1];
            string setCFileName = "../../Data/Project01/" + args[2];
            string setDFileName = "../../Data/Project01/" + args[3];

            // load data
            SetClass<int> setA = loadIntSet(setAFileName);
            if (setA == null)
            {
                Console.WriteLine("Failed to load data from input file");
                return;
            }
            SetClass<int> setB = loadIntSet(setBFileName);
            if (setB == null)
            {
                Console.WriteLine("Failed to load data from input file");
                return;
            }
            SetClass<int> setC = loadIntSet(setCFileName);
            if (setC == null)
            {
                Console.WriteLine("Failed to load data from input file");
                return;
            }
            SetClass<int> setD = loadIntSet(setDFileName);
            if (setD == null)
            {
                Console.WriteLine("Failed to load data from input file");
                return;
            }

            // some examples
            int element1 = 0;
            int element2 = 1;

            // test Membership
            Console.WriteLine(string.Format("{0} is an element of A: {1}", element1, setA.Membership(element1)));
            Console.WriteLine(string.Format("{0} is an element of A: {1}", element2, setA.Membership(element2)));

            // test IsSubsetOf
            Console.WriteLine(string.Format("A is a subset of C: {0}", setA.IsSubsetOf(setC)));
            Console.WriteLine(string.Format("C is a subset of A: {0}", setC.IsSubsetOf(setA)));

            // test IsSupersetOf
            Console.WriteLine(string.Format("A is a superset of C: {0}", setA.IsSupersetOf(setC)));
            Console.WriteLine(string.Format("C is a superset of A: {0}", setC.IsSupersetOf(setA)));

            // test Equal
            Console.WriteLine(string.Format("A is equal to D: {0}", setA.IsEqual(setD)));

            // test Powerset
            SetClass<SetClass<int>> powerB = setB.Powerset();
            int sizeOfPowerB = powerB.Data.Count;
            Console.WriteLine(string.Format("Powerset of B includes {0} sets as follows,", sizeOfPowerB));
            for (int i=0; i<sizeOfPowerB; i++)
            {
                int subsetSize = powerB.Data[i].Data.Count;
                
                if (subsetSize == 0)
                    Console.WriteLine("\t Empty,");
                else
                {
                    Console.Write("\t {");
                    for (int j = 0; j < subsetSize - 1; j++)
                        Console.Write(string.Format("{0},", powerB.Data[i].Data[j]));
                    Console.Write(string.Format("{0}", powerB.Data[i].Data[subsetSize-1]));
                    if (i == sizeOfPowerB - 1)
                        Console.WriteLine("}");
                    else
                        Console.WriteLine("},");
                }
            }

            // test IntersectionWith
            SetClass<int> interAB = setA.IntersectionWith(setB);
            Console.Write("Intersection of A and B is: ");
            if (interAB.Data.Count == 0)
                Console.WriteLine("Empty");
            else
            {
                Console.Write("{");
                for (int i = 0; i < interAB.Data.Count - 1; i++)
                    Console.Write(string.Format("{0},", interAB.Data[i]));
                Console.Write(string.Format("{0}", interAB.Data[interAB.Data.Count - 1]));
                Console.WriteLine("}");
            }

            // test UnionWith
            SetClass<int> unionAB = setA.UnionWith(setB);
            Console.Write("Union of A and B is: ");
            if (unionAB.Data.Count == 0)
                Console.WriteLine("Empty");
            else
            {
                Console.Write("{");
                for (int i = 0; i < unionAB.Data.Count - 1; i++)
                    Console.Write(string.Format("{0},", unionAB.Data[i]));
                Console.Write(string.Format("{0}", unionAB.Data[unionAB.Data.Count - 1]));
                Console.WriteLine("}");
            }

            // test difference
            SetClass<int> diffAB = setA.Difference(setB);
            Console.Write("Difference of A from B is: ");
            if (diffAB.Data.Count == 0)
                Console.WriteLine("Empty");
            else
            {
                Console.Write("{");
                for (int i = 0; i < diffAB.Data.Count - 1; i++)
                    Console.Write(string.Format("{0},", diffAB.Data[i]));
                Console.Write(string.Format("{0}", diffAB.Data[diffAB.Data.Count - 1]));
                Console.WriteLine("}");
            }

            // test Cartesian product
            SetClass<Tuple<int, int>> product = setA.CartesianProduct<int>(setB);
            Console.WriteLine(string.Format("Cartesian product of A and B includes {0} elements as follows,", product.Data.Count));
            if (product.Data.Count == 0)
                Console.WriteLine("Empty");
            else
            {
                for (int i = 0; i < product.Data.Count; i++)
                    Console.WriteLine(string.Format("\t({0},{1})", product.Data[i].Item1, product.Data[i].Item2));
            }

            Console.ReadLine();
        }
	}
}

