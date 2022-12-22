namespace Stack;

public class ETA
{
    public static int CarFleet(int target, int[] position, int[] speed)
    {
        var positionAndSpeedPairs = position.Zip(speed);
        positionAndSpeedPairs = positionAndSpeedPairs.OrderByDescending(x => x.First);
        
        var stack = new Stack<double>();
        foreach (var pair in positionAndSpeedPairs)
        {
            var eta = (double)(target - pair.First) / pair.Second;
            if (stack.Count == 0 || eta > stack.Peek())
            {
                stack.Push(eta);
            }
        }

        return stack.Count;
    }
}