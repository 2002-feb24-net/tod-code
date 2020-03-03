using System;

namespace RockPaperScissors
{
    class RockPaperScissorsGame
    {
        public int compWins=0;    
        public int humanWins=0;

        public int ties=0;


        public bool PlayRound ()
        {

            Console.WriteLine("Rock Paper Scissors says shoot (press R,P, S):");
            char choice = Console.ReadLine()[0];
            choice = char.ToLower(choice);
            char comp = CompChoice();
            if (choice == 'q')
                return true;
            if(choice == 'r' && comp == 's')
                winner(true);
            else if (choice == 's' && comp == 'p')
                winner(true);
            else if (choice == 'p' && comp == 'r')
                winner(true);
            else if (choice == 's' && comp == 'r')
                winner(false);
            else if (choice == 'r' && comp == 'p')
                winner(false);
            else if (choice == 'p' && comp == 'r')
                winner(false);
            else if (choice != 'r' && choice != 'p' && choice != 's')
                Console.WriteLine("Please choose either Rock, Paper or Scisor.");
            else
            { 
                Console.WriteLine("It was a tie");
                ties++;
            }
            return false;

        }

        private void winner(bool win)
        {
            if(win)
            {
                Console.WriteLine("You won!");
                humanWins++;
            }

            else
            {
                Console.WriteLine("You lost!");
                compWins++;
            }
        }
        private char CompChoice() 
        {
            Random rnd = new Random();
            int rndAnswer = rnd.Next(2);
            if (rndAnswer == 0)
                return 'r';
            if (rndAnswer == 1)
                return 'p';
            if (rndAnswer == 2)
                return 's';
            return 'r';            
        } 
        public void PrintSummary()
        {
            Console.WriteLine("Summary:");
            Console.WriteLine($"Player Wins: {humanWins}");
            Console.WriteLine($"Computer Wins: {compWins}");
            Console.WriteLine($"Ties: {ties}");
        }
    }
}

