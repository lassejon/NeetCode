// See https://aka.ms/new-console-template for more information
using Heaps;

var nums = new int[] { 4, 5, 8, 2 };
var k = 3;

var kthLargest = new KthLargest(k, nums);

Console.WriteLine(kthLargest.Add(3));
Console.WriteLine(kthLargest.Add(5));
Console.WriteLine(kthLargest.Add(10));
Console.WriteLine(kthLargest.Add(9));
Console.WriteLine(kthLargest.Add(4));

{
    var taskScheduler = new KthLargest.TaskScheduler();

    var tasks = new char[] { 'A', 'B', 'A' };
    var n = 2;

    Console.WriteLine(taskScheduler.LeastInterval(tasks, n));

    var medianFinder = new KthLargest.MedianFinder();
    var medians = new List<double>();

    medianFinder.AddNum(-1);
    medians.Add(medianFinder.FindMedian());
    medianFinder.AddNum(-2);
    medians.Add(medianFinder.FindMedian());

    medianFinder.AddNum(-3);
    medians.Add(medianFinder.FindMedian());

    medianFinder.AddNum(-4);
    medians.Add(medianFinder.FindMedian());

    medianFinder.AddNum(-5);
    medians.Add(medianFinder.FindMedian());

    medians.ForEach(m => Console.Write(String.Format("{0:0.00000}", m)));

}

Console.WriteLine();

{
    var taskScheduler = new KthLargest.TaskScheduler();

    var tasks = new char[] { 'A', 'B', 'A' };
    var n = 2;

    Console.WriteLine(taskScheduler.LeastInterval(tasks, n));

    var medianFinder = new KthLargest.MedianFinder();
    var medians = new List<double>();

    medianFinder.AddNum(1);
    medianFinder.AddNum(2);
    medians.Add(medianFinder.FindMedian());

    medianFinder.AddNum(3);
    medians.Add(medianFinder.FindMedian());

    medians.ForEach(m => Console.Write(String.Format("{0:0.00000}", m)));

}