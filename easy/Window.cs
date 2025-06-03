public class Window
{
    public int MaxProfit(int[] prices)
    {
        int ans = 0;
        int left = 0;
        int right = 1;
        while (right < prices.Length)
        {
            if (prices[left] < prices[right])
            {
                ans = Math.Max(prices[right] - prices[left], ans);
            }
            else
            {
                left = right;
            }
            right++;
        }
        return ans;
    }
}
