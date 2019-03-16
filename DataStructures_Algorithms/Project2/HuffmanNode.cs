using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Project2
{
    class HuffmanNode
    {
        public char Value { get; set; }
        public double Frequency { get; set; }
        public string Code { get; set; }

        public HuffmanNode LeftChild { get; set; }
        public HuffmanNode RightChild { get; set; }

        // this is used for leaf nodes
        public HuffmanNode(char Value, double Frequency = 0)
        {
            this.Value = Value;
            this.Frequency = Frequency;
            this.LeftChild = this.RightChild = null;
            this.Code = "";
        }

        // this is used for internal nodes (i.e. non-leaf nodes)
        public HuffmanNode(HuffmanNode LeftChild, HuffmanNode RightChild)
        {
            this.Value = '!';
            this.LeftChild = LeftChild;
            this.RightChild = RightChild;
            this.Frequency = this.LeftChild.Frequency + this.RightChild.Frequency;
            this.Code = "";
        }
    }
}