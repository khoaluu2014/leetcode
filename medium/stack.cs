public class Stack
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int n = temperatures.Length;
        int[] result = new int[n];
        Stack<int[]> stack = new Stack<int[]>();

        for (int i = 0; i < n; i++)
        {
            int temp = temperatures[i];
            while (stack.Count > 0 && temp > stack.Peek()[0])
            {
                int[] pair = stack.Pop();
                result[pair[1]] = i - pair[1];
            }
            stack.Push(new int[] { temp, i });
        }
        return result;
    }

    public int CarFleet(int target, int[] position, int[] speed)
    {
        int n = position.Length;
        var pairs = new List<(int position, int speed)>();

        for (int i = 0; i < n; i++)
        {
            pairs.Add((position[i], speed[i]));
        }

        pairs.Sort((a, b) => b.position.CompareTo(a.position));

        Stack<double> stack = new Stack<double>();
        foreach (var pair in pairs)
        {
            double time = (double)(target - pair.position) / pair.speed;
            if (stack.Count > 0 && time <= stack.Peek())
            {
                continue;
            }
            stack.Push(time);
        }

        return stack.Count;
    }
}
