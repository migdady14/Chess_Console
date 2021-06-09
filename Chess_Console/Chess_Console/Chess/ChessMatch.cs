using System;
using Chess_Console.Board;
using Chess_Console.Board.Enum;
using Chess_Console.Board.Exceptions;

namespace Chess_Console.Chess
{
    class ChessMatch
    {
        public ChessBoard ChessBoard { get; private set; }
        public int Turn { get; private set; }
        public Color TurnsPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            ChessBoard = new ChessBoard(8, 8);
            Turn = 1;
            TurnsPlayer = Color.White;
            Finished = false;
            StartGamePositioning();
        }

        public void Move(Position start, Position end)
        {
            Piece p = ChessBoard.RemovePiece(start);
            p.IncreaseMoveCount();
            Piece capturedPiece = ChessBoard.RemovePiece(end);
            ChessBoard.InsertPiece(p, end);
        }

        public void PlayTurn(Position start, Position end)
        {
            Move(start, end);
            Turn++;
            SwitchPlayer();
        }

        public void ValidateStartPosition(Position pos)
        {
            if (ChessBoard.Piece(pos) == null)
            {
                throw new BoardException("Piece not found. Press ENTER to continue");
            }
            if (TurnsPlayer != ChessBoard.Piece(pos).Color)
            {
                throw new BoardException("Please, choose a piece that belongs to you. Press ENTER to continue");
            }
            if (!ChessBoard.Piece(pos).VerifyMovement())
            {
                throw new BoardException("There's no available movement for this piece. Press ENTER to continue");
            }
        }

        public void ValidateEndPosition(Position start, Position end)
        {
            if (!ChessBoard.Piece(start).CanMoveTo(end))
            {
                throw new BoardException("Invalid movement. Press ENTER to continue");
            }
        }

        private void SwitchPlayer()
        {
            if (TurnsPlayer.Equals(Color.White))
            {
                TurnsPlayer = Color.Black;
            }
            else
            {
                TurnsPlayer = Color.White;
            }
        }

        private void StartGamePositioning()
        {
            ChessBoard.InsertPiece(new King(Color.Black, ChessBoard), new ChessPosition('e', 8).ToPosition());
            ChessBoard.InsertPiece(new Queen(Color.Black, ChessBoard), new ChessPosition('d', 8).ToPosition());
            ChessBoard.InsertPiece(new Bishop(Color.Black, ChessBoard), new ChessPosition('c', 8).ToPosition());
            ChessBoard.InsertPiece(new Bishop(Color.Black, ChessBoard), new ChessPosition('f', 8).ToPosition());
            ChessBoard.InsertPiece(new Knight(Color.Black, ChessBoard), new ChessPosition('b', 8).ToPosition());
            ChessBoard.InsertPiece(new Knight(Color.Black, ChessBoard), new ChessPosition('g', 8).ToPosition());
            ChessBoard.InsertPiece(new Rook(Color.Black, ChessBoard), new ChessPosition('a', 8).ToPosition());
            ChessBoard.InsertPiece(new Rook(Color.Black, ChessBoard), new ChessPosition('h', 8).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.Black, ChessBoard), new ChessPosition('a', 7).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.Black, ChessBoard), new ChessPosition('b', 7).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.Black, ChessBoard), new ChessPosition('c', 7).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.Black, ChessBoard), new ChessPosition('d', 7).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.Black, ChessBoard), new ChessPosition('e', 7).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.Black, ChessBoard), new ChessPosition('f', 7).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.Black, ChessBoard), new ChessPosition('g', 7).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.Black, ChessBoard), new ChessPosition('h', 7).ToPosition());

            ChessBoard.InsertPiece(new King(Color.White, ChessBoard), new ChessPosition('e', 1).ToPosition());
            ChessBoard.InsertPiece(new Queen(Color.White, ChessBoard), new ChessPosition('d', 1).ToPosition());
            ChessBoard.InsertPiece(new Bishop(Color.White, ChessBoard), new ChessPosition('c', 1).ToPosition());
            ChessBoard.InsertPiece(new Bishop(Color.White, ChessBoard), new ChessPosition('f', 1).ToPosition());
            ChessBoard.InsertPiece(new Knight(Color.White, ChessBoard), new ChessPosition('b', 1).ToPosition());
            ChessBoard.InsertPiece(new Knight(Color.White, ChessBoard), new ChessPosition('g', 1).ToPosition());
            ChessBoard.InsertPiece(new Rook(Color.White, ChessBoard), new ChessPosition('a', 1).ToPosition());
            ChessBoard.InsertPiece(new Rook(Color.White, ChessBoard), new ChessPosition('h', 1).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.White, ChessBoard), new ChessPosition('a', 2).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.White, ChessBoard), new ChessPosition('b', 2).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.White, ChessBoard), new ChessPosition('c', 2).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.White, ChessBoard), new ChessPosition('d', 2).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.White, ChessBoard), new ChessPosition('e', 2).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.White, ChessBoard), new ChessPosition('f', 2).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.White, ChessBoard), new ChessPosition('g', 2).ToPosition());
            ChessBoard.InsertPiece(new Pawn(Color.White, ChessBoard), new ChessPosition('h', 2).ToPosition());
        }
    }
}
