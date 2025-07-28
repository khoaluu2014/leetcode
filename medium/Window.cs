public class Window
{
    public int LengthOfLongestSubstring(string s)
    {
        HashSet<char> set = new HashSet<char>();
        int l = 0;
        int res = 0;
        for (int r = 0; r < s.Length; r++)
        {
            while (set.Contains(s[r]))
            {
                set.Remove(s[l]);
                l++;
            }
            set.Add(s[r]);
            res = Math.Max(res, r - l + 1);
        }
        return res;
    }
    public int CharacterReplacement(string s, int k)
    {
        int l = 0;
        int ans = 0;
        Dictionary<char, int> dict = new Dictionary<char, int>();
        int max_freq = 0;
        for (int r = 0; r < s.Length; r++)
        {
            if (!dict.ContainsKey(s[r]))
            {
                dict[s[r]] = 0;
            }
            dict[s[r]]++;
            max_freq = Math.Max(max_freq, dict[s[r]]);
            int window = r - l + 1;
            while (window - max_freq > k)
            {
                dict[s[l]]--;
                l++;
                window = r - l + 1;
            }
            ans = Math.Max(ans, window);
        }
        return ans;
    }
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
        {
            return false;
        }
        int[] s1Count = new int[26];
        int[] window = new int[26];
        for (int i = 0; i < s1.Length; i++)
        {
            s1Count[s1[i] - 'a']++;
            window[s2[i] - 'a']++;
        }
        int matches = 0;
        for (int i = 0; i < s1Count.Length; i++)
        {
            if (s1Count[i] == window[i])
            {
                matches++;
            }
        }

        if (matches == 26)
        {
            return true;
        }

        int l = 0;
        for (int r = s1.Length; r < s2.Length; r++)
        {
            int right = s2[r] - 'a';
            window[right]++;
            if (window[right] == s1Count[right])
            {
                matches++;
            }
            else if (window[right] == s1Count[right] + 1)
            {
                matches--;
            }
            int left = s2[l] - 'a';
            l++;
            window[left]--;
            if (window[left] == s1Count[left])
            {
                matches++;
            }
            else if (window[left] == s1Count[left] - 1)
            {
                matches--;
            }
            if (matches == 26)
            {
                return true;
            }
        }
        return false;
    }
}
