namespace Chess_Console.Board
{
    class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position()
        {
        }

        public Position(int line, int row)
        {
            Row = line;
            Column = row;
        }

        public override string ToString()
        {
            return $"{Row}, {Column}";
        }
    }
}
