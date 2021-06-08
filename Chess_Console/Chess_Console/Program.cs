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
                ChessBoard chessBoard = new ChessBoard(8, 8);

                chessBoard.InsertPiece(new King(Color.Black, chessBoard), new Position(0, 4));
                chessBoard.InsertPiece(new Queen(Color.Black, chessBoard), new Position(0, 3));
                chessBoard.InsertPiece(new Bishop(Color.Black, chessBoard), new Position(0, 2));
                chessBoard.InsertPiece(new Bishop(Color.Black, chessBoard), new Position(0, 5));
                chessBoard.InsertPiece(new Knight(Color.Black, chessBoard), new Position(0, 1));
                chessBoard.InsertPiece(new Knight(Color.Black, chessBoard), new Position(0, 6));
                chessBoard.InsertPiece(new Rocks(Color.Black, chessBoard), new Position(0, 0));
                chessBoard.InsertPiece(new Rocks(Color.Black, chessBoard), new Position(0, 7));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 0));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 1));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 2));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 3));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 4));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 5));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 6));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 7));


                Screen.PrintBoard(chessBoard);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message );
            }
        }
    }
}
