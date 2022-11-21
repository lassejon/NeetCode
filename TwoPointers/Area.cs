namespace TwoPointers;

public static class Area
{
    public static int Max(int[] height) 
    {
        var max = 0;
        
        var l = 0; var r = height.Length - 1;
        while (l < r) 
        {
            var length = r - l;
            var water = height[l] < height[r] ? length * height[l] : length * height[r];
            max = max > water ? max : water;
            
            if (height[l] > height[r]) 
            {
                r--;
                continue;
            } 
            
            if (height[l] <= height[r]) 
            {
                l++;
                continue;
            } 
        }
        
        return max;
    }
}