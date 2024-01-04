from typing import List
class Solution:
    def maxProduct(self, nums: List[int]) -> int:
        if not nums:
            return 0
        
        res = max_product = min_product = nums[0]
        
        for i in range(1, len(nums)):
            temp = max(nums[i], max_product * nums[i], min_product * nums[i])
            min_product = min(nums[i], max_product * nums[i], min_product * nums[i])

            max_product = temp
            res = max(res, max_product)

        return res

