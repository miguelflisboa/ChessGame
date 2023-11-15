using board;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "Q";
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

            // North
            pos.defineValue(position.row - 1, position.column);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
                pos.row--;
            }
            // North East
            pos.defineValue(position.row - 1, position.column + 1);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
                pos.row--;
                pos.column++;
            }
            // East
            pos.defineValue(position.row, position.column + 1);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
                pos.column++;
            }
            // South East
            pos.defineValue(position.row + 1, position.column + 1);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
                pos.row++;
                pos.column++;
            }
            // South
            pos.defineValue(position.row + 1, position.column);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
                pos.row++;
            }
            // South West
            pos.defineValue(position.row + 1, position.column - 1);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
                pos.row++;
                pos.column--;
            }
            // West
            pos.defineValue(position.row, position.column - 1);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
                pos.column--;
            }
            // North West
            pos.defineValue(position.row - 1, position.column - 1);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
                pos.row--;
                pos.column--;
            }

            return movements;
        }
    }
}
