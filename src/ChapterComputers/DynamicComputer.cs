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

    }
}
