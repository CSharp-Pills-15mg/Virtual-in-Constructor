using System;

namespace Nagarro.VirtualInConstructor.Problem
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