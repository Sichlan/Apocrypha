using System;

namespace Apocrypha.CommonObject.Exceptions
{
    public class UnrecognizedModifierException : Exception
    {
        public UnrecognizedModifierException(string modifier)
        {
            Modifier = modifier;
        }

        public UnrecognizedModifierException(string modifier, string? message) : base(message)
        {
            Modifier = modifier;
        }

        public UnrecognizedModifierException(string modifier, string? message, Exception? innerException) : base(message, innerException)
        {
            Modifier = modifier;
        }

        public string Modifier { get; set; }
    }
}