using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Board
    {
        private string[,] board = { { "1", "2", "3" },
                                    { "4", "5", "6" },
                                    { "7", "8", "9" } };

        public void PrintBoard()
        {
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" " + board[0, 0] + " | " + board[0, 1] + " | " + board[0, 2] + " ");
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" " + board[1, 0] + " | " + board[1, 1] + " | " + board[1, 2] + " ");
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" " + board[2, 0] + " | " + board[2, 1] + " | " + board[2, 2] + " ");
            Console.WriteLine("   |   |   ");
        }

        // Try to put "mark" at position "posiiton" on the board
        // Returns true if successful and false if not
        public bool PlaceMark(string mark)
        {
            Console.WriteLine("Enter an integer between 1 and 9");
            // 1 2 3
            // 4 5 6
            // 7 8 9

            string position_string = Console.ReadLine();

            int position;

            if (!int.TryParse(position_string, out position))
            {
                Console.WriteLine("Your input must be an integer between 1 and 9!");
                Console.WriteLine();
                return false;
            }

            int i = (position - 1) / 3;
            int j = (position - 1) % 3;

            if ((!mark.Equals("O")) && (!mark.Equals("X"))) {
                Console.WriteLine("Invalid Symbol!");
                Console.WriteLine();
                return false;
            }
            else if (i < 0 || i > 2 || j < 0 || j > 2)
            {
                Console.WriteLine("That position is out of bounds!");
                Console.WriteLine();
                return false;
            }
            else if (board[i, j].Equals("O") || board[i, j].Equals("X"))
            {
                Console.WriteLine("That spot is taken already!");
                Console.WriteLine();
                return false;
            }
            else
            {
                board[i, j] = mark;
                return true;
            }
        }

        // Tells you if a player won, if the game is drawn, or if the game is ongoing.
        // Returns true if the game is over, and false if it has not
        public bool CheckBoard()
        {
            Console.WriteLine();

            // Check for a horizontal victory
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 1; j < board.GetLength(1); j++)
                {
                    if (!board[i, j].Equals(board[i, j - 1])) {
                        // There was no victory in this row
                        break;
                    }

                    if (j == board.GetLength(1) - 1)
                    {
                        // All entries in this row are the same
                        PrintBoard();
                        Console.WriteLine($"Player {board[i, j]} has won!");
                        return true;
                    }
                }
            }

            // Check for a vertical victory
            for (int j = 0; j < board.GetLength(1); j++)
            {
                for (int i = 1; i < board.GetLength(0); i++)
                {
                    if (!board[i, j].Equals(board[i - 1, j])) {
                        // There was no victory in this coumn
                        break;
                    }

                    if (i == board.GetLength(0) - 1)
                    {
                        // All entries in this column are the same
                        PrintBoard();
                        Console.WriteLine($"Player {board[i, j]} has won!");
                        return true;
                    }
                }
            }

            int min_side_length = Math.Min(board.GetLength(0), board.GetLength(1));

            // Check for a victory diagonally (from top left to bottom right)
            for (int i = 1; i < min_side_length; i++)
            {
                if (!board[i, i].Equals(board[i - 1, i - 1]))
                {
                    // Not all diagonal marks are equal
                    break;
                }

                if (i == min_side_length - 1)
                {
                    // All marks in this diagonal are equal
                    PrintBoard();
                    Console.WriteLine($"Player {board[i, i]} has won!");
                    return true;
                }
            }

            // Check for a victory diagonally (from top right to bottom left)
            for (int i = 1; i < min_side_length; i++)
            {
                if (!board[i, min_side_length - 1 - i].Equals(board[i - 1, min_side_length - 1 - (i - 1)]))
                {
                    // Not all diagonal marks are equal
                    break;
                }

                if (i == min_side_length - 1)
                {
                    // All marks in this diagonal are equal
                    PrintBoard();
                    Console.WriteLine($"Player {board[i, min_side_length - 1 - i]} has won!");
                    return true;
                }
            }

            // Check for a tie
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if ((!board[i, j].Equals("O")) && (!board[i, j].Equals("X")))
                    {
                        // There is at least one empty square left, so continue.
                        return false;
                    }
                }
            }

            // There are no empty squares left, so the game is tied
            PrintBoard();
            Console.WriteLine("There is a draw!");
            return true;
        }
    }
}
