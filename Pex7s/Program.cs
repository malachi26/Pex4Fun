using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Pex7s
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var watch = new Stopwatch();
            //var functionReturn = 0;
            Console.WriteLine("coder         | iteration | Time | result");
            for (int i = 5; i > 0; i--)
            {
                FunctionF(i);
                FunctionNathan(i);
                FunctionKovach(i);
            }
            for (int i = 1; i < 10; i++)
            {
                FunctionOutputDelegator("Kovach's Code", FunctionKovach, i);
                FunctionOutputDelegator("Lyle's Code", FunctionF, i);
                FunctionOutputDelegator("Nathan's Code", FunctionNathan, i);
            }
            Console.ReadLine();
        }
        public static void FunctionOutputDelegator(string functionName, Func<int, int> function, int integer)
        {
            var functionReturn = 0;
            var watch = new Stopwatch();
            watch.Start();
            functionReturn = function(integer);
            watch.Stop();
            Console.WriteLine($"{functionName} | x = {integer} | {watch.ElapsedTicks.ToString()} | {functionReturn.ToString()}");
        }
        public static int FunctionF(int x)
        {
            if (x == 1) return 7;
            if (x >= 33) return -7;
            var y = x - 1;
            return (7 * (int)(Math.Pow(2, y)) + FunctionF(y));
        }

        public static int FunctionNathan(int x)
        {
            if (x >= 32) return -7;
            return (((int)Math.Pow(2, x)) - 1) * 7;
        }

        public static int FunctionKovach(int x)
        {
            var result = 0;
            if (x == 1)
            {
                result = x * 7;
            }
            else
            {
                result += x * 7;
                while (x > 0)
                {
                    x--;
                    result += FunctionKovach(x);
                }
            }
            return result;

        }

        public static bool AreStringsAnagrams(string a, string b)
        {

            if (a.Length != b.Length)
            {
                return false;
            }



            Dictionary<char, int> firstString = new Dictionary<char, int>();
            Dictionary<char, int> secondString = new Dictionary<char, int>();

            foreach (char character in a.ToLower())
            {

                if (firstString.ContainsKey(character))
                {
                    firstString[character]++;
                }
                else
                {
                    firstString[character] = 1;
                }
            }

            foreach (char character2 in b.ToLower())
            {
                if (secondString.ContainsKey(character2))
                {
                    secondString[character2]++;
                }
                else
                {
                    secondString[character2] = 1;
                }
            }

            foreach (KeyValuePair<char, int> letterValue in secondString)
            {
                if (!firstString.ContainsKey(letterValue.Key)
                    || (firstString[letterValue.Key] != secondString[letterValue.Key]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool LinqAreStringsAnagrams(string a, string b)
        {
            var firstString = a.ToLower().GroupBy(val => val).ToDictionary(letter => letter.Key, letter => letter.Count());
            var secondString = b.ToLower().GroupBy(val => val).ToDictionary(letter => letter.Key, letter => letter.Count());


            foreach (var kvp in firstString)
                if (!secondString.ContainsKey(kvp.Key) || secondString[kvp.Key] != kvp.Value)
                    return false;

            return firstString.Keys.Count == secondString.Keys.Count;
        }


        public static bool IsNumberPrime(int number)
        {
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
