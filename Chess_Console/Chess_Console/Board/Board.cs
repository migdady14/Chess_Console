
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

        public void insertPiece(Piece p, Position pos)
        {
            pieces[pos.Row, pos.Column] = p;
            p.Position = pos;
        }
    }
}
