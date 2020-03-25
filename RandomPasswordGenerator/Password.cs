namespace RandomPasswordGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Password
    {
        private const int MinLength = 6;
        private const int MaxLength = 128;

        public Password(IEnumerable<char> value)
        {
            this.Value = this.RequireValidValue(value);
        }

        public string Value { get; }

        public static void CheckLength(int length)
        {
            if (length < Password.MinLength || length > Password.MaxLength)
            {
                throw new ArgumentException(
                    $"Password length must be between {Password.MinLength} and {Password.MinLength} characters.");
            }
        }

        public override string ToString() => this.Value;

        private string RequireValidValue(IEnumerable<char> value)
        {
            value = value ?? throw new ArgumentNullException(nameof(value));

            var password = new string(value.ToArray());

            Password.CheckLength(password.Length);

            return password;
        }
    }
}
