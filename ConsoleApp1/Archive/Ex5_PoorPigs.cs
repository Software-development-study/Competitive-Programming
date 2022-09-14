using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Ex5_PoorPigs
    {
        public static void Run()
        {
            int res = PoorPigs1(1000, 15, 60);

            Console.WriteLine($"Result : {res}");
            Console.ReadKey();
        }

        public static int PoorPigs(int buckets, int minutesToDie, int minutesToTest)//lion in a desert
        {
            if (buckets < 3)//1 or 2 - break recursion
            {
                return 1;
            }

            if (minutesToDie <= minutesToTest)
            {
                return buckets - 2;
            }

            minutesToTest -= minutesToDie;
            return PoorPigs(buckets / 2, minutesToDie, minutesToTest - minutesToDie) * (minutesToTest / minutesToDie);
        }

        public static int PoorPigs1(int buckets, int minutesToDie, int minutesToTest)//lion in a desert
        {
            bool mustWait = false;

            int count = 0;

            while(buckets > 0 && minutesToTest > minutesToDie) 
            {
                buckets /= 2;
                minutesToTest -= minutesToDie;
                count++;
            }

            if(count == 0)
            {
                count = 2;
            }
            
            int result = (int)Math.Ceiling(Math.Pow(buckets, 1.0 / count));

            return result;
        }
    }
}
