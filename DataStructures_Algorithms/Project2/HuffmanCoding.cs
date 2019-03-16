using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures_Algorithms.Project1;

namespace DataStructures_Algorithms.Project2
{
    // Material
    // https://en.wikipedia.org/wiki/Huffman_coding
    // https://www.siggraph.org/education/materials/HyperGraph/video/mpeg/mpegfaq/huffman_tutorial.html
    // http://www.geeksforgeeks.org/greedy-algorithms-set-3-huffman-coding/

    public class HuffmanCoding
    {
        private HuffmanTree HFTree;

        public Vector<string> Encode(Vector<char> input)
        {
            HFTree = new HuffmanTree();
            HFTree.Encode(input);

            Vector<string> EncodedResult = new Vector<string>();
            for (int i = 0; i < input.Count; i++)
                EncodedResult.Add(HFTree.CodeTable[input[i]]);

            return EncodedResult;
        }

        public Vector<char> Decode(Vector<string> input)
        {
            Vector<char> DecodedResult = new Vector<char>();
            for (int i=0; i<input.Count; i++)
                DecodedResult.Add(HFTree.Decode(input[i]));
            return DecodedResult;
        }
    }
}
