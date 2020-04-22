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
			/*SoundPlayer player = new SoundPlayer();
			player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "music.wav";
			player.Play();

			SoundPlayer player1 = new SoundPlayer();
			player1.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "pop.wav";

			SoundPlayer player2 = new SoundPlayer();
			player2.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "died.wav";
			//player2.Play();*/


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
			sound.Play("music");

			Sound sound1 = new Sound(settings.GetResourcesFolder());

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					food = foodCreator.CreateFood();
					food.Draw();
					sound1.PlayEat();
					//player1.Play();
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
