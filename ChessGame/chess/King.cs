using board;

namespace chess
{
    class King : Piece
    {
        private ChessMatch match;

        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        private bool towerToRoque(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Tower && p.color == this.color && p.qofMovements == 0;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] movements = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            // North
            pos.defineValue(position.row - 1, position.column);
            if (board.positionTest(pos) && canMove(pos))
            {
                movements[pos.row, pos.column] = true;
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

            // Small Roque
            if (qofMovements == 0 && !match.xeque)
            {
                Position posTr = new Position(position.row, position.column + 3);
                if (towerToRoque(posTr))
                {
                    Position p1 = new Position(position.row, position.column + 1);
                    Position p2 = new Position(position.row, position.column + 2);
                    if (board.piece(p1) == null && board.piece(p2) == null)
                    {
                        movements[position.row, position.column + 2] = true;
                    }
                }
            }

            // Big Roque
            if (qofMovements == 0 && !match.xeque)
            {
                Position posTl = new Position(position.row, position.column - 4);
                if (towerToRoque(posTl))
                {
                    Position p1 = new Position(position.row, position.column + 1);
                    Position p2 = new Position(position.row, position.column + 2);
                    Position p3 = new Position(position.row, position.column + 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        movements[position.row, position.column - 2] = true;
                    }
                }
            }

            return movements;
        }
    }
}
