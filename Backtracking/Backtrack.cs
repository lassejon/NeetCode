using System.ComponentModel.DataAnnotations;

namespace Backtracking
{
    public class Backtracking
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var subset = new List<int>();
            var result = new List<IList<int>>();

            this.Backtrack(0, nums, subset, result);

            return result;
        }

        private void Backtrack(int i, int[] nums, List<int> subset, List<IList<int>> result)
        {
            if (i >= nums.Length)
            {
                result.Add(new List<int>(subset));
                return;
            }

            subset.Add(nums[i]);
            this.Backtrack(i + 1, nums, subset, result);

            subset.Remove(nums[i]);
            this.Backtrack(i + 1, nums, subset, result);
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new HashSet<IList<int>>();
            var subset = new List<int>();

            this.BacktrackCombination(0, candidates, target, result, subset);

            return result.ToList();
        }

        private void BacktrackCombination(int i, int[] candidates, int target, HashSet<IList<int>> result,
            List<int> subset)
        {
            var sum = subset.Sum();
            if (sum == target)
            {
                result.Add(new List<int>(subset));

                return;
            }

            if (sum > target || i >= candidates.Length)
            {
                return;
            }

            subset.Add(candidates[i]);

            BacktrackCombination(i, candidates, target, result, subset);

            subset.Remove(candidates[i]);
            BacktrackCombination(i + 1, candidates, target, result, subset);
        }

        public static int NumDistinct(string source, string target)
        {
            var count = 0;
            
            var cacheStack = new Stack<(int sourceIndex, int targetIndex)>();
            var indexStack = new Stack<(int sourceIndex, int targetIndex)>();
            indexStack.Push((0, 0));

            var cache = new Dictionary<(int sourceIndex, int targetIndex), int>();

            while (indexStack.Count > 0)
            {
                var (sourceIndex, targetIndex) = indexStack.Pop();

                var i = sourceIndex;
                while (i < source.Length && targetIndex < target.Length)
                {
                    if (cache.TryGetValue((i, targetIndex), out var cacheCount))
                    {
                        count += cacheCount;
                    }
                    else
                    {
                        cacheStack.Push((i, targetIndex));
                    }

                    if (source[i] == target[targetIndex])
                    {
                        indexStack.Push((i + 1, targetIndex));

                        if (targetIndex >= target.Length - 1) 
                        {
                            count++;

                            while (cacheStack.Count > 0) 
                            { 
                                var toCache = cacheStack.Pop();
                                cache[toCache] = cacheCount;
                            }
                            cache[(i, targetIndex)] = count;
                        }

                        targetIndex++;
                    }

                    i++;
                }
            }

            return count;
        }

        public static int NumDistinctRecursive(string source, string target)
        {
            var cache = new Dictionary<(int sourceIndex, int targetIndex), int>();

            return Dfs(0, 0, source, target, ref cache);
        }

        static int Dfs(int sourceIndex, int targetIndex, string source, string target, ref Dictionary<(int sourceIndex, int targetIndex), int>  cache)
        {
            if (targetIndex >= target.Length)
            {
                return 1;
            }

            if (sourceIndex >= source.Length)
            {
                return 0;
            }

            if (cache.TryGetValue((sourceIndex, targetIndex), out var count))
            {
                return count;
            }

            if (source[sourceIndex] == target[targetIndex])
            {
                cache[(sourceIndex, targetIndex)] = Dfs(sourceIndex + 1, targetIndex + 1, source, target, ref cache) + Dfs(sourceIndex + 1, targetIndex, source, target, ref cache);
            }
            else
            {
                cache[(sourceIndex, targetIndex)] = Dfs(sourceIndex + 1, targetIndex, source, target, ref cache);
            }

            return cache[(sourceIndex, targetIndex)];
        }
        public static IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();

            BacktrackDfs(nums, new Stack<int>(), new bool[nums.Length], ref result);

            return result;
        }

        private static void BacktrackDfs(int[] nums, Stack<int> permutation, IList<bool> used, ref List<IList<int>> permutations)
        {
            if (permutation.Count == nums.Length)
            {
                permutations.Add(permutation.ToList());
                return;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (used[i])
                {
                    continue;
                }
                
                used[i] = true;
                permutation.Push(nums[i]);

                BacktrackDfs(nums, permutation, used, ref permutations);

                used[i] = false;
                permutation.Pop();
            }
        }
        
        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            var result = new List<IList<int>>();
            var cache = new HashSet<List<int>>(new ListEqualityComparer());

            BacktrackDfsUnique(nums, new Stack<int>(), new bool[nums.Length], ref result, cache);

            return result;
        }

        private static void BacktrackDfsUnique(int[] nums, Stack<int> permutation, IList<bool> used, 
            ref List<IList<int>> permutations, HashSet<List<int>> cache)
        {
            var list = permutation.ToList();
            if (permutation.Count == nums.Length && !cache.Contains(list))
            {
                permutations.Add(list);
                cache.Add(list);
                return;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (used[i])
                {
                    continue;
                }
                
                used[i] = true;
                permutation.Push(nums[i]);

                BacktrackDfsUnique(nums, permutation, used, ref permutations, cache);

                used[i] = false;
                permutation.Pop();
            }
        }
    }

    public class ListEqualityComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            if (x.Capacity != y.Capacity && x.Count != y.Count) return false;

            return x.SequenceEqual(y);
        }

        public int GetHashCode(List<int> obj)
        {
            return HashCode.Combine(obj.Capacity, obj.Count);
        }
    }
}