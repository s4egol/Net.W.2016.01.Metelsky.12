using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class FibonacciLogicTests
    {
        [TestCase(1, Result = new long[] {0})]
        [TestCase(3, Result = new long[] {0,1,1})]
        [TestCase(5, Result = new long[] {0,1,1,2,3})]
        [TestCase(7, Result = new long[] { 0, 1, 1, 2, 3, 5, 8 })]
        public long[] GetNumbersFibonacci_returnedValues(int count)
        {
            long[] numbersFibonacci = null;
            numbersFibonacci = new long[count];

            int i = 0;
            foreach (var value in FibonacciLogic.GetNumbersFibonacci(count))
            {
                numbersFibonacci[i] = value;
                i++;
            }

            return numbersFibonacci;
        } 
    }
}
