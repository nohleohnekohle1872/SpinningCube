using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpinningCube
{
    public class Square
    {
        public double SideLength { get; set; }
        public Point MiddlePoint { get; set; }
        public Point[] Points { get; set; }

        public Square(double sideLength, Point middlePoint) 
        { 
            SideLength = sideLength;
            MiddlePoint = middlePoint;
            Points = CalculatePoints();
        }

        public Point[] CalculatePoints()
        {
            List<Point> Points = [];
            if (SideLength % 2 == 0)
                SideLength++;

            for (int i = (int)MiddlePoint.X - (int)(SideLength / 2); i < (int)MiddlePoint.X + (int)(SideLength / 2); i++)
            {
                int x = i;
                int y = (int)MiddlePoint.Y - (int)SideLength / 2;
                Points.Add(new((double)x, (double)y, 0));
            }

            for (int i = (int)MiddlePoint.Y - (int)(SideLength / 2); i < (int)MiddlePoint.Y + (int)(SideLength / 2); i++)
            {
                int x = (int)MiddlePoint.X + (int)SideLength / 2;
                int y = i;
                Points.Add(new((double)x, (double)y, 0));
            }

            for (int i = (int)MiddlePoint.X + (int)(SideLength / 2); i > (int)MiddlePoint.X - (int)(SideLength / 2); i--)
            {
                int x = i;
                int y = (int)MiddlePoint.Y + (int)SideLength / 2;
                Points.Add(new((double)x, (double)y, 0));
            }

            for (int i = (int)MiddlePoint.Y + (int)(SideLength / 2); i > (int)MiddlePoint.Y - (int)(SideLength / 2); i--)
            {
                int x = (int)MiddlePoint.X - (int)SideLength / 2;
                int y = i;
                Points.Add(new((double)x, (double)y, 0));
            }

            return Points.ToArray();
        }

        public void Draw(ConsoleColor color)
        {
            foreach (Point p in Points)
            {
                p.Draw(color, "**");
            }
        }

        public void Remove()
        {
            foreach (Point p in Points)
            {
                p.Remove();
            }
        }

        public void Rotate(double x, double y, double z, Point axisPoint)
        {
            int counter = 0;

            foreach (Point p in Points)
            {
                Vector v = Vector.GetDirectionVectorBy2Points(p, axisPoint);
                v = v.Rotate(x, y, z);
                VectorialLineEquation vLE = new(axisPoint.ToVector(), v);
                Points[counter] = vLE.GetPoint(1);
                counter++;
                //
                Points[counter - 1].Draw(ConsoleColor.Green, "**");
            }
        }

    }
}
