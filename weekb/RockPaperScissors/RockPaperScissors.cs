using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    class Score
    {
        private char playerChoice;
        public char compChoice;
        private int round;

        public int win;
            public void AddScore(char player, char comp, int num)
        {
            playerChoice = player;
            compChoice = comp;
            round = num;
            CalculateWin();
        }

        private void CalculateWin()
        {
            if(playerChoice == compChoice)
                win = 0;
            else if(playerChoice == 'r' && compChoice == 's')
                win = 1;
            else if (playerChoice == 's' && compChoice == 'p')
                win = 1;
            else if (playerChoice == 'p' && compChoice == 'r')
                win = 1;
            else if (playerChoice == 's' && compChoice == 'r')
                win = 2;
            else if (playerChoice == 'r' && compChoice == 'p')
                win = 2;
            else if (playerChoice == 'p' && compChoice == 'r')
                win = 2; 
            else
                win = -1;
        }

    }
    public class RockPaperScissorsGame
    {
        public int compWins=0;    
        public int humanWins=0;

        public int ties=0;

        List <Score> scoreList = new List <Score>();
        public bool PlayRound ()
        {
            int roundCount = ties + compWins + humanWins + 1;
            Console.WriteLine($"Round {roundCount}");
            Console.WriteLine("Rock Paper Scissors says shoot (press R,P, S):");
            char choice = Console.ReadLine()[0];
            choice = char.ToLower(choice);
            char comp = CompRandom.DecideMove(); 
            if (choice == 'q')
                return true;
            Score roundScore = new Score();
            roundScore.AddScore(choice, comp, roundCount);
            winner(roundScore.win, roundScore.compChoice );
            if(roundScore.win != -1)
                scoreList.Add(roundScore);
            return false;
        

        }

        private void winner(int win, char compChoice)
        {
            if(win == 1)
            {
                Console.WriteLine("You won!");
                humanWins++;
            }
            else if (win == 2)
            {
                Console.WriteLine("You lost!");
                compWins++;
            }
            else if (win == 0)
            {
                Console.WriteLine("It's a tie!");
                ties++;
            }
            else if (win == -1)
            {
                Console.WriteLine("Please press 'r','p', or 's' or 'q'");
            }
            if (compChoice == 'r')
                Console.WriteLine("Computer choose rock.");
            else if (compChoice == 's')
                Console.WriteLine("Computer choose scissors");
            else if (compChoice == 'p')
                Console.WriteLine("Computer choose paper");
            
        }
        
        public void PrintSummary()
        {
            Console.WriteLine("Summary:");
            int playWins = 0;
            int computerWins = 0;
            int roundTies = 0;
            foreach(var roundSum in scoreList)
            {
                if(roundSum.win == 1)
                    playWins++;
                else if (roundSum.win == 2)
                    computerWins++;
                else if (roundSum.win == 0)
                    roundTies++;
            }

            Console.WriteLine($"Player Wins: {playWins}");
            Console.WriteLine($"Computer Wins: {computerWins}");
            Console.WriteLine($"Ties: {roundTies}");

            if (humanWins > compWins)
                Console.WriteLine("Player won majority of games");
            else if (compWins > humanWins)
                Console.WriteLine("Computer won majority of the games");
            else
                Console.WriteLine("Games were a tie");
        }
    }
}

