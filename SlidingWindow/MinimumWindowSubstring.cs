namespace SlidingWindow;

public static class MinimumWindowSubstring
{
    public static int[] MaxSlidingWindow(int[] nums, int k)
    {
        var result = new int[nums.Length - k + 1];
        var descendingDeque = new LinkedList<int>();

        var l = 0;
        for (var r = 0; r < nums.Length; r++)
        {
            var current = nums[r];
            while (descendingDeque.Last != null && descendingDeque.Count > 0 && nums[descendingDeque.Last.Value] < current)
            {
                descendingDeque.RemoveLast();
            }

            descendingDeque.AddLast(r);

            if (descendingDeque.First != null && descendingDeque.Count > 0 && descendingDeque.First.Value < l)
            {
                descendingDeque.RemoveFirst();
            }

            if ((l + r + 1) < k) continue;
            result[l] = nums[descendingDeque.First.Value];
            l++;
        }
        
        return result;
    }
    
    public static int[] MaxSlidingWindowBruteForce(int[] nums, int k)
    {
        var result = new int[nums.Length - k + 1];
        
        var l = 0;
        for (var r = k - 1; r < nums.Length; r++)
        {
            var subArray = nums.Skip(l).Take(k);
            var max = subArray.Max();
            result[l] = max;
            l++;
        }

        return result;
    }
    public static string MinWindow(string s, string t) 
    {
        if (t == string.Empty)
            return string.Empty;
        if (t.Length > s.Length)
            return string.Empty;
        if (s == t)
            return t;

        var minSubString = string.Empty;
        var shortestSubString = s.Length;

        var countT = t.GroupBy(c => c).ToDictionary(kv => kv.Key, kv => kv.Count());
        var windowCount = new Dictionary<char, int>();
        
        

        var need = countT.Count;
        var have = 0; 
        
        var l = 0;
        for (var r = 0; r < s.Length; r++)
        {
            var rightChar = s[r];
            
            windowCount.TryGetValue(rightChar, out var rightVal);
            windowCount[rightChar] = rightVal + 1;
            
            if (countT.ContainsKey(rightChar) && windowCount[rightChar] == countT[rightChar])
            {
                have++;
            }
            
            while (have == need && l <= r)
            {
                var currentSubstringLength = r - l + 1;
                if (currentSubstringLength <= shortestSubString)
                {
                    minSubString = s.Substring(l, currentSubstringLength);
                    shortestSubString = currentSubstringLength;
                }
                var leftChar = s[l];

                windowCount.TryGetValue(leftChar, out var leftVal);
                windowCount[leftChar] = leftVal - 1;
                if (countT.ContainsKey(leftChar) && windowCount[leftChar] < countT[leftChar])
                {
                    have--;
                }
                
                l++;
            }
        }
        
        return minSubString;
    }
    
    // private static bool DictionaryContains<TKey>(IReadOnlyDictionary<TKey, int> contains, Dictionary<TKey, int> contained) where TKey : notnull
    // {
    //     var result = false;
    //
    //     if (contains.Count != contained.Count)
    //         return false;
    //
    //     foreach (var kv in contained)
    //     {
    //         if (!contains.TryGetValue(kv.Key, out var count))
    //         {
    //             return false;
    //         }
    //
    //         if (count < kv.Value)
    //         {
    //             return false;
    //         }
    //
    //         result = true;
    //     }
    //
    //     return result;
    // }
}