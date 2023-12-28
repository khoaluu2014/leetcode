from typing import Optional
# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
class Solution:
    def isValidBST(self, root: Optional[TreeNode]) -> bool:
        
        return self.validate(root)

    def validate(self, root: Optional[TreeNode], lower=float('-inf'), upper=float('inf')) -> bool:
        if not root:
            return True
        
        if root.val <= lower or root.val >= upper:
            return False
        
        if not self.validate(root.left, lower, root.val):
            return False
        if not self.validate(root.right, root.val, upper):
            return False
        return True