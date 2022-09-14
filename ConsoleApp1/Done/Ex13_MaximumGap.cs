using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Ex13_MaximumGap
    {
        public static void Run()
        {
            int[] arr = { 3, 6, 9, 1 };

            var watch = System.Diagnostics.Stopwatch.StartNew();

            long res = MaximumGap(arr);

            Console.WriteLine(watch.Elapsed.ToString());

            Console.WriteLine("Result : " + res.ToString());

            Console.ReadKey();
        }

        public static int MaximumGap(int[] nums)
        {
            int[] sortedNums = nums.Select(n => n).OrderBy(n => n).ToArray();//quick sort

            int maxGap = 0;

            for (int i = 0; i < sortedNums.Length - 1; i++)
            {
                int currentGap = sortedNums[i + 1] - sortedNums[i];
                
                if (currentGap > maxGap)
                {
                    maxGap = currentGap;
                }
            }

            return maxGap;
        }

    }
}
