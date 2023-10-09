using board;
using chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                ChessPosition cp1 = new ChessPosition('a', 8);
                ChessPosition cp2 = new ChessPosition('b', 6);

                board.alocatePiece(new Tower(board, Color.Black), cp1.toPosition());
                //board.alocatePiece(new Tower(board, Color.White), new Position(0, 0));
                board.alocatePiece(new King(board, Color.White), cp2.toPosition());


                Screen.printBoard(board);

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();

        }
    }
}