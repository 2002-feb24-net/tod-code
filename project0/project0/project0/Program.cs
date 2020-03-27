using System;

namespace Project0
{
    /// <summary>
    /// literally just runs the console, nothing else
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var startConsole = new MenuConsole();
            startConsole.IntroMenu();
        }
    }
}
/*
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.data.Entities
{
    public static class secretconfig
    {
        internal static string path = "Server=tcp:training-tshjones.database.windows.net,1433;Initial Catalog=restaurant;Persist Security Info=False;User ID=Gwyrddu;Password=****;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
*/
