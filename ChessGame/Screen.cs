using board;
using System;
using chess;

namespace ChessGame
{
    internal class Screen
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (board.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        printPiece(board.piece(i, j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static ChessPosition readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        public static void printPiece(Piece piece)
        {
            ConsoleColor aux = Console.ForegroundColor;
            if (piece.color == Color.White)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(piece);
            }
            Console.ForegroundColor = aux;
        }
    }
}
