namespace TriesSoHard;

public class TrieNode
{
    public Dictionary<char, TrieNode> Tries { get; } = new();
    public bool IsEndOfWord { get; set; }

    public TrieNode(bool isEndOfWord = false)
    {
        IsEndOfWord = isEndOfWord;
    }
}

public class WordDictionary
{
    private TrieNode _root = new();

    public void AddWord(string word)
    {
        var currentNode = _root;
        foreach (var c in word)
        {
            if (!currentNode.Tries.ContainsKey(c))
            {
                currentNode.Tries[c] = new TrieNode();
            }

            currentNode = currentNode.Tries[c];
        }
    }
    
    public bool Search(string word) 
    {
        
    }
}

public class Trie {

    private readonly TrieNode _root;
    
    public Trie()
    {
        _root = new TrieNode();
    }
    
    public void Insert(string word)
    {
        var currentNode = _root;
        for (int i = 0; i < word.Length; i++)
        {
            var c = word[i];

            if (!currentNode.Tries.ContainsKey(c))
            {
                currentNode.Tries[c] = new TrieNode();
            }

            currentNode = currentNode.Tries[c];
            
            var isEndOfWord = i == word.Length - 1;
            currentNode.IsEndOfWord = currentNode.IsEndOfWord || isEndOfWord;
        }
    }
    
    public bool Search(string word, bool searchPartialWord = false)
    {
        var currentNode = _root;
        foreach (var c in word)
        {
            if (!currentNode.Tries.ContainsKey(c))
            {
                return false;
            }

            currentNode = currentNode.Tries[c];
        }

        return searchPartialWord || currentNode.IsEndOfWord;
    }
    
    public bool StartsWith(string prefix)
    {
        return this.Search(prefix, true);
    }
}