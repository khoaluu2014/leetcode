class Solution {
  isValid(s) {
    if (!s) {
      return true;
    }
    let stack = [];
    let map = {
      "}": "{",
      "]": "[",
      ")": "(",
    };

    for (const i of s) {
      if (!(i in map)) {
        stack.push(i);
      } else if (stack.length === 0 || stack[stack.length - 1] !== map[i]) {
        return false;
      } else {
        stack.pop();
      }
    }
    return stack.length === 0;
  }
}

let sol = new Solution();

let s = "]";

console.log(sol.isValid(s));
