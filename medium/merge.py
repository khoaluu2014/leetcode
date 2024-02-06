from typing import List
class Solution:
    def merge(self, intervals: List[List[int]]) -> List[List[int]]:

        intervals.sort(key = lambda i : i[0])
        res = [intervals[0]]

        for interval in intervals[1:]:
            if res[-1][1] >= interval[0]:
                res[-1][1] = max(res[-1][1], interval[1])
            elif res[-1][1] < interval[0]:
                res.append(interval)

        return res

sol = Solution()

intervals = [[1,4], [0,4]]

print(sol.merge(intervals))
