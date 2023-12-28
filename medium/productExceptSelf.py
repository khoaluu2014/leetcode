from typing import List

class Solution:
    def productExceptSelf(self, nums: List[int]) -> List[int]:
        n = len(nums)
        ans = [0] * n
        prefix = 1
        for i in range(n):
            ans[i] = prefix
            prefix = prefix * nums[i]
        #[1, 1, 2, 6]
        suffix = 1
        for i in range(n-1, -1, -1):
            ans[i] = ans[i] * suffix
            suffix = suffix * nums[i]
        return ans


def main():
    sol = Solution()
    nums = [1,2,3,4]
    ans = sol.productExceptSelf(nums)
    print(ans)

if __name__ == "__main__":
    main()