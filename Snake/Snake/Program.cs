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

            Walls wall = new Walls(Console.BufferWidth, Console.BufferHeight);
            wall.Draw();

            Point startPosition = new Point(5, 5, '*');
            Snake snake = new Snake(startPosition, 4, Direction.Right);

            FoodCreator foodCreator = new FoodCreator(Console.BufferWidth, Console.BufferHeight, '@');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (wall.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                    snake.Move();

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyDirection = Console.ReadKey();
                    snake.HandleKey(keyDirection.Key);
                }
            }
        }

    }
}
