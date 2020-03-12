using System;

namespace RockPaperScissors
{
    public class CompRandom : ICompChoice
    {
        

        public static char DecideMove()
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
    }

}