using System;
using System.IO;

namespace LinksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //C:/Users/gushcbog/Desktop/Links.xml
            
            ManipulateWithLinks.FileExistence();
            Navigate.MainMenu();
            
            Console.Read();
        }
        
    }
}