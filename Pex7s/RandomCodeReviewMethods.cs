using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pex7s
{
    public static class RandomCodeReviewMethods
    {
        public static bool ContainsVowels(string input)
        {
            Console.WriteLine("We will check if your string contains any vowels or not.");
            Console.Write("Enter a word: ");
            //var vowelsInWord = Console.ReadLine().ToLower().Intersect("aeiou".ToCharArray());
            var vowelsInWord = input.ToLower().Intersect("aeiou".ToCharArray());
            if (!vowelsInWord.Any())
            {
                //Console.WriteLine("There are no vowels in this word, how do you pronounce that?");
                return false;
            }
            else
            {
                return true;
                //foreach (var vowel in vowelsInWord)
                //{
                //    Console.WriteLine($"Your word contains the vowel '{vowel}'");
                //}
            }
        }
    }
}
