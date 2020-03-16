// class is to handle console IO for entering items into file io and pullng up menu
// maybe add interface when multiple io consoles needed

using System;

namespace restaurant
{
    public static class MenuConsole
    {
        
        public static void AddMenuItemConsole()
        {
            Console.WriteLine("Enter name of food:");
            string name = Console.ReadLine();
            Console.WriteLine(name);
        }


    }
    
}