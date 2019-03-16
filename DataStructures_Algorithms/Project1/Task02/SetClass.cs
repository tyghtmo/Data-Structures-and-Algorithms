using System;
using DataStructures_Algorithms.Project1;

namespace DataStructures_Algorithms
{
	public class SetClass<T>
	{
        /*
		public Vector<T> Data { get; set;}

		public bool Membership(T element) {
			return true;
		}

		public bool IsSubsetOf(SetClass<T> B) {
			return true;
		}

		public bool IsSupersetOf(SetClass<T> B) { return false;}

        public SetClass<SetClass<T>> Powerset() { return null;}

        public SetClass<T> IntersectionWith(SetClass<T> B) { return null; }

        public SetClass<T> UnionWith(SetClass<T> B) { return null;}

        public SetClass<T> Difference(SetClass<T> B)
		{
			return null;
		}

        public SetClass<T> SymmetricDifference(SetClass<T> B) { return null; }

        public SetClass<T> Complement(SetClass<T> U)
		{
			return null;
		}

        public SetClass<Tuple<T, T2>> CartesianProduct<T2>(SetClass<T2> B)
		{
			return null;
		}

		public SetClass(Vector<T> d)
		{
			Data = d;
		}
        */

        public Vector<T> Data { get; set; }

        public bool Add(T element)
        {
            bool exist = Membership(element);
            if (!exist)
                this.Data.Add(element);
            return !exist;
        }

        public bool Membership(T element)
        {
            bool b = Data.Contains(element);
            return Data.Contains(element);
        }

        public bool IsSubsetOf(SetClass<T> B)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                if (B.Data.Contains(Data[i]) == false) return false;
            }
            return true;
        }

        public bool IsSupersetOf(SetClass<T> B)
        {
            return B.IsSubsetOf(this);
        }

        public bool IsEqual(SetClass<T> B)
        {
            return this.IsSubsetOf(B) && B.IsSubsetOf(this);
        }

        public SetClass<SetClass<T>> Powerset()
        {
            SetClass<SetClass<T>> power = new SetClass<SetClass<T>>(new Vector<SetClass<T>>());

            if (this.Data.Count == 0)
            {
                power.Add(this);
            }
            else
            {
                // Assume that s is a subset that contains all elements of data exept Data[0]
                // Step 1: Your are to create such a set s
                // Hint: just simply add all elements from Data[1] to Data[Count-1] to s
                SetClass<T> s = new SetClass<T>(new Vector<T>());
                for (int j = 1; j < this.Data.Count; j++)
                    s.Data.Add(this.Data[j]);

                // Step 2: Let powerS be the power set of s.
                // powerS can be obtained recursively, e.g.
                SetClass<SetClass<T>> powerS = s.Powerset();

                // Step 3: You need to add all elements of powerS to power. 
                // This is because s is a subset created from Data[1] to Data[Count-1] and thus
                // powerS is a subset of power. In particular, you should 
                // add powerS.Data[0] to power
                // add powerS.Data[1] to power
                // ...
                // add powerS.Data[powerS.Data.Count-1] to power
                for (int j = 0; j < powerS.Data.Count; j++)
                    power.Add(powerS.Data[j]);

                // Step 4: 
                // For each set p of powerS, you create another set, called augP (i.e. augmented p) such that  
                //      (i) augP is a copy of p. Note that you should not simply assign as augP = p.
                //      (ii) augP is then augmented with Data[0], i.e. augP.Add(this.Data[0]);
                //      then add augP to power
                // End for
                for (int j = 0; j < powerS.Data.Count; j++)
                {
                    SetClass<T> p = powerS.Data[j];
                    SetClass<T> augP = new SetClass<T>(new Vector<T>());
                    for (int k = 0; k < p.Data.Count; k++)
                        augP.Add(p.Data[k]);
                    augP.Add(this.Data[0]);
                    power.Add(augP);
                }
            }
            return power;
        }

        public SetClass<T> IntersectionWith(SetClass<T> B)
        {
            SetClass<T> inter = new SetClass<T>(new Vector<T>());
            for (int i=0; i<this.Data.Count; i++)
            {
                if (B.Membership(this.Data[i]))
                    inter.Add(this.Data[i]);
            }
            return inter;
        }

        public SetClass<T> UnionWith(SetClass<T> B)
        {
            SetClass<T> union = new SetClass<T>(new Vector<T>());
            for (int i = 0; i < this.Data.Count; i++)
                union.Add(this.Data[i]);
            for (int i = 0; i < B.Data.Count; i++)
                union.Add(B.Data[i]);
            return union;
        }

        public SetClass<T> Difference(SetClass<T> B)
        {
            SetClass<T> diff = new SetClass<T>(new Vector<T>());
            for (int i = 0; i < this.Data.Count; i++)
                if (!B.Membership(this.Data[i]))
                    diff.Add(this.Data[i]);
            return diff;
        }

        public SetClass<Tuple<T, T2>> CartesianProduct<T2>(SetClass<T2> B)
        {
            SetClass<Tuple<T, T2>> product = new SetClass<Tuple<T, T2>>(new Vector<Tuple<T, T2>>());

            for (int i = 0; i < this.Data.Count; i++)
                for (int j = 0; j < B.Data.Count; j++)
                    product.Add(new Tuple<T, T2>(this.Data[i], B.Data[j]));

            return product;
        }

        public SetClass(Vector<T> d)
        {
            Data = d;
        }
    }
}