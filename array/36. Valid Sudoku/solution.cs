public class Solution {
    public bool IsValidSudoku(char[][] board) {
        
        //check row
        for(int i=0; i<9; i++){
            HashSet<char> set = new HashSet<char>();
            for(int j=0; j<9; j++){
                if(set.Contains(board[i][j])){
                    return false;
                }
                if(board[i][j]!='.'){
                    set.Add(board[i][j]);
                }
            }        
        }
        
        //check col
        for(int i=0; i<9; i++){
            HashSet<char> set = new HashSet<char>();
            for(int j=0; j<9; j++){
                if(set.Contains(board[j][i]))
                    return false;
                if(board[j][i]!='.')
                    set.Add(board[j][i]);
            }        
        }
        
        //check matrix
        for(int i=0; i<9; i++){
            int sr = i/3;
            int sc = i%3;
            HashSet<char> set = new HashSet<char>();
            for(int r = sr*3;r<sr*3+3;r++)
            {
                for(int c = sc*3;c<sc*3+3;c++){
                    if(set.Contains(board[r][c]))
                        return false;
                    if(board[r][c]!='.')
                        set.Add(board[r][c]);
                }
            }
        }
        
        return true;
    }
}