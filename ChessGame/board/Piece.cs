
using System.ComponentModel.DataAnnotations.Schema;

namespace board
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qofMovements { get; protected set; }
        public Board table { get; protected set; }

        public Piece(Board table, Color color)
        {
            this.position = null;
            this.table = table;
            this.color = color;
            this.qofMovements = 0;
        }

        public Piece(Position position, Board table, Color color)
        {
            this.position = position;
            this.table = table;
            this.color = color;
            this.qofMovements = 0;
        }
    }
}
