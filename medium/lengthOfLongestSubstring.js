class Solution {
  lengthOfLongestSubstring(s) {
    let start = 0;
    let ans = 0;
    let charSet = new Set();

    if (!s) {
      return 0;
    }

    for (let i = 0; i < s.length; i++) {
      while (charSet.has(s[i])) {
        charSet.delete(s[start]);
        start++;
      }
      charSet.add(s[i]);
      ans = Math.max(ans, i - start);
    }
    return ans + 1;
  }
}
