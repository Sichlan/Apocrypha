namespace Apocrypha.CommonObject.Services.DiceRollerServices;

public class Node
{
    public Node(string equationPart)
    {
        EquationPart = equationPart;
        Children = new List<Node>();
    }

    public string EquationPart { get; set; }
    public double OwnValue { get; set; }
    public List<Node> Children { get; set; }

    public void AddChild(Node node)
    {
        Children.Add(node);
    }

    public double GetFullValue()
    {
        return OwnValue + Children.Sum(child => child.GetFullValue());
    }
}