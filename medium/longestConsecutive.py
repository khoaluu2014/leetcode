from typing import List

class Solution:
    def longestConsecutive(self, nums: List[int]) -> int:
        if not nums:
            return 0

        n = len(nums)
        num_set = set(nums)
        seq = 0

        for num in nums:
            if (num - 1) not in num_set:
                length = 1
                while (num + length) in num_set:
                    length += 1
                seq = max(seq, length)
        return seq