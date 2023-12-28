from typing import List

class Solution:
    def exist(self, board: List[List[str]], word: str) -> bool:
        vis = set()

        def dfs(r, c, i):
            if i == len(word):
                return True
            if not (0 <= r < len(board)) or not (0 <= c < len(board[0])) or word[i] != board[r][c] or (r,c) in vis:
                return False
            vis.add((r,c))
            for dr, dc in [(-1, 0), (1, 0), (0, -1), (0, 1)]:
                if(dfs(r + dr, c + dc, i + 1)):
                    return True
            vis.remove((r,c))
            return False

        for i in range(len(board)):
            for j in range(len(board[0])):
                if dfs(i, j, 0):
                    return True
        return False