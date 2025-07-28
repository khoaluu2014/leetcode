// See https://aka.ms/new-console-template for more information
public class Stack
{
    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> dict = new Dictionary<char, char>();

        dict.Add('}', '{');
        dict.Add(']', '[');
        dict.Add(')', '(');

        foreach (char c in s.ToCharArray())
        {
            if (dict.ContainsKey(c))
            {
                if (stack.Count != 0 && stack.Peek() == dict[c])
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }
            else
            {
                stack.Push(c);
            }
        }

        return stack.Count == 0;
    }
}
