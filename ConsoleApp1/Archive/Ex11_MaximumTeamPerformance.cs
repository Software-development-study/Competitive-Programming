using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Ex11_MaximumTeamPerformance
    {
        public static void Run()
        {
            MaxPerformance(6, new int[] { 2, 10, 3, 1, 5, 8 }, new int[] { 5, 4, 3, 9, 7, 2 }, 2);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">Integer 1</param>
        /// <param name="speed"></param>
        /// <param name="efficiency"></param>
        /// <param name="k">Integer 2</param>
        /// <returns>
        /// sum of k most efficient engineers in terms of: speed * efficiency ( s1 + s2 ) * min(e1,e2)
        /// </returns>
        public static int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
        {
            int result = 0;

            List<Tuple<int,int>> engineersDetails = new List<Tuple<int,int>>();

            for (int i = 0; i < n; i++)
            {
                engineersDetails.Add(new Tuple<int, int>(speed[i], efficiency[i]));
            }

            engineersDetails = engineersDetails.OrderByDescending(s => s.Item1).ToList();//order by speed

            int currentSpeedSum = 0;
            int currentMin = 0;

            int lastMostEfficientEngineer = -1;

            int temp = 0;

            for (int i = 0; i < n; i++)
            {
                currentSpeedSum = currentSpeedSum + engineersDetails[i].Item1;


            }

            foreach (Tuple<int,int> engineerDetails in engineersDetails)
            {

            }

            return result;
        }

    }
}