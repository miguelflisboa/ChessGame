using System;
using board;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color turnPlayer { get; private set; }
        public bool ended { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            turnPlayer = Color.White;
            ended = false;
            alocatePieces();
        }

        public void executeMoviment(Position origin, Position destiny)
        {
            Piece chosed = board.removePiece(origin);
            Piece captured = board.removePiece(destiny);
            chosed.increaseMovements();
            board.alocatePiece(chosed, destiny);
        }

        public void play(Position origin, Position destiny)
        {
            executeMoviment(origin, destiny);
            turn++;
            changePlayer();
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
            if(turnPlayer == Color.White)
            {
                turnPlayer = Color.Black;
            }
            else
            {
                turnPlayer = Color.White;
            }
        }

        private void alocatePieces()
        {

            board.alocatePiece(new Tower(board, Color.Black), new ChessPosition('a', 8).toPosition());
            board.alocatePiece(new Tower(board, Color.Black), new ChessPosition('h', 8).toPosition());
            board.alocatePiece(new King(board, Color.Black), new ChessPosition('e', 8).toPosition());

            board.alocatePiece(new Tower(board, Color.White), new ChessPosition('a', 1).toPosition());
            board.alocatePiece(new Tower(board, Color.White), new ChessPosition('h', 1).toPosition()); 
            board.alocatePiece(new King(board, Color.White), new ChessPosition('e', 1).toPosition());
        }
    }
}
