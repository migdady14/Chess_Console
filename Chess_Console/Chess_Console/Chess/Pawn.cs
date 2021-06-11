using System;
using Chess_Console.Board;
using Chess_Console.Board.Enum;

namespace Chess_Console.Chess
{
    class Pawn : Piece
    {
        public ChessMatch Match { get; set; }

        public Pawn(Color color, ChessBoard board, ChessMatch match) : base(color, board)
        {
            Match = match;
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

            if (Color == Color.White)
            {

                // North.
                pos.SetValues(Position.Column, Position.Row - 1);
                if (Board.ValidPosition(pos) && CanMoveForward(pos))
                {
                    mat[pos.Column, pos.Row] = true;
                }
                // North2.
                pos.SetValues(Position.Column, Position.Row - 2);
                if (Board.ValidPosition(pos) && CanMoveForward(pos) && MoveCount == 0)
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

                // #SpecialMove En Passant
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Column - 1, Position.Row);
                    if (Board.ValidPosition(left) && CanMoveDiagonal(left) && Board.Piece(left) == Match.EnPassant)
                    {
                        mat[left.Column, left.Row - 1] = true;
                    }

                    Position right = new Position(Position.Column + 1, Position.Row);
                    if (Board.ValidPosition(right) && CanMoveDiagonal(right) && Board.Piece(right) == Match.EnPassant)
                    {
                        mat[right.Column, right.Row - 1] = true;
                    }
                }
            }
            else
            {

                // South.
                pos.SetValues(Position.Column, Position.Row + 1);
                if (Board.ValidPosition(pos) && CanMoveForward(pos))
                {
                    mat[pos.Column, pos.Row] = true;
                }
                // South2.
                pos.SetValues(Position.Column, Position.Row + 2);
                if (Board.ValidPosition(pos) && CanMoveForward(pos) && MoveCount == 0)
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

                // #SpecialMove En Passant
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Column - 1, Position.Row);
                    if (Board.ValidPosition(left) && CanMoveDiagonal(left) && Board.Piece(left) == Match.EnPassant)
                    {
                        mat[left.Column, left.Row - 1] = true;
                    }
                
                    Position right = new Position(Position.Column + 1, Position.Row);
                    if (Board.ValidPosition(right) && CanMoveDiagonal(right) && Board.Piece(right) == Match.EnPassant)
                    {
                        mat[right.Column, right.Row + 1] = true;
                    }
                }

            }
            return mat;
        }


    }
}