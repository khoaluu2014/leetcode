from typing import List


class TrieNode:
    def __init__(self):
        self.children = {}
        self.end = False
        self.word = None

    def addWord(self, word):
        curr = self
        for c in word:
            if c not in curr.children:
                curr.children[c] = TrieNode()
            curr = curr.children[c]
        curr.end = True
        curr.word = word


class Solution:
    def findWords(self, board: List[List[str]], words: List[str]) -> List[str]:
        root = TrieNode()
        res, vis = set(), set()
        for word in words:
            root.addWord(word)

        for r in range(len(board)):
            for c in range(len(board[0])):
                self.dfs(board, r, c, root, res, vis)
        return list(res)

    def dfs(self, board, r, c, node, result, vis):
        char = board[r][c]
        if char not in node.children or (r, c) in vis:
            return
        node = node.children[char]
        if node.end:
            result.add(node.word)
            node.end = False
        vis.add((r, c))
        for x, y in [(r - 1, c), (r + 1, c), (r, c - 1), (r, c + 1)]:
            if 0 <= x < len(board) and 0 <= y < len(board[0]):
                self.dfs(board, x, y, node, result, vis)
        vis.remove((r, c))
