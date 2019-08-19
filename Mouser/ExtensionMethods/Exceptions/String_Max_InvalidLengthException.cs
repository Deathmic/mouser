using System;

namespace Mouser.ExtensionMethods.Exceptions
{
    public class String_Max_InvalidLengthException : Exception
    {
        public String_Max_InvalidLengthException(string sMessage) : base(sMessage)
        {
        }
    }
}