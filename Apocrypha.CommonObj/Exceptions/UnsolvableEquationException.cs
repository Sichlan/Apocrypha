namespace Apocrypha.CommonObject.Exceptions;

public class UnsolvableEquationException : Exception
{
    public UnsolvableEquationException(string equation)
    {
        Equation = equation;
    }

    public UnsolvableEquationException(string equation, string message) : base(message)
    {
        Equation = equation;
    }

    public UnsolvableEquationException(string equation, string message, Exception innerException) :
        base(message, innerException)
    {
        Equation = equation;
    }

    public string Equation { get; set; }
}