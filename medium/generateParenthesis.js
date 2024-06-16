class Solution {
  generateParenthesis(n) {
    const res = [];

    this.backtrack(n, 0, 0, "", res);
    return res;
  }
  backtrack(n, openN, closedN, current, res) {
    if (openN === closedN && openN === n) {
      res.push(current);
      return;
    }
    if (openN < n) {
      this.backtrack(n, openN + 1, closedN, current + "(", res);
    }
    if (closedN < openN) {
      this.backtrack(n, openN, closedN + 1, current + ")", res);
    }
  }
}
