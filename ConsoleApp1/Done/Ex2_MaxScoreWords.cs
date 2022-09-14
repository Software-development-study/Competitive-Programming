using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Ex2_MaxScoreWords
    {
        public static void Run()
        {
            //string[] words = { "dog", "cat", "dad", "good" };
            //char[] letters = { 'a', 'a', 'c', 'd', 'd', 'd', 'g', 'o', 'o' };
            //int[] score = { 1, 0, 9, 5, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //string[] words = { "xxxz", "ax", "bx", "cx" };
            //char[] letters = { 'z', 'a', 'b', 'c', 'x', 'x', 'x' };
            //int[] score = { 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 10 };


            string[] words = { "add", "dda", "bb", "ba", "add" };
            char[] letters = { 'a', 'a', 'a', 'a', 'b', 'b', 'b', 'b', 'c', 'c', 'c', 'c', 'c', 'd', 'd', 'd' };
            int[] score = { 3, 9, 8, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Console.WriteLine(MaxScoreWords(words, letters, score));
            Console.ReadKey();
        }

        public static int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            int maxScore = 0;
            int currentScore = 0;
            int[] letterCount = null;
            char[] availableLetters = null;

            for (int i = 0; i < words.Length; i++)
            {
                currentScore = 0;
                availableLetters = letters.Select(x => x).ToArray();//Storing the letters in an array to be able to remove them from the array - otherwise it cannot be recursive
                letterCount = InitializeLettersCount(availableLetters);//for each word we need to create bucket array for letters

                for (int k = 0; k < words[i].Length; k++)
                {
                    if (letterCount[words[i][k] - 'a'] <= 0) //Check that there enough letters of the current word in the bucket array
                    {
                        currentScore = 0; //word letters cannot be counted to score because the word cannot be used
                        break;
                    }

                    letterCount[words[i][k] - 'a']--; //Decrement the count of the current letter in the array as if we used one letter
                    currentScore += score[words[i][k] - 'a'];
                }

                if (currentScore > 0) //clear the letters from the available letters array - because we already used them in our current score
                {
                    availableLetters = ClearLettersArray(availableLetters, words[i]);
                }

                currentScore += MaxScoreWords(words.Skip(i + 1).ToArray(), availableLetters, score); //Recursive call 

                if (currentScore > maxScore)
                {
                    maxScore = currentScore;
                }
            }

            return maxScore;
        }

        public static char[] ClearLettersArray(char[] letters, string word)
        {
            for (int j = 0; j < word.Length; j++)
            {
                for (int m = 0; m < letters.Length; m++)
                {
                    if (letters[m] == word[j])
                    {
                        letters[m] = '\0';
                        break;
                    }
                }
            }
            return letters;
        }

        public static int[] InitializeLettersCount(char[] letters)
        {
            int[] letterCount = new int[26]; //Initialize the bucket array with zeros

            for (int j = 0; j < letters.Length; j++)
            {
                if (letters[j] != '\0')
                {
                    letterCount[letters[j] - 'a']++; //Increment the count of the current available letter in the array
                }
            }

            return letterCount;
        }
    }
}
