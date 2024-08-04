public class KthLargest
{
    private PriorityQueue<int, int> minHeap;
    private int k;

    public KthLargest(int k, int[] nums)
    {
        this.k = k;
        this.minHeap = new PriorityQueue<int, int>();

        foreach (int num in nums)
        {
            minHeap.Enqueue(num, num);
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }
    }

    public int Add(int val)
    {
        minHeap.Enqueue(val, val);
        if (minHeap.Count > k)
        {
            minHeap.Dequeue();
        }

        return minHeap.Peek();
    }
}

public class Heap
{
    public int LastStoneWeight(int[] stones)
    {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        foreach (int stone in stones)
        {
            minHeap.Enqueue(-stone, -stone);
        }
        while (minHeap.Count > 1)
        {
            int first = minHeap.Dequeue();
            int second = minHeap.Dequeue();

            if (second > first)
            {
                minHeap.Enqueue(first - second, first - second);
            }
        }

        minHeap.Enqueue(0, 0);
        return Math.Abs(minHeap.Peek());
    }

    public int[][] KClosest(int[][] points, int k)
    {
        PriorityQueue<int[], double> minHeap = new PriorityQueue<int[], double>();
        int[][] res = new int[k][];

        foreach (int[] point in points)
        {
            int x = point[0];
            int y = point[1];
            double distance = Math.Sqrt(x * x + y * y);
            minHeap.Enqueue(point, distance);
        }

        for (int i = 0; i < k; i++)
        {
            res[i] = minHeap.Dequeue();
        }

        return res;
    }

    public int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

        foreach (int num in nums)
        {
            maxHeap.Enqueue(-num, -num);
        }

        while (k > 1)
        {
            maxHeap.Dequeue();
            k--;
        }

        return -maxHeap.Dequeue();
    }

    public int LeastInterval(char[] tasks, int n)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach (char task in tasks)
        {
            dict[task] = (dict.ContainsKey(task)) ? dict[task] + 1 : 1;
        }

        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();
        foreach (int freq in dict.Values)
        {
            maxHeap.Enqueue(freq, -freq);
        }

        int time = 0;
        Queue<int[]> queue = new Queue<int[]>();
        while (maxHeap.Count > 0 || queue.Count > 0)
        {
            if (queue.Count > 0 && queue.Peek()[1] <= time)
            {
                int taskFreq = queue.Dequeue()[0];
                maxHeap.Enqueue(taskFreq, -taskFreq);
            }
            if (maxHeap.Count > 0)
            {
                int freq = maxHeap.Dequeue() - 1;
                if (freq > 0)
                {
                    queue.Enqueue(new int[] { freq, time + n + 1 });
                }
            }
            time++;
        }
        return time;
    }
}
