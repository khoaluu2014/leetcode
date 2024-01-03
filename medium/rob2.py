from typing import List
class Solution:
    def rob(self, nums: List[int]) -> int:
        l = len(nums)
        def helper(q,r):
            rob1, rob2 = 0, 0

            for n in range(q, r):
                temp = max(nums[n] + rob1, rob2)
                rob1 = rob2
                rob2 = temp
            return rob2
        return max(helper(0, l-1), helper(1, l), nums[0])

