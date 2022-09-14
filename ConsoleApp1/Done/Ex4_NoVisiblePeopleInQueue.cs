using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ex4_NoVisiblePeopleInQueue
    {
        public static void Run()
        {
            //int[] heights = new int[100000];

            //for (int j = 0; j < heights.Length; j++)
            //{
            //    heights[j] = j + 1;
            //}

            var watch = System.Diagnostics.Stopwatch.StartNew();

            //int[] heights1 = { 10, 6, 8, 5, 11, 9 };
            //int[] heights2 = { 5, 1, 2, 3, 10 };
            //int[] heights3 = { 4, 3, 2, 1 };
            int[] heigths4 = { 3, 1, 5, 8, 6 };

            //int[] answer1 = CanSeePersonsCount3(heights1);
            //int[] answer2 = CanSeePersonsCount3(heights2);
            //int[] answer3 = CanSeePersonsCount3(heights3);
            int[] answer4 = CanSeePersonsCount3(heigths4);
            //int[] answer4 = CanSeePersonsCount3(heights1);

            //Console.Write($"Anwer1 : ");
            //for (int i = 0; i < answer1.Length; i++)
            //{
            //    Console.Write($" , {answer1[i].ToString()}");
            //}
            //Console.WriteLine();

            //Console.Write($"Anwer2 : ");
            //for (int i = 0; i < answer2.Length; i++)
            //{
            //    Console.Write($" , {answer2[i].ToString()}");
            //}
            //Console.WriteLine();

            //Console.Write($"Anwer3 : ");
            //for (int i = 0; i < answer3.Length; i++)
            //{
            //    Console.Write($" , {answer3[i].ToString()}");
            //}
            //Console.WriteLine();
            //watch.Stop();

            Console.Write($"Anwer4 : ");
            for (int i = 0; i < answer4.Length; i++)
            {
                Console.Write($" , {answer4[i].ToString()}");
            }
            Console.WriteLine();


            Console.WriteLine(watch.Elapsed.ToString());
            Console.ReadKey();
        }
        public static int[] CanSeePersonsCount(int[] heights)
        {
            int[] answer = new int[heights.Length];

            for (int i = 0; i < heights.Length - 1; i++)
            {
                int currentHeight = heights[i];
                int count = 0;
                int lastHighestPosition = i + 1;

                for (int j = i + 1; j < heights.Length; j++)
                {
                    if (heights[j] >= heights[lastHighestPosition])
                    {
                        count++;
                        lastHighestPosition = j;
                    }
                    if (currentHeight < heights[j])
                    {
                        break;
                    }
                }

                if (i + 1 == heights.Length) //For last person in array
                {
                    count = 0;
                }

                answer[i] = count;
            }

            return answer;
        }
        public static int[] CanSeePersonsCount2(int[] heights)// int[] heights1 = { 10, 6, 8, 5, 11, 9 };
        {
            int[] answer = new int[heights.Length];

            int currentPosition = heights.Length - 1;

            for (int viewerPosition = heights.Length - 2; viewerPosition >= 0; viewerPosition--)//viewer
            {
                if (viewerPosition + 1 == currentPosition || heights[viewerPosition] > heights[viewerPosition + 1])
                {
                    answer[viewerPosition]++;
                }

                if (heights[viewerPosition] > heights[currentPosition] || (viewerPosition == 0 && currentPosition > 0))
                {
                    currentPosition--;
                    viewerPosition = currentPosition;
                }
            }


            return answer;
        }

        //public static int[] CanSeePersonsCount3(int[] heights)// int[] heights1 = { 10, 6, 8, 5, 11, 9 };
        //{
        //    int[] answer = new int[heights.Length];
        //    int amountOfPeople = heights.Length;
        //    int lastPositionIndex = amountOfPeople - 1;




        //    for (int viewerPosition = 0; viewerPosition < amountOfPeople - 1; viewerPosition++)
        //    {
        //        int currentPosition = viewerPosition + 1;

        //        while (currentPosition < amountOfPeople && heights[viewerPosition] < heights[currentPosition])//much more efficient
        //        {
        //            answer[viewerPosition] = 1;
        //            viewerPosition++;
        //            currentPosition++;
        //        }

        //        int descendingPositionStarted = currentPosition;

        //        while(descendingPositionStarted < )

        //        int count = 0;
        //        int currentHighest = currentPosition;
        //        int viewerHeight = heights[viewerPosition];

        //        if (currentPosition <= lastPositionIndex)
        //        {
        //            while (currentPosition < amountOfPeople && viewerHeight > heights[currentPosition])
        //            {
        //                if (heights[currentPosition] >= heights[currentHighest])
        //                {
        //                    count++;
        //                    currentHighest = currentPosition;
        //                }
        //                currentPosition++;
        //            }

        //            if (currentPosition <= lastPositionIndex)
        //                count++;
        //        }
        //        answer[viewerPosition] = count;

        //    }

        //    answer[lastPositionIndex] = 0;

        //    return answer;

        //}

        public static int[] CanSeePersonsCount3(int[] heights)
        {
            int numberOfPeople = heights.Length;

            int[] result = new int[numberOfPeople];

            Stack<int> currentViewers = new Stack<int>();

            for (int currentPosition = 0; currentPosition < numberOfPeople; currentPosition++)//current spectated position by viewers from the left [0,1,2 -> *3*,..]
            {
                while (currentViewers.Count > 0)
                {
                    int lastViewer = currentViewers.Peek();

                    if (heights[lastViewer] >= heights[currentPosition])//until someone shorter is found
                    {
                        result[currentViewers.Peek()]++;
                        break;
                    }

                    result[currentViewers.Pop()]++;//remove shorter people than current position
                }

                currentViewers.Push(currentPosition);
            }

            return result;
        }
    }
}