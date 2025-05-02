using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpinningCube
{
    public class VectorialLineEquation
    {
        public Vector PlaceVector { get; set; }
        public double Factor {  get; set; }
        public Vector DirectionVector { get; set; }
        

        public VectorialLineEquation(Vector placeVector, Vector directionVector) 
        { 
            PlaceVector = placeVector;
            DirectionVector = directionVector;
        }

        public Point GetPoint(double factor)
        {
            Factor = factor;
            Vector v1 = Vector.MultiplyF(DirectionVector, factor);
            v1 = Vector.Addition([v1, PlaceVector]);
            return Vector.ToPoint(v1);
        }
    }
}
