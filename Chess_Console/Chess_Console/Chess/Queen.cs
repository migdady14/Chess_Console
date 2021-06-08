using System;
using Chess_Console.Board;
using Chess_Console.Board.Enum;

namespace Chess_Console.Chess
{
    class Queen : Piece
    {
        public Queen(Color color, ChessBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
