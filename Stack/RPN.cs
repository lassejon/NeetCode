namespace Stack;

public static class RPN
{
    public static int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();
        var result = new int();
        foreach (var token in tokens)
        {
            if (int.TryParse(token, out var value))
            {
                stack.Push(value);
                continue;
            }

            result = CalculateNext(token, stack.Pop(), stack.Pop());
            stack.Push(result);
        }

        result = stack.Count > 0 ? stack.Pop() : result;
        return result;
    }

    private static int CalculateNext(string token, int second, int first)
    {
        return token switch
        {
            "+" => first + second,
            "-" => first - second,
            "*" => first * second,
            "/" => first / second,
            _ => throw new ArgumentOutOfRangeException(nameof(token), token, null)
        };
    }
}