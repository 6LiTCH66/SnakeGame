using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace Snake1
{
    class Program
    {
        static void Main(string[] args)
        {
			SoundPlayer player = new SoundPlayer();
			player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "music.wav";
			player.Play();

			SoundPlayer player1 = new SoundPlayer();
			player1.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "pop.wav";

			SoundPlayer player2 = new SoundPlayer();
			player2.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "died.wav";
			//player2.Play();


			Console.SetWindowSize(80, 25);

			Walls walls = new Walls(80, 25);
			walls.Draw();

			Point p = new Point(4, 5, '*');
			Snakee snake = new Snakee(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					player2.Play();
					try
					{ 
						Console.Write("Ente youe name:");
						String nimi = (Console.ReadLine());
						if (nimi.Length >= 3)
						{
							StreamWriter to_file = new StreamWriter("Answer.txt", true);
							to_file.WriteLine(nimi);
							to_file.Close();
						}
					}
					catch(Exception)
					{
						Console.WriteLine("Try again pleas!");
					}

					break;

				}
				if (snake.Eat(food))
				{
					food = foodCreator.CreateFood();
					food.Draw();
					player1.Play();
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
		}

	}
}
