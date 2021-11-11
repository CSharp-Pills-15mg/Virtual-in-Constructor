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
    internal class Derived : Base
    {
        // (2)
        // The "value" field is declared read-only.
        // And, being initialized in the constructor, it should never be null, right?
        private readonly string value;

        public Derived(string value)
        {
            // (3)
            // The "value" field is initialized with a non-null value.
            // That means it should never be null, right?
            this.value = value ?? throw new ArgumentNullException(nameof(value));
        }

        protected override int CalculateLength()
        {
            // (4)
            // This method is called from the constructor of the base class.
            // At this point, the constructor of the "Derived" class is not yet called,
            // so "value" is still null ...
            //
            // ... crush, boom, bang !!!

            return value.Length;
        }
    }
}