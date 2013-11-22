using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrices
    {
        //pre calculated value for pi/180
        public const double _PI180 = 0.01745329251;
        //pre calculated value for 180/pi
        public const double _180PI = 57.2957795131;

        public double DegreesToRadians(double x)
        {
            return x * _PI180;
        }

        public double RadiansToDegrees(double x)
        {
            return x * _180PI;
        }

        public float[,] IdentityMatrix()
        {
            return new float[4, 4] { { 1f, 0f, 0f, 0f },
                                      { 0f, 1f, 0f, 0f },
                                      { 0f, 0f, 1f, 0f },
                                      { 0f, 0f, 0f, 1f } };
        }

        public float[,] TranslationMatrix(float x, float y, float z)
        {
            return new float[4, 4] { { 1f, 0f, 0f, x },
                                      { 0f, 1f, 0f, y },
                                      { 0f, 0f, 1f, z },
                                      { 0f, 0f, 0f, 1f } };
        }

        public float[,] ScaleMatrix(float x, float y, float z)
        {
            return new float[4, 4] { { x, 0f, 0f, 0f },
                                      { 0f, y, 0f, 0f },
                                      { 0f, 0f, z, 0f },
                                      { 0f, 0f, 0f, 1f } };
        }
    }
}
