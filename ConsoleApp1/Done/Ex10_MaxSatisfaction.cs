using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Ex10_MaxSatisfaction
    {
        public static void Run()
        {
            //string[] ideas = new string[] { "coffee", "donuts", "time", "toffee" };

            int[] sat = new int[] { -1, -8, 0, 5, -9 };

            var watch = System.Diagnostics.Stopwatch.StartNew();

            long res = MaxSatisfaction(sat);

            Console.WriteLine(watch.Elapsed.ToString());

            Console.WriteLine("Result : " + res.ToString());

            Console.ReadKey();
        }

        public static int MaxSatisfaction(int[] satisfaction)//How many 'minuses' we would accept to gain in order to increase 'good' dishes because of time*
        {
            Array.Sort(satisfaction);//from low to high

            int maxSatisfaction = 0;

            for (int skipAmount = 0; skipAmount < satisfaction.Length; skipAmount++)//We want the highest 
            {
                int time = 1;

                int satisfactionAfterSkipping = satisfaction.Skip(skipAmount).ToList().Sum(x => x * time++);

                if(satisfactionAfterSkipping > maxSatisfaction)
                {
                    maxSatisfaction = satisfactionAfterSkipping;
                }
            }

            return maxSatisfaction;
        }
    }
}
