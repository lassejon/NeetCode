namespace Stack;

public static class Hard
{
    public static int LargestRectangleArea(int[] heights)
    {
        var stack = new Stack<Pillar>();
        var maxArea = int.MinValue;
        for (var i = 0; i < heights.Length; i++)
        {
            var currentHeight = heights[i];
            var startIndex = i;
            while (stack.Count > 0 && stack.Peek().Height > currentHeight)
            {
                var pillar = stack.Pop();
                var area = (i - pillar.StartIndex) * (pillar.Height);
                maxArea = Math.Max(maxArea, area);

                startIndex = pillar.StartIndex;
            }

            stack.Push(new Pillar() {StartIndex = startIndex, Height = heights[i]});
        }

        while (stack.Count > 0)
        {
            var pillar = stack.Pop();
            var area = (heights.Length - pillar.StartIndex) * (pillar.Height);
            maxArea = Math.Max(maxArea, area);
        }

        return maxArea;
    }

    private class Pillar
    {
        public int StartIndex { get; init; }
        public int Height { get; init; }
    }
}