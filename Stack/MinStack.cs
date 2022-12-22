namespace Stack;

public class MinStack
{
    private Stack<int> _stack;
    private Stack<int> _minStack;

    public MinStack()
    {
        _stack = new Stack<int>();
        _minStack = new Stack<int>();
    }
    
    public void Push(int val)
    {
        var curMin = _minStack.Count > 0 ? Math.Min(_minStack.Peek(), val) : val;
        _minStack.Push(curMin);
        _stack.Push(val);
    }
    
    public void Pop()
    {
        _stack.Pop();
        _minStack.Pop();
    }
    
    public int Top()
    {
        return _stack.Peek();
    }
    
    public int GetMin()
    {
        return _minStack.Peek();
    }
}