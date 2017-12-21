using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace serializeDeserializeBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = args[0];
            // string inputStr = "1,null,2,3";
            Console.WriteLine("input: {0}", inputStr);
            Codec codec = new Codec();
            Console.WriteLine("deserialize result: {0}", codec.serialize(codec.deserialize(inputStr)));
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Codec
    {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            List<string> sb = new List<string>();
            serialize(root, sb);
            return string.Join(",", sb);
        }

        void serialize(TreeNode node, List<string> sb)
        {
            if (node != null)
            {
                sb.Add(node.val.ToString());
                serialize(node.left, sb);
                serialize(node.right, sb);
            }
            else sb.Add("null");
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {   
            return buildTree(data.Split(',').ToList());            
        }

        TreeNode buildTree(List<string> nodes)
        {
            if(nodes.Count == 0) return null;

            string node = nodes[0];
            nodes.RemoveAt(0);
            if (node == "null") {
                return null;
            }
            else
            {
                TreeNode tn = new TreeNode(Int32.Parse(node));
                tn.left = buildTree(nodes);
                tn.right = buildTree(nodes);                 
                return tn;
            }
        }

    }
}
