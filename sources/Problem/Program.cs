// C# Pills 15mg
// Copyright (C) 2021 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;

namespace DustInTheWind.VirtualInConstructor.Problem
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