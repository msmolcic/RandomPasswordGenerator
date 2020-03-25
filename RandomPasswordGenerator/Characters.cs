namespace RandomPasswordGenerator
{
    using System;

    [Flags]
    public enum Characters
    {
        None             = 0     ,
        Symbols          = 1 << 0,
        Numbers          = 1 << 1,
        LowercaseLetters = 1 << 2,
        UppercaseLetters = 1 << 3,
        Ambiguous        = 1 << 4,
    }
}
