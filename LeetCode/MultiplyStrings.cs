using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// https://leetcode.com/problems/multiply-strings/#/description
/// Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2.
///
///Note:
///
///The length of both num1 and num2 is < 110.
///Both num1 and num2 contains only digits 0-9.
///Both num1 and num2 does not contain any leading zero.
///You must not use any built-in BigInteger library or convert the inputs to integer directly.
/// </summary>
namespace LeetCode
{

    class MultiplyStrings
    {
        public string Multiply(string num1, string num2)
        {
            if(num1.Length==1)
            {
                if(num1[0]=='0')
                {
                    return "0";
                }
            }else if (num2.Length == 1)
            {
                if (num2[0] == '0')
                {
                    return "0";
                }
            }


            //This piece of codes makes things easier as you always know that the first string is bigger(useful for reducing validations)
            if (num1.Length < num2.Length)
                return Multiply(num2, num1);

            //TO hold the individual 
            IList<string> results = new List<string>();

            int num2Size= num2.Length;
            int i = num2Size - 1;

            results.Add(MultiplyNumbers(num1, num2[i]));
            i--;

            while (i>=0)
            {
                StringBuilder temp = new StringBuilder();
                int j = num2Size - i - 1;
                while (j > 0)
                { 
                    temp.Append("0");
                    j--;
                }
                results.Add(MultiplyNumbers(num1,num2[i])+ temp.ToString());
                i--;
            }
            long finalResult ;
            long.TryParse(AddResults(results, results.Count-1),out finalResult);
            return finalResult.ToString() ;
        }


        private string AddResults(IList<string> results, int currentIndex)
        {
            if (currentIndex == 0)
                return results[currentIndex];

            string tempSum = AddTwoStrings(results[currentIndex],AddResults(results,currentIndex-1));

            return tempSum;
        }

        /// <summary>
        /// Multiply starting from least significat number in num2 to num1
        /// </summary>
        /// <param name="num1">number 1</param>
        /// <param name="num2">digit in num2</param>
        /// <returns></returns>
        private string MultiplyNumbers(string num1,char num2)
        {
            int num1Size = num1.Length;
            int j = num1Size-1;
            StringBuilder result=new StringBuilder();
            int carryover = 0;

            while(j>=0 || carryover>0)
            {
                int product = 0;

                if (j >= 0)
                    product = (num1[j] - '0') * (num2 - '0');

                product = product + carryover;
                carryover = 0;

                carryover = product / 10;

                result.Append(((product % 10)));
                j--;
            }
            string finalResult = new string(result.ToString().ToCharArray().Reverse().ToArray());

            return finalResult;
        }

        /// <summary>
        /// Adding two numbers in string format.
        /// 
        /// Referred some idea from(C++ solution) https://leetcode.com/problems/add-strings/#/solutions
        /// </summary>
        /// <param name="num1">First Number</param>
        /// <param name="num2">Second Number</param>
        /// <returns>sum of the two number</returns>
        public string AddTwoStrings(string num1, string num2)
        {
            //This piece of codes makes things easier as you always know that the first string is bigger(useful for reducing validations)
            if (num1.Length < num2.Length)
                return AddTwoStrings(num2, num1);

            int i = num1.Length - 1;
            int j = num2.Length - 1;
            int carryOver = 0;
            char[] result = new char[num1.Length];

            //Loop through the strings and add
            while (i >= 0 || j >= 0)
            {
                int sum = 0;
                sum += carryOver;
                carryOver = 0;

                if (i >= 0)
                {
                    // This has to be done to get the actual number. '0' - ASCII value is "48" , '1' - ASCII value is 49
                    //so '1' while adding will be as 49+..., so 49-48 ('0') gives 1 - This is done while doing the math, '0' ASCII value again added while storing the result back to char array
                    sum += num1[i] - '0';

                }

                if (j >= 0)
                {
                    sum += num2[j] - '0';
                }

                //get the carryover if number is grreater than 10... always 1, as a max of 9 + 9 =18
                if (sum >= 10)
                {

                    carryOver = sum / 10;
                }

                result[i] = (char)((sum % 10) + '0');//Add the ASCII value back while storing

                i--;
                j--;
            }

            //If the first string is bigger then add the carryover to the next (<- direction) number
            //This case is only when the numbers are inequal and carryover is present, when numbers are equal then it is done while returning the result
            if ((i > 0) && (carryOver == 1))
            {
                result[i] = (char)(result[i] + 1 - '0');
                carryOver = 0;
            }
            string finalResult = new string(result);

            //Concatinate the carryover, if string are
            return carryOver == 1 ? string.Concat("1", finalResult) : finalResult;

        }
    }
}
