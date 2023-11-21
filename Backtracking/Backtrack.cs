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
            // s index, t index
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

                    if (source[i] == target[targetIndex])
                    {
                        indexStack.Push((i + 1, targetIndex));

                        if (targetIndex >= target.Length - 1) 
                        {
                            count++;
                        }

                        targetIndex++;

                        cache[(i, targetIndex)] = count;
                    } else
                    {
                        cache[(i, targetIndex)] = 0;
                    }

                    i++;
                }
            }

            return count;
        }
    }
}