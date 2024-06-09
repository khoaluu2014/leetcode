class Solution {
  /**
   * @param {character[][]} board
   * @return {boolean}
   */
  isValidSudoku(board) {
    let row = Array.from({ length: 9 }, () => new Set());
    let col = Array.from({ length: 9 }, () => new Set());
    let box = Array.from({ length: 9 }, () => new Set());

    for (let i = 0; i < 9; i++) {
      for (let j = 0; j < 9; j++) {
        let num = board[i][j];
        let box_num = Math.floor(i / 3) * 3 + Math.floor(j / 3);
        if (num == ".") {
          continue;
        } else if (
          row[i].has(num) ||
          col[j].has(num) ||
          box[box_num].has(num)
        ) {
          return false;
        }
        row[i].add(num);
        col[j].add(num);
        box[box_num].add(num);
      }
    }
    return true;
  }
}
