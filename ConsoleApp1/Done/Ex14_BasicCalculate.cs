using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Ex14_BasicCalculate
    {
        public static void Run()
        {
            string s = "(1+(4+5+2)-3)+(6+8)";

            var watch = System.Diagnostics.Stopwatch.StartNew();

            long res = Calculate(s);

            Console.WriteLine(watch.Elapsed.ToString());

            Console.WriteLine("Result : " + res.ToString());

            Console.ReadKey();
        }

        public static int Calculate(string s)
        {
            int result = 0;

            Stack parantheses = new Stack();

            bool isAddition = true;

            int currentNumber = 0;

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                        parantheses.Push(new Tuple<int, char>(result, isAddition ? '+' : '-')); //Result until this point and what to do after
                        result = 0;
                        isAddition = true;
                        currentNumber = 0;
                        break;
                    case ')':
                        result = isAddition ? result + currentNumber : result - currentNumber;
                        Tuple<int, char> currentParantheses = (Tuple<int, char>)parantheses.Pop();
                        result = currentParantheses.Item2 == '+' ? currentParantheses.Item1 + result : currentParantheses.Item1 - result;
                        currentNumber = 0;
                        break;
                    case '+':
                    case '-':
                        result = isAddition ? result + currentNumber : result - currentNumber;//based on current action type
                        currentNumber = 0;
                        isAddition = s[i] == '+';
                        break;
                    case ' ':
                        break;
                    default:
                        if (s[i] >= '0' && s[i] <= '9')
                        {
                            int currentDigit = (s[i] - '0');

                            currentNumber *= 10;//On first digit it will be 0
                            currentNumber += currentDigit;
                        }
                        break;
                }
            }

            result = currentNumber > 0 ? (isAddition ? result + currentNumber : result - currentNumber) : result;

            return result;
        }
    }
}


//int currentDigit = (s[i] - '0');

//if (isSameDigit)
//{

//}

//isSameDigit = true;

//result = isAddition ? result + currentDigit : result - currentDigit;