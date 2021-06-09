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
            if (Color == Color.White)
            {
                return "\u265f";
            }
            return "\u2659";
        }

        private bool CanMoveForward(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null;
        }
        private bool CanMoveDiagonal(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p.Color != this.Color;
        }


        public override bool[,] AvailableMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            switch(Color)
            {
                case Color.Black:
                    // South.
                    pos.SetValues(Position.Column, Position.Row + 1);
                    if (Board.ValidPosition(pos) && CanMoveForward(pos))
                    {
                        mat[pos.Column, pos.Row] = true;
                    }
                    // Southeast.
                    pos.SetValues(Position.Column + 1, Position.Row + 1);
                    if (Board.ValidPosition(pos) && CanMoveDiagonal(pos))
                    {
                        mat[pos.Column, pos.Row] = true;
                    }
                    // Southwest.
                    pos.SetValues(Position.Column - 1, Position.Row + 1);
                    if (Board.ValidPosition(pos) && CanMoveDiagonal(pos))
                    {
                        mat[pos.Column, pos.Row] = true;
                    }
                    break;
                case Color.White:
                    // North.
                    pos.SetValues(Position.Column, Position.Row - 1);
                    if (Board.ValidPosition(pos) && CanMoveForward(pos))
                    {
                        mat[pos.Column, pos.Row] = true;
                    }
                    // Northeast.
                    pos.SetValues(Position.Column + 1, Position.Row - 1);
                    if (Board.ValidPosition(pos) && CanMoveDiagonal(pos))
                    {
                        mat[pos.Column, pos.Row] = true;
                    }
                    // Northwest.
                    pos.SetValues(Position.Column - 1, Position.Row - 1);
                    if (Board.ValidPosition(pos) && CanMoveDiagonal(pos))
                    {
                        mat[pos.Column, pos.Row] = true;
                    }
                    break;
            }
            
            return mat;
        }
    }
}
