//-----------------------------------------------------------------------------
// (c) 2020 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace ArduinoShell
{
    [Serializable]
    public class ShellException : Exception
    {
        public ShellException() : base()
        {
        }

        public ShellException(string message) : base(message)
        {
        }

        public ShellException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ShellException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
