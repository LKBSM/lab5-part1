using System;

namespace lab5_part_2
{
    // Define the custom exception class as required
    public class PasswordComplexityException : Exception
    {
        public PasswordComplexityException() { }

        public PasswordComplexityException(string message)
            : base(message) { }

        public PasswordComplexityException(string message, Exception inner)
            : base(message, inner) { }
    }
}