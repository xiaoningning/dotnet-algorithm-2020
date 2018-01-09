using System;
using System.Collections.Generic;

namespace twoSumIVBST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The tree input is hard coded.");            
            Console.WriteLine("target: {0}", args[0]);
            int target = Int32.Parse(args[0]);
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.right = new TreeNode(6);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(4);
            root.right.right = new TreeNode(7);
            Console.WriteLine("the number of LCIS: {0}", FindTarget1(root, target));
        }

        static bool FindTarget(TreeNode root, int k){
            HashSet<int> s = new HashSet<int>();
            return FindTarget(root, s, k);
        }

        static bool FindTarget(TreeNode root, HashSet<int> set, int k) {
            bool res = false;            
            if (root != null){
                if (set.Contains(k - root.val)) return true;
                set.Add(root.val);
                return FindTarget(root.left,set, k) || FindTarget(root.right, set,k);
            } 
            return res;
        }

        static bool FindTarget1(TreeNode root, int k){
            List<int> nums = new List<int>();
            InOrder(root, nums);
            for(int i = 0, j = nums.Count - 1; i < j;){
                if(nums[i] + nums[j] == k) return true;
                if(nums[i] + nums[j] < k) i++;
                else j--;
            }
            return false;
        }

        static void InOrder(TreeNode root, List<int> nums){
            if (root == null) return;
            InOrder(root.left, nums);
            nums.Add(root.val);
            InOrder(root.right, nums);
        }

    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
