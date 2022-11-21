namespace SlidingWindow;

public static class StockPrices
{
    public static int MaxProfit(int[] prices) {
        var minPricePointer = 0;
        var maxProfitPointer = 1;
        var maxProfit = 0;
        
        while (maxProfitPointer < prices.Length) 
        {
            if (prices[maxProfitPointer] > prices[minPricePointer]) {
                var profit = prices[maxProfitPointer] - prices[minPricePointer];
                maxProfit = Math.Max(maxProfit, profit);
            }
            else
            {
                minPricePointer = maxProfitPointer;
            }
            
            maxProfitPointer++;
        }
        
        return maxProfit;
    }
}