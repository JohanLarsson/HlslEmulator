namespace HlslEmulator
{
    using System;
    using MathNet.Numerics.LinearAlgebra.Generic;
    using MathNet.Numerics.LinearAlgebra.Single;

// ReSharper disable InconsistentNaming
    public class float4 : DenseVector
    {
        public float4(float r, float g, float b, float a)
            : base(4)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
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
        public float b { get { return base[1]; } private set { base[1] = value; } }
        public float a { get { return base[1]; } private set { base[1] = value; } }
        public float3 rgb { get{return new float3(r,g,b);} }
        public override Matrix<float> CreateMatrix(int rows, int columns)
        {
            throw new System.NotImplementedException();
        }
        public override Vector<float> CreateVector(int size)
        {
            throw new System.NotImplementedException();
        }
    }
    // ReSharper restore InconsistentNaming
}