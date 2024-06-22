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
}
