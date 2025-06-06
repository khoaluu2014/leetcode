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

    public List<List<int>> ThreeSum(int[] nums)
    {
        List<List<int>> ans = new List<List<int>>();

        List<int> sorted = new List<int>(nums);
        sorted.Sort();

        for (int i = 0; i < sorted.Count - 2; i++)
        {
            if (i > 0 && sorted[i] == sorted[i - 1])
            {
                continue;
            }
            int l = i + 1;
            int r = sorted.Count - 1;
            while (l < r)
            {
                if (sorted[i] == -(sorted[l] + sorted[r]))
                {
                    ans.Add(new List<int> { sorted[i], sorted[l], sorted[r] });
                    l++;
                    r--;
                    while (l < r && sorted[l] == sorted[l - 1])
                    {
                        l++;
                    }
                    while (l < r && sorted[r] == sorted[r + 1])
                    {
                        r--;
                    }
                }
                else if (sorted[i] > -(sorted[l] + sorted[r]))
                {
                    r--;
                }
                else if (sorted[i] < -(sorted[l] + sorted[r]))
                {
                    l++;
                }
            }
        }

        return ans;
    }

    public int MaxArea(int[] heights)
    {
        int max = 0;
        int l = 0;
        int r = heights.Length - 1;

        while (l < r)
        {
            int area = (r - l) * Math.Min(heights[l], heights[r]);
            max = Math.Max(max, area);
            if (heights[l] < heights[r])
            {
                l++;
            }
            else if (heights[l] >= heights[r])
            {
                r--;
            }
        }

        return max;
    }

    public int Trap(int[] height)
    {
        int ans = 0;
        int l = 0;
        int r = height.Length - 1;
        int maxLeft = height[l];
        int maxRight = height[r];
        while (l < r)
        {
            if (maxLeft < maxRight)
            {
                l++;
                maxLeft = Math.Max(height[l], maxLeft);
                ans += maxLeft - height[l];
            }
            else
            {
                r--;
                maxRight = Math.Max(height[r], maxRight);
                ans += maxRight - height[r];
            }
        }

        return ans;
    }
}
