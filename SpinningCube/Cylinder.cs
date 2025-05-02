using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpinningCube
{
    public class Cylinder
    {
        public Point MiddlePoint { get; set; }
        public double Radius { get; set; }
        public Point[] Points { get; set; }
        public int Length { get; set; }


        public Cylinder(Point middlePoint, double radius, int length)
        {
            MiddlePoint = middlePoint;
            Radius = radius;
            Length = length;
            Points = CalculatePoints();
        }

        public Point[] CalculatePoints()
        {
            List<Circle> circles = [];
            List<Point> points = [];
            for (int i = 0; i < Length; i++)
            {
                circles.Add(new(new(MiddlePoint.X - (int)(Length / 2) + i, MiddlePoint.Y, MiddlePoint.Z), Radius));
            }

            foreach (Circle c in circles)
            {
                foreach (Point p in c.Points)
                    points.Add(p);
            }

            return points.ToArray();
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
                Points[counter - 1].Draw(ConsoleColor.Cyan, "**");
            }
        }

        public void Draw(ConsoleColor color)
        {
            foreach (Point point in Points)
            {
                point.Draw(color, "**");
            }
        }

        public void Remove()
        {
            foreach (Point p in Points)
            {
                p.Remove();
            }
        }

    }
}
