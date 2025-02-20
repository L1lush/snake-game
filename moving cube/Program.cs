using System;
using System.Threading;

namespace moving_cube
{
	internal class Program
	{
		static int h = 0; 
		static int w = 0;

		static void Main(string[] args)
		{
			Console.WriteLine("choose the size of the grid (tyoe it twice)");
			h = int.Parse(Console.ReadLine());
			w = int.Parse(Console.ReadLine());
			board();
		}

		static void board()
		{
			int moves = 0;
			int points = 0;
			int changeh = h / 2;
			int changew = w / 2; 

			Random rand = new Random();

			int randomH = rand.Next(0, h);
			int randomW = rand.Next(0, w);

			while (true)
			{
				int[,] board = new int[h, w];
				int[,] player = new int[h, w];

				player[changeh, changew] = 1;
				board[randomH, randomW] = 9; 

				for (int i = 0; i < board.GetLength(0); i++)
				{
					for (int j = 0; j < board.GetLength(1); j++)
					{
						if (player[i, j] == 1)
						{
							Console.Write("P ");
						}
						else if (board[i, j] == 9)
						{
							Console.Write("X ");
						}
						else
						{
							Console.Write("0 ");
						}
					}
					Console.WriteLine();
				}

				ConsoleKeyInfo keyInfo = Console.ReadKey();

				if (keyInfo.Key == ConsoleKey.W && changeh > 0)
				{
					moves++;
					changeh--; 
				}
				if (keyInfo.Key == ConsoleKey.S && changeh < h - 1)
				{
					moves++;
					changeh++;
				}
				if (keyInfo.Key == ConsoleKey.D && changew < w - 1)
				{
					moves++;
					changew++;
				}
				if (keyInfo.Key == ConsoleKey.A && changew > 0)
				{
					moves++;
					changew--;
				}
				if (changeh == randomH && changew == randomW)
				{
					points++;
					Console.Clear();
					Console.WriteLine($"You reached the point yout total Points is {points}");
					Console.WriteLine($"and yout total moves is {moves}");
					randomH = rand.Next(0, h);
					randomW = rand.Next(0, w);
				}
				else
				{
					Console.Clear();
				}
			}
		}
	}
}
