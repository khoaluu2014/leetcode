public class Array
{
    public bool hasDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();

        foreach (int num in nums)
        {
            if (set.Contains(num))
            {
                return true;
            }
            else
            {
                set.Add(num);
            }
        }
        return false;
    }

    public bool IsAnagram(string s, string t)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        if (s.Length != t.Length)
        {
            return false;
        }

        foreach (char c in s)
        {
            if (!dict.ContainsKey(c))
            {
                dict[c] = 0;
            }
            dict[c]++;
        }

        foreach (char c in t)
        {
            if (!dict.ContainsKey(c) || dict[c] == 0)
            {
                return false;
            }
            dict[c]--;
        }
        return true;
    }
}
