using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "P";
        }

        private bool isThereEnemy(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != this.color;
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
            int dir;

            if (color == Color.White)
            {
                dir = 1;
            }
            else
            {
                dir = -1;
            }

            // North
            pos.defineValue(position.row - dir * 1, position.column);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
            }

            // Double North
            pos.defineValue(position.row - dir * 2, position.column);
            if (board.positionTest(pos) && canMove(pos) && qofMovements == 0)
            {
                movements[pos.row, pos.column] = true;
            }
            // North East
            pos.defineValue(position.row - dir * 1, position.column + 1);
            if (board.positionTest(pos) && isThereEnemy(pos))
            {
                movements[pos.row, pos.column] = true;
            }
            // North West
            pos.defineValue(position.row - dir * 1, position.column - 1);
            if (board.positionTest(pos) && isThereEnemy(pos))
            {
                movements[pos.row, pos.column] = true;
            }

            return movements;
        }
    }
}
