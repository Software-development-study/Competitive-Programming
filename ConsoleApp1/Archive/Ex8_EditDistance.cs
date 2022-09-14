using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Ex8_EditDistance
    {
        public static void Run()
        {
            string word1 = "horse";
            string word2 = "ros";

            var watch = System.Diagnostics.Stopwatch.StartNew();

            int res = EditDistance(word1, word2, 0);
            //int res = EditDistance(word1, word2);

            Console.WriteLine(watch.Elapsed.ToString());

            Console.WriteLine("Result : " + res.ToString());

            Console.ReadKey();
        }

        public static int EditDistance(string word1, string word2,int depth)
        {
            string depthString = "";
            for (int i = 0; i < depth; i++)
            {
                depthString = depthString + i.ToString() + ":>>>";
            }
            Console.WriteLine(depthString + " Word : " + word1);

            if (word1 == word2)
                return 0;

            int result = 1;
            int minResult = 0;

            if(word1 == "hors")
            {
                var a = 123;
            }

            if (word1.Length < word2.Length)//Insert
            {
                for (int i = 0; i < 22; i++)//traverse a,b,c letters
                {
                    for (int charIndex = 0; charIndex <= word1.Length; charIndex++)
                    {

                        var sb = new StringBuilder(word1);
                        sb.Insert(charIndex, (char)('a' + i));
                        string newWord = sb.ToString();

                        Console.WriteLine($"{depthString} Insert '{(char)('a' + i)}' --> {newWord}");

                        if (newWord == word2)
                        {
                            Console.WriteLine("-----------------------------------------------------------------------------------------Done");
                            return 1;
                        }
                        else if (word1.Count(c => c == ((char)('a' + i))) < word2.Count(c => c == ((char)('a' + i)))) //only missing letters
                        {
                            //result = EditDistance(newWord, word2) + 1;
                            result = EditDistance(newWord, word2, depth + 1) + 1;
                            if (result == 2)
                            {
                                var a = 123;
                            }
                            if (minResult == 0)
                                minResult = result;
                            else if (result < minResult)
                                minResult = result;
                        }
                    }
                }
            }


            if (word1.Length == word2.Length)// Replace
            {
                for (int i = 0; i < 22; i++)
                {
                    for (int j = 0; j < word1.Length; j++)
                    {
                        var sb = new StringBuilder(word1);
                        var sb1 = new StringBuilder(word2);

                        if (sb[j] != (char)('a' + i) && (char)('a' + i) == sb1[j])//To prevent replacing to same char and going to recursion loop
                        {
                            
                            Console.Write($"{depthString} Replace '{sb[j]}' with '{(char)('a' + i)}' --> ");

                            sb.Remove(j, 1);

                            sb.Insert(j, (char)('a' + i));

                            string newWord = sb.ToString();

                            Console.WriteLine(newWord);

                            if (newWord == word2)
                            {
                                Console.WriteLine("-----------------------------------------------------------------------------------------Done");
                                return 1;
                            }
                            else if (word1.Count(c => c == ((char)('a' + i))) < word2.Count(c => c == ((char)('a' + i)))) //only missing letters
                            {

                                //result = EditDistance(newWord, word2) + 1;
                                result = EditDistance(newWord, word2, depth + 1) + 1;
                                if (result == 2)
                                {
                                    var a = 123;
                                }
                                if (minResult == 0)
                                    minResult = result;
                                else if (result < minResult)
                                    minResult = result;
                            }
                        }
                    }
                }
            }

            if (word1.Length > word2.Length)
            {
                for (int j = 0; j < word1.Length; j++)
                {

                    var sb = new StringBuilder(word1);

                    sb.Remove(j, 1);

                    string newWord = sb.ToString();

                    Console.WriteLine($"{depthString} Remove '{j}' index --> {newWord}");

                    if (newWord == word2)
                    {
                        Console.WriteLine("-----------------------------------------------------------------------------------------Done");
                        return 1;
                    }

                    result = EditDistance(newWord, word2, depth + 1) + 1;
                    //result = EditDistance(newWord, word2) + 1;
                    if (result == 2)
                    {
                        var a = 123;
                    }
                    if (minResult == 0)
                        minResult = result;
                    else if (result < minResult)
                        minResult = result;

                }
            }
            if(minResult == 2)
            {
                var a = 123;
            }

            return minResult;

        }
    }
}
