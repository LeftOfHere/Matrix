using System;
using System.Linq;

namespace Matrix
{
    class Matrices
    {
        //pre calculated value for pi/180
        public const float _PI180 = 0.01745329251f;
        //pre calculated value for 180/pi
        public const float _180PI = 57.2957795131f;

        public float DegreesToRadians(float x)
        {
            return x * _PI180;
        }

        public float RadiansToDegrees(float x)
        {
            return x * _180PI;
        }

        /// <summary>
        /// |    1        0        0        0    |
        /// |                                    |
        /// |    0        1        0        0    |
        /// |                                    |
        /// |    0        0        1        0    |
        /// |                                    |
        /// |    0        0        0        1    |
        /// </summary>
        /// <returns>The matrix</returns>
        public float[] IdentityMatrix()
        {
            float[] m = new float[16];

            m[0] = m[5] = m[10] = m[15] = 1.0f;
            m[1] = m[2] = m[3] = m[4] = 0.0f;
            m[6] = m[7] = m[8] = m[9] = 0.0f;
            m[11] = m[12] = m[13] = m[14] = 0.0f;

            return m;
        }

        /// <summary>
        /// |    1        0        0        X    |
        /// |                                    |
        /// |    0        1        0        Y    |
        /// |                                    |
        /// |    0        0        1        Z    |
        /// |                                    |
        /// |    0        0        0        1    |
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>The matrix</returns>
        public float[] TranslationMatrix(float x, float y, float z)
        {
            float[] matrix = IdentityMatrix();

            matrix[12] = x;
            matrix[13] = y;
            matrix[14] = z;

            return matrix;
        }

        /// <summary>
        /// |    SX       0        0        0    |
        /// |                                    |
        /// |    0        SY       0        0    |
        /// |                                    |
        /// |    0        0        SZ       0    |
        /// |                                    |
        /// |    0        0        0        1    |
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>The matrix</returns>
        public float[] ScaleMatrix(float x, float y, float z)
        {
            float[] matrix = IdentityMatrix();

            matrix[0] = x;
            matrix[5] = y;
            matrix[10] = z;

            return matrix;
        }

        /// <summary>
        /// |    1        0        0        0    |
        /// |                                    |
        /// |    0      cos(θ)   sin(θ)     0    |
        /// |                                    |
        /// |    0     -sin(θ)   cos(θ)     0    |
        /// |                                    |
        /// |    0        0        0        1    |
        /// </summary>
        /// <param name="degOrRad">THe degrees or radians to rotate</param>
        /// <param name="rad">Set true if passing in radians.</param>
        /// <returns>The matrix</returns>
        public float[] RotateXMatrix(float degOrRad, bool rad = false)
        {
            if (!rad)
                degOrRad = DegreesToRadians(degOrRad);

            float[] matrix = IdentityMatrix();

            // Rotate X formula.
            matrix[5] = float.Parse(Math.Cos(degOrRad).ToString());
            matrix[6] = -float.Parse(Math.Sin(degOrRad).ToString());
            matrix[9] = -matrix[6];
            matrix[10] = matrix[5];

            return matrix;
        }

        /// <summary>
        /// |  cos(θ)     0    -sin(θ)      0    |
        /// |                                    |
        /// |    0        1        0        0    |
        /// |                                    |
        /// |  sin(θ)     0     cos(θ)      0    |
        /// |                                    |
        /// |    0        0        0        1    |
        /// </summary>
        /// <param name="degOrRad"></param>
        /// <param name="rad"></param>
        /// <returns></returns>
        public float[] RotateYMatrix(float degOrRad, bool rad = false)
        {
            if (!rad)
                degOrRad = DegreesToRadians(degOrRad);

            float[] matrix = IdentityMatrix();

            // Rotate Y formula.
            matrix[0] = float.Parse(Math.Cos(degOrRad).ToString());
            matrix[2] = float.Parse(Math.Sin(degOrRad).ToString());
            matrix[8] = -matrix[2];
            matrix[10] = matrix[0];

            return matrix;
        }

        /// <summary>
        /// |  cos(θ)  -sin(θ)     0        0    |
        /// |                                    |
        /// |  sin(θ)   cos(θ)     0        0    |
        /// |                                    |
        /// |    0        0        1        0    |
        /// |                                    |
        /// |    0        0        0        1    |
        /// </summary>
        /// <param name="degOrRad"></param>
        /// <param name="rad"></param>
        /// <returns></returns>
        public float[] RotateZMatrix(float degOrRad, bool rad = false)
        {
            if (!rad)
                degOrRad = DegreesToRadians(degOrRad);

            float[] matrix = IdentityMatrix();

            // Rotate Z formula.
            matrix[0] = float.Parse(Math.Cos(degOrRad).ToString());
            matrix[1] = float.Parse(Math.Sin(degOrRad).ToString());
            matrix[4] = -matrix[1];
            matrix[5] = matrix[0];

            return matrix;
        }
    }
}
