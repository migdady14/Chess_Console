using System;
using Chess_Console.Board;
using Chess_Console.Board.Enum;

namespace Chess_Console.Chess
{
    class Rook : Piece
    {
        public Rook(Color color, ChessBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            if (Color == Color.White)
            {
                return "\u265c";
            }
            return "\u2656";
        }

        public override bool[,] AvailableMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            // North.
            pos.SetValues(Position.Column, Position.Row - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row - 1;
            }
            // East.
            pos.SetValues(Position.Column + 1, Position.Row);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }
            // South.
            pos.SetValues(Position.Column, Position.Row + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row + 1;
            }
            // West.
            pos.SetValues(Position.Column - 1, Position.Row);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }
            return mat;
        }
    }
}
