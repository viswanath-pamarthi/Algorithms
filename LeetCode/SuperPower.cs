using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class SuperPower
    {
        public int SuperPow(int number, int[] power)
        {

            if (power.Length == 0)
                return 0;

            if (number == 1)
                return 1;

            string stringPower = string.Join("", power);
            int actualPower;
            int.TryParse(stringPower, out actualPower);

            return CalculatePower(number, actualPower);
        }

        private int CalculatePower(int number, int power)
        {
            if (power == 0)
                return 1;

            int partialResult = CalculatePower(number, power/2);

            if (power % 2 == 0)
                return partialResult * partialResult;
            else
                return power < 0 ? (partialResult * partialResult * (1 / number)) : (partialResult * partialResult * number);//only for the n=1 and n=odd then the n=5 then n=1 and n=5 stages only uses this


        }
    }
}
