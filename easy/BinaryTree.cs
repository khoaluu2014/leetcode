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

public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
        {
            return null;
        }

        TreeNode node = new TreeNode(root.val);

        node.left = InvertTree(root.right);
        node.right = InvertTree(root.left);

        return node;
    }

    public int MaxDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }

    public int DiameterOfBinaryTree(TreeNode root)
    {
        int DFS(TreeNode root, ref int res)
        {
            if (root == null)
            {
                return 0;
            }

            int left = DFS(root.left, ref res);
            int right = DFS(root.right, ref res);
            res = Math.Max(res, left + right);
            return 1 + Math.Max(left, right);
        }

        int res = 0;
        DFS(root, ref res);
        return res;
    }

    public bool IsBalanced(TreeNode root)
    {
        int[] DFS(TreeNode root)
        {
            if (root == null)
            {
                return new int[] { 1, 0 };
            }

            int[] left = DFS(root.left);
            int[] right = DFS(root.right);
            bool balanced = left[0] == 1 && right[0] == 1 && Math.Abs(left[1] - right[1]) <= 1;
            int height = 1 + Math.Max(left[1], right[1]);
            return new int[] { balanced ? 1 : 0, height };
        }

        return DFS(root)[0] == 1;
    }

    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
        {
            return true;
        }

        if (p != null && q != null && p.val == q.val)
        {
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
        else
        {
            return false;
        }
    }

    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        if (subRoot == null)
        {
            return true;
        }

        if (root == null)
        {
            return false;
        }

        if (IsSameTree(root, subRoot))
        {
            return true;
        }

        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

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
}
