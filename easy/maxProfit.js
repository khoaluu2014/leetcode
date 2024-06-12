class Solution {
  maxProfit(prices) {
    let ans = 0;
    let minPrice = prices[0];
    for (let i = 0; i < prices.length; i++) {
      minPrice = Math.min(minPrice, prices[i]);
      ans = Math.max(ans, prices[i] - minPrice);
    }

    return ans;
  }
}
