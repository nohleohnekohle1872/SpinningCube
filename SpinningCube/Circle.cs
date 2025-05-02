using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpinningCube
{
    public class Circle
    {
        public Point MiddlePoint { get; set; }
        public double Radius { get; set; }
        public Point[] Points { get; set; }


        public Circle(Point middlePoint, double radius) 
        {
            MiddlePoint = middlePoint;
            Radius = radius;
            Points = CalculatePoints();
        }

        public Point[] CalculatePoints()
        {
            List<Point> borderPoints = [];
            bool next = true;

            for (double i = 0; i <= 360; i += 1)
            {
                int x = (int)Math.Round(Math.Cos(Program.TransformDegreeToRadiant(i)) * Radius) + (int)MiddlePoint.X;
                int y = (int)Math.Round(Math.Sin(Program.TransformDegreeToRadiant(i)) * Radius) + (int)MiddlePoint.Y;

                Point point = new(x, y, 0);

                if (i == 0)
                {
                    borderPoints.Add(point);
                    continue;
                }
                
                foreach (Point p in borderPoints)
                {
                    if (point.IsEqualTo(p))
                        next = false;
                }
                
                if (next)
                    borderPoints.Add(point);

                next = true;
            }

            return borderPoints.ToArray();
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
                Points[counter - 1].Draw(ConsoleColor.Cyan, "**");
            }
        }
    }
}
