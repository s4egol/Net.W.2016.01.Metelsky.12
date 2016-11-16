using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task3;

namespace Task3.Tests
{
    [TestFixture]
    public class CustomSetTests
    {
        [Test]
        public void Foreach_returnedValues()
        {
            CustomSet<string> customSet = new CustomSet<string>(20);

            string[] array = new string[20];
            for (int i = 0; i < 20; i++)
            {
                array[i] = i.ToString();
                customSet.Insert(i.ToString());
            }

            int j = 0;
            foreach (var element in customSet)
            {
                Assert.AreEqual(array[j], element);
                j++;
            }
        }

        [Test]
        public void UnionSets_returnedValues()
        {
            string[] array = new string[5] {"Apple", "Orange", "Banana", "Watermelon", null}; 

            CustomSet<string> customSet1 = new CustomSet<string>(3);
            customSet1.Insert("Apple");
            customSet1.Insert("Orange");
            customSet1.Insert("Banana");

            CustomSet<string> customSet2 = new CustomSet<string>(3);
            customSet1.Insert("Apple");
            customSet1.Insert("Orange");
            customSet1.Insert("Watermelon");
            customSet1.UnionSets(customSet1);

            int j = 0;
            foreach (var element in customSet1)
            {
                Assert.AreEqual(array[j], element);
                j++;
            }
        }

    }
}
