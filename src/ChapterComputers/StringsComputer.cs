using System.Text;

namespace AlgorithmsNStructures.ChapterComputers
{
    internal class StringsComputer
    {
        #region Reverse String

        /*
        AlgorithmProblem:
          - ProblemName: "Reverse String"
            - ProblemStatement: "Write a function that reverses a string. The input string is given as an array of characters s. You must do this by modifying the input array in-place with O(1) extra memory."
            - Constraints: 
              - "1 <= s.length <= 105"
              - "s[i] is a printable ascii character."
            - Examples: 
              - Example: 
                - Input: "s = ['h','e','l','l','o']"
                - Output: "['o','l','l','e','h']"
              - Example: 
                - Input: "s = ['H','a','n','n','a','H']"
                - Output: "['h','a','n','n','a','H']"
            - Methods: 
              - ReverseString_InPlace: 
                - Approach: 
                  "Two pointers technique is used where one pointer starts from the beginning while the other pointer starts from the end. Swap the elements at both pointers. Move the start pointer one step towards the end and the end pointer one step towards the start. Continue this process until the start pointer becomes greater than or equal to the end pointer."
        */

        public void ReverseString_InPlace(char[] s)
        {
            int start = 0, end = s.Length - 1;
            char temp;

            while (start < end)
            {
                temp = s[start];
                s[start] = s[end];
                s[end] = temp;

                start++;
                end--;
            }
        }

        /*
                - TimeComplexity: "O(n), where n is the size of the array. Each element is swapped once."
                - SpaceComplexity: "O(1), no additional space is used other than the input array."
        */

        #endregion


        #region Reverse Integer

        /*
        AlgorithmProblem:
          - ProblemName: "Reverse Integer"
            - ProblemStatement: "Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0."
            - Constraints: 
              - "-231 <= x <= 231 - 1"
            - Examples: 
              - Example: 
                - Input: "x = 123"
                - Output: "321"
              - Example: 
                - Input: "x = -123"
                - Output: "-321"
              - Example: 
                - Input: "x = 120"
                - Output: "21"
            - Methods: 
              - ReverseInteger: 
                - Approach: 
                  "Iteratively pop the last digit from the original number and push it to the reverse number. Also, check for overflow/underflow during the process."
        */

        public int ReverseInteger(int x)
        {
            long rev = 0;
            while (x != 0)
            {
                rev = rev * 10 + x % 10;
                x /= 10;

                if (rev > int.MaxValue || rev < int.MinValue)
                {
                    return 0;
                }
            }

            return (int)rev;
        }

        /*
                - TimeComplexity: "O(log(x)), where x is the size of the integer. Since we are dividing the number by 10 in each iteration, the time complexity is logarithmic."
                - SpaceComplexity: "O(1), no additional space is used other than the input and output integers."
        */

        #endregion

        #region First Unique Character in a String

        /*
        AlgorithmProblem:
          - ProblemName: "First Unique Character in a String"
            - ProblemStatement: "Given a string s, find the first non-repeating character in it and return its index. If it does not exist, return -1."
            - Constraints: 
              - "1 <= s.length <= 105"
              - "s consists of only lowercase English letters."
            - Examples: 
              - Example: 
                - Input: "s = \"leetcode\""
                - Output: "0"
              - Example: 
                - Input: "s = \"loveleetcode\""
                - Output: "2"
              - Example: 
                - Input: "s = \"aabb\""
                - Output: "-1"
            - Methods: 
              - FirstUniqChar: 
                - Approach: 
                  "Traverse the string once to create a frequency count of each character. 
                   Then traverse the string again to find the first character with a count of 1."
        */

        public int FirstUniqChar(string s)
        {
            int[] letters = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                letters[s[i] - 'a']++;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (letters[s[i] - 'a'] == 1)
                {
                    return i;
                }
            }

            return -1;
        }

        /*
                - TimeComplexity: "O(n), where n is the length of the string. We need to traverse the string twice."
                - SpaceComplexity: "O(1), as the space used does not grow with the size of the input string, but is constant (26 letters of the alphabet)."
        */

        #endregion


        #region Valid Anagram

        /*
        AlgorithmProblem:
          - ProblemName: "Valid Anagram"
            - ProblemStatement: "Given two strings s and t, return true if t is an anagram of s, and false otherwise."
            - Constraints: 
              - "1 <= s.length, t.length <= 5 * 104"
              - "s and t consist of lowercase English letters."
            - Examples: 
              - Example: 
                - Input: "s = \"anagram\", t = \"nagaram\""
                - Output: "true"
              - Example: 
                - Input: "s = \"rat\", t = \"car\""
                - Output: "false"
            - Methods: 
              - IsAnagram: 
                - Approach: 
                  "Sort both the strings and then compare if both the sorted strings are equal. 
                   If they are equal, then they are anagrams of each other."
        */

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            char[] sArray = s.ToCharArray();
            char[] tArray = t.ToCharArray();

            Array.Sort(sArray);
            Array.Sort(tArray);

            return new string(sArray) == new string(tArray);
        }

        /*
                - TimeComplexity: "O(n log n), where n is the length of the input string. The dominating time complexity is due to the sort function."
                - SpaceComplexity: "O(1), as the space used does not grow with the size of the input string."
        */

        #endregion


        #region Valid Palindrome
        /*
        AlgorithmProblem:
          - ProblemName: 
            - ProblemStatement: "A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Given a string s, return true if it is a palindrome, or false otherwise."
            - Constraints: "1 <= s.length <= 2 * 10^5. s consists only of printable ASCII characters."
            - Examples: 
              - Example: 
                - Input: "A man, a plan, a canal: Panama"
                - Output: "True"
              - Example: 
                - Input: "race a car"
                - Output: "False"
              - Example: 
                - Input: " "
                - Output: "True"
            - Methods: 
              - MethodName_PostfixIfApplicable: IsPalindrome
                - Approach: "The function initializes two pointers, one at the start of the string and the other at the end. It then enters a loop that continues until the two pointers meet. In each iteration, the function advances the start pointer if the current character is not alphanumeric and retreats the end pointer if the current character is not alphanumeric. If both characters are alphanumeric, it checks whether they are the same. If they are not the same, it returns false. If the loop completes without finding any unequal characters, it returns true."
        */

        public bool IsPalindrome(string s)
        {
            // Initialize pointers
            int start = 0, end = s.Length - 1;

            while (start < end)
            {
                // Skip non-alphanumeric characters
                if (!Char.IsLetterOrDigit(s[start]))
                {
                    start++;
                }
                else if (!Char.IsLetterOrDigit(s[end]))
                {
                    end--;
                }
                else
                {
                    // Check if characters are the same
                    if (Char.ToLower(s[start]) != Char.ToLower(s[end]))
                    {
                        return false;
                    }
                    start++;
                    end--;
                }
            }

            return true;
        }
        /*
                - TimeComplexity: "The time complexity is O(n), where n is the length of the string. In the worst-case scenario, the function has to scan through all characters of the string."
                - SpaceComplexity: "The space complexity is O(1), as only a constant amount of space is used, regardless of the input string size."
        */
        #endregion


        #region String to Integer (atoi)
        /*
        AlgorithmProblem:
          - ProblemName:
            - String to Integer (atoi)
            - ProblemStatement: "Implement a method that converts a string to a 32-bit signed integer (similar to C/C++'s atoi function). The string can include leading or trailing whitespace, a leading '-' or '+', and any characters after the integer part should be ignored."
            - Constraints: "The input string's length is between 0 and 200. The input string consists of English letters (lower-case and upper-case), digits (0-9), ' ', '+', '-', and '.'."
            - Examples: 
              - Example: 
                - Input: "42"
                - Output: 42
              - Example: 
                - Input: "   -42"
                - Output: -42
              - Example: 
                - Input: "4193 with words"
                - Output: 4193
            - Methods: 
              - MethodName_MyAtoi: 
                - Approach: "The function skips any leading whitespace, checks for a leading '-' or '+', reads in the digits until a non-digit character is encountered or the end of the string, and converts the string of digits to an integer. The sign of the result is determined by the leading '-' or '+' (the result is positive if neither is present). If the integer is outside the range of a 32-bit signed integer, it is clamped to the range."
        */

        public int MyAtoi(string str)
        {
            // Initial check
            if (string.IsNullOrEmpty(str)) return 0;

            // Initialize variables
            int sign = 1, i = 0, n = str.Length;
            int result = 0;

            // Skip leading spaces
            while (i < n && str[i] == ' ') i++;

            // Check for the sign if present
            if (i < n && (str[i] == '+' || str[i] == '-'))
            {
                sign = (str[i++] == '-') ? -1 : 1;
            }

            // Extract digits and ignore any non-digit character
            while (i < n && char.IsDigit(str[i]))
            {
                // Check for overflow
                if (result > int.MaxValue / 10 ||
                    (result == int.MaxValue / 10 && str[i] - '0' > int.MaxValue % 10))
                {
                    return (sign == 1) ? int.MaxValue : int.MinValue;
                }

                // Add digit to result
                result = result * 10 + (str[i++] - '0');
            }

            return result * sign;
        }
        /*
        - TimeComplexity: "The time complexity is O(n), where n is the length of the string. In the worst-case scenario, the function has to scan through all characters of the string."
        - SpaceComplexity: "The space complexity is O(1), as only a constant amount of space is used, regardless of the input string size."
        */
        #endregion


        #region Implement strStr()

        /*
        AlgorithmProblem:
          - ProblemName: "Implement strStr()"
            - ProblemStatement: "Given two strings haystack and needle, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack."
            - Constraints: 
              - "0 <= haystack.length, needle.length <= 5 * 10^4"
              - "haystack and needle consist of only lowercase English characters."
            - Examples: 
              - Example: 
                - Input: "haystack = 'hello', needle = 'll'"
                - Output: "2"
              - Example: 
                - Input: "haystack = 'aaaaa', needle = 'bba'"
                - Output: "-1"
            - Methods: 
              - StrStrLinearScan: 
                - Approach: "Perform a linear scan through the haystack string. At each position, attempt to match the needle string."
        */

        public int StrStrLinearScan(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
                return 0;
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                for (int j = 0; j < needle.Length && haystack[i + j] == needle[j]; j++)
                {
                    if (j == needle.Length - 1)
                        return i;
                }
            }
            return -1;
        }

        /*
                - TimeComplexity: "O(n*m), where n is the length of the haystack and m is the length of the needle."
                - SpaceComplexity: "O(1), as we are not using any additional space that scales with the input size."
              - StrStrBuiltInFunctions:
                - Approach: "Using the built-in 'IndexOf' function of C# to find the first occurrence of needle in haystack."
        */

        public int StrStrBuiltInFunctions(string haystack, string needle)
        {
            return haystack.IndexOf(needle);
        }

        /*
                - TimeComplexity: "O(n*m), where n is the length of the haystack and m is the length of the needle."
                - SpaceComplexity: "O(1), as we are not using any additional space that scales with the input size."
        */

        #endregion

        #region Longest Common Prefix

        /*
        AlgorithmProblem:
          - ProblemName: "Longest Common Prefix"
            - ProblemStatement: "Write a function to find the longest common prefix string amongst an array of strings. If there is no common prefix, return an empty string."
            - Constraints: 
              - "1 <= strs.length <= 200"
              - "0 <= strs[i].length <= 200"
              - "strs[i] consists of only lowercase English letters."
            - Examples: 
              - Example: 
                - Input: "strs = ['flower','flow','flight']"
                - Output: "'fl'"
              - Example: 
                - Input: "strs = ['dog','racecar','car']"
                - Output: "''"
            - Methods: 
              - LongestCommonPrefixVerticalScan: 
                - Approach: "This method checks each character in the same position for all the strings until it finds a mismatch. It is called vertical scanning because it checks the same character position vertically across all strings."
        */

        public string LongestCommonPrefixVerticalScan(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            for (int i = 0; i < strs[0].Length; i++)
            {
                char c = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i == strs[j].Length || strs[j][i] != c)
                        return strs[0].Substring(0, i);
                }
            }
            return strs[0];
        }

        /*
                - TimeComplexity: "O(S), where S is the sum of all characters in all strings."
                - SpaceComplexity: "O(1), constant space is used."
              - LongestCommonPrefixDivideAndConquer:
                - Approach: "The problem is broken down into subproblems and the result of the subproblems are used to compute the result of the original problem. The divide and conquer approach splits the array of strings into two equal halves and finds the common prefix for each half first. Then it combines the results of the two halves."
        */

        public string LongestCommonPrefixDivideAndConquer(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";
            return LongestCommonPrefixDivideAndConquer(strs, 0, strs.Length - 1);
        }

        private string LongestCommonPrefixDivideAndConquer(string[] strs, int l, int r)
        {
            if (l == r)
                return strs[l];
            else
            {
                int mid = (l + r) / 2;
                string lcpLeft =   LongestCommonPrefixDivideAndConquer(strs, l , mid);
                string lcpRight =  LongestCommonPrefixDivideAndConquer(strs, mid + 1,r);
                return CommonPrefix(lcpLeft, lcpRight);
            }
        }

        string CommonPrefix(string left, string right)
        {
            int min = Math.Min(left.Length, right.Length);
            for (int i = 0; i < min; i++)
            {
                if (left[i] != right[i])
                    return left.Substring(0, i);
            }
            return left.Substring(0, min);
        }

        /*
                - TimeComplexity: "O(S), where S is the sum of all characters in all strings."
                - SpaceComplexity: "O(m*log(n)), where m is the length of the longest string, and n is the number of strings in the array."
              - LongestCommonPrefixBinarySearch:
                - Approach: "The approach assumes that there is a common prefix among the strings. A binary search is used to find this common prefix."
        */

        public string LongestCommonPrefixBinarySearch(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";
            int minLen = strs.Min(str => str.Length);
            int low = 1;
            int high = minLen;
            while (low <= high)
            {
                int middle = (low + high) / 2;
                if (IsCommonPrefix(strs, middle))
                    low = middle + 1;
                else
                    high = middle - 1;
            }
            return strs[0].Substring(0, (low + high) / 2);
        }

        private bool IsCommonPrefix(string[] strs, int len)
        {
            string str1 = strs[0].Substring(0, len);
            for (int i = 1; i < strs.Length; i++)
                if (!strs[i].StartsWith(str1))
                    return false;
            return true;
        }

        /*
                - TimeComplexity: "O(S*log(n)), where S is the sum of all characters in all strings, and n is the number of strings in the array."
                - SpaceComplexity: "O(1), constant space is used."
        */

        #endregion

    }
}
