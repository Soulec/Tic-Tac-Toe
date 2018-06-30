using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameWon = false;

            while (!gameWon)
            {
                Player player = new Player(); // default: player 1
                Board board = new Board(); // constructor creates a board array with default values (3x3 Array)
                Render render = new Render(board); // use constructor of Render class to build up the board
                WinCondition winCondition = new WinCondition();
                var numberOfTurns = 0; //tracks number of turns (tic tac toe maximum 9 turns)
                
                render.renderBoard(board);

                while (!gameWon) // end program once game is finished
                {
                    PrintMessage(player); // print out whose turn it is

                    try
                    {                       
                        var userInput = GetUserInput(); //get input and parse to number | also check if valid input
                        render.renderBoard(userInput, player, board); // use board object with default values to setup the game 
                        
                        gameWon = winCondition.CheckWinCondition(board, render, player); //Method returns true if the player got 3 in a row
                        if (gameWon)
                        {
                            Console.WriteLine($"Player {player.PlayerTurn} wins! \n");
                            break;
                        }

                        player.SwapPlayersTurn();
                        numberOfTurns++; // end of turn
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine("\nInvalid Input! Please enter a number between 1 and 9\n");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("\nInvalid Input! Please use another field!\n");
                    }

                    if (numberOfTurns == 9)
                    {
                        Console.WriteLine("Draw!\n");
                        break;
                    }
                }

                Console.WriteLine("Play another round? Y/N");

                if (Console.ReadLine() == "Y")  // set gameWon to false to restart the while loop and start a new game
                {
                    gameWon = false;
                }
            }

        }

        private static int GetUserInput()
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                if (number > 0 && number < 10) // tic tac toe has 9 fields, so anything out of range would result in an invalid move
                    return number;
                if (number < 1 || number > 9)
                    throw new ArgumentOutOfRangeException();
            }

            throw new ArgumentException();

        }

        private static void PrintMessage(Player player)
        {
            Console.Write($"Player {player.PlayerTurn}: Choose your field! ");
        }
    }
}
