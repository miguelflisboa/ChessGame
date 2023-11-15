using board;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "B";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] movements = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            // NorthWest
            pos.defineValue(position.row - 1, position.column - 1);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
                pos.row--;
                pos.column--;
            }

            // NorthEast
            pos.defineValue(position.row - 1, position.column + 1);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
                pos.row--;
                pos.column++;
            }

            // SouthEast
            pos.defineValue(position.row + 1, position.column + 1);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
                pos.row++;
                pos.column++;
            }

            // SouthWest
            pos.defineValue(position.row + 1, position.column - 1);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
                pos.row++;
                pos.column--;
            }

            return movements;
        }
    }
}
