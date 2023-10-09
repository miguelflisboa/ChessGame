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
        private int turn;
        private Color turnPlayer;
        public bool ended { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 0;
            turnPlayer = Color.White;
            ended = false;
            alocatePieces();
        }

        public void executeMoviment(Position origin, Position destine)
        {
            Piece chosed = board.removePiece(origin);
            Piece captured = board.removePiece(destine);
            chosed.increaseMovements();
            board.alocatePiece(chosed, destine);
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
