using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallsList;

        public Walls(int width, int height)
        {
            wallsList = new List<Figure>();

            HorizontalLine upLine = new HorizontalLine(0, width - 2, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, width - 2, height - 1, '+');
            VerticalLine leftLine = new VerticalLine(0, height - 1, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, height - 1, width - 2, '+');

            wallsList.Add(upLine);
            wallsList.Add(downLine);
            wallsList.Add(leftLine);
            wallsList.Add(rightLine);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallsList)
            {
                if (wall.IsHit(figure))
                    return true;
            }
            return false;
        }

        public void Draw()
        {
            foreach (Figure item in wallsList)
            {
                item.Draw();
            }
        }
    }
}
