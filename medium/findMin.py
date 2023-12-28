from typing import List

class Solution:
    def findMin(self, nums: List[int]) -> int:
        n = len(nums)
        left = 0
        right = n - 1
        res = nums[0]
        while left <= right:
            if nums[left] < nums[right]:
                return min(res, nums[left])
            
            mid = (left + right) // 2
            res = min(nums[mid], res)
            #[1, 2, 4, 5, 6, 7, 0]
            if nums[mid] >= nums[left]:
                left = mid + 1
            elif nums[mid] < nums[left]:
                right = mid - 1
        return res

def main():
    nums = [4, 5, 1, 2, 3]
    sol = Solution()
    print(sol.findMin(nums))
if __name__ == "__main__":
    main()