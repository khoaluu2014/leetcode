class Solution:
    def characterReplacement(self, s: str, k: int) -> int:
        char_freq = dict()
        max_freq = 0
        start = 0
        max_length = 0
        n = len(s)
        for end in range(n):
            char_freq[s[end]] = char_freq.get(s[end], 0) + 1
            max_freq = max(max_freq, char_freq[s[end]])
            while (end - start + 1) - max_freq > k:
                char_freq[s[start]] -= 1
                start += 1
            max_length = max(max_length, end - start + 1)
        return max_length


def main():
    sol = Solution()
    s = "AABABBA"
    k = 1
    ans = sol.characterReplacement(s, k)
    print(ans)


if __name__ == "__main__":
    main()
