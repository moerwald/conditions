using System;
using System.Runtime.Serialization;

namespace Conditions.PreConditions
{
    [Serializable]
    internal class PreConditionFailedException : Exception
    {
        public PreConditionFailedException()
        {
        }

        public PreConditionFailedException(string message) : base(message)
        {
        }

        public PreConditionFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PreConditionFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}