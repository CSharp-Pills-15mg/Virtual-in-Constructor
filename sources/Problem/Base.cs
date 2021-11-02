namespace Nagarro.VirtualInConstructor.Problem
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