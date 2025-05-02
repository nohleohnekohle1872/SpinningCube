using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpinningCube
{
    public class Sphere
    {
        public Point MiddlePoint { get; set; }
        public double Radius { get; set; }
        public Point[] Points { get; set; } = [];
        public Circle[] Circles { get; set; } = [];


        public Sphere(Point middlePoint, double radius)
        {
            MiddlePoint = middlePoint;
            Radius = radius;
            Circles = CreateCircles();
            Points = GetPoints();
        }

        public Circle[] CreateCircles()
        {
            List<Point> points = [];

            for (int i = 0; i < 360; i++)
            {

            }
            Circle c = new(MiddlePoint, Radius);
            foreach (Point p in c.Points)
            {
                points.Add(p);
            }

            // TODO
            return new Circle[] { c };
        }

        public Point[] GetPoints()
        {
            // TODO
            return new Point[Points.Length];
        }

        public void Draw(ConsoleColor color)
        {
            foreach (Point p in Points)
            {
                p.Draw(color, new(p.Sign, 2));
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
                Points[counter - 1].Draw(ConsoleColor.DarkGreen, new(Points[counter - 1].Sign, 2));
            }
        }

    }
}
