﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Quaternion
    {
        public float W;
        public float X;
        public float Y;
        public float Z;

        public Quaternion()
        {
        }

        public Quaternion(float w, float x, float y, float z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        public Quaternion QuaternionIdentity()
        {
            Quaternion q = new Quaternion();

            q.X = 0;
            q.Y = 0;
            q.Z = 0;
            q.W = 1;

            return q;
        }
    }
}