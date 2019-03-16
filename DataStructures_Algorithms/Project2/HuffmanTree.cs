using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures_Algorithms.Project1;

namespace DataStructures_Algorithms.Project2
{
    class HuffmanTree
    {
        public HuffmanNode Root { get; set; }

        // CodeTable is a Dictionary in which each row contains a pair of information
        // - Key: a letter, e.g. "a"
        // - Value: Huffman code, e.g. "000"
        // For example, an element of CodeTable should look like <'A', "000">
        public Dictionary<char, string> CodeTable = new Dictionary<char, string>();

        public HuffmanTree() { Root = null; }

        private void CreateNodes(ref List<HuffmanNode> Nodes, Vector<char> Input)
        {
            Nodes = new List<HuffmanNode>();
            for (int i = 0; i < Input.Count; i++)
            {
                // check if input[i] exists
                int j;
                for (j = 0; j < Nodes.Count; j++)
                {
                    if (Nodes[j].Value.Equals(Input[i]))
                        break;
                }
                if (j < Nodes.Count)
                    Nodes[j].Frequency++;
                else
                    Nodes.Add(new HuffmanNode(Input[i], 1));
            }
        }

        private void Sort(ref List<HuffmanNode> Nodes)
        {
            //list sorted by frequency in ascending order.
            List<HuffmanNode> orderedNodes = Nodes.OrderBy(node => node.Frequency).ToList();
            Nodes = orderedNodes;
            
        }

        private void Build(ref List<HuffmanNode> Nodes)
        {
            
            while (Nodes.Count > 1)
            {
                Sort(ref Nodes);

                if (Nodes.Count >= 2)
                {
                    // Create parent item from first two nodes in list
                    List<HuffmanNode> children = Nodes.Take(2).ToList<HuffmanNode>();
                    HuffmanNode parent = new HuffmanNode(children[0], children[1]);

                    //remove child nodes and add parent node to list
                    Nodes.Remove(children[0]);
                    Nodes.Remove(children[1]);
                    Nodes.Add(parent);
                }
                this.Root = Nodes.FirstOrDefault();
            }
        }

        private void ConstructCodeTable()
        {

            HuffmanNode currentNode = Root;
            HuffmanNode parentNode = Root;
            string bitString = "";

            while (Root.LeftChild != null || Root.RightChild != null)
            {
               
                //Traverses array from left to right to create bit string 
                if (currentNode.Value == '!')
                {
                    if(currentNode.LeftChild != null)
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.LeftChild;
                        bitString = bitString + "0";
                    }
                    else if (currentNode.RightChild != null)
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.RightChild;
                        bitString = bitString + "1";
                    }
                }
                else if (currentNode.Value != '!')                  //Adds leaf nodes to code table and removes them from root tree
                {
                    CodeTable.Add(currentNode.Value, bitString);
                    if(bitString.EndsWith("0"))
                    {
                        parentNode.LeftChild = null;
                        currentNode = Root;
                        parentNode = Root;
                        bitString = "";
                    }
                    else if (bitString.EndsWith("1"))
                    {
                        parentNode.RightChild = null;
                        currentNode = Root;
                        parentNode = Root;
                        bitString = "";
                    }
                    
                }


                //removes internal nodes from root tree
                if(currentNode.LeftChild == null && currentNode.RightChild == null && currentNode.Value == '!')
                {
                    if (bitString.EndsWith("0")) parentNode.LeftChild = null;
                    else if (bitString.EndsWith("1")) parentNode.RightChild = null;

                    bitString = "";
                    currentNode = Root;
                }

            }
            

        }

        public void Encode(Vector<char> Input)
        {
            // create a list of nodes.
            // each node corresponds to a letter and associated with the frequency
            List<HuffmanNode> Nodes = null;
            CreateNodes(ref Nodes, Input);

            // sort the list Nodes in ascending order of frequency
            Sort(ref Nodes);

            // construct the Huffman tree
            Build(ref Nodes);

            // construct CodeTable
            ConstructCodeTable();
        }

        // this method aims to decode a string code
        // for example, Decode("000") could return 'A'
        public char Decode(string Code)
        {
            char decoded = '-';

            if(CodeTable.ContainsValue(Code))
            {
                foreach(var keyVal in CodeTable)
                {
                    if(keyVal.Value == Code)
                    {
                        decoded = keyVal.Key;
                    }
                }
            }

            return decoded;
        }
    }
}