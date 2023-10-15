namespace Apocrypha.CommonObject.Exceptions;

public class UnsolvableEquationException : Exception
{
    public UnsolvableEquationException(string equation)
    {
        Equation = equation;
    }

    public string Equation { get; set; }
}