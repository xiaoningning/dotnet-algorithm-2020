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
            Codec1 codec = new Codec1();
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
            if (nodes.Count == 0) return null;

            string node = nodes[0];
            nodes.RemoveAt(0);
            if (node == "null")
            {
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

    public class Codec1
    {
        public string serialize(TreeNode root)
        {
            List<string> strList = new List<string>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            if (root != null) q.Enqueue(root);
            while (q.Count != 0)
            {
                TreeNode tmp = q.Dequeue();
                if (tmp != null)
                {
                    strList.Add(tmp.val.ToString());
                    q.Enqueue(tmp.left);
                    q.Enqueue(tmp.right);
                }
                else
                {
                    strList.Add("null");
                }
            }
            return string.Join(",", strList);
        }

        public TreeNode deserialize(string data)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            List<string> nodes = data.Split(',').ToList();

            if (nodes.Count == 0) return null;

            string node = nodes[0];
            nodes.RemoveAt(0);

            if (node == "null")
            {
                return null;
            }
            else
            {
                TreeNode res = new TreeNode(Int32.Parse(node));
                q.Enqueue(res);
                while (q.Count != 0)
                {
                    TreeNode curr = q.Dequeue();
                    if (nodes.Count == 0) break;
                    else
                    {
                        node = nodes[0];
                        nodes.RemoveAt(0);
                        if (node != "null")
                        {
                            curr.left = new TreeNode(Int32.Parse(node));
                            q.Enqueue(curr.left);
                        }
                    }
                    if (nodes.Count == 0) break;
                    else
                    {
                        node = nodes[0];
                        nodes.RemoveAt(0);
                        if (node != "null")
                        {
                            curr.right = new TreeNode(Int32.Parse(node));
                            q.Enqueue(curr.right);
                        }
                    }
                }
                return res;
            }
        }
    }
}
