using System;
using System.Linq;

namespace Matrix
{
    class MatrixMath
    {
        /// <summary>
        /// Multiplies matrix m1 with matrix m2 (m1 x m2). 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns>The resulting matrix.</returns>
        public float[] MultiplyMatrix(float[] m1, float[] m2)
        {
            float[] result = new Matrices().IdentityMatrix();

            // Fisrt Column
            result[0] = m1[0] * m2[0] + m1[4] * m2[1] + m1[8] * m2[2] + m1[12] * m2[3];
            result[1] = m1[1] * m2[0] + m1[5] * m2[1] + m1[9] * m2[2] + m1[13] * m2[3];
            result[2] = m1[2] * m2[0] + m1[6] * m2[1] + m1[10] * m2[2] + m1[14] * m2[3];
            result[3] = m1[3] * m2[0] + m1[7] * m2[1] + m1[11] * m2[2] + m1[15] * m2[3];

            // Second Column
            result[4] = m1[0] * m2[4] + m1[4] * m2[5] + m1[8] * m2[6] + m1[12] * m2[7];
            result[5] = m1[1] * m2[4] + m1[5] * m2[5] + m1[9] * m2[6] + m1[13] * m2[7];
            result[6] = m1[2] * m2[4] + m1[6] * m2[5] + m1[10] * m2[6] + m1[14] * m2[7];
            result[7] = m1[3] * m2[4] + m1[7] * m2[5] + m1[11] * m2[6] + m1[15] * m2[7];

            // Third Column
            result[8] = m1[0] * m2[8] + m1[4] * m2[9] + m1[8] * m2[10] + m1[12] * m2[11];
            result[9] = m1[1] * m2[8] + m1[5] * m2[9] + m1[9] * m2[10] + m1[13] * m2[11];
            result[10] = m1[2] * m2[8] + m1[6] * m2[9] + m1[10] * m2[10] + m1[14] * m2[11];
            result[11] = m1[3] * m2[8] + m1[7] * m2[9] + m1[11] * m2[10] + m1[15] * m2[11];

            // Fourth Column
            result[12] = m1[0] * m2[12] + m1[4] * m2[13] + m1[8] * m2[14] + m1[12] * m2[15];
            result[13] = m1[1] * m2[12] + m1[5] * m2[13] + m1[9] * m2[14] + m1[13] * m2[15];
            result[14] = m1[2] * m2[12] + m1[6] * m2[13] + m1[10] * m2[14] + m1[14] * m2[15];
            result[15] = m1[3] * m2[12] + m1[7] * m2[13] + m1[11] * m2[14] + m1[15] * m2[15];

            return result;
        }

        /// <summary>
        // This is the arithmetical formula optimized to work with unit quaternions.
        // |1-2y²-2z²        2xy-2zw         2xz+2yw       0|
        // | 2xy+2zw        1-2x²-2z²        2yz-2xw       0|
        // | 2xz-2yw         2yz+2xw        1-2x²-2y²      0|
        // |    0               0               0          1|
        /// </summary>
        /// <param name="q">float[4] quaternian (x,y,z,w)</param>
        /// <returns>The resultin matrix</returns>
        public float[] QuaternianToMatrix(Quaternion q)
        {
            float[] matrix = new Matrices().IdentityMatrix();

            // First Column
            matrix[0] = 1 - 2 * (q.Y * q.Y + q.Z * q.Z);
            matrix[1] = 2 * (q.X * q.Y + q.Z * q.W);
            matrix[2] = 2 * (q.X * q.Z - q.Y * q.W);
            matrix[3] = 0;

            // Second Column
            matrix[4] = 2 * (q.X * q.Y - q.Z * q.W);
            matrix[5] = 1 - 2 * (q.X * q.X + q.Z * q.Z);
            matrix[6] = 2 * (q.Z * q.Y + q.X * q.W);
            matrix[7] = 0;

            // Third Column
            matrix[8] = 2 * (q.X * q.Z + q.Y * q.W);
            matrix[9] = 2 * (q.Y * q.Z - q.X * q.W);
            matrix[10] = 1 - 2 * (q.X * q.X + q.Y * q.Y);
            matrix[11] = 0;

            // Fourth Column
            matrix[12] = 0;
            matrix[13] = 0;
            matrix[14] = 0;
            matrix[15] = 1;

            return matrix;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="q1"></param>
        /// <param name="q2"></param>
        /// <returns>New Quaternion</returns>
        public Quaternion MultiplyQuaternions(Quaternion q1, Quaternion q2)
        {
            Quaternion newQ = new Quaternion();

            // Assume that this multiplies q1 x q2, in this order, resulting in "newQ".
            newQ.W = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z;
            newQ.X = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y;
            newQ.Y = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X;
            newQ.Z = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W;

            return newQ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="q1"></param>
        /// <param name="q2"></param>
        /// <returns>New Quaternion</returns>
        public Quaternion InverseQuaternions(Quaternion q)
        {
            q.X *= -1;
            q.Y *= -1;
            q.Z *= -1;

            return q;
        }
    }
}
