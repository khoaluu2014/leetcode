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
}
