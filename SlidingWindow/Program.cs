// See https://aka.ms/new-console-template for more information

using SlidingWindow;

foreach (var i in MinimumWindowSubstring.MaxSlidingWindow(new [] {1,3,-1,-3,5,3,6,7}, 3))
{
    Console.Write(i);
}

Console.WriteLine();
Console.WriteLine(MinimumWindowSubstring.MinWindow("ADOBECODEBANC", "ABC"));
Console.WriteLine(PermutationInString.CheckInclusion("ccc", "cbac"));
Console.WriteLine(StockPrices.MaxProfit(new int[] {2,1,2,1,0,1,2}));
