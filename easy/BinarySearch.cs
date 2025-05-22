public class BinarySearch
{
    public int Search(int[] nums, int target)
    {
        int n = nums.Length;
        int l = 0;
        int r = n;

        while (l < r)
        {
            int mid = (l + r) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                r = mid;
            }
            else if (nums[mid] < target)
            {
                l = mid + 1;
            }
        }
        return -1;
    }

    public bool SearchMatrix(int[][] matrix, int target)
    {
        int n = matrix.Length;
        int m = matrix[0].Length;

        int l = 0;
        int r = n * m;

        while (l < r)
        {
            int mid = l + (r - l) / 2;
            int row = mid / m;
            int col = mid % m;

            int num = matrix[row][col];
            if (num == target)
            {
                return true;
            }
            else if (num > target)
            {
                r = mid;
            }
            else if (num < target)
            {
                l = mid + 1;
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
            int mid = (l + r) / 2;
            int totalTime = 0;
            foreach (int p in piles)
            {
                totalTime += (int)Math.Ceiling((double)p / mid);
            }
            if (totalTime <= h)
            {
                res = mid;
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }
        return res;
    }

    public int FindMin(int[] nums)
    {
        int n = nums.Length;
        int l = 0;
        int r = n - 1;

        if (nums[l] < nums[r])
        {
            return nums[l];
        }
        while (l < r)
        {
            int mid = l + (r - l) / 2;
            if (nums[mid] > nums[r])
            {
                l = mid + 1;
            }
            else if (nums[mid] <= nums[r])
            {
                r = mid;
            }
        }
        return nums[l];
    }

    public int SearchRotated(int[] nums, int target)
    {
        int n = nums.Length;
        int l = 0;
        int r = n - 1;
        while (l <= r)
        {
            int mid = l + (r - l) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            if (nums[l] <= nums[mid])
            {
                if (target >= nums[l] && target < nums[mid])
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            else
            {
                if (target > mid && target <= nums[r])
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
        }
        return -1;
    }
}
