using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MikuMiku
{
    public struct GenMatrix
    {
        public static readonly GenMatrix    Identity    = new GenMatrix(1,0,0,0, 0,1,0,0, 0,0,1,0, 0,0,0,1);
        public static readonly GenMatrix    Zero        = new GenMatrix(0,0,0,0, 0,0,0,0, 0,0,0,0, 0,0,0,0);

        public float    M11, M12, M13, M14;
        public float    M21, M22, M23, M24;
        public float    M31, M32, M33, M34;
        public float    M41, M42, M43, M44;

        public float[]  ToArray()
        {
            return new float[]
            {
                M11, M12, M13, M14,
                M21, M22, M23, M24,
                M31, M32, M33, M34,
                M41, M42, M43, M44,
            };
        }

        public GenMatrix(
            float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44)
        {
            M11= m11; M12= m12; M13= m13; M14= m14;
            M21= m21; M22= m22; M23= m23; M24= m24;
            M31= m31; M32= m32; M33= m33; M34= m34;
            M41= m41; M42= m42; M43= m43; M44= m44;
        }

        public GenMatrix(
            float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33,
            float m41, float m42, float m43)
        {
            M11= m11; M12= m12; M13= m13; M14= 0;
            M21= m21; M22= m22; M23= m23; M24= 0;
            M31= m31; M32= m32; M33= m33; M34= 0;
            M41= m41; M42= m42; M43= m43; M44= 1;
        }

        public GenMatrix(
            float m11, float m12, float m13,
            float m21, float m22, float m23,
            float m31, float m32, float m33)
        {
            M11= m11; M12= m12; M13= m13; M14= 0;
            M21= m21; M22= m22; M23= m23; M24= 0;
            M31= m31; M32= m32; M33= m33; M34= 0;
            M41= 0;   M42= 0;   M43= 0;   M44= 1;
        }

        public static GenMatrix RotationX(float rad)
        {
            var c   = (float)Math.Cos(rad);
            var s   = (float)Math.Sin(rad);
            return new GenMatrix(
                 1, 0, 0,
                 0, c, s,
                 0,-s, c);
        }

        public static GenMatrix RotationY(float rad)
        {
            var c   = (float)Math.Cos(rad);
            var s   = (float)Math.Sin(rad);
            return new GenMatrix(
                 c, 0,-s,
                 0, 1, 0,
                 s, 0, c);
        }

        public static GenMatrix RotationZ(float rad)
        {
            var c   = (float)Math.Cos(rad);
            var s   = (float)Math.Sin(rad);
            return new GenMatrix(
                 c, s, 0,
                -s, c, 0,
                 0, 0, 1);
        }

        public static GenMatrix Scale(float s)
        {
            return new GenMatrix(
                s, 0, 0,
                0, s, 0,
                0, 0, s);
        }

        public static GenMatrix Scale(float x, float y, float z)
        {
            return new GenMatrix(
                x, 0, 0,
                0, y, 0,
                0, 0, z);
        }

        public static GenMatrix Scale(GenVector3 v)
        {
            return Scale(v.X, v.Y, v.Z);
        }

        public static GenMatrix Translation(float x, float y, float z)
        {
            return new GenMatrix(
                1, 0, 0,
                0, 1, 0,
                0, 0, 1,
                x, y, z);
        }

        public static GenMatrix Translation(GenVector3 v)
        {
            return Translation(v.X, v.Y, v.Z);
        }

        public static GenMatrix Multiply(GenMatrix a, GenMatrix b)
        {
            return new GenMatrix(
                a.M11*b.M11 + a.M12*b.M21 + a.M13*b.M31 + a.M14*b.M41,
                a.M11*b.M12 + a.M12*b.M22 + a.M13*b.M32 + a.M14*b.M42,
                a.M11*b.M13 + a.M12*b.M23 + a.M13*b.M33 + a.M14*b.M43,
                a.M11*b.M14 + a.M12*b.M24 + a.M13*b.M34 + a.M14*b.M44,
                a.M21*b.M11 + a.M22*b.M21 + a.M23*b.M31 + a.M24*b.M41,
                a.M21*b.M12 + a.M22*b.M22 + a.M23*b.M32 + a.M24*b.M42,
                a.M21*b.M13 + a.M22*b.M23 + a.M23*b.M33 + a.M24*b.M43,
                a.M21*b.M14 + a.M22*b.M24 + a.M23*b.M34 + a.M24*b.M44,
                a.M31*b.M11 + a.M32*b.M21 + a.M33*b.M31 + a.M34*b.M41,
                a.M31*b.M12 + a.M32*b.M22 + a.M33*b.M32 + a.M34*b.M42,
                a.M31*b.M13 + a.M32*b.M23 + a.M33*b.M33 + a.M34*b.M43,
                a.M31*b.M14 + a.M32*b.M24 + a.M33*b.M34 + a.M34*b.M44,
                a.M41*b.M11 + a.M42*b.M21 + a.M43*b.M31 + a.M44*b.M41,
                a.M41*b.M12 + a.M42*b.M22 + a.M43*b.M32 + a.M44*b.M42,
                a.M41*b.M13 + a.M42*b.M23 + a.M43*b.M33 + a.M44*b.M43,
                a.M41*b.M14 + a.M42*b.M24 + a.M43*b.M34 + a.M44*b.M44);
        }

        public static GenMatrix Invert(GenMatrix m)
        {
	        var m2  = new GenMatrix();

	        float _a= m.M32*m.M43 - m.M33*m.M42;
	        float _b= m.M32*m.M44 - m.M34*m.M42;
	        float _c= m.M33*m.M44 - m.M34*m.M43;
	        float _d= m.M22*m.M33 - m.M23*m.M32;
	        float _e= m.M22*m.M34 - m.M24*m.M32;
	        float _f= m.M23*m.M34 - m.M24*m.M33;
	        float _g= m.M22*m.M43 - m.M23*m.M42;
	        float _h= m.M22*m.M44 - m.M24*m.M42;
	        float _i= m.M23*m.M44 - m.M24*m.M43;

	        m2.M11	=  (m.M22*_c - m.M23*_b + m.M24*_a);
	        m2.M12	= -(m.M12*_c - m.M13*_b + m.M14*_a);
	        m2.M13	=  (m.M12*_i - m.M13*_h + m.M14*_g);
	        m2.M14	= -(m.M12*_f - m.M13*_e + m.M14*_d);

	        float _j= m.M31*m.M43 - m.M33*m.M41;
	        float _k= m.M31*m.M44 - m.M34*m.M41;
	        float _l= m.M21*m.M33 - m.M23*m.M31;
	        float _m= m.M21*m.M34 - m.M24*m.M31;
	        float _n= m.M21*m.M43 - m.M23*m.M41;
	        float _o= m.M21*m.M44 - m.M24*m.M41;

	        m2.M21	= -(m.M21*_c - m.M23*_k + m.M24*_j);
	        m2.M22	=  (m.M11*_c - m.M13*_k + m.M14*_j);
	        m2.M23	= -(m.M11*_i - m.M13*_o + m.M14*_n);
	        m2.M24	=  (m.M11*_f - m.M13*_m + m.M14*_l);

	        float _p= m.M31*m.M42 - m.M32*m.M41;
	        float _q= m.M21*m.M32 - m.M22*m.M31;
	        float _r= m.M21*m.M42 - m.M22*m.M41;

	        m2.M31	=  (m.M21*_b - m.M22*_k + m.M24*_p);
	        m2.M32	= -(m.M11*_b - m.M12*_k + m.M14*_p);
	        m2.M33	=  (m.M11*_h - m.M12*_o + m.M14*_r);
	        m2.M34	= -(m.M11*_e - m.M12*_m + m.M14*_q);

	        m2.M41	= -(m.M21*_a - m.M22*_j + m.M23*_p);
	        m2.M42	=  (m.M11*_a - m.M12*_j + m.M13*_p);
	        m2.M43	= -(m.M11*_g - m.M12*_n + m.M13*_r);
	        m2.M44	=  (m.M11*_d - m.M12*_l + m.M13*_q);

	        float d	= 1 / (m.M11*m2.M11 - m.M12*m2.M21 + m.M13*m2.M31 - m.M14*m2.M41);

	        m2.M11*=d; m2.M12*=d; m2.M13*=d; m2.M14*=d;
	        m2.M21*=d; m2.M22*=d; m2.M23*=d; m2.M24*=d;
	        m2.M31*=d; m2.M32*=d; m2.M33*=d; m2.M34*=d;
	        m2.M41*=d; m2.M42*=d; m2.M43*=d; m2.M44*=d;

	        return m2;
        }
    }
}
