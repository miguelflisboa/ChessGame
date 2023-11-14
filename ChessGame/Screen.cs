using board;
using System.Collections.Generic;
using chess;

namespace ChessGame
{
    internal class Screen
    {
        public static void printMatch(ChessMatch match)
        {
            printBoard(match.board);
            Console.WriteLine();
            printCapturedPieces(match);

            Console.WriteLine("Turn: " + match.turn);
            Console.WriteLine("Waiting play by: " + match.turnPlayer);

            if (match.xeque)
            {
                Console.WriteLine("Xeque!!!");
            }

           
        }

        public static void printCapturedPieces(ChessMatch match)
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.WriteLine("Captured Pieces:");

            Console.Write("White: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSet(match.capturedPieces(Color.White));
            Console.ForegroundColor = aux;

            Console.Write("Black: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            printSet(match.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
        }

        public static void printSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach(Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write("]\n" );
        }
        
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    printPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalColor = Console.BackgroundColor;
            ConsoleColor alteredColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = alteredColor;
                    }

                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = originalColor;
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

            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
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
                Console.Write(" ");
            }
            
        }
    }
}
