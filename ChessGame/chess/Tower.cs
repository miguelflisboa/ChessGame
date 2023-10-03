using board;

namespace chess
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color) { }

        public Tower(Position position, Board board, Color color) : base(position, board, color) { }

        public override string ToString()
        {
            return "T";
        }
    }
}
