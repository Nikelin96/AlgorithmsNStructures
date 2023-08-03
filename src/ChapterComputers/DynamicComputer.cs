namespace AlgorithmsNStructures.ChapterComputers
{
    internal class DynamicComputer
    {
        #region Climbing Stairs 
        /*
        AlgorithmProblem:
          - Region: "ClimbingStairs"
          - ProblemName: "Climbing Stairs"
            - ProblemStatement: "Given an integer n, return the number of distinct ways to climb a staircase of n steps. You can climb either 1 or 2 steps at a time."
            - Constraints: "1 <= n <= 45."
            - Examples: 
              - Example: 
                - Input: "2"
                - Output: "2"
              - Example: 
                - Input: "3"
                - Output: "3"
            - Methods: 
              - ClimbStairsMethod: 
                - Approach: "The approach is based on dynamic programming where the total number of ways to reach the nth step is the sum of ways to reach the (n-1)th step and the (n-2)th step."
        */

        public int ClimbStairsMethod(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;

            int one_step_before = 2;
            int two_steps_before = 1;
            int all_ways = 0;

            for (int i = 2; i < n; i++)
            {
                all_ways = one_step_before + two_steps_before;
                two_steps_before = one_step_before;
                one_step_before = all_ways;
            }
            return all_ways;
        }

        /*
                - TimeComplexity: "O(n), where n is the given input. The function iterates through each step once, therefore the time complexity is linear."
                - SpaceComplexity: "O(1), we're using a constant amount of space that does not scale with input size."
        */

        #endregion


        #region  Best Time to Buy and Sell Stock

        /*
        AlgorithmProblem:
          - Region: "StockProfitRegion"
          - ProblemName: "MaxProfit"
            - ProblemStatement: "Given an array of prices, where prices[i] is the price of a given stock on the ith day, return the maximum profit you can achieve from this transaction by choosing a single day to buy one stock and choosing a different day in the future to sell that stock."
            - Constraints: "1 <= prices.length <= 105, 0 <= prices[i] <= 104."
            - Examples: 
              - Example: 
                - Input: "[7,1,5,3,6,4]"
                - Output: "5"
              - Example: 
                - Input: "[7,6,4,3,1]"
                - Output: "0"
            - Methods: 
              - MaxProfit: 
                - Approach: "Maintain two variables - minprice and maxprofit. Traverse the array, updating minprice as the minimum value of minprice and prices[i], and update maxprofit as the maximum of maxprofit and prices[i]-minprice."
        */

        public int MaxProfit(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                    minPrice = prices[i];
                else if (prices[i] - minPrice > maxProfit)
                    maxProfit = prices[i] - minPrice;
            }
            return maxProfit;
        }

        /*
                - TimeComplexity: "O(n), where n is the length of the array. This is because we have a single loop that traverses through the array once."
                - SpaceComplexity: "O(1), we're not using additional space that scales with input size. We're only using a few variables for storing intermediate results."
        */

        #endregion


    }
}
