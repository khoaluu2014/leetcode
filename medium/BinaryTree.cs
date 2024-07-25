public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class BinaryTree {

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null)
        {
            return null;
        }

        if (p.val < root.val && q.val < root.val)
        {
            return LowestCommonAncestor(root.left, p, q);
        }
        if (p.val > root.val && q.val > root.val)
        {
            return LowestCommonAncestor(root.right, p, q);
        }

        return root;
    }

    public List<List<int>> LevelOrder(TreeNode root)
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        List<List<int>> res = new List<List<int>>();

        if (root != null)
        {
            q.Enqueue(root);
        }

        while (q.Count > 0)
        {
            List<int> val = new List<int>();

            for (int i = 0, len = q.Count; i < len; i++)
            {
                TreeNode node = q.Dequeue();
                val.Add(node.val);
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }

            res.Add(val);
        }

        return res;
    }

    public List<int> RightSideView(TreeNode root)
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        List<int> ans = new List<int>();

        if (root != null)
        {
            q.Enqueue(root);
        }

        while (q.Count > 0)
        {
            TreeNode right = null!;

            for (int i = 0, len = q.Count; i < len; i++)
            {
                TreeNode node = q.Dequeue();
                if (node != null)
                {
                    right = node;
                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }
            }
        }

        return ans;
    }

    public int GoodNodes(TreeNode root)
    {
        int dfs(TreeNode root, int max)
        {
            if (root == null)
            {
                return 0;
            }

            // Compare to previous max
            int res = (root.val >= max) ? 1 : 0;
            // Update max
            max = Math.Max(root.val, max);
            res += dfs(root.left, max);
            res += dfs(root.right, max);
            return res;
        }

        return dfs(root, root.val);
    }
    
    public bool IsValidBST(TreeNode root) {

      bool dfs(TreeNode node, double left, double right) {
        if(node == null) {
          return true;
        }

        if(node.val <= left || node.val >= right) {
          return false;
        }

        return dfs(node.left, left, node.val) && dfs(node.right, node.val, right);
      }

      return dfs(root, double.NegativeInfinity, double.PositiveInfinity);
    }
}
