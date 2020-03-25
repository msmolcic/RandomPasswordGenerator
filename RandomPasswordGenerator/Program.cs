namespace RandomPasswordGenerator
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var generator = new PasswordGenerator();
            var password = generator.GeneratePassword(
                allowedCharacters: Characters.Symbols
                | Characters.Numbers
                | Characters.LowercaseLetters
                | Characters.UppercaseLetters,
                passwordLength: 8);

            Console.WriteLine($"Auto-generated password: {password}");
        }
    }
}
