namespace HlslEmulator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Security.Cryptography.X509Certificates;
    using MathNet.Numerics.LinearAlgebra.Generic;
    using MathNet.Numerics.LinearAlgebra.Single;
    using NUnit.Framework;

    // ReSharper disable InconsistentNaming
    public class EmulatorBase
    {
        protected static float4 tex2D(float4 inputSampler, float2 uv)
        {
            return inputSampler;
        }
        protected static float2 mul(float2 v, float f)
        {
            return new float2(v.Multiply(f));
        }
        protected static float2 mul(float f, float2 v)
        {
            return new float2(v.Multiply(f));
        }
        protected static float3 mul(float3 v, float f)
        {
            return new float3(v.Multiply(f));
        }
        protected static float3 mul(float f, float3 v)
        {
            return new float3(v.Multiply(f));
        }
        protected static float4 mul(float4 v, float f)
        {
            return new float4(v.Multiply(f));
        }
        protected static float4 mul(float f, float4 v)
        {
            return new float4(v.Multiply(f));
        }
        protected static float2 mul(float2 v, float2x2 m)
        {
            return new float2(m.Multiply(v));
        }
        protected static float3 lerp(float3 rgb1, float3 rgb2, float f)
        {
            var floats = new List<float>();
            for (int i = 0; i < 3; i++)
            {
                floats.Add(lerp(rgb1[i], rgb2[i], f));
            }
            return new float3(floats);
        }
        protected static float lerp(float f1, float f2, float f)
        {
            if (f > 1)
                f = 1;
            if (f < 0)
                f = 0;
            return f1 + f * (f2 - f1);
        }
        //protected static float Pi { get { return (float)Math.PI; } }
        protected static float abs(float f)
        {
            return Math.Abs(f);
        }
        protected static float degrees(float a)
        {
            return (float)(a * 180.0 / Math.PI);
        }
        protected static float radians(float a)
        {
            return (float)(a * Math.PI / 180);
        }
        protected static float dot(DenseVector v1, DenseVector v2)
        {
            return v1.DotProduct(v2);
        }
        protected static float distance(DenseVector p1, DenseVector p2)
        {
            Vector<float> v = p1-p2;
            return length(v);
        }
        protected static float2 float2(double x, double y)
        {
            return new float2((float)x, (float)y);
        }
        protected static float3 float3(float r, float g, float b)
        {
            return new float3(r, g, b);
        }
        protected static float4 float4(float3 rgb, float a)
        {
            return new float4(rgb.r, rgb.g, rgb.b, a);
        }
        protected static float4 float4(double r, double g, double b, double a)
        {
            return new float4(r, g, b, a);
        }
        protected float2x2 float2x2(float r0c0, float r0c1, float r1c0, float r1c1)
        {
            return new float2x2(r0c0, r0c1, r1c0, r1c1);
        }
        protected static float atan2(float y, float x)
        {
            double d = Math.Atan2(y, x);
            return (float)d;
        }
        protected static float sin(float angle)
        {
            return (float)Math.Sin(angle);
        }
        protected static float cos(float angle)
        {
            return (float)Math.Cos(angle);
        }
        protected static float acos(float f)
        {
            return (float)Math.Acos(f);
        }
        protected static float2 normalize(float2 x)
        {
            return new float2(x.Normalize(2.0));
        }
        protected static float length(Vector<float> v1)
        {
            return v1.Norm(2);
        }
    }
    // ReSharper restore InconsistentNaming
}