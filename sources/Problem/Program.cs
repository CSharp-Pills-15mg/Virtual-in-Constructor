using System;

namespace Nagarro.VirtualInConstructor.Problem
{
    // This application demonstrates why it is not a good idea to call
    // abstract or virtual methods from the constructor.
    //
    // Next: Go to "Base" class.

    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Derived derived = new Derived("Alexandru Iuga");

                DisplaySuccess("Success");
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private static void DisplaySuccess(string text)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = oldColor;
        }

        private static void DisplayError(Exception exception)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exception);
            Console.ForegroundColor = oldColor;
        }
    }
}