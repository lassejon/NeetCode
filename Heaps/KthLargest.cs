using Microsoft.VisualBasic;

namespace Heaps
{
    public class KthLargestNaive
    {
        private List<int> _nums;
        private readonly int _k;
        public KthLargestNaive(int k, int[] nums)
        {
            _nums = nums.OrderByDescending(i => i).ToList();
            _k = k - 1;
        }

        public int Add(int val)
        {
            var added = false;

            for (var i = 0; i < _nums.Count; i++)
            {
                if (_nums[i] <= val)
                {
                    added = true;
                    _nums.Insert(i, val);
                    break;
                }
            }

            if (!added)
            {
                _nums.Add(val);
            }

            return _nums[_k];
        }
    }

    public class KthLargest
    {
        private PriorityQueue<int, int> _nums = new ();
        private readonly int _k;
        public KthLargest(int k, int[] nums)
        {
            _k = k;

            foreach (var num in nums)
            {
                this.Add(num);
            }
        }

        public int Add(int val)
        {
            if (_nums.Count < _k)
            {
                _nums.Enqueue(val, val);

                return _nums.Peek();
            }

            if (val > _nums.Peek())
            {
                _nums.Enqueue(val, val);

                if (_nums.Count > _k)
                    _nums.Dequeue();
            }

            return _nums.Peek();
        }

        public class KthLargestElement
        {
            private PriorityQueue<int, int> _nums = new();
            private int _k;
            public void Initialize(int k, int[] nums)
            {
                _k = k;

                foreach (var num in nums)
                {
                    this.Add(num);
                }
            }

            public void Add(int val)
            {
                if (_nums.Count < _k)
                {
                    _nums.Enqueue(val, val);

                    return;
                }

                if (val > _nums.Peek())
                {
                    _nums.Enqueue(val, val);

                    if (_nums.Count > _k)
                        _nums.Dequeue();
                }
            }

            public int FindKthLargest(int[] nums, int k)
            {
                this.Initialize(k, nums);

                return _nums.Peek();
            }
        }

        public class Stones
        {
            private PriorityQueue<int, int> _stones;

            public int LastStoneWeight(int[] stones)
            {
                _stones = new(stones.Select(s => (s, -s)));

                while (_stones.Count != 1) 
                {
                    this.SmashStones();
                }

                return _stones.Peek();
            }

            private void SmashStones()
            {
                var heaviestStone = _stones.Dequeue();
                var heavyStone = _stones.Dequeue();

                var stone = heaviestStone - heavyStone;

                if (stone > 0 || _stones.Count < 1)
                {
                    _stones.Enqueue(stone, -stone);
                }
            }
        }

        public class KthClosestPoint
        {
            private int _k;
            private PriorityQueue<int[], double> _points = new ();

            private readonly (int, int) _fixedPoint = (0, 0);

            public void Initialize(int k, int[][] points)
            {
                _k = k;

                foreach (var point in points)
                {
                    this.Add(point);
                }
            }
            private void Add(int[] point)
            {
                var distance = this.CalculateDistance(point);

                if (_points.Count < _k)
                {
                    _points.Enqueue(point, -distance);

                    return;
                }

                _ = _points.TryPeek(out _, out var priority);

                if (distance > priority)
                {
                    _points.Enqueue(point, -distance);

                    if (_points.Count > _k)
                        _points.Dequeue();
                }
            }

            private double CalculateDistance(int[] point)
            {
                var xDistance = Math.Pow(_fixedPoint.Item1 - point[0], 2);
                var yDistance = Math.Pow(_fixedPoint.Item2 - point[1], 2);

                var euclideanDistance = Math.Sqrt(xDistance + yDistance);

                return euclideanDistance;
            }

            public int[][] KClosest(int[][] points, int k)
            {
                this.Initialize(k, points);

                var kthClosestPoints = new int[_points.Count][];

                var i = 0;
                while (_points.Count > 0) 
                {
                    kthClosestPoints[i] = _points.Dequeue();
                    i++;
                }

                return kthClosestPoints;
            }
        }

        public class TaskScheduler
        {
            private PriorityQueue<char, int> _tasks = new ();
            private Queue<(char task, int left, int timeToAddBack)> _tasksToAddBack = new();

            private void Initialize(char[] tasks)
            {
                this.AddTasks(tasks);
            }

            private void AddTasks(char[] tasks) 
            {
                _tasks = new(tasks.GroupBy(c => c).Select(g => (g.Key, -g.Count())));
            }

            public int LeastInterval(char[] tasks, int n)
            {
                this.Initialize(tasks);

                var time = 0;
                while (_tasks.Count > 0 || _tasksToAddBack.Count > 0)
                {
                    var taskToProcess = _tasks.TryDequeue(out var task, out var priority);
                    if (taskToProcess)
                    {
                        priority++;

                        if (priority < 0)
                        {
                            _tasksToAddBack.Enqueue((task, priority, time + n));
                        }
                    }

                    while (_tasksToAddBack.TryPeek(out var taskToAddBack) && taskToAddBack.timeToAddBack <= time)
                    {
                        taskToAddBack = _tasksToAddBack.Dequeue();

                        _tasks.Enqueue(taskToAddBack.task, taskToAddBack.left);
                    }

                    time++;
                }

                return time;
            }
        }

        public class MedianFinder
        {
            private readonly PriorityQueue<int, int> _maxHeap = new();
            private readonly PriorityQueue<int, int> _minHeap = new();

            public void AddNum(int num)
            {
                if (_maxHeap.Count < 1 || num < _maxHeap.Peek())
                {
                    _maxHeap.Enqueue(num, -num);
                } else
                { 
                    _minHeap.Enqueue(num, num);
                }

                BalanceHeaps();
            }

            private void BalanceHeaps() 
            { 
                var maxHeapCount = _maxHeap.Count;
                var minHeapCount = _minHeap.Count;
                var difference = this.GetDifference(maxHeapCount, minHeapCount);
                
                if (difference > 1)
                {
                    if (maxHeapCount > minHeapCount) 
                    {
                        this.ShiftNumber(_maxHeap, _minHeap);
                    }
                    else
                    {
                        this.ShiftNumber(_minHeap, _maxHeap);
                    }
                }
            }

            private int GetDifference(int left, int right)
            {
                return Math.Abs(left - right);
            }

            private void ShiftNumber(PriorityQueue<int, int> shifter, PriorityQueue<int, int> shiftee)
            {
                var dequeued = shifter.TryDequeue(out var number, out var priority);
                if (dequeued)
                {
                    shiftee.Enqueue(number, -priority);
                }
            }

            public double FindMedian()
            {
                var maxHeapCount = _maxHeap.Count;
                var minHeapCount = _minHeap.Count;
                var difference = this.GetDifference(maxHeapCount, minHeapCount);

                double median;
                if (difference > 0)
                {
                    if (maxHeapCount > minHeapCount)
                    {
                        median = _maxHeap.Peek();
                    }
                    else
                    {
                        median = _minHeap.Peek();
                    }

                    return median;
                }

                median = (double)(_maxHeap.Peek() + _minHeap.Peek()) / 2;

                return median;
            }
        }
    }
}
