using System;
using System.IO;

namespace LinksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManipulateWithLinks.FileExistence();
            Navigate.MainMenu();
            
            Console.Read();
        }
        
    }
}