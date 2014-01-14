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

        public float2(Vector<float> normalize)
            : base(2)
        {
            if (normalize.Count != 2)
                throw new ArgumentException();
            base[0] = normalize[0];
            base[1] = normalize[1];
        }

        public float x { get { return base[0]; } }
        public float y { get { return base[1]; } }
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