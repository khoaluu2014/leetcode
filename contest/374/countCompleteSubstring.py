class Solution:
    def countCompleteSubstrings(self, word: str, k: int) -> int:
        def isComplete(sub):
            freq = dict()
            for char in sub:
                freq[char] = freq.get(char, 0) + 1

            for char in sub:
                if freq[char] != k:
                    return False
            
            for i in range(1, len(sub)):
                if abs(ord(sub[i]) - ord(sub[i-1])) > 2:
                    return False
            
            return True
        
        count = 0
        for i in range(len(word)):
            for j in range(i+1, len(word) + 1):
                if isComplete(word[i:j]):
                    count += 1

        return count