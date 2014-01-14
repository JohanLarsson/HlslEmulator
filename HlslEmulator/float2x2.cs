namespace HlslEmulator
{
    using MathNet.Numerics.LinearAlgebra.Single;

// ReSharper disable InconsistentNaming
    public class float2x2 : DenseMatrix
    {
        public float2x2(float r0c0, float r0c1, float r1c0, float r1c1)
            : base(2,2)
        {
            base[0, 0] = r0c0;
            base[0, 1] = r0c1;
            base[1, 0] = r1c0;
            base[1, 1] = r1c1;
        }
        
    }
    // ReSharper restore InconsistentNaming
}