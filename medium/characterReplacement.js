class Solution {
  characterReplacement(s, k) {
    let count = {};
    let ans = 0;
    let l = 0;

    for (let r = 0; r < s.length; r++) {
      count[s[r]] = 1 + (count[s[r]] || 0);
      if (r - l + 1 - Math.max(...Object.values(count)) > k) {
        count[s[l]]--;
        l++;
      }
      ans = Math.max(ans, r - l + 1);
    }

    return ans;
  }
}
