using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');

            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

            Point startPosition = new Point(5, 5, '*');
            Snake snake = new Snake(startPosition, 4, Direction.Right);
            
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyDirection = Console.ReadKey();
                    snake.HandleKey(keyDirection.Key);
                }
                Thread.Sleep(200);
                snake.Move();
            }
        }

    }
}
