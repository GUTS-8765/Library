using System;

namespace BookTracker
{
    public class InvalidBookDataException : Exception
    {
        public InvalidBookDataException(string message) : base(message) { }
    }
}