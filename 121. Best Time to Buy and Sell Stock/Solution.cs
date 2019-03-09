public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Length < 1){
            return 0;
        }
        int minPrice = prices[0];
        int maxProfit = 0;
        
        for(int i = 0; i < prices.Length; i++)
        {
            if(prices[i] < minPrice)
            {
                minPrice = prices[i];
            }
            else if(prices[i] - minPrice > maxProfit)
            {
                maxProfit = prices[i] - minPrice;
            }
        }
        
        return maxProfit;
    }
}