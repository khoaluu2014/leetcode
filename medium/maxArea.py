from typing import List
class Solution:
    def maxArea(self, height: List[int]) -> int:
        maxArea = 0
        n = len(height)
        i = 0
        j = n - 1
        while(i < j):
            area = (j - i) * min(height[i], height[j])
            maxArea = max(area, maxArea)
            if height[i] < height[j]:
                i += 1
            else:
                j -= 1
        return maxArea 
        

def main():
    sol = Solution()
    height = [1,8,6,2,5,4,8,3,7]
    ans = sol.maxArea(height)
    print(ans)

if __name__ == "__main__":
    main()