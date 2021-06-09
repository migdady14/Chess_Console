using Chess_Console.Board.Enum;

namespace Chess_Console.Board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MoveCount { get; protected set; }
        public ChessBoard Board { get; protected set; }

        public Piece()
        {
        }

        public Piece(Color color, ChessBoard board)
        {
            Position = null;
            Color = color;
            Board = board;
            MoveCount = 0;
        }

        public void IncreaseMoveCount()
        {
            MoveCount++;
        }

        public abstract bool[,] AvailableMoves();

        public bool VerifyMovement()
        {
            bool[,] mat = AvailableMoves();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected bool CanMove(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != this.Color;
        }

        public bool CanMoveTo(Position pos)
        {
            return AvailableMoves()[pos.Column, pos.Row];
        }

    }
}
