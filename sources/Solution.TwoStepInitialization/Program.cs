using System;

namespace Nagarro.VirtualInConstructor.Solution.TwoPhaseConstruction
{
    // This application demonstrates how a virtual call in constructor can be avoided by
    // implementing a two step initialization.
    //
    // Next: Go to "Base" class.

    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Derived derived = new Derived("Alexandru Iuga");
                derived.Initialize();
                
                derived.DoSomethingBase();
                derived.DoSomethingDerived();

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