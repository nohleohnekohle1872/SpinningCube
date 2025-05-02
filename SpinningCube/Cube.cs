using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpinningCube
{
    public class Cube
    {
        public double SideLength { get; set; }
        public Point MiddlePoint { get; set; }
        public Point[] Points { get; set; }

        public Cube(double sideLength, Point middlePoint)
        {
            SideLength = sideLength;
            MiddlePoint = middlePoint;
            Points = CalculatePoints();
        }

        public Point[] CalculatePoints()
        {
            Square sq = new(SideLength, MiddlePoint);
            Point[] firstPoints = sq.CalculatePoints();
            HashSet<Point> points = [];
            foreach (Point p in firstPoints)
            {
                points.Add(p);
            }

            sq.Rotate(0, 90, 0, MiddlePoint);
            Point[] secondPoints = sq.Points;
            foreach (Point p in secondPoints)
            {
                points.Add(new(p.X - (double)(int)(sq.SideLength / 2), p.Y, p.Z + (double)(int)(sq.SideLength / 2)));
                points.Add(new(p.X + (double)(int)(sq.SideLength / 2), p.Y, p.Z + (double)(int)(sq.SideLength / 2)));
            }

            sq.Rotate(0, 90, 0, MiddlePoint);
            Point[] thridPoints = sq.Points;
            foreach (Point p in secondPoints)
            {
                points.Add(new(p.X, p.Y, p.Z + sq.SideLength));
            }

            return points.ToArray();
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

        public void Rotate(double x, double y, double z)
        {
            int counter = 0;

            foreach (Point p in Points)
            {
                Vector v = Vector.GetDirectionVectorBy2Points(p, MiddlePoint);
                v = v.Rotate(x, y, z);
                VectorialLineEquation vLE = new(MiddlePoint.ToVector(), v);
                Points[counter] = vLE.GetPoint(1);
                counter++;
                //
                Points[counter - 1].Draw(ConsoleColor.DarkGreen, "**");
            }
        }
    }
}
