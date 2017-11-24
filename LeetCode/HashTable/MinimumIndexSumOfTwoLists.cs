using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.HashTable
{
    class MinimumIndexSumOfTwoLists
    {
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            //referend the discussion section for idea
            //usual way of doing it of n*m time complexity, that is comparing each element with another element of other list
            //However, while comparing you have to memorize the minimum index sum previous solutions. I liked the idea of storing one list in hash table and comparing the other list item by retreiving the item from hash table

            //store the list1 in a hash table(non-genric C# collection)/dictionary (generic hash table)
            Dictionary<string, int> listOfItems = new Dictionary<string, int>();

            for (int i = 0; i < list1.Count(); i++)
                listOfItems.Add(list1[i], i);


            int minimumSum = int.MaxValue;//store the minimum index sum, initialized to integer max, because if it is set to 0 then none of the sums except 0+0 indexes will be less than 0(default value)
            List<string> matchingItem = new List<string>();//store the menu item thats matching and having the minimum index sum

            //loop throught second list
            for (int i = 0; i < list2.Count(); i++)
            {
                int listOneIndex;

                //check if the item is present in the Dictionary
                if (listOfItems.TryGetValue(list2[i], out listOneIndex))
                {
                    //check if index sum is minimum, then save the details
                    if (((listOneIndex + i) < minimumSum))
                    {
                        minimumSum = listOneIndex + i;
                        matchingItem.Clear();
                        matchingItem.Add(list2[i]);
                    }
                    else if ((listOneIndex + i) == minimumSum)
                    {
                        minimumSum = listOneIndex + i;
                        matchingItem.Add(list2[i]);
                    }
                }
            }

            return matchingItem.ToArray();
        }
    }
}
