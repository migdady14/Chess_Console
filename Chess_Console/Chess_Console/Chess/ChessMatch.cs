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
        public bool Check { get; private set; }
        public Piece EnPassant { get; private set; }

        public ChessMatch()
        {
            ChessBoard = new ChessBoard(8, 8);
            Turn = 1;
            TurnsPlayer = Color.White;
            Finished = false;
            EnPassant = null;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            Check = false;
            StartGamePositioning();
        }

        public Piece Move(Position start, Position end)
        {
            Piece p = ChessBoard.RemovePiece(start);
            p.IncreaseMoveCount();
            Piece capturedPiece = ChessBoard.RemovePiece(end);
            ChessBoard.InsertPiece(p, end);
            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }

            // #SpecialMove Castling
            if (p is King && end.Column == start.Column + 2)
            {
                Position rookStart = new Position(start.Column + 3, start.Row);
                Position rookEnd = new Position(start.Column + 1, start.Row);
                Piece R = ChessBoard.RemovePiece(rookStart);
                R.IncreaseMoveCount();
                ChessBoard.InsertPiece(R, rookEnd);
            }
            if (p is King && end.Column == start.Column - 2)
            {
                Position rookStart = new Position(start.Column - 4, start.Row);
                Position rookEnd = new Position(start.Column - 1, start.Row);
                Piece R = ChessBoard.RemovePiece(rookStart);
                R.IncreaseMoveCount();
                ChessBoard.InsertPiece(R, rookEnd);
            }

            // #SpecialMove En Passant
            if (p is Pawn)
            {
                if (start.Column != end.Column && capturedPiece == null)
                {
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(end.Column, end.Row + 1);
                    }
                    else
                    {
                        posP = new Position(end.Column, end.Row - 1);
                    }
                    capturedPiece = ChessBoard.RemovePiece(posP);
                    CapturedPieces.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void UndoMove(Position start, Position end, Piece cPiece)
        {
            Piece p = ChessBoard.RemovePiece(end);
            p.DecreaseMoveCount();
            if (cPiece != null)
            {
                ChessBoard.InsertPiece(cPiece, end);
                CapturedPieces.Remove(cPiece);
            }
            ChessBoard.InsertPiece(p, start);

            // #SpecialMove Castling
            if (p is King && end.Column == start.Column + 2)
            {
                Position rookStart = new Position(start.Column + 3, start.Row);
                Position rookEnd = new Position(start.Column + 1, start.Row);
                Piece R = ChessBoard.RemovePiece(rookEnd);
                R.DecreaseMoveCount();
                ChessBoard.InsertPiece(R, rookStart);
            }
            if (p is King && end.Column == start.Column - 2)
            {
                Position rookStart = new Position(start.Column - 4, start.Row);
                Position rookEnd = new Position(start.Column - 1, start.Row);
                Piece R = ChessBoard.RemovePiece(rookEnd);
                R.DecreaseMoveCount();
                ChessBoard.InsertPiece(R, rookStart);
            }

            // #SpecialMove En Passant
            if (p is Pawn)
            {
                if (start.Column != end.Column && cPiece == EnPassant)
                {
                    Piece pawn = ChessBoard.RemovePiece(end);
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(end.Column, 3);
                    }
                    else
                    {
                        posP = new Position(end.Column, 4);
                    }
                    ChessBoard.InsertPiece(pawn, posP);
                }
            }
        }

        public void PlayTurn(Position start, Position end)
        {
            Piece capturedPiece = Move(start, end);

            if (InCheck(TurnsPlayer))
            {
                UndoMove(start, end, capturedPiece);
                throw new BoardException("You can't put yourself in check. Press ENTER to continue");
            }

            if (InCheck(Enemy(TurnsPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (CheckMate(TurnsPlayer))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                SwitchPlayer();
            }

            Piece p = ChessBoard.Piece(end);

            // #SpecialMove En Passant
            if (p is Pawn && (end.Row == start.Row - 2 || end.Row == start.Row + 2))
            {
                EnPassant = p;
            }
            else
            {
                EnPassant = null;
            }
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

        public HashSet<Piece> GetInGamePieces(Color color)
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

        private Piece King(Color color)
        {
            foreach (Piece x in GetInGamePieces(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public Color Enemy(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        public bool InCheck(Color color)
        {
            Piece king = King(color);
            if (king == null)
            {
                throw new BoardException("Ther's no king in your game!");
            }
            foreach (Piece x in GetInGamePieces(Enemy(color)))
            {
                bool[,] mat = x.AvailableMoves();
                if (mat[king.Position.Column, king.Position.Row])
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckMate(Color color)
        {
            if (!InCheck(color))
            {
                return false;
            }
            foreach (Piece x in GetInGamePieces(color))
            {
                bool[,] mat = x.AvailableMoves();
                for (int i = 0; i < ChessBoard.Rows; i++)
                {
                    for (int j = 0; j < ChessBoard.Columns; j++)
                    {
                        if (mat[j, i])
                        {
                            Position start = x.Position;
                            Position end = new Position(j, i);
                            Piece capPiece = Move(x.Position, end);
                            bool check = InCheck(color);
                            UndoMove(start, end, capPiece);
                            if (!check)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void InsertNewPiece(char column, int row, Piece piece)
        {
            ChessBoard.InsertPiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        private void StartGamePositioning()
        {
            InsertNewPiece('e', 8, new King(Color.Black, ChessBoard, this));
            InsertNewPiece('d', 8, new Queen(Color.Black, ChessBoard));
            InsertNewPiece('c', 8, new Bishop(Color.Black, ChessBoard));
            InsertNewPiece('f', 8, new Bishop(Color.Black, ChessBoard));
            InsertNewPiece('b', 8, new Knight(Color.Black, ChessBoard));
            InsertNewPiece('g', 8, new Knight(Color.Black, ChessBoard));
            InsertNewPiece('a', 8, new Rook(Color.Black, ChessBoard));
            InsertNewPiece('h', 8, new Rook(Color.Black, ChessBoard));
            InsertNewPiece('a', 7, new Pawn(Color.Black, ChessBoard, this));
            InsertNewPiece('b', 7, new Pawn(Color.Black, ChessBoard, this));
            InsertNewPiece('c', 7, new Pawn(Color.Black, ChessBoard, this));
            InsertNewPiece('d', 7, new Pawn(Color.Black, ChessBoard, this));
            InsertNewPiece('e', 7, new Pawn(Color.Black, ChessBoard, this));
            InsertNewPiece('f', 7, new Pawn(Color.Black, ChessBoard, this));
            InsertNewPiece('g', 7, new Pawn(Color.Black, ChessBoard, this));
            InsertNewPiece('h', 7, new Pawn(Color.Black, ChessBoard, this));

            InsertNewPiece('e', 1, new King(Color.White, ChessBoard, this));
            InsertNewPiece('d', 1, new Queen(Color.White, ChessBoard));
            InsertNewPiece('c', 1, new Bishop(Color.White, ChessBoard));
            InsertNewPiece('f', 1, new Bishop(Color.White, ChessBoard));
            InsertNewPiece('b', 1, new Knight(Color.White, ChessBoard));
            InsertNewPiece('g', 1, new Knight(Color.White, ChessBoard));
            InsertNewPiece('a', 1, new Rook(Color.White, ChessBoard));
            InsertNewPiece('h', 1, new Rook(Color.White, ChessBoard));
            InsertNewPiece('a', 2, new Pawn(Color.White, ChessBoard, this));
            InsertNewPiece('b', 2, new Pawn(Color.White, ChessBoard, this));
            InsertNewPiece('c', 2, new Pawn(Color.White, ChessBoard, this));
            InsertNewPiece('d', 2, new Pawn(Color.White, ChessBoard, this));
            InsertNewPiece('e', 2, new Pawn(Color.White, ChessBoard, this));
            InsertNewPiece('f', 2, new Pawn(Color.White, ChessBoard, this));
            InsertNewPiece('g', 2, new Pawn(Color.White, ChessBoard, this));
            InsertNewPiece('h', 2, new Pawn(Color.White, ChessBoard, this));
        }
    }
}
