using System;
using Chess_Console.Board;
using Chess_Console.Board.Enum;

namespace Chess_Console.Chess
{
    class Bishop : Piece
    {
        public Bishop(Color color, ChessBoard board) : base(color, board)
        {
        }

        public override string ToString()
        {
            if (Color == Color.White)
            {
                return "\u265d";
            }
            return "\u2657";
        }

        public override bool[,] AvailableMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            // Northeast.
            pos.SetValues(Position.Column + 1, Position.Row - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
                pos.Row = pos.Row - 1;
            }
            // Southeast.
            pos.SetValues(Position.Column + 1, Position.Row + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
                pos.Row = pos.Row +  1;
            }
            // Southwest.
            pos.SetValues(Position.Column - 1, Position.Row + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row + 1;
                pos.Column = pos.Column - 1;
            }
            // Northwest.
            pos.SetValues(Position.Column - 1, Position.Row - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Column, pos.Row] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row - 1;
                pos.Column = pos.Column - 1;
            }
            return mat;
        }
    }
}
