class Solution:
    def checkInclusion(self, s1: str, s2: str) -> bool:
        s1_freq = dict()
        s2_freq = dict()
        window_len = len(s1)

        for char in s1:
            s1_freq[char] = s1_freq.get(char, 0) + 1
        for i in range(len(s2)):
            s2_freq[s2[i]] = s2_freq.get(s2[i], 0) + 1
            if i >= window_len:
                left_char = s2[i - window_len]
                if s2_freq[left_char] == 1:
                    s2_freq.pop(left_char)
                elif s2_freq[left_char] > 1:
                    s2_freq[left_char] -= 1
            print(f"s1_freq: {s1_freq}")
            print(f"s2_freq: {s2_freq}")
            if s1_freq == s2_freq:
                return True
        return False



def main():
    sol = Solution()
    s1 = "adc"
    s2 = "dcda"
    ans = sol.checkInclusion(s1, s2)
    print(ans)

if __name__ == "__main__":
    main()