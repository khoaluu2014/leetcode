from typing import List

class Solution:
    def isValidSudoku(self, board: List[List[str]]) -> bool:
        row = [set() for _ in range(9)] 
        col = [set() for _ in range(9)] 
        box = [set() for _ in range(9)] 
        for i in range(9):
            for j in range(9):
                num = board[i][j]
                box_index = (i//3) * 3 + j//3
                if num == ".":
                    continue
                if (num in row[i]) or (num in col[j]) or (num in box[box_index]):
                    return False
                row[i].add(num)
                col[j].add(num)
                box[box_index].add(num)

        return True

def main():
    sol = Solution()
    board = [["5","3",".",".","7",".",".",".","."],
             ["6",".",".","1","9","5",".",".","."],
             [".","9","8",".",".",".",".","6","."],
             ["8",".",".",".","6",".",".",".","3"],
             ["4",".",".","8",".","3",".",".","1"],
             ["7",".",".",".","2",".",".",".","6"],
             [".","6",".",".",".",".","2","8","."],
             [".",".",".","4","1","9",".",".","5"],
             [".",".",".",".","8",".",".","7","9"]]
    ans = sol.isValidSudoku(board)
    print(ans)

if __name__ == "__main__":
    main()