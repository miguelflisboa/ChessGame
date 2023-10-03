

namespace board
{
    internal class Board
    {
        public int lines {  get; set; }
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

        public void alocatePiece (Piece p, Position pos)
        {
            piecesOnBoard[pos.line, pos.column] = p;
            p.position = pos;
        }
    }
}
