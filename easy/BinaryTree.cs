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
}
