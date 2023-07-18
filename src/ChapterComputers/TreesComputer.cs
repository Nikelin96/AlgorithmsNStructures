using AlgorithmsNStructures.Models;

namespace AlgorithmsNStructures.ChapterComputers
{
    internal class TreesComputer
    {
        #region Maximum Depth of Binary Tree

        /*
        ProblemName: Maximum Depth of Binary Tree

        ProblemStatement: Given the root of a binary tree, the task is to return its maximum depth.
        The maximum depth of a binary tree is the number of nodes along the longest path from the root node down to the farthest leaf node.

        Constraints: The number of nodes in the tree is in the range [0, 104]. -100 <= Node.val <= 100.

        Example:
        - Input: root = [3,9,20,null,null,15,7]
        - Output: 3
        */

        // Method: MaxDepthRecursive
        /*
        Approach: If the current node is null, return 0. Recursively find the maximum depth of the left and right subtrees. The maximum depth of the current node is the maximum of the depths of the left and right subtrees, plus 1.

        Time complexity: O(n), where n is the number of nodes in the tree, as we must visit every node exactly once.

        Space complexity: O(h), where h is the height of the tree, corresponding to the maximum number of recursive calls on the stack.
        */
        public int MaxDepthRecursive(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftDepth = MaxDepthRecursive(root.left);
            int rightDepth = MaxDepthRecursive(root.right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        // Method: MaxDepthIterative
        /*
        Approach: The approach is similar to the recursive one but instead uses a depth-first traversal method using a stack.

        Time complexity: O(n), where n is the number of nodes in the tree, as we must visit every node exactly once.

        Space complexity: O(h), where h is the height of the tree, corresponding to the maximum number of items on the stack.
        */
        public int MaxDepthIterative(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return dDepth(root, 0);
        }

        private int dDepth(TreeNode root, int curDepth)
        {
            int leftMax = 0;
            int rightMax = 0;
            if (root.left != null)
            {
                int depthLeft = dDepth(root.left, curDepth + 1);
                leftMax = 1 + depthLeft;
            }
            if (root.right != null)
            {
                int depthRight = dDepth(root.right, curDepth + 1);
                rightMax = 1 + depthRight;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }
            if (leftMax >= rightMax)
            {
                return leftMax;
            }
            else
            {
                return rightMax;
            }
        }

        #endregion

        #region Validate Binary Search Tree

        /*
        ProblemName: Validate Binary Search Tree

        ProblemStatement: Given the root of a binary tree, determine if it is a valid binary search tree (BST).

        Constraints: The number of nodes in the tree is in the range [1, 104]. -231 <= Node.val <= 231 - 1

        Examples: 
        - Example 1:
          - Input: root = [2,1,3]
          - Output: true
        - Example 2:
          - Input: root = [5,1,4,null,null,3,6]
          - Output: false
          - Explanation: The root node's value is 5 but its right child's value is 4.
        */

        // Method: IsValidBSTRecursive
        /*
        Approach: This problem is solved by using a recursive depth-first search. A node is valid if it fits within the minimum and maximum values for its position in the tree. The left child of a node must have a value less than its parent, so it must fall within the minimum and the value of the parent. The right child of a node must have a value greater than its parent, so it must fall between the value of the parent and the maximum. By starting with the minimum and maximum values of long integers and updating the values as we recursively process the nodes, we can validate the entire tree.

        Time Complexity: O(n), where n is the number of nodes in the tree, as we need to visit each node exactly once.

        Space Complexity: O(h), where h is the height of the tree, because of the maximum amount of space needed for the recursive call stack.
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

        // Method: IsValidBSTIterative
        /*
        Approach: The iterative approach uses an in-order traversal and checks whether the values of the nodes are in ascending order. If the values are in ascending order, it is a valid BST, otherwise not. In the traversal, we maintain a stack of nodes and a variable to hold the previous node value.

        Time Complexity: O(n), where n is the number of nodes in the tree, as we need to visit each node exactly once.

        Space Complexity: O(h), where h is the height of the tree, because of the maximum size of the stack.
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

        #endregion


        #region Symmetric Tree

        /*
        ProblemName: Symmetric Tree

        ProblemStatement: Given the root of a binary tree, check whether it is a mirror of itself 
        (i.e., symmetric around its center).

        Constraints: The number of nodes in the tree is in the range [1, 1000]. -100 <= Node.val <= 100

        Examples: 
        - Example 1:
          - Input: root = [1,2,2,3,4,4,3]
          - Output: true
        - Example 2:
          - Input: root = [1,2,2,null,3,null,3]
          - Output: false
        */

        // Method: IsSymmetricRecursive
        /*
        Approach: This problem can be solved recursively by checking if the left subtree is a mirror of the right subtree. The function IsSymmetricRecursive calls a helper function that performs this check. If both the left and right subtrees are null, it returns true. If only one of them is null, it returns false. If neither are null, it checks if their values are equal and if the left child of the left subtree is a mirror of the right child of the right subtree and vice versa.

        Time Complexity: O(n), where n is the number of nodes in the tree, as we need to visit each node exactly once.

        Space Complexity: O(h), where h is the height of the tree, because of the maximum amount of space needed for the recursive call stack.
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

        // Method: IsSymmetricIterative
        /*
        Approach: This problem can also be solved iteratively using a queue. The function IsSymmetricIterative enqueues the left and right children of the root node, then repeatedly dequeues two nodes at a time and checks if their values are equal. If both nodes are null, it continues to the next pair of nodes. If only one node is null or if their values are not equal, it returns false. If their values are equal, it enqueues the left and right children of the first node and the right and left children of the second node. The function returns true if it successfully processes all pairs of nodes.

        Time Complexity: O(n), where n is the number of nodes in the tree, as we need to visit each node exactly once.

        Space Complexity: O(n), in the worst case we might need to store all nodes in the queue.
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

        #endregion

        #region Binary Tree Level Order Traversal

        /*
        ProblemName: Binary Tree Level Order Traversal

        ProblemStatement: Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

        Constraints: The number of nodes in the tree is in the range [0, 2000]. -1000 <= Node.val <= 1000

        Examples: 
        - Example 1:
          - Input: root = [3,9,20,null,null,15,7]
          - Output: [[3],[9,20],[15,7]]
        - Example 2:
          - Input: root = [1]
          - Output: [[1]]
        - Example 3:
          - Input: root = []
          - Output: []
        */

        // Method: LevelOrder
        /*
        Approach: This problem can be solved using the Breadth-First Search (BFS) algorithm. We process the nodes level by level, from left to right. For each level, we dequeue all nodes at that level, add their values to a list, and enqueue their children for the next level. The loop continues until there are no more nodes to process, i.e., the queue is empty. At that point, the function returns the result, which is a list of levels, where each level is represented as a list of node values.

        Time Complexity: O(n), where n is the number of nodes in the tree. This is because each node is processed once.

        Space Complexity: O(n), because in the worst case scenario, the maximum size of the queue can be the total number of nodes in the tree (This would happen in the case of a perfect binary tree).
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

        #endregion

        #region Convert Sorted Array to Binary Search Tree

        /*
        ProblemName: Convert Sorted Array to Binary Search Tree

        ProblemStatement: Given an integer array nums where the elements are sorted in ascending order, convert it to a height-balanced binary search tree.

        Constraints: 1 <= nums.length <= 104 -104 <= nums[i] <= 104 nums is sorted in a strictly increasing order.

        Examples: 
        - Example 1:
          - Input: nums = [-10,-3,0,5,9]
          - Output: [0,-3,9,-10,null,5]
          - Explanation: [0,-10,5,null,-3,null,9] is also accepted
        - Example 2:
          - Input: nums = [1,3]
          - Output: [3,1]
          - Explanation: [1,null,3] and [3,1] are both height-balanced BSTs.
        */

        // Method: SortedArrayToBST
        /*
        Approach: The middle element of the array becomes the root of the binary search tree (BST) because it ensures that the tree remains height balanced. We use a helper function, ConvertArrayToBST, to recursively construct the left and right subtrees. Elements to the left of the mid will form the left subtree, and elements to the right of mid will form the right subtree.

        Time Complexity: O(n), where n is the number of elements in the array. This is because each element in the array is visited once.

        Space Complexity: O(log n), which is the maximum depth of the tree. This happens when the tree is balanced and the recursive call stack would be as deep as the height of the tree.
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

        #endregion

    }
}
