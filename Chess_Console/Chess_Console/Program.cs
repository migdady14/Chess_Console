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
                Screen screen = new Screen();

                while (!match.Finished)
                {
                    try
                    {
                        screen.PrintMatch(match);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
