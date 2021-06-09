using System;
using Chess_Console.Board;
using Chess_Console.Board.Enum;

namespace Chess_Console.Chess
{
    class Knight : Piece
    {
        public Knight(Color color, ChessBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            if (Color == Color.White)
            {
                return "\u265e";
            }
            return "\u2658";
        }
        public override bool[,] AvailableMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            // North1.
            pos.SetValues(Position.Column - 1, Position.Row - 3);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // Nort2.
            pos.SetValues(Position.Column + 1, Position.Row - 3);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // East1.
            pos.SetValues(Position.Column + 3, Position.Row - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // East2.
            pos.SetValues(Position.Column + 3, Position.Row + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // South1.
            pos.SetValues(Position.Column + 1, Position.Row + 3);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // South2.
            pos.SetValues(Position.Column - 1, Position.Row + 3);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // West1.
            pos.SetValues(Position.Column - 3, Position.Row + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // West2.
            pos.SetValues(Position.Column - 3, Position.Row - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            return mat;
        }
    }
}
