using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// https://leetcode.com/problems/single-number-ii/#/description
/// Given an array of integers, every element appears three times except for one, which appears exactly once. Find that single one.
///
///Note:
///Your algorithm should have a linear runtime complexity.Could you implement it without using extra memory?
/// 
/// 
/// 
/// 
/// Excellent explanation: (Hint from solutions)https://discuss.leetcode.com/topic/22821/an-general-way-to-handle-all-this-sort-of-questions/12
/// Many may wonder what 'a', 'b', 'c' means and how can we manipulate a number like one single bit, as you see in the code, a, b and c are all full 32-bit numbers, not bits. I cannot blame readers to have questions like that because the author did not make it very clear.
///
///In Single Number, it is easy to think of XOR solution because XOR manipulation has such properties:
///
///Commutative: A^B == B^A, this means XOR applies to unsorted arrays just like sorted. (1^2^1^2==1^1^2^2)
///Circular: A^B^...^B == A where the count of B's is a multiple of 2.
///So, if we apply XOR to a preceding zero and then an array of numbers, every number that appears twice will have no effect on the final result. Suppose there is a number H which appears just once, the final XOR result will be 0^H^...H where H appears as many as in input array.
///
///When it comes to Single Number II (every one occurs K=3 times except one occurs M times, where M is not a multiple of K), we need a substitute of XOR (notated as @) which satisfies:
///
///Commutative: A@B == B@A.
///Circular: A@B@...@B == A where the count of B's is a multiple of K.
///We need to MAKE the @ operation. This general solution suggests that we maintain a state for each bit, where the state corresponds to how many '1's have appeared on that bit, so we need a int[32] array.
///<![CDATA[ .... c data is to escape the < and > in comments that are causing compile error
///bitCount = [];
///for (i = 0; i < 32; i++) {
///  bitCount[i] = 0;
///}
///The state transits like this:
///
///for (j = 0; j < nums.length; j++) {
///    n = nums[j];
///    for (i = 0; i < 32; i++) {
///        hasBit = (n & (1 << i)) != 0;
///        if (hasBit) {
///            bitCount[i] = (bitCount[i] + 1) % K;
///        }
///    }
///}
///I use '!=' instead of '>' in 'hasBit = (n & (1 << i)) != 0;' because 1<<31 is considered negative. After this, bitCount will store the module count of appearance of '1' by K in every bit. We can then find the wanted number by inspecting bitCount.
///
///exept = 0;
///for (i = 0; i < 32; i++) {
///  if (bitCount[i] > 0) {
///    exept |= (1 << i);
///  }
///}
///return exept;
///We use bitCount[i] > 0 as condition because there is no tell how many times that exceptional number appears.
///
///Now let's talk about ziyihao's solution. His solution looks much magical than mine because given a fixed K, we can encode the state into a few bits. In my bitCount version, we have a int[32] array to store the count of each bit but a 32-bit integer is way more than what we need to store just 3 states. So ideally we can have a bit[32][2] structure to store the counts. We name bit[...][0] as 'a' and bit[...][1] as 'b' and the bits of n as 'c' and we have ziyihao's post.
///]]>
/// </summary>
namespace LeetCode
{
    class SingleNumber2
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            //referred solutions : https://discuss.leetcode.com/topic/22821/an-general-way-to-handle-all-this-sort-of-questions
            //https://stackoverflow.com/questions/12567329/multidimensional-array-vs
            //double[,] is a 2d array (matrix) while double[][] is an array of arrays (jagged arrays) and the         
            int[,] states = new int[2, 32];//states[0]Holds the states of k occurences for a number (for each bit here, from question point of view each number appears 3 times) 
                                           //states[1] holds the state for m occurences for a number, from question a number appears 1(m) time. here we count the occurences of each bit and modulo by m
            int k = 3;//3 times
            int m = 1;//1 time
            int resultK = 0;
            int resultM = 0;

            for (int i=0;i<nums.Length;i++)
            {
                for(int j=0;j<32;j++)
                {
                    bool hasBit = (nums[i] & (1 << j)) != 0;

                    if(hasBit)
                    {
                        states[0,j] = (states[0,j] + 1) % k;
                        states[1,j] = (states[1,j] + 1) % k;
                    }
                }
            }

            for(int i=0;i<32;i++)
            {
                if(states[0,i]>0)
                {
                    resultK |= (1 << i);//left shift the 1 to construct/set that bit
                }

                if (states[1, i] > 0)
                {
                    resultM |= (1 << i);//left shift the 1 to construct/set that bit
                }

            }

            return resultK|resultM;
        }




    }
}
