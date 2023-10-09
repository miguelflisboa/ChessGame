

namespace board
{
    internal class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] piecesOnBoard;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            piecesOnBoard = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return piecesOnBoard[line, column];
        }

        public Piece piece(Position pos)
        {
            return piecesOnBoard[pos.line, pos.column];
        }

        public void alocatePiece(Piece p, Position pos)
        {
            if (isThereAPiece(pos))
            {
                throw new BoardException("There is already a piece!!!!");
            }
            piecesOnBoard[pos.line, pos.column] = p;
            p.position = pos;
        }

        public Piece removePiece(Position pos)
        {
            if (!isThereAPiece(pos))
            {
                return null;
            }
            else
            {
                Piece aux = piece(pos);
                piecesOnBoard[pos.line, pos.column] = null;
                return aux;
            }
        }

        public bool isThereAPiece(Position pos)
        {
            validatingPosition(pos);
            return piece(pos.line, pos.column) != null;
        }

        public bool positionTest(Position pos)
        {
            if (pos.line < 0 || pos.line > lines || pos.column < 0 || pos.column > columns)
            {
                return false;
            }

            return true;
        }

        public void validatingPosition(Position pos)
        {
            if(!positionTest(pos))
            {
                throw new BoardException("Invalid position!!!!");
            }
        }
    }
}
