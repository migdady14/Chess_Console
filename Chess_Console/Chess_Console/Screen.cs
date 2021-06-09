using System;
using Chess_Console.Board;
using Chess_Console.Chess;

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
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("     (A) (B) (C) (D) (E) (F) (G) (H)");
        }
        public static void PrintBoard(ChessBoard board, bool[,] possiblePositions)
        {
            ConsoleColor originalBK = Console.BackgroundColor;
            ConsoleColor customBK = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                int chessP = board.Rows - i;
                Console.Write("(#" + chessP + ") ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[j, i])
                    {
                        Console.BackgroundColor = customBK;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBK;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBK;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("     (A) (B) (C) (D) (E) (F) (G) (H)");
            Console.BackgroundColor = originalBK;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("[ ] ");
            }
            else
            {
                Console.Write($"[{piece}] ");
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }
    }
}
