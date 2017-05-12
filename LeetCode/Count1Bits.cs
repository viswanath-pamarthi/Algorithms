using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * https://leetcode.com/problems/counting-bits/#/description
 * Given a non negative integer number num. For every numbers i in the range 0 ≤ i ≤ num calculate the number of 1's in their binary representation and return them as an array.

Example:
For num = 5 you should return [0,1,1,2,1,2].

Follow up:

It is very easy to come up with a solution with run time O(n*sizeof(integer)). But can you do it in linear time O(n) /possibly in a single pass?
Space complexity should be O(n).
Can you do it like a boss? Do it without using any builtin function like __builtin_popcount in c++ or in any other language.
 * 
 * */
/*Solution one of the to do it in single pass/ O(n)
 * from https://leetcode.com/problems/counting-bits/#/solutions
 * Question:
Given a non negative integer number num. For every numbers i in the range 0 ≤ i ≤ num calculate the number of 1's in their binary representation and return them as an array.

Thinking:

We do not need check the input parameter, because the question has already mentioned that the number is non negative.

How we do this? The first idea come up with is find the pattern or rules for the result. Therefore, we can get following pattern

Index : 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15

num : 0 1 1 2 1 2 2 3 1 2 2 3 2 3 3 4

Do you find the pattern?

Obviously, this is overlap sub problem, and we can come up the DP solution. For now, we need find the function to implement DP.

dp[0] = 0;

dp[1] = dp[0] + 1;

dp[2] = dp[0] + 1;

dp[3] = dp[1] +1;

dp[4] = dp[0] + 1;

dp[5] = dp[1] + 1;

dp[6] = dp[2] + 1;

dp[7] = dp[3] + 1;

dp[8] = dp[0] + 1;
...

This is the function we get, now we need find the other pattern for the function to get the general function. After we analyze the above function, we can get
dp[0] = 0;

dp[1] = dp[1-1] + 1;

dp[2] = dp[2-2] + 1;

dp[3] = dp[3-2] +1;

dp[4] = dp[4-4] + 1;

dp[5] = dp[5-4] + 1;

dp[6] = dp[6-4] + 1;

dp[7] = dp[7-4] + 1;

dp[8] = dp[8-8] + 1;
..

Obviously, we can find the pattern for above example, so now we get the general function

dp[index] = dp[index - offset] + 1;

Coding:

public int[] countBits(int num) {
    int result[] = new int[num + 1];
    int offset = 1;
    for (int index = 1; index < num + 1; ++index){
        if (offset * 2 == index){
            offset *= 2;
        }
        result[index] = result[index - offset] + 1;
    }
    return result;
}
 * 
 * 
 * */
namespace LeetCode
{
    class Count1Bits
    {
        /// <summary>
        /// run time O(n*sizeof(integer))
        /// O(n) solution at https://leetcode.com/problems/counting-bits/#/solutions
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int[] CountBits(int num)
        {
            //int num;
            int[] countOfBits = new int[num+1];

            //loop through the numbers
            for (int j = num; j >= 0; j--)
            {
                int numberOfBits = 0;
                //loop through the 32 bits and check each bit
                for (int i = 0; i < 32; i++)
                {
                    int bitShift = 1 << i;

                    if ((j & bitShift) != 0)
                    {
                        numberOfBits++;
                    }
                }

                countOfBits[j] = numberOfBits;
            }

            return countOfBits;
        }
    }
}
/*
 * Another solution from 
 * http://www.geeksforgeeks.org/count-set-bits-in-an-integer/
 * 
 * 
 * 2. Brian Kernighan’s Algorithm:
Subtraction of 1 from a number toggles all the bits (from right to left) till the rightmost set bit(including the righmost set bit). So if we subtract a number by 1 and do bitwise & with itself (n & (n-1)), we unset the righmost set bit. If we do n & (n-1) in a loop and count the no of times loop executes we get the set bit count.
Beauty of the this solution is number of times it loops is equal to the number of set bits in a given integer.

 
   1  Initialize count: = 0
   2  If integer n is not zero
      (a) Do bitwise & with (n-1) and assign the value back to n
          n: = n&(n-1)
      (b) Increment count by 1
      (c) go to step 2
   3  Else return count
 
Implementation of Brian Kernighan’s Algorithm:

#include<stdio.h>
 
/* Function to get no of set bits in binary
   representation of passed binary no. 
unsigned int countSetBits(int n)
{
    unsigned int count = 0;
    while (n)
    {
        n &= (n - 1);
        count++;
    }
    return count;
}

// Program to test function countSetBits 
int main()
{
    int i = 9;
    printf("%d", countSetBits(i));
    getchar();
    return 0;
}
Run on IDE
Example for Brian Kernighan’s Algorithm:

   n =  9 (1001)
   count = 0

   Since 9 > 0, subtract by 1 and do bitwise & with(9-1)
   n = 9&8  (1001 & 1000)
   n = 8
   count  = 1

   Since 8 > 0, subtract by 1 and do bitwise & with(8-1)
   n = 8&7  (1000 & 0111)
   n = 0
   count = 2

   Since n = 0, return count which is 2 now.
Time Complexity: O(logn)
 * 
 * 
 * */
