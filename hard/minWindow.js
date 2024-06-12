class Solution {
  minWindow(s, t) {
    const map = new Map();

    for (const x of t) {
      map.set(x, (map.get(x) || 0) + 1);
    }

    let matched = 0;
    let start = 0;
    let minLen = s.length + 1;
    let subStr = 0;

    for (let end = 0; end < s.length; end++) {
      let right = s[end];
      if (map.has(right)) {
        map.set(right, map.get(right) - 1);
        if (map.get(right) === 0) {
          matched++;
        }
      }
      while (matched === map.size) {
        if (minLen > end - start + 1) {
          minLen = end - start + 1;
          subStr = start;
        }
        const deleted = s[start++];
        if (map.has(deleted)) {
          if (map.get(deleted) == 0) matched--;
          map.set(deleted, map.get(deleted) + 1);
        }
      }
    }
    return minLen > s.length ? "" : s.substring(subStr, subStr + minLen);
  }
}
