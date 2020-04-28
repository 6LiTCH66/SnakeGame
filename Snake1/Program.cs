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
			Console.SetWindowSize(80, 25);

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
					sound2.PlayDied(); 

					Console.Write("Ente youe name:");
					String nimi = (Console.ReadLine());

					Console.WriteLine(nimi + " scored " + i + " Points");
					
					string answer = nimi + ": " + i + " Points";

					StreamWriter to_file = new StreamWriter(@"C:\Users\Game\source\repos\Snake1\Snake1\resources\results.txt", true);
					to_file.WriteLine(answer);
					to_file.Close();

					break;

				}
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
