
namespace Chess_Console.Board
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Piece[,] pieces;

        public Board()
        {
        }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new Piece[Rows, Columns];
        }
    }
}
