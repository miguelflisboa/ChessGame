

namespace board
{
    internal class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] piecesOnBoard;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            piecesOnBoard = new Piece[rows, columns];
        }

        public Piece piece(int row, int column)
        {
            return piecesOnBoard[row, column];
        }

        public Piece piece(Position pos)
        {
            return piecesOnBoard[pos.row, pos.column];
        }

        public void allocatePiece(Piece p, Position pos)
        {
            if (isThereAPiece(pos))
            {
                throw new BoardException("There is already a piece!!!!");
            }
            piecesOnBoard[pos.row, pos.column] = p;
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
                piecesOnBoard[pos.row, pos.column] = null;
                return aux;
            }
        }

        public bool isThereAPiece(Position pos)
        {
            validatingPosition(pos);
            return piece(pos.row, pos.column) != null;
        }

        public bool positionTest(Position pos)
        {
            if (pos.row < 0 || pos.row > rows - 1 || pos.column < 0 || pos.column > columns - 1)
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
