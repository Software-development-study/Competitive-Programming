using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Ex12_EarliestFullBloom
    {
        public static void Run()
        {
            int[] plantTime = { 1, 4, 3 };
            int[] growTime = { 2, 3, 1 };


            var watch = System.Diagnostics.Stopwatch.StartNew();
            
            long res = EarliestFullBloom(plantTime, growTime);

            Console.WriteLine(watch.Elapsed.ToString());

            Console.WriteLine("Result : " + res.ToString());

            Console.ReadKey();
        }

        public static long EarliestFullBloom(int[] plantTime, int[] growTime)
        {
            int totalPlantTime = 0;

            Tuple<int, int>[] sortedGrowTime = growTime
                .Select((time, index) => new Tuple<int, int>(index, time))//Keep index for each plant
                .OrderByDescending(x => x.Item2)//Longest planting time first
                .ToArray();

            int totalPlantTimeWithLastPlantGrowth = 0;

            for (int plantNumber = 0; plantNumber < plantTime.Length; plantNumber++)
            {
                int currentPlantIndex = sortedGrowTime[plantNumber].Item1;

                int currentPlantTime = plantTime[currentPlantIndex];

                int currentGrowthTime = growTime[currentPlantIndex];

                totalPlantTime += currentPlantTime;//Sum of all plants planting times

                if (totalPlantTime + currentGrowthTime > totalPlantTimeWithLastPlantGrowth)
                {
                    totalPlantTimeWithLastPlantGrowth = totalPlantTime + currentGrowthTime;//switch last growth time with new
                }
               
            }

            return totalPlantTimeWithLastPlantGrowth;
        }


        public static long EarliestFullBloom1(int[] plantTime, int[] growTime)
        {
            int numberOfPlants = plantTime.Length;

            int totalPlantTime = plantTime.Sum();

            Tuple<int, int>[] sortedGrowTime = growTime
                .Select((time, index) => new Tuple<int, int>(index, time))
                .OrderByDescending(x => x.Item2)
                .ToArray();

            int result = 0;

            for (int plantNumber = 0; plantNumber < numberOfPlants; plantNumber++)
            {
                int currentPlantIndex = sortedGrowTime[plantNumber].Item1;

                int currentPlantTime = plantTime[currentPlantIndex];

                int currentGrowthTime = growTime[currentPlantIndex];

                int nextPlantIndex = currentPlantIndex + 1;

                if (currentPlantTime + currentGrowthTime < currentPlantTime + growTime[nextPlantIndex])
                {
                    result += currentPlantTime;
                }
                else//Only if current plant growth time will pass next plant plant time
                {
                    if (result + currentGrowthTime < totalPlantTime)
                    {

                    }
                    result += currentPlantTime + growTime[currentPlantIndex];
                }
            }

            return result;
        }

    }
}
