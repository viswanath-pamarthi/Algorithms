using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// https://leetcode.com/problems/find-the-celebrity/description/
/// Suppose you are at a party with n people (labeled from 0 to n - 1) and among them, there may exist one celebrity. The definition of a celebrity is that all the other n - 1 people know him/her but he/she does not know any of them.
///
///Now you want to find out who the celebrity is or verify that there is not one.The only thing you are allowed to do is to ask questions like: "Hi, A. Do you know B?" to get information of whether A knows B. You need to find out the celebrity (or verify there is not one) by asking as few questions as possible(in the asymptotic sense).
///
///You are given a helper function bool knows(a, b) which tells you whether A knows B.Implement a function int findCelebrity(n), your function should minimize the number of calls to knows.
///
///Note: There will be exactly one celebrity if he/she is in the party. Return the celebrity's label if there is a celebrity in the party. If there is no celebrity, return -1.
/// </summary>
namespace LeetCode
{
    class FindTheCelebrity
    {
        //The Knows API is defined in the parent class Relation.
        bool Knows(int a, int b)
        {
            return true; // just placed this in the method to prevent build errors
        }

        /// <summary>
        /// Time complexity: O(n)
        /// Space complexity : O(1)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindCelebrity(int n)
        {
            //Referred the discussion section for the idea of this solution

            //First find the possible celebrity using the rule that celebrity doesn't know anyone - first for  loop does this
            int possibleCelebrity = 0;//start with zero

            for (int person = 1; person < n; person++)
            {
                //if the possible celebrity knows another person then he is not a celebrity, there is a possibility that the other person is a celebrity as the possible celebrity knows this person.So, we make the other person as a possible celebrity for next iteration. So, in this scenario the possible celebrity is not required to cehck again (1 person removed from the possibilities, let with n-1 person in party to check.)

                //iF the possible celebrity doesn't know the other person then still there is a chance that the possibleCelebrity can be the actual celebrity. At the same time the other person is also knocked out of the race of being a celebrity as the rule that everyone in the party should know the celebrity
                //Finally only one possibleCelebrity will be left. So, in the next loop we will check the 2 rules again to make sure possibleCelebrity is a actual celebrity
                if (Knows(possibleCelebrity, person))
                    possibleCelebrity = person;
            }

            //double check both rules for the possibleCelebrity, even though few cases of if the celeb knows other is checked and other rule are check , we will double check here. If the first person is a celebrity then in the previous loop all the indexes greter then 0 are already validated for the rule celeb shouldn't know others. but if the celeb is last person then  they are not.
            for (int person = 0; person < n; person++)
            {
                if ((person != possibleCelebrity) && (!Knows(person, possibleCelebrity) || (Knows(possibleCelebrity, person))))
                {
                    return -1;
                }
            }

            return possibleCelebrity;
            /*
            if(n<2)
                return -1;

            if(n==2)
            {
                bool i=Knows(0,1);
                bool j=Knows(1,0);

                if(i && !j)
                {
                    return 1;
                }
                else if(!i && j)
                {
                    return 0;
                }
                else
                    return -1;
            }


            //If there is no index as key in relationState Dictionary then it is like he don't know anyone
            Dictionary<int,HashSet<int>> relationState=new Dictionary<int,HashSet<int>>();      

            int iKnowsOthers=0;
            int othersKnowI=0;

            for(int i=0;i<n;i++)
            {

                iKnowsOthers=0;
                othersKnowI=0;    

               // relationState.Add(i,new Hashset<int>());

                //j starts at i+1 because by the time you choose 2 as i, 2,0 is done when i=0, 2,1 is done when i=1;, 2,2 is not required
                for(int j=i+1;j<n;j++)
                {
                    //no case for slef knowing
                    //if(i!=j)
                    //{
                        //find if i knows j
                        if(relationState.ContainsKey(i))
                        {
                            if(relationState[i].Contains(j))
                            {                            
                                iKnowsOthers++;      
                            }
                            else
                            {
                                if(Knows(i,j))
                                {
                                    iKnowsOthers++;                                  
                                    relationState[i].Add(j);   
                                }                             
                            }
                        }
                        else
                        {
                            relationState.Add(i,new HashSet<int>());

                            if(Knows(i,j))
                            {
                                iKnowsOthers++;
                                relationState[i].Add(j);
                            }                        
                        }

                        //find if j knows i                    
                        if(relationState.ContainsKey(j))
                        {
                            if(relationState[j].Contains(i))
                            {                              
                                othersKnowI++;
                            }
                            else
                            {
                                if(Knows(j,i))
                                {
                                    othersKnowI++;
                                    relationState[j].Add(i);    
                                }

                            }
                        }
                        else
                        {
                            relationState.Add(j,new HashSet<int>());

                            if(Knows(j,i))
                            {
                                othersKnowI++;
                                relationState[j].Add(i);
                            }                        
                        }
                    //}
                }

                //if iKnowsOthers is 0 and othersKnowI is n-1 then i is the celebrity
                if((iKnowsOthers==0) && (othersKnowI== n-1))
                    return i;
            }

            return -1;*/
        }
    }
}
