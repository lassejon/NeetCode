namespace BinarySearch;

public class Binary
{
    public static int Search(int[] nums, int target) 
    {
        var l = 0;
        var r= nums.Length - 1;

        while (l <= r)
        {
            var m = (l + r) / 2;
            var value = nums[m];
            if (target > value)
            {
                l = m - 1;
            }

            if (target < value)
            {
                r = m + 1;
            }

            if (target == value)
            {
                return m;
            }
        }

        return -1;
    }
    
    public static bool SearchMulti(int[][] matrix, int target) 
    {
        if (matrix.Length == 0)
        {
            return false;
        }
        
        var l = 0;
        var height = matrix.Length;
        var width = matrix[0].Length;
        var r= height * width - 1;

        while (l <= r)
        {
            var m = (l + r) / 2;
            var row = m / width;
            var col = m % width;
            
            var value = matrix[row][col];
            if (target > value)
            {
                l = m + 1;
            }

            if (target < value)
            {
                r = m - 1;
            }

            if (target == value)
            {
                return true;
            }
        }

        return false;
    }
    
    public static int MinEatingSpeed(int[] piles, int h) 
    {
        var l = (int)Math.Ceiling((double)piles.Select(p => (long)p).Sum() / h);

        var r = piles.Max();
        var minK = r;

        while (l <= r)
        {
            var k = (l + r) / 2;
            
            var hoursSpentEating = 0;

            foreach (var pile in piles)
            {
                hoursSpentEating += (int)Math.Ceiling((double)pile / k);

                if (hoursSpentEating > h)
                {
                    l = k + 1;
                    break;
                }
            }

            if (hoursSpentEating <= h)
            {
                minK = k;
                r = k - 1;
            }

        }

        return minK;
    }
    
    public static int SearchRotated(int[] nums, int target)
    {
        var l = 0;
        var r = nums.Length - 1;

        while (l <= r)
        {
            var m = (l + r) / 2;

            if (nums[m] == target)
            {
                return m;
            }

            if (target < nums[m] && target < nums[l])
            {
                l = m + 1;
                continue;
            }
            
            if (target < nums[m] && target > nums[r])
            {
                r = m - 1;
                continue;
            }

            if (target > nums[m] && target < nums[l])
            {
                l = m + 1;
                continue;
            }
            
            if (target > nums[m] && target > nums[r])
            {
                r = m - 1;
            }
        }

        return -1;
    }
}