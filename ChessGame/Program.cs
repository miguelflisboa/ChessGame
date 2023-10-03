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
            Board board = new Board(8, 8);
            board.alocatePiece(new Tower(board, Color.Black) , new Position(0, 0));
            board.alocatePiece(new King(board, Color.White), new Position(1, 3));


            Screen.printBoard(board);

            Console.ReadLine();

        }
    }
}