namespace RandomPasswordGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PasswordGenerator
    {
        private Random random;

        public Password GeneratePassword(Characters allowedCharacters, int passwordLength)
        {
            if (allowedCharacters == Characters.None)
            {
                throw new ArgumentException(
                    "Password parameters must allow at least some ASCII characters.");
            }

            Password.CheckLength(passwordLength);

            // Generate new random seed.
            this.random = new Random(Guid.NewGuid().GetHashCode());

            var sequence = new List<char>();

            var allowedSets = CharacterSet.Values
                .Where(set => (allowedCharacters & set.Key) == set.Key);

            foreach (var set in allowedSets)
            {
                sequence.AddRange(
                    this.GetRandomCharacterSequence(
                        size: 1,
                        source: set.Value));
            }

            sequence.AddRange(
                this.GetRandomCharacterSequence(
                    size: passwordLength - sequence.Count,
                    source: allowedSets.SelectMany(set => set.Value).ToArray()));

            this.Shuffle(sequence);

            return new Password(sequence);
        }

        private char[] GetRandomCharacterSequence(int size, char[] source)
        {
            source = source ?? throw new ArgumentNullException(nameof(source));

            return Enumerable
                .Range(0, size)
                .Select(_ => this.GetRandomCharacter(source))
                .ToArray();
        }

        private char GetRandomCharacter(char[] source)
        {
            source = source ?? throw new ArgumentNullException(nameof(source));

            var index = this.random.Next(0, source.Length);

            return source[index];
        }

        private void Shuffle(List<char> characters)
        {
            characters = characters ?? throw new ArgumentNullException(nameof(characters));

            int index = characters.Count;

            while (index > 1)
            {
                index--;
                int randomCharacterIndex = this.random.Next(index + 1);
                char randomCharacter = characters[randomCharacterIndex];
                characters[randomCharacterIndex] = characters[index];
                characters[index] = randomCharacter;
            }
        }
    }
}
