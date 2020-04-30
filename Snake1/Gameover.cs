using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class Gameover
    {
        public void Game()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 1);
            Console.WriteLine("╔═══╗╔══╗╔╗──╔╗╔═══╗──╔══╗╔╗╔╗╔═══╗╔═══╗");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(20, 2);
            Console.WriteLine("║╔══╝║╔╗║║║──║║║╔══╝──║╔╗║║║║║║╔══╝║╔═╗║");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(20, 3);
            Console.WriteLine("║║╔═╗║╚╝║║╚╗╔╝║║╚══╗──║║║║║║║║║╚══╗║╚═╝║");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(20, 4);
            Console.WriteLine("║║╚╗║║╔╗║║╔╗╔╗║║╔══╝──║║║║║╚╝║║╔══╝║╔╗╔╝");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("║╚═╝║║║║║║║╚╝║║║╚══╗──║╚╝║╚╗╔╝║╚══╗║║║║");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(20, 6);
            Console.WriteLine("╚═══╝╚╝╚╝╚╝──╚╝╚═══╝──╚══╝─╚╝─╚═══╝╚╝╚╝");
        }
    }
}
