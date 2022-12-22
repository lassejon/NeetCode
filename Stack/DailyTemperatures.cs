namespace Stack;

public class DailyTemperatures
{
    public int[] DailyTemperaturesNext(int[] temperatures)
    {
        var result = new int[temperatures.Length];
        var toCompare = new Stack<int>();
        for (var i = 0; i < temperatures.Length; i++)
        {
            if (toCompare.Count > 0 && toCompare.Pop() is var index && index < temperatures[i])
            {
                result[index] = i - index;
            }
            
            toCompare.Push(i);
        }

        foreach (var index in toCompare)
        {
            result[index] = 0;
        }

        return result;
    }

    
}