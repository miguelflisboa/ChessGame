using board;

namespace chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] movements = new bool[board.rows,board.columns];

            Position pos = new Position(0, 0);

            // North
            pos.defineValue(position.row - 1, position.column);
            if (board.positionTest(pos) && canMove(pos) )
            {
                movements[pos.row,pos.column] = true; 
            }
            // North East
            pos.defineValue(position.row - 1, position.column + 1);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // East
            pos.defineValue(position.row, position.column + 1);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // South East
            pos.defineValue(position.row + 1, position.column + 1);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // South
            pos.defineValue(position.row + 1, position.column);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // South West
            pos.defineValue(position.row + 1, position.column - 1);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // West
            pos.defineValue(position.row, position.column - 1);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // North West
            pos.defineValue(position.row - 1, position.column - 1);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }

            return movements;
        }
    }
}
