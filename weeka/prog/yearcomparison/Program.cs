using System;

namespace yearcomparison
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your age in seconds: ");
            double ageinseconds = double.Parse(Console.ReadLine());
            double yourearthage = CalculateEarthAge(ageinseconds);
            double marsyear = yourearthage/1.9;
            double mercuryyear = yourearthage/.2;
            double venusyear = yourearthage/.6;
            double jupiteryear = yourearthage/11.9;
            double saturnyear = yourearthage/29.5;
            double uranusyear = yourearthage/84;
            double neptuneyear = yourearthage/164.8;
            
            Console.WriteLine($"Your age on Mercury is {Math.Round(mercuryyear,3)}");
            Console.WriteLine($"Your age on Venus is {Math.Round(venusyear,3)}");
            Console.WriteLine($"Your age on Earth is {Math.Round(yourearthage,3)}");
            Console.WriteLine($"Your age on Mars is {Math.Round(marsyear,3)}");
            Console.WriteLine($"Your age on Jupiter is {Math.Round(jupiteryear,3)}");
            Console.WriteLine($"Your age on Saturn is {Math.Round(saturnyear,3)}");
            Console.WriteLine($"Your age on Uranus is {Math.Round(uranusyear,3)}");
            Console.WriteLine($"Your age on Neptune is {Math.Round(neptuneyear,3)}");

            }
            static double CalculateEarthAge(double ageSeconds)
            {
                double earthSeconds = 31536000;
                return ageSeconds/earthSeconds;
            }
                    

                    

        
    }
}
