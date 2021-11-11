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

namespace DustInTheWind.VirtualInConstructor.Solution.TwoStepInitialization
{
    internal abstract class Base
    {
        // (3)
        // Add a property to keep track if the instance was fully initialized or not.
        //
        // The property is protected to be accessible to the derived classes.
        // This will be needed later so that the derived classes can prevent
        // public calls if the instance is not fully instantiated.
        protected bool IsInitialized { get; private set; }

        public int Length { get; private set; }

        protected Base()
        {
            // (1)
            // The call to "CalculateLength" (the virtual method) is removed from the constructor.
        }

        public void Initialize()
        {
            // (2)
            // The call to "CalculateLength" (the virtual method) is moved in a second
            // method (the second step of the initialization).
            // 
            // This second method must be called manually after the object is constructed,
            // to complete the two-step initialization.
            Length = CalculateLength();

            // (4)
            // Mark that the initialization is complete.
            IsInitialized = true;
        }

        protected virtual int CalculateLength()
        {
            return 0;
        }

        public void DoSomethingBase()
        {
            // (5)
            // Protect every public method so that it cannot be called if object is not fully initialized.
            //
            // Next: Go to "Derived" class.
            if (!IsInitialized)
                throw new NotInitializedException(GetType());

            // Do some stuff
            // ...
        }
    }
}