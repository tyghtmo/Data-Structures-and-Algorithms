using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Week02
{
    public class PartComparer : IComparer<Part>
    {
        public int Compare(Part A, Part B)
        {
            if (A == null && B == null) return 0;
            if (A == null && B != null) return 1;
            if (A != null && B == null) return -1;
            return A.PartId.CompareTo(B.PartId) * -1;
        }
    }
}
