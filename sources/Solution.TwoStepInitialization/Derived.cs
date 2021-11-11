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

namespace DustInTheWind.VirtualInConstructor.Solution.TwoStepInitialization
{
    internal class Derived : Base
    {
        private readonly string value;

        public Derived(string value)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));
        }

        protected override int CalculateLength()
        {
            return value.Length;
        }

        public void DoSomethingDerived()
        {
            // (6)
            // Protect every public method so that it cannot be called if object is not fully initialized.
            if (!IsInitialized)
                throw new NotInitializedException(GetType());

            // Do some more stuff
            // ...
        }
    }
}