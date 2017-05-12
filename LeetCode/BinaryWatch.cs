using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class BinaryWatch
    {
        public IList<string> ReadBinaryWatch(int num)
        {
            IList<string> possibleCombinations = new List<string>();
            HammingWeight checkSetBits = new HammingWeight();

            for (uint i=0;i<12;i++)
            {
                for(uint j=0;j<60;j++)
                {
                    //check the number of bits count in i and number of bits count, add to equal to that of num, add the results to list
                    if((checkSetBits.HammingWeightSolution(i) + checkSetBits.HammingWeightSolution(j))==num)

                    possibleCombinations.Add(string.Format("{0}:{1:00}", i, j));
                }
            }

            return possibleCombinations;
        }
    }
}
