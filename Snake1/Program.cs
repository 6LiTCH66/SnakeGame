using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using WMPLib;

namespace Snake1
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.SetWindowSize(80, 30);

			Walls walls = new Walls(80, 25);
			walls.Draw();

			Point p = new Point(4, 5, '*');
			
			Snakee snake = new Snakee(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();

			Params settings = new Params();
			Sound sound = new Sound(settings.GetResourcesFolder());
			sound.Play();

			Sound sound1 = new Sound(settings.GetResourcesFolder());

			Sound sound2 = new Sound(settings.GetResourcesFolder());

			int i = 0;

			while (true)
			{

				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					Gameover gameover = new Gameover();
					gameover.Game();
					sound2.PlayDied(); 

					Console.Write("Ente your name: ");
					String nimi = (Console.ReadLine());

					Console.WriteLine(nimi + " scored " + i + " Points");
					
					string answer = nimi + ": " + i + " Points";


					// string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

					// string resourcesDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\resources"));


					string filePath = Path.Combine(settings.GetResourcesFolder(), "results.txt");

					using (StreamWriter to_file = new StreamWriter(filePath, true))
					{

						to_file.WriteLine(answer);
					}


					Console.ForegroundColor = ConsoleColor.White;

					using (StreamReader from_file = new StreamReader(filePath))
					{
						string text = from_file.ReadToEnd();
						Console.WriteLine(text);
					}

					Console.ReadLine();

					break;

				}
				Score score = new Score();
				score.Scoree(i);

				if (snake.Eat(food))
				{
					i++;

					food = foodCreator.CreateFood();
					food.Draw();
					sound1.PlayEat();

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
