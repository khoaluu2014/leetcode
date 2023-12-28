from typing import List

class Solution:
    def search(self, nums: List[int], target: int) -> int:
        n = len(nums)
        left = 0
        right = n - 1
        while left <= right:
            mid = (left + right) // 2
            if nums[left] == target:
                return left
            if nums[right] == target:
                return right
            if nums[mid] == target:
                return mid
            if nums[left] <= nums[mid]:
                if target > nums[mid] or target < nums[left]:
                    left = mid + 1
                elif target <= nums[mid] and target >= nums[left]:
                    right = mid - 1
            elif nums[left] > nums[mid]:
                if target < nums[mid] or target > nums[right]:
                    right = mid - 1
                elif target >= nums[mid] and target <= nums[right]:
                    left = left + 1
        return -1

def main():
    nums = [4,5,6,7,0,1,2]
    target = 4
    sol = Solution()
    print(sol.search(nums, target))

if __name__ == "__main__":
    main()