namespace AlgorithmsNStructures.files_to_check
{
    // Simulate the version control system
    public class VersionControl
    {
        private int firstBad;

        public VersionControl(int firstBadVersion)
        {
            firstBad = firstBadVersion;
        }

        public bool IsBadVersion(int version)
        {
            return version >= firstBad;
        }
    }


    public class SortComputer
    {
        public int[] SelectionSort(int[] entryArray)
        {
            for (int i = 0; i < entryArray.Count() - 1; i++)
            {
                var smallest = i;

                for (int j = i + 1; j < entryArray.Count(); j++)
                {
                    if (entryArray[j] < entryArray[smallest])
                    {
                        smallest = j;
                    }
                }
                var temp = entryArray[i];
                entryArray[i] = entryArray[smallest];
                entryArray[smallest] = temp;
            }
            return entryArray;
        }

        public int[] InsertionSort(int[] entryArray)
        {
            for (int i = 1; i < entryArray.Length; i++)
            {
                var key = entryArray[i];
                var j = i - 1;
                while (j >= 0 && entryArray[j] > key)
                {
                    entryArray[j + 1] = entryArray[j];
                    j--;
                }
                entryArray[j + 1] = key;
            }
            return entryArray;
        }


        #region Merge Sorted Array

        /*
        AlgorithmProblem:
          - ProblemName: "Merge Sorted Array"
            - ProblemStatement: "You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively. Merge nums1 and nums2 into a single array sorted in non-decreasing order."
            - Constraints: "nums1.length == m + n, nums2.length == n, 0 <= m, n <= 200, 1 <= m + n <= 200, -10^9 <= nums1[i], nums2[j] <= 10^9."
            - Examples: 
              - Example: 
                - Input: "nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3"
                - Output: "[1,2,2,3,5,6]"
              - Example: 
                - Input: "nums1 = [1], m = 1, nums2 = [], n = 0"
                - Output: "[1]"
              - Example: 
                - Input: "nums1 = [0], m = 0, nums2 = [1], n = 1"
                - Output: "[1]"
            - Methods: 
              - Merge: 
                - Approach: "Start merging from the end. Initialize two pointers in nums1 and nums2 respectively, and compare their values to decide which one gets placed in the current last open position of nums1. Continue until all the elements of nums1 and nums2 have been checked."
                - Implementation:
        */

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int p1 = m - 1;
            int p2 = n - 1;
            int p = m + n - 1;

            while ((p1 >= 0) && (p2 >= 0))
            {
                if (nums1[p1] > nums2[p2])
                {
                    nums1[p] = nums1[p1];
                    p1--;
                }
                else
                {
                    nums1[p] = nums2[p2];
                    p2--;
                }
                p--;
            }

            // if there are still elements in nums2
            while (p2 >= 0)
            {
                nums1[p] = nums2[p2];
                p2--;
                p--;
            }
        }

        /*
                - TimeComplexity: "O(m + n), where m and n are the lengths of the two arrays. Each increment/decrement of the pointer is a constant time operation."
                - SpaceComplexity: "O(1), as the merging is done in-place without using additional space."
        */

        #endregion

        #region First Bad Version

        /*
        AlgorithmProblem:
          - ProblemName: "First Bad Version"
            - ProblemStatement: "Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad. You are given an API bool isBadVersion(version) which returns whether version is bad. Implement a function to find the first bad version."
            - Constraints: "1 <= bad <= n <= 2^31 - 1."
            - Examples: 
              - Example: 
                - Input: "n = 5, bad = 4"
                - Output: "4"
              - Example: 
                - Input: "n = 1, bad = 1"
                - Output: "1"
            - Methods: 
              - FirstBadVersion: 
                - Approach: "Use a binary search approach to minimize the number of calls to the API. Start with the range of all versions and repeatedly divide this range in half until finding the first bad version."
                - Implementation:
        */

        /* The isBadVersion API is defined in the parent class VersionControl.
              bool IsBadVersion(int version); */

        public int FirstBadVersion(int n)
        {
            var random = new Random();
            var versionControl = new VersionControl(random.Next(n));
            int start = 1;
            int end = n;
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                if (versionControl.IsBadVersion(mid))
                {
                    end = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return start;
        }

        /*
                - TimeComplexity: "O(log n), where n is the number of versions. The binary search algorithm halves the search space with each step, so it has a logarithmic time complexity."
                - SpaceComplexity: "O(1), as we only use a constant amount of space to store our variables."
        */

        #endregion
    }
}
