﻿using System;
using System.Runtime.Serialization;

namespace HabiticaSimpleToDo
{
    [Serializable]
    internal class NoCredentialsException : Exception
    {
        public NoCredentialsException()
        {
        }

        public NoCredentialsException(string message) : base(message)
        {
        }

        public NoCredentialsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoCredentialsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}