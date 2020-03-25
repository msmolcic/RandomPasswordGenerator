namespace RandomPasswordGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public static class CharacterSet
    {
        private static readonly Dictionary<Characters, char[]> AllSets
            = new Dictionary<Characters, char[]>();

        static CharacterSet()
        {
            AllSets.Add(Characters.Symbols         , new char[] { '#', '$', '$', '@', });
            AllSets.Add(Characters.Numbers         , GetAsciiCharactersInRange(48, 57));  // 0 ... 9
            AllSets.Add(Characters.LowercaseLetters, GetAsciiCharactersInRange(97, 122)); // a ... z
            AllSets.Add(Characters.UppercaseLetters, GetAsciiCharactersInRange(65, 90));  // 0 ... 9
            AllSets.Add(Characters.Ambiguous       , new char[] { ',', '.', ':', ';', '<', '>', '[', ']', '{', '}' });
        }

        public static IReadOnlyDictionary<Characters, char[]> Values =>
            new ReadOnlyDictionary<Characters, char[]>(CharacterSet.AllSets);

        private static char[] GetAsciiCharactersInRange(byte start, byte end)
        {
            if (start > end)
            {
                throw new ArgumentException("Invalid number sequence.");
            }

            return Enumerable
                .Range(start, end - start + 1)
                .Select(asciiValue => (char) asciiValue)
                .ToArray();

        }
    }
}
