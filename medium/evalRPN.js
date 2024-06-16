class Solution {
  evalRPN(tokens) {
    let stack = [];
    let ans = 0;
    for (const token of tokens) {
      if (token !== "+" && token !== "-" && token !== "*" && token !== "/") {
        stack.push(parseInt(token));
      } else {
        while (stack.length > 0) {
          let num = stack.pop();
          console.log(num);
          console.log(token);
          if (token === "+") {
            ans += num;
          } else if (token === "-") {
            ans -= num;
          } else if (token === "*") {
            ans *= num;
          } else if (token === "/") {
            ans /= num;
          }
          console.log(ans);
        }
      }
    }
    return ans;
  }
}

let sol = new Solution();

tokens = ["2", "1", "+", "3", "*"];

console.log(sol.evalRPN(tokens));
