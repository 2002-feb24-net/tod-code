using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            bool readyToQuit = false;
            RockPaperScissorsGame game = new RockPaperScissorsGame();
            
            Console.WriteLine("Do you want to play a round? ");
            string input = Console.ReadLine();

        while(!readyToQuit)
        {

            if (input == "n")
            {
                readyToQuit = true;
            }
            else
            {
                readyToQuit = game.PlayRound();
                // that method should play a round and print the results
            }
        }
        game.PrintSummary();
        // that method should print out a summar of a round
        // how many wins, how many losses
    }
}
}
