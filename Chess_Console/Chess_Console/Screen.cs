using System;
using System.Collections.Generic;
using Chess_Console.Board.Enum;
using Chess_Console.Board.Exceptions;
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

        public void PrintMatch(ChessMatch match)
        {
            Console.Clear();
            PrintBoard(match.ChessBoard);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn);
            Console.WriteLine("Waiting movement from player: " + match.TurnsPlayer);
            if (match.Check)
            {
                Console.WriteLine();
                Console.WriteLine("!!!YOU ARE IN CHECK!!!");
            }

            Console.WriteLine();
            Console.Write("Start position: ");
            Position start = ReadChessPosition().ToPosition();
            if (start == null)
            {
                throw new BoardException("Please make a valid movement (eg: A1). Press ENTER to continue");
            }
            match.ValidateStartPosition(start);

            bool[,] possiblePositions = match.ChessBoard.Piece(start).AvailableMoves();

            Console.Clear();
            PrintBoard(match.ChessBoard, possiblePositions);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn);
            Console.WriteLine("Waiting movement from player: " + match.TurnsPlayer);


            Console.WriteLine();
            Console.Write("End position: ");
            Position end = ReadChessPosition().ToPosition();
            if (end == null)
            {
                throw new BoardException("Please make a valid movement (eg: A1). Press ENTER to continue");
            }
            match.ValidateEndPosition(start, end);

            match.PlayTurn(start, end);
        }

        public void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured:");
            Console.Write("White pieces: ");
            PrintPieceSet(match.GetCapturedPieces(Color.White));
            Console.WriteLine();
            Console.WriteLine("Captured:");
            Console.Write("Black pieces: ");
            PrintPieceSet(match.GetCapturedPieces(Color.Black));
        }

        public void PrintPieceSet(HashSet<Piece> p)
        {
            Console.Write("[");
            foreach (Piece x in p)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
            Console.WriteLine();
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
