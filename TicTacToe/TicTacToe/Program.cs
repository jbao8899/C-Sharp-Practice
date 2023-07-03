namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter \"start\" to begin a game");
                Console.WriteLine("Enter anything else to quit");

                input = Console.ReadLine();

                // Did not choose to start a game
                if (!input.ToLower().Equals("start"))
                {
                    break; // from outer loop
                }

                Board board = new Board();
                string activePlayer = "O";

                while (true)
                {
                    board.PrintBoard();

                    Console.WriteLine($"It is player {activePlayer}'s turn.");

                    while (true)
                    {
                        // Keep asking where the mark should be placed, until it is put somewhere valid
                        bool placementWasValid = board.PlaceMark(activePlayer);
                        
                        if (placementWasValid)
                        {
                            break;
                        }
                    }

                    if (activePlayer.Equals("O"))
                    {
                        activePlayer = "X";
                    }
                    else
                    {
                        activePlayer = "O";
                    }
                    
                    if (board.CheckBoard())
                    {
                        // This game is over
                        break;
                    }
                }
            }
            //board.PrintBoard();

        }
    }
}