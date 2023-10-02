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
			Position P;

			P = new Position(3, 2);

			Console.WriteLine("Position: " +  P);

			Console.ReadLine();

		}
	}
}