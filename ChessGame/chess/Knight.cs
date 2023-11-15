using board;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "N";
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

            // North East
            pos.defineValue(position.row - 2, position.column + 1);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // East North
            pos.defineValue(position.row - 1, position.column + 2);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // East South
            pos.defineValue(position.row + 1, position.column + 2);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // South East
            pos.defineValue(position.row + 2, position.column + 1);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // South West
            pos.defineValue(position.row + 2, position.column - 1);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // West South
            pos.defineValue(position.row + 1, position.column - 2);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // West North
            pos.defineValue(position.row - 1, position.column - 2);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // North West
            pos.defineValue(position.row - 2, position.column - 1);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }

            return movements;
        }
    }
}
