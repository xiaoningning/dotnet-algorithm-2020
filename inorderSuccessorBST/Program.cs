using System;

namespace inorderSuccessorBST
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(2);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(1);
            
            var res = obj.InorderSuccessor(root, root.left);
            Console.WriteLine("inorder successor of bst {0}", res == null ? "" : res.val.ToString());
        }
    }
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Solution {
        /**
        (a) Inorder (Left, Root, Right) 
        (b) Preorder (Root, Left, Right) 
        (c) Postorder (Left, Right, Root) 
        */
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
            if(root == null) return null;
            if( p.val >= root.val)
                return InorderSuccessor(root.right, p);
            else {
                TreeNode left = InorderSuccessor(root.left, p);
                return left != null? left : root;            
            }
        }
        /**
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
            TreeNode res = null;
            while (root != null) {
                if (p.val < root.val ) {
                    res = root;
                    root = root.left;
                } 
                else root = root.right;
            }
            return res;
        }
        */
    }
}
