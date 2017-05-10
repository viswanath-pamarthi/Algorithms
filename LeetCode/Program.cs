using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            HammingDistance hammingDistance1 = new HammingDistance(20,30);
            hammingDistance1.solutionOne();


            HammingDistance hammingDistance2 = new HammingDistance(20, 30);
            hammingDistance2.solutionTwo();

            //Console.WriteLine("{0} is output od xor", numberOne ^ numberTwo);
        }
    }
}
