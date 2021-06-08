using Chess_Console.Board.Enum;

namespace Chess_Console.Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MoveCount { get; protected set; }
        public ChessBoard Board { get; protected set; }

        public Piece()
        {
        }

        public Piece(Position position, Color color, ChessBoard board)
        {
            Position = position;
            Color = color;
            Board = board;
            MoveCount = 0;
        }
    }
}
