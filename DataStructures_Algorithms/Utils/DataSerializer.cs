using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using DataStructures_Algorithms.Week01;

namespace DataStructures_Algorithms.Utils
{
    public class DataSerializer<T> where T : IConvertible
    {
        public static void Serialise(string path, Vector<T> vector)
        {
            using (Stream stream = File.Open(path, FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, vector);
            }
        }

        public void deserialise(string path, ref Vector<T> vector)
        {
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                vector = (Vector<T>)bin.Deserialize(stream);

            }
        }

        public static void LoadVectorFromTextFile(string path, ref Vector<T> vector)
        {
            vector = new Vector<T>();
            string line = "";
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    //This would work only for primitive types
                    vector.Add((T)Convert.ChangeType(line, typeof(T)));
                }
            }
        }

        public static void SaveVectorToTextFile(string path, Vector<T> vector)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                var count = vector.Count;
                for (int i = 0; i < count ; i++)
                {
                    sw.WriteLine(vector[i]);              
                }
            }
        }
    }
}
