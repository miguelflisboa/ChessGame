using board;

namespace chess
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "T";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] movements = new bool[board.rows, board.columns];

            Position pos = new Position(0,0);

            // North
            pos.defineValue(position.row - 1, position.column);
            while (board.positionTest(pos) && canMove(pos))
            {                
                movements[pos.row, pos.column] = true;
                if(board.piece(pos) != null && board.piece(pos).color != this.color) { break;  }
                pos.row--;
            }

            // East
            pos.defineValue(position.row, position.column + 1);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
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

            // West
            pos.defineValue(position.row, position.column - 1);
            while (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) { break; }
                pos.column--;
            }

            return movements;
        }
    }
}
