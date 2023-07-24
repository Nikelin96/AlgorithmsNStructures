namespace AlgorithmsNStructures.ChapterComputers
{
    internal class ArrayComputer
    {

        #region Remove Duplicates

        /*
        AlgorithmProblem:
          - ProblemName: "Remove Duplicates from Sorted Array"
            - ProblemStatement: "Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place 
                                 such that each unique element appears only once. The relative order of the elements should 
                                 be kept the same. Then return the number of unique elements in nums."
            - Constraints: "1 <= nums.length <= 3 * 104
                            -100 <= nums[i] <= 100
                            nums is sorted in non-decreasing order."
            - Examples: 
              - Example: 
                - Input: "[1,1,2]"
                - Output: "2, nums = [1,2,_]"
              - Example: 
                - Input: "[0,0,1,1,1,2,2,3,3,4]"
                - Output: "5, nums = [0,1,2,3,4,_,_,_,_,_]"
            - Methods: 
              - RemoveDuplicatesMethod: 
                - Approach: "Two-pointer technique where one pointer (i) holds the index of the next unique element and 
                             the other pointer (j) scans through the array comparing elements."
                - Implementation:
        */

        public int RemoveDuplicatesMethod(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        /*
                - TimeComplexity: "O(n), where n is the length of nums. Each of i and j traverses at most n steps."
                - SpaceComplexity: "O(1), No additional space is allocated."
        */
        #endregion

        #region Best Time Buy Sell Stock 

        /*
        AlgorithmProblem:
          - ProblemName: "Best Time to Buy and Sell Stock II"
            - ProblemStatement: "Given an integer array prices where prices[i] is the price of a given stock on the ith day.
                                 On each day, you may decide to buy and/or sell the stock. You can only hold at most one share 
                                 of the stock at any time. However, you can buy it then immediately sell it on the same day. 
                                 Find and return the maximum profit you can achieve."
            - Constraints: "1 <= prices.length <= 3 * 104
                            0 <= prices[i] <= 104"
            - Examples: 
              - Example: 
                - Input: "[7,1,5,3,6,4]"
                - Output: "7"
              - Example: 
                - Input: "[1,2,3,4,5]"
                - Output: "4"
              - Example: 
                - Input: "[7,6,4,3,1]"
                - Output: "0"
            - Methods: 
              - MaxProfitMethod: 
                - Approach: "One pass through the prices array. If the current price is greater than the previous price, 
                             add the difference to the maxProfit. This effectively accumulates all increases in price."
                - Implementation:
        */

        public int MaxProfitMethod(int[] prices)
        {
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }
            return maxProfit;
        }

        /*
                - TimeComplexity: "O(n), where n is the length of prices. We traverse the prices array once."
                - SpaceComplexity: "O(1), No additional space is allocated."
        */
        #endregion

        #region Rotate Array

        /*
        AlgorithmProblem:
          - ProblemName: "Rotate Array"
            - ProblemStatement: "Given an integer array nums, rotate the array to the right by k steps, where k is non-negative."
            - Constraints: "1 <= nums.length <= 105
                            -231 <= nums[i] <= 231 - 1
                            0 <= k <= 105"
            - Examples: 
              - Example: 
                - Input: "[1,2,3,4,5,6,7], 3"
                - Output: "[5,6,7,1,2,3,4]"
              - Example: 
                - Input: "[-1,-100,3,99], 2"
                - Output: "[3,99,-1,-100]"
            - Methods: 
              - RotateMethod: 
                - Approach: "First, reduce the number of rotations. We just need to make k % nums.length rotations.
                             Then, reverse the whole array, reverse the first k numbers, and reverse the rest."
                - Implementation:
        */

        public void RotateMethod(int[] nums, int k)
        {
            k %= nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }

        private void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        /*
                - TimeComplexity: "O(n), where n is the length of the nums array. We do a constant amount of work for each element."
                - SpaceComplexity: "O(1), No extra space is used."
        */
        #endregion

        #region Contains Duplicate

        /*
        AlgorithmProblem:
          - ProblemName: "Contains Duplicate"
            - ProblemStatement: "Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct."
            - Constraints: "1 <= nums.length <= 105
                            -109 <= nums[i] <= 109"
            - Examples: 
              - Example: 
                - Input: "[1,2,3,1]"
                - Output: "true"
              - Example: 
                - Input: "[1,2,3,4]"
                - Output: "false"
              - Example: 
                - Input: "[1,1,1,3,3,4,3,2,4,2]"
                - Output: "true"
            - Methods: 
              - ContainsDuplicateMethod: 
                - Approach: "Using HashSet to keep track of seen numbers. If a number is already in the HashSet, return true."
                - Implementation:
        */

        public bool ContainsDuplicateMethod(int[] nums)
        {
            HashSet<int> seen = new HashSet<int>();
            foreach (var num in nums)
            {
                if (seen.Contains(num)) return true;
                seen.Add(num);
            }
            return false;
        }

        /*
                - TimeComplexity: "O(n), where n is the number of elements in the array. We are scanning the array only once."
                - SpaceComplexity: "O(n), as we are using a HashSet to store unique elements from the array."
        */

        #endregion

        #region Single Number

        /*
        AlgorithmProblem:
          - ProblemName: "Single Number"
            - ProblemStatement: "Given a non-empty array of integers nums, every element appears twice except for one. Find that single one."
            - Constraints: "1 <= nums.length <= 3 * 104
                            -3 * 104 <= nums[i] <= 3 * 104
                            Each element in the array appears twice except for one element which appears only once."
            - Examples: 
              - Example: 
                - Input: "[2,2,1]"
                - Output: "1"
              - Example: 
                - Input: "[4,1,2,1,2]"
                - Output: "4"
              - Example: 
                - Input: "[1]"
                - Output: "1"
            - Methods: 
              - SingleNumberMethod: 
                - Approach: "Use XOR operation to find the single number. The property of XOR is that it returns 0 if we take XOR of two same numbers. Finally, we get the number that appears once."
                - Implementation:
        */

        public int SingleNumberMethod(int[] nums)
        {
            int singleNumber = 0;
            foreach (var num in nums)
            {
                singleNumber ^= num;
            }
            return singleNumber;
        }

        /*
                - TimeComplexity: "O(n), where n is the number of elements in the array. We are scanning the array only once."
                - SpaceComplexity: "O(1), as we are not using any additional space that scales with input size."
        */

        #endregion

        #region Intersection Arrays

        /*
        AlgorithmProblem:
          - ProblemName: "Intersection of Two Arrays II"
            - ProblemStatement: "Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result must appear as many times as it shows in both arrays and you may return the result in any order."
            - Constraints: "1 <= nums1.length, nums2.length <= 1000
                            0 <= nums1[i], nums2[i] <= 1000"
            - Examples: 
              - Example: 
                - Input: "nums1 = [1,2,2,1], nums2 = [2,2]"
                - Output: "[2,2]"
              - Example: 
                - Input: "nums1 = [4,9,5], nums2 = [9,4,9,8,4]"
                - Output: "[4,9]"
            - Methods: 
              - IntersectionMethod: 
                - Approach: "Use a Dictionary to record the count of each number in the first array. Then iterate through the second array and decrease the count in the Dictionary for each number encountered. Add the number to the result if the count in the Dictionary is more than zero."
                - Implementation:
        */

        public int[] IntersectionMethod(int[] nums1, int[] nums2)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in nums1)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict[num] = 1;
            }

            var res = new List<int>();
            foreach (var num in nums2)
            {
                if (dict.ContainsKey(num) && dict[num] > 0)
                {
                    res.Add(num);
                    dict[num]--;
                }
            }

            return res.ToArray();
        }

        /*
                - TimeComplexity: "O(n + m), where n and m are the lengths of the two arrays. We first iterate over nums1 and then nums2."
                - SpaceComplexity: "O(n), as we create a dictionary to store the counts of numbers in nums1."
        */

        #endregion

        #region Plus One 

        /*
        AlgorithmProblem:
          - ProblemName: "Plus One"
            - ProblemStatement: "You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer. The digits are ordered from most significant to least significant in left-to-right order. The large integer does not contain any leading 0's. Increment the large integer by one and return the resulting array of digits."
            - Constraints: "1 <= digits.length <= 100
                            0 <= digits[i] <= 9
                            digits does not contain any leading 0's."
            - Examples: 
              - Example: 
                - Input: "digits = [1,2,3]"
                - Output: "[1,2,4]"
              - Example: 
                - Input: "digits = [4,3,2,1]"
                - Output: "[4,3,2,2]"
              - Example: 
                - Input: "digits = [9]"
                - Output: "[1,0]"
            - Methods: 
              - PlusOneMethod: 
                - Approach: "Starting from the last digit, increment it by 1. If it becomes 10, set it to 0 and carry the 1 over to the next digit. If there is still a carry after going through all digits, prepend a 1 to the array."
                - Implementation:
        */

        public int[] PlusOneMethod(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }

            var result = new int[digits.Length + 1];
            result[0] = 1;
            return result;
        }

        /*
                - TimeComplexity: "O(n), where n is the length of the array. In the worst case, we need to iterate through the whole array."
                - SpaceComplexity: "O(n), where n is the length of the array. In the worst case, when all digits are 9, we need to create a new array that has one more digit."
        */

        #endregion

        #region Move Zeroes

        /*
        AlgorithmProblem:
          - ProblemName: "Move Zeroes"
            - ProblemStatement: "Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements. You must do this in-place without making a copy of the array."
            - Constraints: "1 <= nums.length <= 10^4
                            -2^31 <= nums[i] <= 2^31 - 1"
            - Examples: 
              - Example: 
                - Input: "nums = [0,1,0,3,12]"
                - Output: "[1,3,12,0,0]"
              - Example: 
                - Input: "nums = [0]"
                - Output: "[0]"
            - Methods: 
              - MoveZeroesMethod: 
                - Approach: "Keep a pointer for the last non-zero element found so far. When encountering a non-zero element, swap it with the first zero element (if one is found)."
                - Implementation:
        */

        public void MoveZeroesMethod(int[] nums)
        {
            int lastNonZeroFoundAt = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    int temp = nums[i];
                    nums[i] = nums[lastNonZeroFoundAt];
                    nums[lastNonZeroFoundAt++] = temp;
                }
            }
        }

        /*
                - TimeComplexity: "O(n), where n is the length of the array. The entire array needs to be iterated over once."
                - SpaceComplexity: "O(1), as we are not using any extra space that scales with input size."
        */

        #endregion

        #region Two Sum

        /*
        AlgorithmProblem:
          - Region: "TwoSumRegion"
          - ProblemName: "Two Sum"
            - ProblemStatement: "Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target. You may assume that each input would have exactly one solution, and you may not use the same element twice. You can return the answer in any order."
            - Constraints: "2 <= nums.length <= 10^4
                            -10^9 <= nums[i] <= 10^9
                            -10^9 <= target <= 10^9
                            Only one valid answer exists."
            - Examples: 
              - Example: 
                - Input: "nums = [2,7,11,15], target = 9"
                - Output: "[0,1]"
              - Example: 
                - Input: "nums = [3,2,4], target = 6"
                - Output: "[1,2]"
              - Example: 
                - Input: "nums = [3,3], target = 6"
                - Output: "[0,1]"
            - Methods: 
              - TwoSumMethod: 
                - Approach: "Use a hash map to store the numbers and their indices. While iterating over the array, check if the complement of the current number (target - current number) exists in the hash map. If it exists, return the indices. Otherwise, add the current number and its index to the hash map."
                - Implementation:
        */

        public int[] TwoSumMethod(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    return new int[] { dict[complement], i };
                }

                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }

            return new int[] { -1, -1 }; // return a default value when no solution found
        }

        /*
                - TimeComplexity: "O(n), where n is the length of the array. In the worst-case scenario, we have to iterate over the entire array once."
                - SpaceComplexity: "O(n), in the worst-case scenario, all elements will be stored in the hash map."

        This solution makes use of a dictionary (hash map) to reduce the time complexity from O(n^2) to O(n). It keeps track of each number and its index, and checks whether the complement of the current number is already in the dictionary. If the complement is found, it returns the indices of the two numbers. If not, it adds the current number and its index to the dictionary. The time complexity is O(n), as in the worst case, the entire array is iterated over once. The space complexity is also O(n), as in the worst case, all elements are stored in the dictionary.

        */

        #endregion

        #region Valid Sudoku Region

        /*
        AlgorithmProblem:
          - ProblemName: "Valid Sudoku"
            - ProblemStatement: "Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules: Each row must contain the digits 1-9 without repetition. Each column must contain the digits 1-9 without repetition. Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition."
            - Constraints: "board.length == 9
                            board[i].length == 9
                            board[i][j] is a digit 1-9 or '.'."
            - Examples: 
              - Example: 
                - Input: "board = [["5","3",".",".","7",".",".",".","."], ...]"
                - Output: "true"
              - Example: 
                - Input: "board = [["8","3",".",".","7",".",".",".","."], ...]"
                - Output: "false"
            - Methods: 
              - IsValidSudoku: 
                - Approach: "Use three arrays to store the presence of a digit in a row, a column, and a box. Iterate over each cell of the board, if a cell is not empty, check whether the current digit has appeared before in its corresponding row, column, or box. If it has, return false, otherwise, mark it as appeared."
                - Implementation:
        */

        public bool IsValidSudoku(char[][] board)
        {
            bool[][] rows = new bool[9][];
            bool[][] cols = new bool[9][];
            bool[][] boxes = new bool[9][];

            for (int i = 0; i < 9; i++)
            {
                rows[i] = new bool[9];
                cols[i] = new bool[9];
                boxes[i] = new bool[9];
            }

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row][col] == '.')
                    {
                        continue;
                    }

                    int val = board[row][col] - '1';
                    int boxIndex = row / 3 * 3 + col / 3;

                    if (rows[row][val] || cols[col][val] || boxes[boxIndex][val])
                    {
                        return false;
                    }

                    rows[row][val] = true;
                    cols[col][val] = true;
                    boxes[boxIndex][val] = true;
                }
            }

            return true;
        }

        /*
                - TimeComplexity: "O(1), as the size of the Sudoku board is fixed (9x9), the time complexity is constant."
                - SpaceComplexity: "O(1), the space required is also constant because only a fixed amount of space is needed to store the digits in the Sudoku board."
        */

        #endregion

        #region Rotate Image

        /*
        AlgorithmProblem:
          - Region: "RotateImageRegion"
          - ProblemName: "Rotate Image"
            - ProblemStatement: "Given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise) in-place."
            - Constraints: "n == matrix.length == matrix[i].length
                            1 <= n <= 20
                            -1000 <= matrix[i][j] <= 1000"
            - Examples: 
              - Example: 
                - Input: "matrix = [[1,2,3],[4,5,6],[7,8,9]]"
                - Output: "[[7,4,1],[8,5,2],[9,6,3]]"
              - Example: 
                - Input: "matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]"
                - Output: "[[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]"
            - Methods: 
              - Rotate: 
                - Approach: "First transpose the matrix (swap rows and columns), and then for each row, reverse the elements to get the rotated image."
                - Implementation:
        */

        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;

            // Transpose matrix
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    int temp = matrix[j][i];
                    matrix[j][i] = matrix[i][j];
                    matrix[i][j] = temp;
                }
            }

            // Reverse each row
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[i][n - j - 1];
                    matrix[i][n - j - 1] = temp;
                }
            }
        }

        /*
                - TimeComplexity: "O(n^2), where n is the side length of the matrix. This is because we perform a constant operation for each element in the 2D matrix."
                - SpaceComplexity: "O(1), since we modify the matrix in place without using additional space."
        */

        #endregion

    }
}