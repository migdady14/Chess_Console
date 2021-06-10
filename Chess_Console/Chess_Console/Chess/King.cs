using System;
using Chess_Console.Board;
using Chess_Console.Board.Enum;

namespace Chess_Console.Chess
{
    class King : Piece
    {
        private ChessMatch Match { get; set; }

        public King(Color color, ChessBoard board, ChessMatch match) : base(color, board)
        {
            Match = match;
        }

        public override string ToString()
        {
            if (Color == Color.White)
            {
                return "\u265a";
            }
            return "\u2654";
        }

        private bool TestCastling(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p is Rook && p.Color == Color && p.MoveCount == 0;
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

            // #SpecialMove Castling!
            if (MoveCount == 0 && !Match.Check)
            {
                Position posR1 = new Position(Position.Column + 3, Position.Row);
                if (TestCastling(posR1))
                {
                    Position p1 = new Position(Position.Column + 1, Position.Row);
                    Position p2 = new Position(Position.Column + 2, Position.Row);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null)
                    {
                        mat[Position.Column + 2, Position.Row] = true;
                    }
                }
                Position posR2 = new Position(Position.Column + 3, Position.Row);
                if (TestCastling(posR2))
                {
                    Position p1 = new Position(Position.Column - 1, Position.Row);
                    Position p2 = new Position(Position.Column - 2, Position.Row);
                    Position p3 = new Position(Position.Column - 3, Position.Row);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                    {
                        mat[Position.Column - 2, Position.Row] = true;
                    }
                }
            }

            return mat;
        }
    }
}
