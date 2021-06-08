using System;
using Chess_Console.Board;
using Chess_Console.Board.Enum;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard chessBoard = new ChessBoard(8, 8);

            Screen.PrintBoard(chessBoard);
        }
    }
}
