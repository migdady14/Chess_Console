using System;
using Chess_Console.Board;

namespace Chess_Console
{
    class Screen
    {
        public static void PrintBoard(ChessBoard board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                int chessP = board.Rows - i;
                Console.Write("(#" + chessP + ") ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("[ ] ");
                    }
                    else
                    {
                        Console.Write($"[{board.Piece(i, j)}] ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("     (A) (B) (C) (D) (E) (F) (G) (H)");
        }
    }
}
