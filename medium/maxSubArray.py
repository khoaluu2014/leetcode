from typing import List
class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        cur_max = nums[0]
        cur_sum = 0

        for n in nums:
            if cur_sum < 0:
                cur_sum = 0
            cur_sum += n
            cur_max = max(cur_max, cur_sum)

        return cur_max

