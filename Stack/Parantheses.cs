namespace Stack;

public class Parantheses
{
    private static List<string> _result = null!;
    private static Stack<string> _stack = null!;
    private static int _n;

    public static IList<string> Generate(int n)
    {
        _result = new List<string>(n);
        _stack = new Stack<string>();
        _n = n;

        Backtrack(0, 0);
        
        return _result;
    }

    private static void Backtrack(int openParantheses, int closedParantheses)
    {
        if (openParantheses == _n && closedParantheses == _n)
        {
            _result.Add(string.Join("", _stack));
            return;
        }

        if (openParantheses < _n)
        {
            _stack.Push(")");
            Backtrack(openParantheses + 1, closedParantheses);
            _stack.Pop();
        }
        
        if (closedParantheses < openParantheses)
        {
            _stack.Push("(");
            Backtrack(openParantheses, closedParantheses + 1);
            _stack.Pop();
        }
    }
}