namespace LinkedList;

public class Input
{
    public Input(string[] methods, int[][] parameters)
    {
        for (var i = 0; i < methods.Length; i++)
        {
            CallMethod(methods[i], parameters[i]);
        }
    }

    public LRUCache LruCache { get; set; }
    public List<int> GetValues { get; set; } = new List<int>();

    private void CallMethod(string method, int[] parameters)
    {
        switch (method)
        {
            case "LRUCache":
                LruCache = new LRUCache(parameters.FirstOrDefault());
                return;
            case "put":
                LruCache.Put(parameters.FirstOrDefault(), parameters.LastOrDefault());
                return;
            case "get":
                GetValues.Add(LruCache.Get(parameters.FirstOrDefault()));
                return;
        }
    }
}