namespace Chess_Console.Board
{
    class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position()
        {
        }

        public Position(int column, int row)
        {
            Row = row;
            Column = column;
        }

        public void SetValues(int column, int row)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return $"{Row}, {Column}";
        }
    }
}
