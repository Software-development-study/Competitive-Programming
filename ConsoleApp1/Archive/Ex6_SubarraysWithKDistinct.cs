using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Ex6_SubarraysWithKDistinct
    {
        public static void Run()
        {
            int[] nums = { 1, 2, 1, 2, 3 };

            int res = SubarraysWithKDistinct(nums, 2);

            Console.WriteLine($"Result : {res}");
            Console.ReadKey();
        }

        public static int SubarraysWithKDistinct(int[] nums, int k)
        {
            Hashtable result = new Hashtable();

            int count = 0;

            for (int i = k; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length - k + 1; j++)
                {
                    for (int h = 0; h < 10; h++)
                    {
                        result[h] = new Stack<int>();
                    }

                    int currentDigit = j;

                    

                    int digitsUsed = 0;

                    Stack<int> currentStack = (Stack<int>)result[nums[currentDigit]];


                    while (currentDigit < nums.Length && digitsUsed <= k)
                    {

                        if (currentStack.Count == 0)
                        {
                            digitsUsed++;
                        }

                        currentStack.Push(nums[currentDigit]);
                        Console.Write($",{nums[currentDigit]}");
                        currentDigit++;

                        if (currentStack.Count >= i)
                        {
                            break;
                        }
                    }
                    if (digitsUsed == k)
                    {
                        count++;
                    }
                    Console.WriteLine();
                }

            }

            return count;
            Console.ReadKey();
        }


    }
}
