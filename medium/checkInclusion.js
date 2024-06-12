class Solution {
  checkInclusion(s1, s2) {
    if (s1.length > s2.length) {
      return false;
    }

    let s1Map = Array(26).fill(0);
    let s2Map = Array(26).fill(0);

    for (let i = 0; i < s1.length; i++) {
      s1Map[s1.charCodeAt(i) - "a".charCodeAt(0)]++;
      s2Map[s2.charCodeAt(i) - "a".charCodeAt(0)]++;
    }

    let matches = 0;
    for (let i = 0; i < 26; i++) {
      if (s1Map[i] === s2Map[i]) {
        matches++;
      }
    }

    let l = 0;
    for (let r = s1.length; r < s2.length; r++) {
      if (matches === 26) {
        return true;
      }

      let index = s2.charCodeAt(r) - "a".charCodeAt(0);
      s2Map[index]++;
      if (s1Map[index] === s2Map[index]) {
        matches++;
      } else if (s1Map[index] + 1 === s2Map[index]) {
        matches--;
      }
      index = s2.charCodeAt(l) - "a".charCodeAt(0);
      s2Map[index]--;
      if (s1Map[index] === s2Map[index]) {
        matches++;
      } else if (s1Map[index] - 1 === s2Map[index]) {
        matches--;
      }
      l++;
    }
    return matches === 26;
  }
}
