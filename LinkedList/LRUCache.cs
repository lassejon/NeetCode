namespace LinkedList;

public class LRUCache
{
    private readonly Dictionary<int, DoubleLinkedList<int>> _cache = new Dictionary<int, DoubleLinkedList<int>>();
    private readonly int _capacity;
    private int _count;

    private DoubleLinkedList<int> _lru;
    private DoubleLinkedList<int> _mru;
    
    public LRUCache(int capacity)
    {
        _capacity = capacity;
        // _lru = new DoubleLinkedList<int>(-1, 0);
        // _mru = new DoubleLinkedList<int>(-2, 0);
        //
        // _lru.Next = _mru;
        // _mru.Prev = _lru;
        // _cache[_lru.Key] = _lru;
        // _cache[_mru.Key] = _mru;
    }

    private void Remove(DoubleLinkedList<int> node)
    {
        if (_lru == node)
        {
            _lru = _lru.Next;
            return;
        }
        var prev = node.Prev;
        var next = node.Next;
        if (prev != null)
        {
            prev.Next = next;
        }

        if (next != null)
        {
            next.Prev = prev;
        }
    }

    private void Insert(DoubleLinkedList<int> node)
    {
        if (_lru == null)
        {
            _lru = node;
        }
        
        if (_mru == null)
        {
            _mru = node;
        }
        
        var prev = _mru.Prev;
        var next = _mru;

        if (prev != null)
        {
            prev.Next = node;
        }

        if (next != null)
        {
            next.Prev = node;
        }

        node.Prev = prev;
        node.Next = next;
    }

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var node))
        {
            return -1;
        }
        
        Remove(node);
        Insert(node);
        
        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var nodeToRemove))
        {
            Remove(nodeToRemove);
        }
        
        var node = new DoubleLinkedList<int>(key, value);
        
        _cache[key] = node;
        Insert(node);

        if (_cache.Count > _capacity)
        {
            _cache.Remove(_lru.Key);
            Remove(_lru);
        }
    }
}

public class DoubleLinkedList<T>
{
    public T Key  { get; set; }
    public T Value  { get; set; }
    public DoubleLinkedList<T> Next { get; set; }
    public DoubleLinkedList<T> Prev { get; set; }
    
    public DoubleLinkedList(T key = default!, T value = default!, DoubleLinkedList<T>? prev = null,  DoubleLinkedList<T>? next = null)
    {
        Key = key;
        Prev = prev;
        Value = value;
        Next = next;
    }
}