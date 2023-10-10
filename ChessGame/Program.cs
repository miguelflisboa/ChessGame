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
                ChessMatch match = new ChessMatch();

                while(!match.ended)
                {
                    Console.Clear();
                    Screen.printBoard(match.board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origem = Screen.readChessPosition().toPosition();

                    bool[,] posiblePositions = match.board.piece(origem).possibleMovements();
                    
                    Console.Clear();
                    Screen.printBoard(match.board, posiblePositions);

                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    match.executeMoviment(origem, destiny);
                    

                }

                Screen.printBoard(match.board);

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();

        }
    }
}