public class Stack
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] results = new int[temperatures.Length];
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < temperatures.Length; i++)
        {
            int temp = temperatures[i];
            while (stack.Count > 0 && temp > temperatures[stack.Peek()])
            {
                int prev = stack.Pop();
                results[prev] = i - prev;
            }
            stack.Push(i);
        }

        return results;
    }

    public int CarFleet(int target, int[] position, int[] speed)
    {
        int n = position.Length;
        List<(int position, int speed)> pairs = new List<(int, int)>();

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

    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new Stack<int>();
        foreach (String s in tokens)
        {
            if (int.TryParse(s, out int digit))
            {
                stack.Push(digit);
            }
            else
            {
                int b = stack.Pop();
                int a = stack.Pop();
                if (s == "+")
                {
                    stack.Push(a + b);
                }
                else if (s == "-")
                {
                    stack.Push(a - b);
                }
                else if (s == "*")
                {
                    stack.Push(a * b);
                }
                else if (s == "/")
                {
                    stack.Push(a / b);
                }
            }
        }
        return stack.Peek();
    }

    public List<string> GenerateParenthesis(int n)
    {
        List<string> result = new List<string>();
        void recursive(string s, int open, int close)
        {
            if (s.Length == n * 2)
            {
                result.Add(s);
                return;
            }

            if (open < n)
            {
                recursive(s + "(", open + 1, close);
            }
            if (close < open && close < n)
            {
                recursive(s + ")", open, close + 1);
            }
        }
        recursive("", 0, 0);
        return result;
    }
}

public class MinStack
{
    Stack<int> minStack;
    Stack<int> stack;

    public MinStack()
    {
        minStack = new Stack<int>();
        stack = new Stack<int>();
    }

    public void Push(int val)
    {
        if (minStack.Count == 0 || minStack.Peek() >= val)
        {
            minStack.Push(val);
        }
        stack.Push(val);
    }

    public void Pop()
    {
        int pop = stack.Pop();
        if (pop == minStack.Peek())
        {
            minStack.Pop();
        }
    }

    public int Top()
    {
        if (stack.Count == 0)
        {
            return -1;
        }
        else
        {
            return this.stack.Peek();
        }
    }

    public int GetMin()
    {
        if (minStack.Count == 0)
        {
            return -1;
        }
        else
        {
            return minStack.Peek();
        }
    }
}
