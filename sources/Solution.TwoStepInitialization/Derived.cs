using System;

namespace Nagarro.VirtualInConstructor.Solution.TwoPhaseConstruction
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