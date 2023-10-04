namespace Apocrypha.CommonObject.Exceptions;

public class UnrecognizedModifierException : Exception
{
    public UnrecognizedModifierException(string modifier)
    {
        Modifier = modifier;
    }

    public string Modifier { get; set; }
}