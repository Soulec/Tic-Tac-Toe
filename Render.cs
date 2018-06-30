using System;
using System.Linq.Expressions;

namespace tictactoe
{
    class Render
    {
        public Render(Board board)
        {
            renderBoard(board);
        }

        public string lastField { get; private set; }

        public void renderBoard(Board board)
        {
            Console.Clear();
            // print board using field array
            Console.WriteLine(
                $"     |     |     \n" +
                $"  {board.field[0,0]}  |  {board.field[0, 1]}  |  {board.field[0, 2]}  \n" +
                $"_____|_____|_____\n" +
                $"     |     |     \n" +
                $"  {board.field[1, 0]}  |  {board.field[1, 1]}  |  {board.field[1, 2]}  \n" +
                $"_____|_____|_____\n" +
                $"     |     |     \n" +
                $"  {board.field[2, 0]}  |  {board.field[2, 1]}  |  {board.field[2, 2]}  \n" +
                $"     |     |     \n"
            );

        }

        internal void renderBoard(int userInput, Player player, Board board)
        {
            // check each field in field array and check if it is equal to the players input
            // then replace that field with the users playtoken (X or O) and render a new board
            for (int i = 0; i < board.field.GetLength(1); i++)
            {
                for (int x = 0; x < board.field.GetLength(1); x++)
                {
                    if (userInput.ToString() == board.field[i, x])
                    {
                        board.field[i, x] = getPlaytoken(player);
                        renderBoard(board);
                        lastField = $"{i}, {x}"; // save the last play for later use in win condition method
                        return;
                    }
                }
            }            
                     
            throw new ArgumentException(); //Throw an Exception if the player tries to change a field that already has a player token in it    
        }

        public string getPlaytoken(Player player)
        {
            switch (player.PlayerTurn)
            {
                case 1:
                    return "O";
                case 2:
                    return "X";
                default:
                    return null;
            }
        }
    }
}