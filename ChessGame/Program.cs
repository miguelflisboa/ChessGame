using board;
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
			Board board = new Board(8,8);

			Screen.printBoard(board);

			Console.ReadLine();

		}
	}
}