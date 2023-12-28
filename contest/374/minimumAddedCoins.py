from typing import List

class Solution:
    def minimumAddedCoins(self, coins: List[int], target: int) -> int:
        coins.sort()
        current_max = 0
        count = 0
        for coin in coins:
            while coin > current_max + 1 and current_max < target:
                count += 1
                current_max += current_max + 1
            current_max += coin

            if current_max >= target:
                break
        while current_max < target:
            count += 1
            current_max += current_max + 1
        return count