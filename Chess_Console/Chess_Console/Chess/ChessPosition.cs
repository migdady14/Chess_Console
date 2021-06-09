using Chess_Console.Board;

namespace Chess_Console.Chess
{
    class ChessPosition
    {
        public int Row { get; set; }
        public char Column { get; set; }

        public ChessPosition()
        {
        }

        public ChessPosition(char column, int row)
        {
            Row = row;
            Column = column;
        }

        public Position ToPosition()
        {
            return new Position(Column - 'a', 8 - Row);
        }

        public override string ToString()
        {
            return "" + Column + Row;
        }
    }
}
