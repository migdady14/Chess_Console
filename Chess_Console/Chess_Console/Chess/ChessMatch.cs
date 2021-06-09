using System.Collections.Generic;
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
        public HashSet<Piece> Pieces { get; private set; }
        public HashSet<Piece> CapturedPieces { get; private set; }

        public ChessMatch()
        {
            ChessBoard = new ChessBoard(8, 8);
            Turn = 1;
            TurnsPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            StartGamePositioning();
        }

        public void Move(Position start, Position end)
        {
            Piece p = ChessBoard.RemovePiece(start);
            p.IncreaseMoveCount();
            Piece capturedPiece = ChessBoard.RemovePiece(end);
            ChessBoard.InsertPiece(p, end);
            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
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

        public HashSet<Piece> GetCapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in CapturedPieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> GetPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(GetCapturedPieces(color));
            return aux;
        }

        public void InsertNewPiece(char column, int row, Piece piece)
        {
            ChessBoard.InsertPiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        private void StartGamePositioning()
        {
            InsertNewPiece('e', 8, new King(Color.Black, ChessBoard));
            InsertNewPiece('d', 8, new Queen(Color.Black, ChessBoard));
            InsertNewPiece('c', 8, new Bishop(Color.Black, ChessBoard));
            InsertNewPiece('f', 8, new Bishop(Color.Black, ChessBoard));
            InsertNewPiece('b', 8, new Knight(Color.Black, ChessBoard));
            InsertNewPiece('g', 8, new Knight(Color.Black, ChessBoard));
            InsertNewPiece('a', 8, new Rook(Color.Black, ChessBoard));
            InsertNewPiece('h', 8, new Rook(Color.Black, ChessBoard));
            InsertNewPiece('a', 7, new Pawn(Color.Black, ChessBoard));
            InsertNewPiece('b', 7, new Pawn(Color.Black, ChessBoard));
            InsertNewPiece('c', 7, new Pawn(Color.Black, ChessBoard));
            InsertNewPiece('d', 7, new Pawn(Color.Black, ChessBoard));
            InsertNewPiece('e', 7, new Pawn(Color.Black, ChessBoard));
            InsertNewPiece('f', 7, new Pawn(Color.Black, ChessBoard));
            InsertNewPiece('g', 7, new Pawn(Color.Black, ChessBoard));
            InsertNewPiece('h', 7, new Pawn(Color.Black, ChessBoard));

            InsertNewPiece('e', 1, new King(Color.White, ChessBoard));
            InsertNewPiece('d', 1, new Queen(Color.White, ChessBoard));
            InsertNewPiece('c', 1, new Bishop(Color.White, ChessBoard));
            InsertNewPiece('f', 1, new Bishop(Color.White, ChessBoard));
            InsertNewPiece('b', 1, new Knight(Color.White, ChessBoard));
            InsertNewPiece('g', 1, new Knight(Color.White, ChessBoard));
            InsertNewPiece('a', 1, new Rook(Color.White, ChessBoard));
            InsertNewPiece('h', 1, new Rook(Color.White, ChessBoard));
            InsertNewPiece('a', 2, new Pawn(Color.White, ChessBoard));
            InsertNewPiece('b', 2, new Pawn(Color.White, ChessBoard));
            InsertNewPiece('c', 2, new Pawn(Color.White, ChessBoard));
            InsertNewPiece('d', 2, new Pawn(Color.White, ChessBoard));
            InsertNewPiece('e', 2, new Pawn(Color.White, ChessBoard));
            InsertNewPiece('f', 2, new Pawn(Color.White, ChessBoard));
            InsertNewPiece('g', 2, new Pawn(Color.White, ChessBoard));
            InsertNewPiece('h', 2, new Pawn(Color.White, ChessBoard));
        }
    }
}
