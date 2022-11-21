namespace SlidingWindow;

public static class MinimumWindowSubstring
{
    public static string MinWindow(string s, string t) 
    {
        if (t.Length > s.Length)
        {
            return string.Empty;
        }

        if (s == t)
            return t;

        var minSubString = string.Empty;
        var shortestSubString = s.Length;

        var countT = t.GroupBy(c => c).ToDictionary(kv => kv.Key, kv => kv.Count());
        var countTOfS = new Dictionary<char, int>();
        var charsToVisit = new Dictionary<char, int>();
        var indices = new Queue<char>();
        var l = 0;

        for (var r = 0; r < s.Length; r++)
        {
            if (!countT.ContainsKey(s[r])) continue;
            
            countTOfS.TryGetValue(s[r], out var currentCount);
            countTOfS[s[r]] = currentCount + 1;

            if (r != 0)
            {
                if (currentCount <= countT[s[r]])
                {
                    indices.Enqueue(s[r]);
                    charsToVisit[s[r]] = r;
                }
            }

            while (DictionaryContains(countTOfS, countT))
            {
                var currentSubstringLength = r - l + 1;
                if (currentSubstringLength <= shortestSubString)
                {
                    minSubString = s.Substring(l, currentSubstringLength);
                    shortestSubString = currentSubstringLength;
                }
                
                if(countTOfS.ContainsKey(s[l]))
                    countTOfS[s[l]]--;

                if(indices.Count > 0)
                    l = charsToVisit[indices.Dequeue()];
            }
        }
        
        return minSubString;
    }
    
    private static bool DictionaryContains<TKey>(IReadOnlyDictionary<TKey, int> contains, Dictionary<TKey, int> contained) where TKey : notnull
    {
        var result = false;

        if (contains.Count != contained.Count)
            return false;

        foreach (var kv in contained)
        {
            if (!contains.TryGetValue(kv.Key, out var count))
            {
                return false;
            }

            if (count < kv.Value)
            {
                return false;
            }

            result = true;
        }

        return result;
    }
}