using AlgorithmsNStructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsNStructures.ChapterComputers
{
    internal class TreesComputer
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            var rootNode = new TreeNode(nums[nums.Length / 2]);
            foreach (var item in nums)
            {
                this.Set(item, rootNode);
            }

            return rootNode;
        }

        private TreeNode Set(int item, TreeNode pointer)
        {
            var node = new TreeNode(item);

            if (node.val > pointer.val)
            {
                if (pointer.right == null)
                {
                    pointer.right = node;
                }
                else if (pointer.right.val > node.val)
                {
                    node.right = new TreeNode(pointer.right.val);
                    pointer.right = node;
                }
                else if (pointer.right.val < node.val)
                {
                    node.left = new TreeNode(pointer.right.val);
                    pointer.right = node;
                }
            }
            else if (node.val < pointer.val)
            {
                if (pointer.left == null)
                {
                    pointer.left = node;
                }
                else if (pointer.left.val < node.val)
                {
                    node.left = new TreeNode(pointer.left.val);
                    pointer.left = node;
                }
            }

            return pointer;
        }
    }
}
