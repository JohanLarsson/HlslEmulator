namespace HlslEmulator
{
    using System;
    using MathNet.Numerics.LinearAlgebra.Generic;
    using MathNet.Numerics.LinearAlgebra.Single;

    // ReSharper disable InconsistentNaming
    public class float4 : DenseVector
    {
        public float4(double r, double g, double b, double a)
            : base(4)
        {
            this.r = (float)r;
            this.g = (float)g;
            this.b = (float)b;
            this.a = (float)a;
        }

        public float4(Vector<float> v)
            : base(4)
        {
            if (v.Count != 4)
                throw new ArgumentException();
            this.r = v[0];
            this.g = v[1];
            this.b = v[2];
            this.a = v[3];
        }

        public float r { get { return base[0]; } private set { base[0] = value; } }
        public float g { get { return base[1]; } private set { base[1] = value; } }
        public float b { get { return base[2]; } private set { base[2] = value; } }
        public float a { get { return base[3]; } private set { base[3] = value; } }
        public float3 rgb { get { return new float3(r, g, b); } }
        public static float4 operator +(float4 v1, float4 v2)
        {
            return new float4(v1.Add(v2));
        }
        public static float4 operator -(float4 v1, float4 v2)
        {
            return new float4(v1.Subtract(v2));
        }
        public override Matrix<float> CreateMatrix(int rows, int columns)
        {
            throw new System.NotImplementedException();
        }
        public override Vector<float> CreateVector(int size)
        {
            return new float4(1, 2, 3, 4);
        }
    }
    // ReSharper restore InconsistentNaming
}