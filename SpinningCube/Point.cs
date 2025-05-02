using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpinningCube
{
    public class Point
    {
        public double X {  get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.White;
        public char Sign { get; set; }

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector ToVector()
        {
            return new Vector(X, Y, Z);
        }

        public void Draw(ConsoleColor color, string sign)
        {
            if (sign == "  ")
                HelpSystems.PrintString((int)X * 2, (int)Y, sign, color, color);
            else
                HelpSystems.PrintString((int)X * 2, (int)Y, sign, color);
        }

        public void Remove()
        {
            HelpSystems.PrintString((int)X * 2, (int)Y, "  ", ConsoleColor.Black);
        }

        public bool IsEqualTo(Point p)
        {
            if (p.X == X && p.Y == Y && p.Z == Z)
                return true;
            return false;
        }

        public Point MultiplyF(double factor)
        {
            return new(X * factor, Y * factor, Z * factor);
        }

        public void ShowCoordinates(int x, int y)
        {
            HelpSystems.PrintString(x, y, X.ToString());
            y++;
            HelpSystems.PrintString(x, y, Y.ToString());
            y++;
            HelpSystems.PrintString(x, y, Z.ToString());
        }
    }
}
