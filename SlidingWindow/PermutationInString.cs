namespace SlidingWindow;

public class PermutationInString
{
    public static bool CheckInclusion(string s1, string s2) {
        var charCount = s1.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        var substringCharCount = new Dictionary<char, int>();
        var result = false;

        var l = 0;
        for(var r = 0; r < s2.Length; r++) {
            substringCharCount.TryGetValue(s2[r], out var currentCount); 
            substringCharCount[s2[r]] = currentCount + 1;
            
            if ((r - l + 1) > s1.Length)
            {
                if (substringCharCount[s2[l]] == 1)
                    substringCharCount.Remove(s2[l]);
                else
                    substringCharCount[s2[l]]--;
                l++;
            }

            if(IsDictionaryEquivalent(substringCharCount, charCount))
                return true;
        }
        
        return result;
    }

    private static bool IsDictionaryEquivalent<TKey>(Dictionary<TKey, int> dict1, 
        Dictionary<TKey, int> dict2)
    {
        var result = false;

        if (dict1.Count != dict2.Count)
            return false;
        if (dict1.Sum(x => x.Value) != dict2.Sum(x => x.Value)) 
            return false;
            
        foreach(var pair in dict1) 
        {
            if (dict2.ContainsKey(pair.Key) && dict2[pair.Key] == pair.Value)
            {
                result = true;
            } else {
                result = false;
                break;
            }
        }
        
        return result;
    }
}