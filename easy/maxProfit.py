from typing import List
class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        min_price = prices[0]
        max_profit = 0
        n = len(prices) - 1
        i = 0
        while i < n:
            i += 1
            min_price = min(min_price, prices[i])
            max_profit = max(max_profit, prices[i] - min_price)
        
        return max_profit
            

def main():
    sol = Solution()
    prices = [7,1,5,3,6,4]
    ans = sol.maxProfit(prices)
    print(ans)

if __name__ == "__main__":
    main()
