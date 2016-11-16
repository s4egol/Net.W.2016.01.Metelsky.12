using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task2.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void Foreach_returnedValues()
        {
            CustomQueue<int> queue = new CustomQueue<int>(20);

            int[] array = new int[20];
            var random = new Random();
            for (int i = 0; i < 20; i++)
            {
                int value = random.Next(50);
                array[i] = value;
                queue.Enqueue(value);
            }

            int j = 0;
            foreach (var element in queue)
            {
                Assert.AreEqual(array[j],element);
                j++;
            }
        }

        [Test]
        public void Enqueue_returnedValues()
        {
            CustomQueue<double> queue = new CustomQueue<double>();
            queue.Enqueue(10.0);
            queue.Enqueue(40.0);
            queue.Enqueue(50.0);
            queue.Dequeue();
            queue.Enqueue(10.0);
            Assert.AreEqual(queue.Dequeue(),40.0);
            queue.Dequeue();
            Assert.AreEqual(queue.Dequeue(),10.0);
        }

        [Test]
        [ExpectedException(typeof (InvalidOperationException))]
        public void Dequeue_returnedException()
        {
            CustomQueue<double> queue = new CustomQueue<double>();
            queue.Dequeue();
        }

        [Test]
        public void IsEmpty_returnedValues()
        {
            CustomQueue<double> queue = new CustomQueue<double>();
            Assert.AreEqual(queue.IsEmpty(), true);
        }
    }
}
