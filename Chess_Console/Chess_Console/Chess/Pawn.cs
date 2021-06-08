using System;
using Chess_Console.Board;
using Chess_Console.Board.Enum;

namespace Chess_Console.Chess
{
    class Pawn : Piece
    {
        public Pawn(Color color, ChessBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
