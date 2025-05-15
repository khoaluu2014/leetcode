public class TwoPointers
{
    public bool IsPalindrome(string s)
    {
        int l = 0;
        int r = s.Length - 1;
        while (l < r)
        {
            if (!Char.IsLetterOrDigit(s[l]))
            {
                l++;
            }
            else if (!Char.IsLetterOrDigit(s[r]))
            {
                r--;
            }
            else
            {
                if (Char.ToLower(s[l]) != Char.ToLower(s[r]))
                {
                    return false;
                }
                l++;
                r--;
            }
        }
        return true;
    }

    public int[] TwoSum(int[] numbers, int target)
    {
        int l = 0;
        int r = numbers.Length - 1;

        while (l < r)
        {
            int sum = numbers[l] + numbers[r];

            if (sum == target)
            {
                return new int[] { l + 1, r + 1 };
            }
            else if (sum > target)
            {
                r--;
            }
            else if (sum < target)
            {
                l++;
            }
        }

        return new int[] { -1, -1 };
    }
}
