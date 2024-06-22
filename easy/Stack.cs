// See https://aka.ms/new-console-template for more information
public class BinarySearch
{
    public int Search(int[] nums, int target)
    {
        int l = 0;
        int r = nums.Length - 1;
        while (l <= r)
        {
            int mid = l + (r - l) / 2; // this is preventing potential overflow
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target)
            {
                l = mid + 1;
            }
            else if (nums[mid] > target)
            {
                r = mid - 1;
            }
        }
        return -1;
    }
}
