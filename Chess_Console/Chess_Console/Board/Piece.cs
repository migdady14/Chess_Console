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
    }
}
