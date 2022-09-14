using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Ex1_FirstMIssingPositive
    {

        public static void Run()
        {
            //int[] nums = { 1, 2, 0 };
            //int[] nums1 = { 3, 4, -1, 1 };
            //int[] nums2 = { 7, 8, 9, 11, 12 };
            //int[] nums3 = { 1, 4, 6 };
            //int[] nums4 = { 1, 2, 2, 4 };
            //int[] nums5 = { 1 };
            //int[] nums6 = { -1, 4, 2, 1, 9, 10 };
            //Console.WriteLine(FirstMissingPositive(nums));
            //Console.WriteLine(FirstMissingPositive(nums1));
            //Console.WriteLine(FirstMissingPositive(nums2));
            //Console.WriteLine(FirstMissingPositive(nums3));
            //Console.WriteLine(FirstMissingPositive(nums5));
            //Console.WriteLine(FirstMissingPositive(nums6));
        }

        public static int FirstMissingPositive2(int[] nums)
        {
            //Sort the array using insertion sort
            for (int i = 0; i < nums.Length; i++)
            {
                int temp = nums[i];

                for (int j = i - 1; j >= 0;)
                {
                    if (temp < nums[j])
                    {
                        nums[j + 1] = nums[j];
                        j--;
                        nums[j + 1] = temp;
                    }
                    else break;
                }
            }

            int currentSmallestPositive = 1;

            for (int k = 0; k < nums.Length; k++)
            {
                if (nums[k] > 0)
                {
                    if (currentSmallestPositive < nums[k])
                    {
                        return currentSmallestPositive;
                    }
                    else
                    {
                        currentSmallestPositive++;
                    }
                }
            }
            return nums[nums.Length - 1] + 1;
        }

        public static int FirstMissingPositive(int[] nums)
        {
            int temp;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0 && nums[i] < nums.Length)//Only positive inside range
                {
                    if (nums[nums[i] - 1] == nums[i]) //If duplicate skip this iteration
                    {
                        continue;
                    }

                    temp = nums[nums[i] - 1]; //Store the value in the given index in a temp var,will not break because nums[i] > 0
                    nums[nums[i] - 1] = nums[i]; //Replace the value in the index with the given value
                    nums[i] = temp; //The temp value is not important anymore as it is not 
                    i--; //To repeat the step if the right number was switched
                }
            }

            for (int j = 1; j <= nums.Length; j++)//Search for invalid values in index - each index should have the index as value until a missing one will be found
            {
                if (nums[j - 1] != j)
                {
                    return j;
                }
            }

            return nums.Length + 1;
        }

    }
}
