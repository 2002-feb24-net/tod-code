using System;

namespace database
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Server=tcp:training-tshjones.database.windows.net,1433;Initial Catalog=training;Persist Security Info=False;User ID=Gwyrddu;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
        }
    }
}
