namespace HlslEmulator
{
    using System;
    using System.Xml.Schema;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;

    public class AngularGradient : EmulatorBase
    {
        private float4 inputSampler;
        private float2 CenterPoint;
        private float StartAngle;
        private float ArcLength;
        private float4 StartColor;
        private float4 EndColor;
        private static readonly object[] GradientCases =
        {
            new object[] {float4(1, 1, 1, 1), float2(1, 0.5), float2(0.5, 0.5), 0, 45, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(1,1,1,1)},
            new object[] {float4(1, 1, 1, 0), float2(1, 0.5), float2(0.5, 0.5), 0, 45, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(0,0,0,0)},
            new object[] {float4(1, 1, 1, 1), float2(0.5, 1), float2(0.5, 0.5), 0, 45, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(0,0,0,0)},
            new object[] {float4(1, 1, 1, 1), float2(0.5, 1), float2(0.5, 0.5), 0, 45, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(0,0,0,0)},
            new object[] {float4(1, 1, 1, 1), float2(1, 1), float2(0.5, 0.5), 0, 45, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(0,0,0,1)},
            new object[] {float4(1, 1, 1, 1), float2(-1, -1), float2(0.5, 0.5), 0, 45, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(0,0,0,0)},
            new object[] {float4(1, 1, 1, 1), float2(1, 1), float2(0.5, 0.5), 0, -45, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(0,0,0,0)},
            new object[] {float4(1, 1, 1, 1), float2(1, 0), float2(0, 0), 0, 360, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(1,1,1,1)},
            new object[] {float4(1, 1, 1, 1), float2(0, 1), float2(0, 0), 0, 360, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(0.75,0.75,0.75,1)},
            new object[] {float4(1, 1, 1, 1), float2(-1, 0), float2(0, 0), 0, 360, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(0.5,0.5,0.5,1)},
            new object[] {float4(1, 1, 1, 1), float2(0, -1), float2(0, 0), 0, 360, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(0.25,0.25,0.25,1)},
            new object[] {float4(1, 1, 1, 1), float2(1, 0), float2(0, 0), 0, -360, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(1,1,1,1)},
            new object[] {float4(1, 1, 1, 1), float2(0, 1), float2(0, 0), 0, -360, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(0.25,0.25,0.25,1)},
            new object[] {float4(1, 1, 1, 1), float2(-1, 0), float2(0, 0), 0, -360, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(0.5,0.5,0.5,1)},
            new object[] {float4(1, 1, 1, 1), float2(0, -1), float2(0, 0), 0, -360, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(0.75,0.75,0.75,1)},
        };

        [Test, TestCaseSource("GradientCases")]
        public void AngularGradientTest(float4 inputSampler, float2 uv, float2 centerPoint, float startAngle, float arcLength, float4 startColor, float4 endColor, float4 expected)
        {
            this.inputSampler = inputSampler;
            this.CenterPoint = centerPoint;
            this.StartAngle = startAngle;
            this.ArcLength = arcLength;

            this.StartColor = startColor;
            this.EndColor = endColor;
            float4 c = main(uv);
            if (distance(expected, c) < 0.01)
            {
                Assert.Pass();
            }
            else
            {
                Assert.AreEqual(expected, c);
            }
        }

        [TestCase(1, 0, 0, 1, false, 90)]
        [TestCase(1, 0, 0, 1, true, 270)]
        [TestCase(1, 0, 0, -1, true, 90)]
        [TestCase(1, 0, 0, -1, false, 270)]
        [TestCase(1, 0, -1, 0, true, 180)]
        [TestCase(1, 0, -1, 0, false, 180)]
        [TestCase(1, 0, 1, 0, false, 0)]
        [TestCase(0, 1, 1, 0, true, 90)]
        public void AngleToTest(float x1, float y1, float x2, float y2, bool clockWise, float expected)
        {
            float2 v1 = float2(x1, y1);
            float2 v2 = float2(x2, y2);
            float signedAngleTo = AngleTo(v1, v2, clockWise);
            float a = degrees(signedAngleTo);
            Assert.AreEqual(expected, a, 0.1);
        }

        static float4 transparent = float4(0, 0, 0, 0); // WPF uses pre-multiplied alpha everywhere internally for a number of performance reasons.
        static float Pi = 3.141592f;

        float AngleTo(float2 v1, float2 v2, bool clockWise)
        {
            int sign = clockWise ? -1 : 1;
            float a1 = atan2(v1.y, v1.x) * sign;
            float a2 = atan2(v2.y, v2.x) * sign;
            float a = a2 - a1;
            if (a < 0)
            {
                return 2 * Pi + a; ;
            }
            return a;
        }
        float2x2 RotationMatrix(float rotation)
        {
            float c = cos(rotation);
            float s = sin(rotation);
            return float2x2(c, -s, s, c);
        }
        float4 main(float2 uv)
        {
            float4 src = tex2D(inputSampler, uv);
            if (src.a < 0.01 || abs(ArcLength) < 0.01)
            {
                return transparent;
            }
            float2 v = uv - CenterPoint;
            float2 vs = mul(float2(1, 0), RotationMatrix(radians(StartAngle)));
            float a = degrees(AngleTo( vs,v, ArcLength < 0));
            float f = abs(a) < 0.1 ? 0 : a / abs(ArcLength);
            if (f < 0 || f > 1)
            {
                return transparent;
            }
            float3 rgb = lerp(StartColor.rgb, EndColor.rgb, f);
            return float4(rgb, src.a);
        }
    }
}
