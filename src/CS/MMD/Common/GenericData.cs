using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku
{
    public struct GenVector2
    {
        public float    X, Y;

        public override string ToString()
        {
            return string.Format("{0}, {1}", X, Y);
        }

        public GenVector2 Normalized()
        {
            var d   = Dot(this, this);

            if(d < 1e-6f)
                return this;

            d       = 1 / (float)Math.Sqrt(d);

            return new GenVector2() { X= X*d, Y= Y*d };
        }

        public static float Dot(GenVector2 a, GenVector2 b)
        {
            return a.X*b.X + a.Y*b.Y;
        }
    }

    public struct GenVector3
    {
        public float    X, Y, Z;

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", X, Y, Z);
        }

        public GenVector3 Normalized()
        {
            var d   = Dot(this, this);

            if(d < 1e-6f)
                return this;

            d       = 1 / (float)Math.Sqrt(d);

            return new GenVector3() { X= X*d, Y= Y*d, Z= Z*d };
        }

        public static float Dot(GenVector3 a, GenVector3 b)
        {
            return a.X*b.X + a.Y*b.Y + a.Z*b.Z;
        }
    }

    public struct GenVector4
    {
        public float    X, Y, Z, W;

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", X, Y, Z, W);
        }

        public GenVector4 Normalized()
        {
            var d   = Dot(this, this);

            if(d < 1e-6f)
                return this;

            d       = 1 / (float)Math.Sqrt(d);

            return new GenVector4() { X= X*d, Y= Y*d, Z= Z*d, W= W*d };
        }

        public static float Dot(GenVector4 a, GenVector4 b)
        {
            return a.X*b.X + a.Y*b.Y + a.Z*b.Z + a.W*b.W;
        }
    }

    public struct GenColor3
    {
        public float    R, G, B;

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", R, G, B);
        }
    }

    public struct GenColor4
    {
        public float    R, G, B, A;

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", R, G, B, A);
        }
    }
}
