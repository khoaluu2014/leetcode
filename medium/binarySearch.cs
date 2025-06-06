public class BinarySearch
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        int top = 0;
        int bot = m - 1;

        int row = 0;
        while (top <= bot)
        {
            row = (top + bot) / 2;
            if (target > matrix[row][n - 1])
            {
                top = row + 1;
            }
            else if (target < matrix[row][0])
            {
                bot = row - 1;
            }
            else if (target <= matrix[row][n - 1] && target >= matrix[row][0])
            {
                break;
            }
        }

        if (top > bot)
        {
            return false;
        }

        int l = 0;
        int r = n - 1;
        while (l <= r)
        {
            int mid = (l + r) / 2;
            if (target == matrix[row][mid])
            {
                return true;
            }
            else if (target > matrix[row][mid])
            {
                l = mid + 1;
            }
            else if (target < matrix[row][mid])
            {
                r = mid - 1;
            }
        }
        return false;
    }

    public int MinEatingSpeed(int[] piles, int h)
    {
        int l = 1;
        int r = piles.Max();
        int res = r;

        while (l <= r)
        {
            int k = (l + r) / 2;
            int totalTime = 0;

            foreach (int pile in piles)
            {
                totalTime += (int)Math.Ceiling((double)pile / k);
            }
            if (totalTime <= h)
            {
                res = k;
                r = k - 1;
            }
            else if (totalTime > h)
            {
                l = k + 1;
            }
        }
        return res;
    }

    public int FindMin(int[] nums)
    {
        int l = 0;
        int r = nums.Length - 1;

        while (l <= r)
        {
            if (nums[l] <= nums[r])
            {
                return nums[l];
            }
            int mid = (l + r) / 2;
            if (nums[mid] >= nums[l])
            {
                l = mid + 1;
            }
            else if (nums[mid] < nums[l])
            {
                r = mid;
            }
        }

        return 0;
    }

    public int Search(int[] nums, int target)
    {
        int l = 0;
        int r = nums.Length - 1;

        while (l <= r)
        {
            int mid = (l + r) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[l] <= nums[mid])
            {
                if (target > nums[mid] || target < nums[l])
                {
                    l = mid + 1;
                }
                else if (target <= nums[mid] && target >= nums[l])
                {
                    r = mid - 1;
                }
            }
            else if (nums[l] > nums[mid])
            {
                if (target < nums[mid] || target > nums[r])
                {
                    r = mid - 1;
                }
                else if (target >= nums[mid] && target <= nums[r])
                {
                    l = mid + 1;
                }
            }
        }

        return -1;
    }

    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int[] A = nums1;
        int[] B = nums2;
        int total = A.Length + B.Length;
        int half = (total + 1) / 2;

        if (B.Length < A.Length)
        {
            int[] temp = A;
            A = B;
            B = temp;
        }

        int l = 0;
        int r = A.Length;
        while (l <= r)
        {
            int i = (l + r) / 2; // A
            int j = half - i; // B

            int aLeft = i > 0 ? A[i - 1] : int.MinValue;
            int aRight = i < A.Length ? A[i] : int.MaxValue;
            int bLeft = j > 0 ? B[j - 1] : int.MinValue;
            int bRight = j < B.Length ? B[j] : int.MaxValue;

            if (aLeft <= bRight && bLeft <= aRight)
            {
                if (total % 2 != 0)
                {
                    return Math.Max(aLeft, bLeft);
                }
                return (Math.Max(aLeft, bLeft) + Math.Min(aRight, bRight)) / 2.0;
            }
            else if (aLeft > bRight)
            {
                r = i - 1;
            }
            else if (bLeft > aRight)
            {
                l = i + 1;
            }
        }
        return -1;
    }
}

public class TimeMap
{
    private Dictionary<string, List<Tuple<string, int>>> dict;

    public TimeMap()
    {
        dict = new Dictionary<string, List<Tuple<string, int>>>();
    }

    public void Set(string key, string value, int timestamp)
    {
        if (!dict.ContainsKey(key))
        {
            dict.Add(key, new List<Tuple<string, int>>());
        }
        dict[key].Add(new Tuple<string, int>(value, timestamp));
    }

    public string Get(string key, int timestamp)
    {
        if (!dict.ContainsKey(key))
        {
            return "";
        }
        List<Tuple<string, int>> entries = dict[key];
        int n = entries.Count;
        int l = 0;
        int r = n - 1;

        string result = "";

        while (l <= r)
        {
            int mid = l + (r - l) / 2;
            Tuple<string, int> entry = entries[mid];
            int stored_timestamp = entry.Item2;
            string stored_value = entry.Item1;
            if (stored_timestamp <= timestamp)
            {
                result = stored_value;
                l = mid + 1;
            }
            else if (stored_timestamp > timestamp)
            {
                r = mid - 1;
            }
        }
        return result;
    }
}
