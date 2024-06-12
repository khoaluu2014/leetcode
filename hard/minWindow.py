class Solution:
    """
    1. Has a hashmap t_freq for frequency of characters in t
    2. Iterate through the characters in s with end
    3. 2 cases:
        - s[end] is in t_freq:
            - put it in a hashmap window_freq
        - s[end] is not in t_freq:
            - continue the loop
    4. If window_freq = t_freq:
        - update min_index if the new difference is smaller
        - move start of window to where end is
        - empty window_freq
    5. Return substring using min_index
    """

    def minWindow(self, s: str, t: str) -> str:
        t_freq, window_freq = {}, {}
        start = 0
        n = len(s)
        min_index = []
        res, res_len = [-1, -1], float("inf")
        if not t or not s:
            return ""

        for char in t:
            t_freq[char] = t_freq.get(char, 0) + 1

        have, need = 0, len(t_freq)

        for end in range(n):
            char = s[end]
            window_freq[char] = window_freq.get(char, 0) + 1
            if (char in t_freq) and window_freq[char] == t_freq[char]:
                have += 1
            while have == need:
                if (end - start + 1) < res_len:
                    res = [start, end]
                    res_len = end - start + 1
                window_freq[s[start]] -= 1
                if s[start] in t_freq and window_freq[s[start]] < t_freq[s[start]]:
                    have -= 1
                start += 1
        start, end = res
        return s[start : end + 1] if res_len != float("inf") else ""


def main():
    sol = Solution()
    s = "AB"
    t = "B"
    s1 = "ADOBECODEBANC"
    t1 = "BC"
    ans = sol.minWindow(s, t)
    ans1 = sol.minWindow(s1, t1)
    print(ans)
    print(ans1)


if __name__ == "__main__":
    main()
