using System;
using System.Linq;

namespace System
{
    public static class StringExtensions
    {
        public static string Shorten(this String input, int numberOfWords)
        {
            if (numberOfWords < 0)
                throw new ArgumentOutOfRangeException("number of words should be greater than 0");
            var phrase = input.Split(' ');

            if (numberOfWords == 0)
                return "";

            if (phrase.Length < numberOfWords)
                return input;

            return String.Join(" ", phrase.Take(numberOfWords));
        }
    }
}
