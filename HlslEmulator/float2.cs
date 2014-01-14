namespace HlslEmulator
{
    using System;
    using MathNet.Numerics.LinearAlgebra.Generic;
    using MathNet.Numerics.LinearAlgebra.Single;
    using MathNet.Numerics.LinearAlgebra.Storage;

    // ReSharper disable InconsistentNaming
    public class float2 : DenseVector
    {
        public float2(float x, float y)
            : base(2)
        {
            base[0] = x;
            base[1] = y;
        }

        public float2(Vector<float> v)
            : base(2)
        {
            if (v.Count != 2)
                throw new ArgumentException();
            base[0] = v[0];
            base[1] = v[1];
        }

        public float x { get { return base[0]; } }
        public float y { get { return base[1]; } }
        public static float2 operator +(float2 v1, float2 v2)
        {
            return new float2(v1.Add(v2));
        }
        public static float2 operator -(float2 v1, float2 v2)
        {
            return new float2(v1.Subtract(v2));
        }
        public override Matrix<float> CreateMatrix(int rows, int columns)
        {
            throw new System.NotImplementedException();
        }
        public override Vector<float> CreateVector(int size)
        {
            return new float2(1, 2);
        }
    }
    // ReSharper restore InconsistentNaming
}