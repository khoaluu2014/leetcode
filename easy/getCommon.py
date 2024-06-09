from typing import List
import sys
class Solution:
    def getCommon(self, nums1: List[int], nums2: List[int]) -> int:
        map = set()
        res = sys.maxsize
        for num in nums1:
            map.add(num)

        for num in nums2:
            if num in map:
                res = min(res, num)

        if res == sys.maxsize:
            return -1
        return res
