using System;
using Chess_Console.Board;
using Chess_Console.Board.Exceptions;
using Chess_Console.Board.Enum;
using Chess_Console.Chess;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.ChessBoard);

                    Console.WriteLine();
                    Console.Write("Start position: ");
                    Position start = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblePositions = match.ChessBoard.Piece(start).AvailableMoves();

                    Console.Clear();
                    Screen.PrintBoard(match.ChessBoard, possiblePositions);

                    Console.WriteLine();
                    Console.Write("End position: ");
                    Position end = Screen.ReadChessPosition().ToPosition();

                    match.Move(start, end);
                }

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message );
            }
        }
    }
}
