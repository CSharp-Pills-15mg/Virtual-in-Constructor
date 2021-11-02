using System;

namespace Nagarro.VirtualInConstructor.Solution.TwoPhaseConstruction
{
    internal class NotInitializedException : Exception
    {
        private const string MessageTemplate = "Object '{0}' was not fully initialized.";

        public NotInitializedException(Type type)
            : base(string.Format(MessageTemplate, type.FullName))
        {
        }
    }
}