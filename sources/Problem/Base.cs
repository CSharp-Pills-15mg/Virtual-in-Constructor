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

namespace DustInTheWind.VirtualInConstructor.Problem
{
    internal class Base
    {
        public int Length { get; }

        protected Base()
        {
            // (1)
            // A call to the "CalculateLength" method doesn't seem to be nothing wrong, isn't it?
            // But, with the current implementation of the "Derived" class and because of the order
            // in which the constructors are called, this code will crush.
            //
            // Next: Go to "Derived" class.

            Length = CalculateLength();
        }

        protected virtual int CalculateLength()
        {
            return 0;
        }
    }
}