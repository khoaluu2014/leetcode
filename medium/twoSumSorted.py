from typing import List

class Solution:
    def twoSum(self, numbers: List[int], target: int) -> List[int]:
        n = len(numbers) 
        i = 0
        j = n - 1
        while(j > -1):
            complement = target - numbers[j]
            print(complement)
            print(f"i: {numbers[i]}, j {numbers[j]}")
            if complement == numbers[i]:
                return [i+1, j+1]
            elif (complement > numbers[i]) and (i < n):
                i += 1
            elif (complement <  numbers[i]) and (j > -1):
                j -= 1

def main():
    sol = Solution()
    numbers = [5, 25, 75]
    target = 100
    ans = sol.twoSum(numbers, 100)
    print(ans)

if __name__ == "__main__":
    main()