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
                ChessBoard chessBoard = new ChessBoard(8, 8);

                chessBoard.InsertPiece(new King(Color.Black, chessBoard), new Position(0, 4));
                chessBoard.InsertPiece(new Queen(Color.Black, chessBoard), new Position(0, 3));
                chessBoard.InsertPiece(new Bishop(Color.Black, chessBoard), new Position(0, 2));
                chessBoard.InsertPiece(new Bishop(Color.Black, chessBoard), new Position(0, 5));
                chessBoard.InsertPiece(new Knight(Color.Black, chessBoard), new Position(0, 1));
                chessBoard.InsertPiece(new Knight(Color.Black, chessBoard), new Position(0, 6));
                chessBoard.InsertPiece(new Rook(Color.Black, chessBoard), new Position(0, 0));
                chessBoard.InsertPiece(new Rook(Color.Black, chessBoard), new Position(0, 7));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 0));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 1));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 2));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 3));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 4));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 5));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 6));
                chessBoard.InsertPiece(new Pawn(Color.Black, chessBoard), new Position(1, 7));

                chessBoard.InsertPiece(new King(Color.White, chessBoard), new Position(6, 4));
                chessBoard.InsertPiece(new Queen(Color.White, chessBoard), new Position(6, 3));
                chessBoard.InsertPiece(new Bishop(Color.White, chessBoard), new Position(6, 2));
                chessBoard.InsertPiece(new Bishop(Color.White, chessBoard), new Position(6, 5));
                chessBoard.InsertPiece(new Knight(Color.White, chessBoard), new Position(6, 1));
                chessBoard.InsertPiece(new Knight(Color.White, chessBoard), new Position(6, 6));
                chessBoard.InsertPiece(new Rook(Color.White, chessBoard), new Position(6, 0));
                chessBoard.InsertPiece(new Rook(Color.White, chessBoard), new Position(6, 7));
                chessBoard.InsertPiece(new Pawn(Color.White, chessBoard), new Position(7, 0));
                chessBoard.InsertPiece(new Pawn(Color.White, chessBoard), new Position(7, 1));
                chessBoard.InsertPiece(new Pawn(Color.White, chessBoard), new Position(7, 2));
                chessBoard.InsertPiece(new Pawn(Color.White, chessBoard), new Position(7, 3));
                chessBoard.InsertPiece(new Pawn(Color.White, chessBoard), new Position(7, 4));
                chessBoard.InsertPiece(new Pawn(Color.White, chessBoard), new Position(7, 5));
                chessBoard.InsertPiece(new Pawn(Color.White, chessBoard), new Position(7, 6));
                chessBoard.InsertPiece(new Pawn(Color.White, chessBoard), new Position(7, 7));




                Screen.PrintBoard(chessBoard);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message );
            }
        }
    }
}
