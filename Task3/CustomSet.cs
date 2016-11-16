using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class CustomSet<T> : IEnumerable<T>
        where T : class
    {
        private T[] array;
        private int count;
        private int capacity;

        public int Count {
            get
            {
                return count;
            }
        }

        public CustomSet()
        {
            capacity = 10;
            count = 0;
            array = new T[capacity];
        }

        public CustomSet(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException();

            count = 0;
            this.capacity = capacity;
            array = new T[capacity];
        }

        public bool Insert(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            bool contain = array.Contains(value);

            if (!contain)
            {
                if (count == capacity)
                {
                    T[] newArray = new T[capacity * 2];
                    Array.Copy(array, 0, newArray, 0, array.Length);
                    array = newArray;
                    capacity = checked(capacity * 2);
                }
                array[count] = value;
                count++;
            }

            return contain;
        }

        public bool Remove(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            bool contain = array.Contains(value);

            if (contain)
            {
                int index = Array.IndexOf(array, value);
                for (int i = index; i < count-1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[count] = default(T);
                count--;
            }

            return contain;
        }

        public void UnionSets(IEnumerable<T> otherSet)
        {
            if (otherSet == null)
                throw new ArgumentNullException();

            array = array.Union(otherSet).ToArray();
            count = array.Length;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
