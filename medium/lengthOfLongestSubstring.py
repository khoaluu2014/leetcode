class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        char_set = set()
        start = 0
        max_length = 0
        n = len(s)
        if not s:
            return 0
        for end in range(n):
            while s[end] in char_set:
                char_set.remove(s[start])
                start += 1
            char_set.add(s[end])
            max_length = max(max_length, end - start)
        return max_length + 1

def main():
    sol = Solution()
    s = "abcabcbb"
    ans = sol.lengthOfLongestSubstring(s)
    print(ans)

if __name__ == "__main__":
    main()
