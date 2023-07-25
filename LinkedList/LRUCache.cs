namespace LinkedList;

public class LRUCache
{
    private Dictionary<int, DoubleLinkedList<int>> nodes = new Dictionary<int, DoubleLinkedList<int>>();
    private readonly int _capacity;
    private int _count = 0;

    private DoubleLinkedList<int> _lru;
    private DoubleLinkedList<int> _mru;
    
    public LRUCache(int capacity)
    {
        _capacity = capacity;
    }
    
    public int Get(int key)
    {
        if (!nodes.TryGetValue(key, out var node))
        {
            return -1;
        }

        if (node == _lru && _count > 1)
        {
            _lru = node.Next;
            if (_lru != null)
            {
                _lru.Before = null;
            }
        }
        
        var before = node.Before;
        if (before != null)
        {
            before.Next = node.Next;
        }
            
        node.Next = null;
        
        if (_mru != null)
        {
            _mru.Next = node;
            node.Before = _mru;
        }
        _mru = node;

        return node.Value;

    }
    
    public void Put(int key, int value)
    {
        var node = new DoubleLinkedList<int>(key, value);
        
        if (_count == _capacity)
        {
            Delete();
        }
        
        if (nodes.TryGetValue(key, out var existingNode))
        {
            existingNode.Value = value;
            return;
        }
        
        if (_count == 0)
        {
            _mru = node;
            _lru = node;
        }
        else
        {
            _mru.Next = node;
            node.Before = _mru;
            _mru = node;
        }

        nodes[key] = node;

        _count = _count == _capacity ? _count : _count + 1;
    }

    private void Delete()
    {
        var nodeToRemove = _lru;

        if (nodeToRemove == null)
        {
            return;
        }
        
        _lru = nodeToRemove.Next;

        nodeToRemove.Before = null;
        nodeToRemove.Next = null;    
            
        nodes.Remove(nodeToRemove.Key);
    }
}

public class DoubleLinkedList<T>
{
    public T Key  { get; set; }
    public T Value  { get; set; }
    public DoubleLinkedList<T> Next { get; set; }
    public DoubleLinkedList<T> Before { get; set; }
    
    public DoubleLinkedList(T key = default!, T value = default!, DoubleLinkedList<T>? before = null,  DoubleLinkedList<T>? next = null)
    {
        Key = key;
        Before = before;
        Value = value;
        Next = next;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */