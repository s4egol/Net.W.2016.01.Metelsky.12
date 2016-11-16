using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private T[] array;
        private int size;
        private int capacity;

        /// <summary>
        /// Current size of queue
        /// </summary>
        public int Count {
            get
            {
                return size;
            }
        }

        /// <summary>
        /// Initialize queue
        /// </summary>
        public CustomQueue()
        {
            capacity = 10;
            array = new T[capacity];
            size = 0;
        }

        /// <summary>
        /// Initialize queue
        /// </summary>
        /// <param name="capacity">Capasity of queue</param>
        public CustomQueue(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException();

            array = new T[capacity];
            this.capacity = capacity;
            size = 0;
        }

        /// <summary>
        /// Add element to the queue
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            if (size == capacity)
            {
                T[] newArray = new T[capacity*2];
                Array.Copy(array, 0, newArray, 0, array.Length);
                array = newArray;
                capacity = checked(capacity * 2);
            }
            array[size] = value;
            size++;
        }

        /// <summary>
        /// Deleted queue element
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (size == 0)
                throw new InvalidOperationException();

            T returnValue = array[0];
            for (int i = 0; i < size - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[size] = default(T);
            size--;
            return returnValue;
        }

        /// <summary>
        /// check whether the queue is empty
        /// </summary>
        /// <returns>if isn't empty return false, else return true</returns>
        public bool IsEmpty()
        {
            return size == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private struct CustomIterator : IEnumerator<T>
        {
            private int pointer;
            private readonly CustomQueue<T> queue;

            public CustomIterator(CustomQueue<T> collection)
            {
                queue = collection;
                pointer = -1;
            } 

            void IDisposable.Dispose()
            {
                
            }

            /// <summary>
            /// Move to the next element
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                if (pointer < (queue.Count - 1))
                {
                    pointer++;
                    return true;
                }
                else
                    return false;
            }

            /// <summary>
            /// Reset currnt iterator
            /// </summary>
            public void Reset()
            {
                pointer = -1;
            }

            /// <summary>
            /// Get current element of array
            /// </summary>
            public T Current
            {
                get
                {
                    if (pointer != -1)
                        return queue.array[pointer];
                    else
                        throw new InvalidOperationException();
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}
