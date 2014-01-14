namespace HlslEmulator
{
    using System;
    using System.ComponentModel.Design;
    using System.Security.Cryptography.X509Certificates;

    // ReSharper disable InconsistentNaming
    public class EmulatorBase
    {
        protected static float dot(float2 v1, float2 v2)
        {
            return v1.DotProduct(v2);
        }

        protected static float2 float2(float x, float y)
        {
            return new float2(x, y);
        }

        protected float2x2 float2x2(float r0c0, float r0c1, float r1c0, float r1c1)
        {
            return new float2x2( r0c0,  r0c1,  r1c0,  r1c1);
        }

        protected static float atan2(float x, float y)
        {
            return (float) Math.Atan2(x, y);
        }

        protected static float sin(float angle)
        {
            return (float)Math.Sin(angle);
        }

        protected static float cos(float angle)
        {
            return (float)Math.Cos(angle);
        }

        protected static float2 normalize(float2 x)
        {
            return new float2( x.Normalize(2.0));
        }


    }

    // ReSharper restore InconsistentNaming
}