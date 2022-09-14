using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Menu.home();
        }
        public static void PrintColorMessage(ConsoleColor color, string message)
        {
            //Change text color
            Console.ForegroundColor = color;

            //app header
            Console.WriteLine(message);

            //Go back to default color
            Console.ResetColor();
        }

    }



}