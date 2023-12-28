from typing import List
import heapq
class Solution:
    def topKFrequent(self, nums: List[int], k: int) -> List[int]:
        map = {}
        ans = []
        if len(nums) == 0:
            return []
        for num in nums:
            map[num] = map.get(num, 0) + 1
        
        
        #ans = heapq.nlargest(k, map, key=lambda freq : map[freq])
        ans = sorted(map, key = lambda freq: map[freq], reverse = True)
        return ans[:k]

def main():
    nums = [1,1,1,2,2,3] 
    k = 2
    sol = Solution()
    answer = sol.topKFrequent(nums, k)
    print(answer)

if __name__ == "__main__":
    main()
    