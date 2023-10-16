
using System.ComponentModel.DataAnnotations.Schema;

namespace board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qofMovements { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.qofMovements = 0;
        }

        public void increaseMovements()
        {
            this.qofMovements++;
        }

        public void decreaseMovements()
        {
            this .qofMovements--;
        }

        public bool thereIsPossibleMovements()
        {
            bool[,] movements = possibleMovements();
            for (int i = 0; i < board.rows; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (movements[i, j]) return true;
                }
            }
            return false;
        }

        public bool canMoveTo(Position destiny)
        {
            return possibleMovements()[destiny.row, destiny.column];
        }

        public abstract bool[,] possibleMovements();

    }
}
