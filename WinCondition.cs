using System;
using System.Diagnostics;

namespace tictactoe
{
    class WinCondition
    {
        internal bool CheckWinCondition(Board board, Render render, Player player)
        {
            var fieldString = render.lastField.Split(','); //split field coordinates and put them into variables
            int boardRow = int.Parse(fieldString[0]);
            int boardColumn = int.Parse(fieldString[1]);
            string playToken = render.getPlaytoken(player);

            for (int i = 0; i < 4; i++) // 4 loops: horizontal, vertical and two times diagonal
                if (checkForWin(i, boardRow, boardColumn, board, playToken) == 3)
                    return true;

            return false;
        }


        private int checkForWin(int check, int boardRow, int boardColumn, Board board, string playToken)
        {
            int counter = 0; // if counter = 3 -> 3 in a row -> win

            for (int i = 0; i < board.field.GetLength(1); i++) //loop each time
            {
                switch (check) // check used to get into each case
                {
                    case 1: // Vertical
                        if (board.field[i, boardColumn] == playToken)
                            counter++;
                        break;
                    case 2: // Horizontal
                        if (board.field[boardRow, i] == playToken)
                            counter++;
                        break;
                    case 3: // Diagonal: Right to Left
                        if (board.field[i, i] == playToken)
                            counter++;
                        break;
                    case 4: // Diagonal: Left to Right
                        if (board.field[i, 2 - i] == playToken)
                            counter++;
                        break;
                }
            }
            return counter;
        }
    }
}
