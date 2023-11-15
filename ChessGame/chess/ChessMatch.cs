using System.Collections.Generic;
using board;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color turnPlayer { get; private set; }
        public bool ended { get; private set; }
        private HashSet<Piece> piecesOnBoard;
        private HashSet<Piece> capturedInGame;
        public bool xeque { get; private set; }


        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            turnPlayer = Color.White;
            ended = false;
            xeque = false;
            piecesOnBoard = new HashSet<Piece>();
            capturedInGame = new HashSet<Piece>();
            allocatePieces();
        }

        public Piece executeMoviment(Position origin, Position destiny)
        {
            Piece chosed = board.removePiece(origin);
            Piece captured = board.removePiece(destiny);
            chosed.increaseMovements();
            board.allocatePiece(chosed, destiny);
            if (captured != null)
            {
                capturedInGame.Add(captured);
            }

            // Small Roque
            if (chosed is King && destiny.column == origin.column + 2)
            {
                Position originTr = new Position(origin.row, origin.column + 3);
                Position destinyTr = new Position(origin.row, origin.column + 1);
                Piece Tr = board.removePiece(originTr);
                board.allocatePiece(Tr, destinyTr);
                Tr.increaseMovements();
            }

            // Big Roque
            if (chosed is King && destiny.column == origin.column - 2)
            {
                Position originTl = new Position(origin.row, origin.column - 4);
                Position destinyTl = new Position(origin.row, origin.column - 2);
                Piece Tl = board.removePiece(originTl);
                board.allocatePiece(Tl, destinyTl);
                Tl.increaseMovements();
            }

            return captured;
        }

        public void undoingMovement(Position origin, Position destiny, Piece captured)
        {
            Piece piece = board.removePiece(destiny);
            piece.decreaseMovements();
            if (captured != null)
            {
                board.allocatePiece(captured, destiny);
                capturedInGame.Remove(captured);
            }
            board.allocatePiece(piece, origin);

            // Small Roque
            if (piece is King && destiny.column == origin.column + 2)
            {
                Position originTr = new Position(origin.row, origin.column + 3);
                Position destinyTr = new Position(origin.row, origin.column + 1);
                Piece Tr = board.removePiece(destinyTr);
                board.allocatePiece(Tr, originTr);
                Tr.decreaseMovements();
            }

            // Big Roque
            if (piece is King && destiny.column == origin.column - 2)
            {
                Position originTl = new Position(origin.row, origin.column - 4);
                Position destinyTl = new Position(origin.row, origin.column - 1);
                Piece Tl = board.removePiece(destinyTl);
                board.allocatePiece(Tl, originTl);
                Tl.decreaseMovements();
            }
        }

        public void play(Position origin, Position destiny)
        {
            Piece captured = executeMoviment(origin, destiny);

            if (itIsXeque(turnPlayer))
            {
                undoingMovement(origin, destiny, captured);
                throw new BoardException("You can't put yourself in Xeque !!!");
            }

            if (itIsXeque(adversary(turnPlayer)))
            {
                xeque = true;

                if (itIsMate(adversary(turnPlayer)))
                {
                    ended = true;
                }
                else
                {
                    turn++;
                    changePlayer();
                }
            }
            else
            {
                xeque = false;
                turn++;
                changePlayer();
            }

        }

        public void validateOrigin(Position origin)
        {
            if (board.piece(origin) == null)
            {
                throw new BoardException("There is no piece in the chosed origin position!!!");
            }
            if (turnPlayer != board.piece(origin).color)
            {
                throw new BoardException("The piece chosed isn't yours!!!");
            }
            if (!board.piece(origin).thereIsPossibleMovements())
            {
                throw new BoardException("There isn't any possible moviments for this piece!!!");
            }
        }

        public void validateDestiny(Position origin, Position destiny)
        {
            if (!board.piece(origin).canMoveTo(destiny))
            {
                throw new BoardException("Destiny invalid!!!");
            }
        }

        private void changePlayer()
        {
            if (turnPlayer == Color.White)
            {
                turnPlayer = Color.Black;
            }
            else
            {
                turnPlayer = Color.White;
            }
        }

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in capturedInGame)
            {
                if (x.color == color) aux.Add(x);
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in piecesOnBoard)
            {
                if (x.color == color) aux.Add(x);
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        private Color adversary(Color color)
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


        private Piece king(Color color)
        {
            foreach (Piece x in piecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool itIsXeque(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new BoardException("There is no " + color + " king in the board!!");
            }

            foreach (Piece x in piecesInGame(adversary(color)))
            {
                bool[,] mat = x.possibleMovements();
                if (mat[K.position.row, K.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool itIsMate(Color color)
        {
            if (!itIsXeque(color))
            {
                return false;
            }

            foreach (Piece x in piecesInGame(color))
            {
                bool[,] mat = x.possibleMovements();
                for (int i = 0; i < board.rows; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position destiny = new Position(i,j);
                            Position origin = x.position;

                            Piece captured = executeMoviment(origin, destiny);
                            bool xeque = itIsXeque(color);
                            undoingMovement(origin, destiny, captured);
                            if (!xeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void allocateNewPiece(char column, int row, Piece piece)
        {
            board.allocatePiece(piece, new ChessPosition(column, row).toPosition());
            piecesOnBoard.Add(piece);
        }

        private void allocatePieces()
        {
            allocateNewPiece('a', 8, new Tower(board, Color.Black));
            allocateNewPiece('b', 8, new Knight(board, Color.Black));
            allocateNewPiece('c', 8, new Bishop(board, Color.Black));
            allocateNewPiece('d', 8, new Queen(board, Color.Black));
            allocateNewPiece('e', 8, new King(board, Color.Black, this));
            allocateNewPiece('f', 8, new Bishop(board, Color.Black));
            allocateNewPiece('g', 8, new Knight(board, Color.Black));
            allocateNewPiece('h', 8, new Tower(board, Color.Black));

            allocateNewPiece('a', 7, new Pawn(board, Color.Black));
            allocateNewPiece('b', 7, new Pawn(board, Color.Black));
            allocateNewPiece('c', 7, new Pawn(board, Color.Black));
            allocateNewPiece('d', 7, new Pawn(board, Color.Black));
            allocateNewPiece('e', 7, new Pawn(board, Color.Black));
            allocateNewPiece('f', 7, new Pawn(board, Color.Black));
            allocateNewPiece('g', 7, new Pawn(board, Color.Black));
            allocateNewPiece('h', 7, new Pawn(board, Color.Black));


            allocateNewPiece('a', 1, new Tower(board, Color.White));
            allocateNewPiece('b', 1, new Knight(board, Color.White));
            allocateNewPiece('c', 1, new Bishop(board, Color.White));
            allocateNewPiece('d', 1, new Queen(board, Color.White));
            allocateNewPiece('e', 1, new King(board, Color.White, this));
            allocateNewPiece('f', 1, new Bishop(board, Color.White));
            allocateNewPiece('g', 1, new Knight(board, Color.White));
            allocateNewPiece('h', 1, new Tower(board, Color.White));

            allocateNewPiece('a', 2, new Pawn(board, Color.White));
            allocateNewPiece('b', 2, new Pawn(board, Color.White));
            allocateNewPiece('c', 2, new Pawn(board, Color.White));
            allocateNewPiece('d', 2, new Pawn(board, Color.White));
            allocateNewPiece('e', 2, new Pawn(board, Color.White));
            allocateNewPiece('f', 2, new Pawn(board, Color.White));
            allocateNewPiece('g', 2, new Pawn(board, Color.White));
            allocateNewPiece('h', 2, new Pawn(board, Color.White));


        }
    }
}
