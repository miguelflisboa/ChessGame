using board;

namespace chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color) { }

        public King(Position position, Board board, Color color) : base(position, board, color) { }

        public override string ToString()
        {
            return "K";
        }
    }
}
