using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Projections
    {
        public void OrthographicProjection(float[] matrix)
        {
            // These paramaters are lens properties.
            // The "near" and "far" create the Depth of Field.
            // The "left", "right", "bottom" and "top" represent the rectangle formed
            // by the near area, this rectangle will also be the size of the visible area.
            float near = 0.001f, far = 100.0f;
            float left = 0.0f, right = 320.0f, bottom = 480.0f, top = 0.0f;

            // First Column
            matrix[0] = 2.0f / (right - left);
            matrix[1] = 0.0f;
            matrix[2] = 0.0f;
            matrix[3] = 0.0f;

            // Second Column
            matrix[4] = 0.0f;
            matrix[5] = 2.0f / (top - bottom);
            matrix[6] = 0.0f;
            matrix[7] = 0.0f;

            // Third Column
            matrix[8] = 0.0f;
            matrix[9] = 0.0f;
            matrix[10] = -2.0f / (far - near);
            matrix[11] = 0.0f;

            // Fourth Column
            matrix[12] = -(right + left) / (right - left);
            matrix[13] = -(top + bottom) / (top - bottom);
            matrix[14] = -(far + near) / (far - near);
            matrix[15] = 1;
        }

        public void PerspectiveProjection(float[] matrix)
        {
            // These paramaters are about lens properties.
            // The "near" and "far" create the Depth of Field.
            // The "angleOfView", as the name suggests, is the angle of view.
            // The "aspectRatio" is the cool thing about this matrix. OpenGL doesn't
            // has any information about the screen you are rendering for. So the
            // results could seem stretched. But this variable puts the thing into the
            // right path. The aspect ratio is your device screen (or desired area) width divided
            // by its height. This will give you a number < 1.0 the the area has more vertical
            // space and a number > 1.0 is the area has more horizontal space.
            // Aspect Ratio of 1.0 represents a square area.
            float near = 0.001f, far = 100.0f;
            float angleOfView = 45.0f;
            float aspectRatio = 0.75f;

            // Some calculus before the formula.
            float size = near * float.Parse(Math.Tan(new Matrices().DegreesToRadians(angleOfView) / 2.0).ToString());
            float left = -size, right = size, bottom = -size / aspectRatio, top = size / aspectRatio;

            // First Column
            matrix[0] = 2 * near / (right - left);
            matrix[1] = 0.0f;
            matrix[2] = 0.0f;
            matrix[3] = 0.0f;

            // Second Column
            matrix[4] = 0.0f;
            matrix[5] = 2 * near / (top - bottom);
            matrix[6] = 0.0f;
            matrix[7] = 0.0f;

            // Third Column
            matrix[8] = (right + left) / (right - left);
            matrix[9] = (top + bottom) / (top - bottom);
            matrix[10] = -(far + near) / (far - near);
            matrix[11] = -1;

            // Fourth Column
            matrix[12] = 0.0f;
            matrix[13] = 0.0f;
            matrix[14] = -(2 * far * near) / (far - near);
            matrix[15] = 0.0f;
        }
    }
}
