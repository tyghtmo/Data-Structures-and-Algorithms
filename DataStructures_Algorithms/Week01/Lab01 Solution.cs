using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Week01
{

    [Serializable]
    public class Vector<T>
    {

        T[] data;
        const int DEFAULT_CAPACITY = 10;
        int count = 0;

        public Vector()
        {
            data = new T[DEFAULT_CAPACITY];
        }
        public Vector(int CAPACITY)
        {
            data = new T[CAPACITY];
        }


		private void ExtendData(int extensionCapacity)
		{
			T[] newData = new T[data.Length + extensionCapacity];

			for (var i = 0; i < count; i++)
				newData[i] = data[i];

			data = newData;
		}

        public void Add(T element)
        {
            if (count >= data.Length)
                ExtendData(DEFAULT_CAPACITY);
            data[count++] = element;

        }
        public bool Contains(T element)
        {
            if(IndexOf(element) < 0)
				return false;
			return true;
        }

		/*
		 * Running time of IndexOf - T(n) = 3n + 2 [ details: 1 (init i) + [n+1] (condition checking) + n (increment i) + n (if condition checking) + 1 (return statement) ] 
		 * IndexOf is O(n) [ neglicting constants and lower terms]
		 * 
		 */
        public int IndexOf(T element)
        {
            for (var i = 0; i < count; i++)
				if (data[i].Equals(element)) return i;
			return -1;
        }

		public void Clear()
		{
			data = new T[DEFAULT_CAPACITY]; //you can do so many different things here, this just a quick & dry one
			count = 0;
		}

		public T Max()
		{
			var comparer = Comparer<T>.Default;
			T max = data[0];
			for (var i = 1; i < count; i++)
				if (comparer.Compare(data[i], max) > 0) max = data[i];
			return max;
		}

		public T Min()
		{
			var comparer = Comparer<T>.Default;
			T min = data[0];
			for (var i = 1; i < count; i++)
				if (comparer.Compare(data[i], min) < 0) min = data[i];
			return min;
		}


        public void Insert(T element, int index)
        {
            if (index >= count) throw new IndexOutOfRangeException("index out of range");
            if (count == data.Length) ExtendData(DEFAULT_CAPACITY);

            for (int i = count; i > index; i--)
                data[i] = data[i - 1];
            data[index] = element;
            count++;              

        }

		public bool RemoveAll(T element)
		{
			var found = Contains(element); //do we have this element in the list? 
			while (Remove(element) == true) { }
			return found;

		}
        public bool Remove(T element)
        {
			var index = IndexOf(element);
            return RemoveAt(index);      

        }
        public bool RemoveAt(int index)
        {
			if (index >= count || index < 0) return false;
            
			//shift all the elements to the left
            for (int i = index; i < count; i++)
                data[i] = data[i + 1];
            
			//decrement count field
            count--;
           
			return true;
        }


        public int Capacity
        {
            get
            {
                return data.Length;
            }
            set
            {
				if (value <= data.Length)
                    throw new ArgumentOutOfRangeException();
                ExtendData(value);
            }
        }

        public int Count
        {
            get { return count; }
        }
        public T this[int index]
        {
            get
            {
                return data[index]; 
            }
            set
            {
                if (index >= count)
                    throw new IndexOutOfRangeException();
                data[index] = value;

            }
        }
    }
}
