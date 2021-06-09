using System;
using Chess_Console.Board;
using Chess_Console.Board.Enum;

namespace Chess_Console.Chess
{
    class King : Piece
    {
        public King(Color color, ChessBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            if (Color == Color.White)
            {
                return "\u265a";
            }
            return "\u2654";
        }

        public override bool[,] AvailableMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            // North.
            pos.SetValues(Position.Column, Position.Row - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // Northeast.
            pos.SetValues(Position.Column +1, Position.Row - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // East.
            pos.SetValues(Position.Column + 1, Position.Row);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // Southeast.
            pos.SetValues(Position.Column + 1, Position.Row + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // South.
            pos.SetValues(Position.Column, Position.Row + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // Southwest.
            pos.SetValues(Position.Column - 1, Position.Row + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // West.
            pos.SetValues(Position.Column - 1, Position.Row);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            // Northwest.
            pos.SetValues(Position.Column - 1, Position.Row - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
            }
            return mat;
        }
    }
}
