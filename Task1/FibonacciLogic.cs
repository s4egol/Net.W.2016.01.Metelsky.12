using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class FibonacciLogic
    {
        private static long number = 0;
        private static long lastValue = 0;
        public static IEnumerable<long> GetNumbersFibonacci(int count)
        {
            if (count < 0)
                throw new ArgumentException();

            if (count != 0)
            {
                count--;
                yield return number;
            }

            if (count != 0)
            {
                count--;
                number = 1;
                yield return number;
            }

            while (count != 0)
            {
                count--;
                long temp = number;
                number = checked(number + lastValue);
                lastValue = temp;                
                yield return number;

                if (count == 0)
                    ResetValues();
            }
        }

        private static void ResetValues()
        {
            number = 0;
            lastValue = 0;
        }
    }
}
