from typing import (
    List,
)
class Solution:
    def alienOrder(self, words: List[str]) -> str:
        adj = { c:set() for word in words for c in word}
        
        for i in range(len(words) - 1):
            w1, w2 = words[i], words[i+1]
            minLen = min(len(w1), len(w2))
            if len(w1) > len(w2) and w1[:minLen] == w2[:minLen]:
                return ""
            for j in range(minLen):
                if w1[j] != w2[j]:
                    adj[w1[j]].add(w2[j])
                    break

        vis = {} # False = visited, True = current
        res = []

        def dfs(c):
            if c in vis:
                return vis[c]
            vis[c] = True
            for nei in adj[c]:
                if dfs(nei):
                    return True
            vis[c] = False
            res.append(c)

        for c in adj:
            if dfs(c):
                return ""
        
        res.reverse()
        return "".join(res)
   
sol = Solution()
s = sol.alienOrder(["a", "ba", "bc", "c"])
print(s)
