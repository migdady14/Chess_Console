using Chess_Console.Board.Exceptions;

namespace Chess_Console.Board
{
    class ChessBoard
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public ChessBoard()
        {
        }

        public ChessBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new Piece[Rows, Columns];
        }

        public Piece Piece(int row, int column)
        {
            return pieces[row, column];
        }

        public Piece Piece(Position pos)
        {
            return pieces[pos.Row, pos.Column];
        }

        public bool CheckPiece(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void InsertPiece(Piece p, Position pos)
        {
            if (CheckPiece(pos))
            { throw new BoardException("There's a piece on this position already"); }
            pieces[pos.Row, pos.Column] = p;
            p.Position = pos;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Row < 0 || pos.Row >= Rows || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
