from typing import List

class Solution:
    def trap(self, height: List[int]) -> int:
        ans = 0
        n = len(height)
        left = 0
        right = n - 1
        left_max = left
        right_max = right
        while left < right:
            if height[left] <= height[right]:
                if height[left_max] < height[left]:
                    left_max = left
                elif height[left_max] > height[left]:
                    ans += height[left_max] - height[left]
                left += 1
            elif height[left] > height[right]:
                if height[right_max] < height[right]:
                    right_max = right
                elif height[right_max] > height[right]:
                    ans += height[right_max] - height[right]
                right -= 1
        return ans


def main():
    sol = Solution()
    height = [4,2,3]
    ans = sol.trap(height)
    print(ans)

if __name__ == "__main__":
    main()