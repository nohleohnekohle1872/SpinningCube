using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpinningCube
{
    public class Matrix
    {
        public double[,] _Matrix { get; set; } = new double[0,0];
        public int Rows { get; set; }
        public int Columns { get; set; }

        public static Matrix X_RotationMatrix = new(3, 3);
        public static Matrix Y_RotationMatrix = new(3, 3);
        public static Matrix Z_RotationMatrix = new(3, 3);
        

        public Matrix(int rows, int columns) 
        { 
            _Matrix = new double[rows, columns];
            Rows = rows; 
            Columns = columns;
        }

        // adds the element at the first row and first column and increasing => [A1,1] [A1,2] [A1,n] [A2,1] [A2,2] [Am,n]
        public void Fill(double[] values)
        {
            int idx = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _Matrix[i, j] = values[idx];
                    idx++;
                }
            }
        }
        
        public void AddElement(double element, int row, int column)
        {
            _Matrix[row, column] = element;
        }

        public void Show(int x, int y)
        {
            int previous_x = x;
            
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    HelpSystems.PrintString(x, y, $"{_Matrix[i, j]}");
                    x += 2;
                }
                y++;
                x = previous_x;
            }
        }
        
        public double GetElement(int row, int column)
        {
            return _Matrix[row - 1, column - 1];
        }

        public void InitializeWithZeros()
        {
            for(int i = 0; i < Rows; i++)
            {
                for (int k = 0; k < Columns; k++)
                {
                    _Matrix[i, k] = 0;
                }
            }
        }

        public Matrix Multiply(Matrix matrix)
        {
            Matrix m = new(Rows, matrix.Columns);

            for (int i = 0; i < m.Rows; i++)
            {
                for (int k = 0; k < m.Columns; k++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        m._Matrix[i, k] = m._Matrix[i, k]  + _Matrix[i, j] * matrix._Matrix[j, k];
                    }
                }
            }
            return m;
        }

        public Vector ToVector3()
        {
            return new(_Matrix[0,0], _Matrix[1,0], _Matrix[2,0]);
        }

        public Matrix Round()
        {
            Matrix m = new(Rows, Columns);
            for (int i = 0; i < m.Rows; i++)
            {
                for (int k = 0; k < m.Columns; k++)
                {
                    m._Matrix[i, k] = Math.Round(_Matrix[i, k], 0);
                }
            }
            return m;
        }
    }
}
