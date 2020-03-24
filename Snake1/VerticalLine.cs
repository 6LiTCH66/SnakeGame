using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake1
{
    class VerticalLine : Figure
    {
        

        public VerticalLine(int yVverh, int yVniz, int x, char sym)
        {
            List<Point> pList;

            pList = new List<Point>();
            for(int y = yVverh; y<= yVniz; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }                                   
        }
    }
}
