from typing import List, Optional

class TreeNode:
    def __init__(self, val=0, left=None, right=None, count=1):
        self.val = val
        self.left = left
        self.right = right
        self.count = count  # Count of nodes in the subtree rooted at this node

class Solution:
    def buildTree(self, preorder: List[int], inorder: List[int]) -> Optional[TreeNode]:
        if not preorder or not inorder:
            return None
        
        root_val = preorder[0]
        root = TreeNode(root_val)

        root_index = inorder.index(root_val)

        root.left = self.buildTree(preorder[1:root_index+1], inorder[:root_index])
        root.right = self.buildTree(preorder[root_index+1:], inorder[root_index+1:])

        return root
    
def main():
    preorder = [3,9,20,15,7]
    inorder = [9,3,15,20,7]
    print(preorder[1:2])

main()