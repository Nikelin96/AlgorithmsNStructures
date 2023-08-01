using AlgorithmsNStructures.Models;

namespace AlgorithmsNStructures.ChapterComputers
{
    internal class TreesComputer
    {
        #region Maximum Depth of Binary Tree

        /*
        AlgorithmProblem:
          - ProblemName: "Maximum Depth of Binary Tree"
            - ProblemStatement: "Given the root of a binary tree, return its maximum depth. The maximum depth of a binary tree is the number of nodes along the longest path from the root node down to the farthest leaf node."
            - Constraints: 
              - "The number of nodes in the tree is in the range [0, 10^4]."
              - "-100 <= Node.val <= 100."
            - Examples: 
              - Example: 
                - Input: "root = [3,9,20,null,null,15,7]"
                - Output: "3"
            - Methods: 
              - MaxDepthRecursive: 
                - Approach: "This method uses recursion to find the maximum depth. If the current node is null, it returns 0. Otherwise, it calculates the maximum depth of the left and right subtrees and returns the larger one plus 1."
        */

        public int MaxDepthRecursive(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftDepth = MaxDepthRecursive(root.left);
            int rightDepth = MaxDepthRecursive(root.right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        /*
                - TimeComplexity: "O(n), where n is the number of nodes in the tree, as we must visit every node exactly once."
                - SpaceComplexity: "O(h), where h is the height of the tree, corresponding to the maximum number of recursive calls on the stack."
              - MaxDepthIterative:
                - Approach: "This method uses depth-first traversal with a stack to find the maximum depth iteratively. For each node, it pushes the node's children into the stack and updates the maximum depth so far."
        */

        public int MaxDepthIterative(TreeNode root)
        {
            if (root == null) return 0;

            Stack<Tuple<TreeNode, int>> stack = new Stack<Tuple<TreeNode, int>>();
            stack.Push(new Tuple<TreeNode, int>(root, 1));
            int max = 0;

            while (stack.Count != 0)
            {
                var current = stack.Pop();
                root = current.Item1;
                int currentDepth = current.Item2;
                max = Math.Max(max, currentDepth);

                if (root.left != null)
                    stack.Push(new Tuple<TreeNode, int>(root.left, currentDepth + 1));

                if (root.right != null)
                    stack.Push(new Tuple<TreeNode, int>(root.right, currentDepth + 1));
            }

            return max;
        }

        /*
                - TimeComplexity: "O(n), where n is the number of nodes in the tree, as we must visit every node exactly once."
                - SpaceComplexity: "O(n), in the worst case (when the tree is completely unbalanced, e.g., each node has only left or only right child), because in the worst case fully n nodes could be stored in the stack."
        */

        #endregion

        #region Validate Binary Search Tree

        /*
        AlgorithmProblem:
          - ProblemName: "Validate Binary Search Tree"
            - ProblemStatement: "Given the root of a binary tree, determine if it is a valid binary search tree (BST)."
            - Constraints: "The number of nodes in the tree is in the range [1, 104]. -231 <= Node.val <= 231 - 1."
            - Examples: 
              - Example 1: 
                - Input: "root = [2,1,3]"
                - Output: "true"
              - Example 2: 
                - Input: "root = [5,1,4,null,null,3,6]"
                - Output: "false"
            - Methods: 
              - IsValidBSTRecursive: 
                - Approach: "This problem is solved by using a recursive depth-first search. A node is valid if it fits within the minimum and maximum values for its position in the tree..."
        */

        public bool IsValidBSTRecursive(TreeNode root)
        {
            return IsValidBSTRecursive(root, long.MinValue, long.MaxValue);
        }

        private bool IsValidBSTRecursive(TreeNode node, long min, long max)
        {
            if (node == null) return true;
            if (node.val <= min || node.val >= max) return false;
            return IsValidBSTRecursive(node.left, min, node.val) && IsValidBSTRecursive(node.right, node.val, max);
        }

        /*
                - TimeComplexity: "O(n), where n is the number of nodes in the tree, as we need to visit each node exactly once."
                - SpaceComplexity: "O(h), where h is the height of the tree, because of the maximum amount of space needed for the recursive call stack."
              - IsValidBSTIterative: 
                - Approach: "The iterative approach uses an in-order traversal and checks whether the values of the nodes are in ascending order..."
        */

        public bool IsValidBSTIterative(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode prev = null;

            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();

                if (prev != null && root.val <= prev.val)
                {
                    return false;
                }

                prev = root;
                root = root.right;
            }

            return true;
        }

        /*
                - TimeComplexity: "O(n), where n is the number of nodes in the tree, as we need to visit each node exactly once."
                - SpaceComplexity: "O(h), where h is the height of the tree, because of the maximum size of the stack."
        */

        #endregion

        #region Symmetric Tree

        /*
        AlgorithmProblem:
          - ProblemName: "Symmetric Tree"
            - ProblemStatement: "Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center)."
            - Constraints: "The number of nodes in the tree is in the range [1, 1000]. -100 <= Node.val <= 100."
            - Examples: 
              - Example 1: 
                - Input: "root = [1,2,2,3,4,4,3]"
                - Output: "true"
              - Example 2: 
                - Input: "root = [1,2,2,null,3,null,3]"
                - Output: "false"
            - Methods: 
              - IsSymmetricRecursive: 
                - Approach: "This problem can be solved recursively by checking if the left subtree is a mirror of the right subtree..."
        */

        public bool IsSymmetricRecursive(TreeNode root)
        {
            if (root == null) return true;
            return IsSymmetricRecursive(root.left, root.right);
        }

        private bool IsSymmetricRecursive(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;
            return (left.val == right.val) && IsSymmetricRecursive(left.left, right.right) && IsSymmetricRecursive(left.right, right.left);
        }

        /*
                - TimeComplexity: "O(n), where n is the number of nodes in the tree, as we need to visit each node exactly once."
                - SpaceComplexity: "O(h), where h is the height of the tree, because of the maximum amount of space needed for the recursive call stack."
              - IsSymmetricIterative: 
                - Approach: "This problem can also be solved iteratively using a queue..."
        */

        public bool IsSymmetricIterative(TreeNode root)
        {
            if (root == null) return true;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);
            while (queue.Count > 0)
            {
                TreeNode t1 = queue.Dequeue();
                TreeNode t2 = queue.Dequeue();
                if (t1 == null && t2 == null) continue;
                if (t1 == null || t2 == null) return false;
                if (t1.val != t2.val) return false;
                queue.Enqueue(t1.left);
                queue.Enqueue(t2.right);
                queue.Enqueue(t1.right);
                queue.Enqueue(t2.left);
            }
            return true;
        }

        /*
                - TimeComplexity: "O(n), where n is the number of nodes in the tree, as we need to visit each node exactly once."
                - SpaceComplexity: "O(n), in the worst case we might need to store all nodes in the queue."
        */


        #endregion

        #region Binary Tree Level Order Traversal

        /*
        AlgorithmProblem:
          - ProblemName: "Binary Tree Level Order Traversal"
            - ProblemStatement: "Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level)."
            - Constraints: "The number of nodes in the tree is in the range [0, 2000]. -1000 <= Node.val <= 1000."
            - Examples: 
              - Example 1: 
                - Input: "root = [3,9,20,null,null,15,7]"
                - Output: "[[3],[9,20],[15,7]]"
              - Example 2: 
                - Input: "root = [1]"
                - Output: "[[1]]"
              - Example 3: 
                - Input: "root = []"
                - Output: "[]"
            - Methods: 
              - LevelOrder: 
                - Approach: "This problem can be solved using the Breadth-First Search (BFS) algorithm. We process the nodes level by level, from left to right. For each level, we dequeue all nodes at that level, add their values to a list, and enqueue their children for the next level. The loop continues until there are no more nodes to process, i.e., the queue is empty. At that point, the function returns the result, which is a list of levels, where each level is represented as a list of node values."
        */

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int levelCount = queue.Count;
                var levelVals = new List<int>();
                for (int i = 0; i < levelCount; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                    levelVals.Add(node.val);
                }
                result.Add(levelVals);
            }
            return result;
        }

        /*
                - TimeComplexity: "O(n), where n is the number of nodes in the tree. This is because each node is processed once."
                - SpaceComplexity: "O(n), because in the worst case scenario, the maximum size of the queue can be the total number of nodes in the tree (This would happen in the case of a perfect binary tree)."
        */


        #endregion

        #region Convert Sorted Array to Binary Search Tree

        /*
        AlgorithmProblem:
          - ProblemName: "Convert Sorted Array to Binary Search Tree"
            - ProblemStatement: "Given an integer array nums where the elements are sorted in ascending order, convert it to a height-balanced binary search tree."
            - Constraints: "1 <= nums.length <= 10^4, -10^4 <= nums[i] <= 10^4, nums is sorted in a strictly increasing order."
            - Examples: 
              - Example: 
                - Input: "nums = [-10,-3,0,5,9]"
                - Output: "[0,-3,9,-10,null,5]"
              - Example: 
                - Input: "nums = [1,3]"
                - Output: "[3,1]"
            - Methods: 
              - SortedArrayToBST: 
                - Approach: "The middle element of the array becomes the root of the binary search tree (BST) because it ensures that the tree remains height balanced. We use a helper function, ConvertArrayToBST, to recursively construct the left and right subtrees."
        */
        public TreeNode? SortedArrayToBST(int[] nums)
        {
            return ConvertArrayToBST(nums, 0, nums.Length - 1);
        }

        private TreeNode? ConvertArrayToBST(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            int mid = start + (end - start) / 2;
            TreeNode node = new TreeNode(nums[mid]);
            node.left = ConvertArrayToBST(nums, start, mid - 1);
            node.right = ConvertArrayToBST(nums, mid + 1, end);
            return node;
        }

        /*
                - TimeComplexity: "O(n), where n is the number of elements in the array. This is because each element in the array is visited once."
                - SpaceComplexity: "O(log n), which is the maximum depth of the tree. This happens when the tree is balanced and the recursive call stack would be as deep as the height of the tree."
        */


        #endregion

    }
}
