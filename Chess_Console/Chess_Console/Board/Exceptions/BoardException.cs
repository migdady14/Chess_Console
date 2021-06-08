using System;

namespace Chess_Console.Board.Exceptions
{
    class BoardException : Exception
    {
        public BoardException(string msg) : base(msg)
        {
        }
    }
}
