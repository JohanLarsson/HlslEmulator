namespace HlslEmulator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using MathNet.Numerics.LinearAlgebra.Generic;
    using MathNet.Numerics.LinearAlgebra.Single;

// ReSharper disable InconsistentNaming
    public class float3 : DenseVector
    {
        public float3(float r, float g, float b)
            : base(3)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public float3(Vector<float> v)
            : base(3)
        {
            if (v.Count != 3)
                throw new ArgumentException();
            this.r = v[0];
            this.g = v[1];
            this.b = v[2];
        }
        public float3(IEnumerable<float> v)
            : this(OfEnumerable(v))
        {
        }

        public float r { get { return base[0]; } private set { base[0] = value; } }
        public float g { get { return base[1]; } private set { base[1] = value; } }
        public float b { get { return base[1]; } private set { base[1] = value; } }
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