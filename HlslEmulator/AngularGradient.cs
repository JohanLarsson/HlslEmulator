namespace HlslEmulator
{
    using System;
    using System.Xml.Schema;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;

    public class AngularGradient : EmulatorBase
    {
        private static readonly object[] GradientCases =
        {
            new object[] {float4(1, 1, 1, 0), float2(1, 0), float2(0.5, 0.5), 0, 45, float4(1, 1, 1, 1), float4(0, 0, 0, 1), float4(1,1,1,1)},
        };

        [Test, TestCaseSource("GradientCases")]
        public void AngularGradientTest(float4 inputSampler, float2 uv, float2 CenterPoint, float StartAngle, float ArcLength, float4 StartColor, float4 EndColor, float4 expected)
        {
            float4 src = tex2D(inputSampler, uv);
            float2 p = uv - CenterPoint;
            float degAngle = degrees((atan2(p.y, -1 * p.x) + Pi));
            float diff = ArcLength - StartAngle;
            float b = (degAngle - StartAngle) / diff;
            float3 f = lerp(StartColor.rgb, EndColor.rgb, b);
            float4 color = float4(src.a < 0.01
                                        ? float3(0, 0, 0) // WPF uses pre-multiplied alpha everywhere internally for a number of performance reasons.
                                        : f, src.a < 0.01 ? 0 : src.a);
            Assert.AreEqual(expected, color);
            //return color;
        }




        [TestCase(1, 0, 0, 1, false, 90)]
        [TestCase(1, 0, 0, 1, true, 270)]
        [TestCase(1, 0, -1, 0, true, 180)]
        [TestCase(1, 0, -1, 0, false, 180)]
        [TestCase(1, 0, 1, 0, false, 0)]
        public void AngleToTest(float x1, float y1, float x2, float y2, bool clockWise, float expected)
        {
            float2 v1 = float2(x1, y1);
            float2 v2 = float2(x2, y2);
            float signedAngleTo = SignedAngleTo(v1, v2, clockWise);
            float a = degrees(signedAngleTo);
            Assert.AreEqual(expected, a, 0.1);
        }

        float SignedAngleTo(float2 v1, float2 v2, bool clockWise)
        {
            float a = acos(dot(v1, v2) / (length(v1) * length(v2)));
            if (clockWise)
            {
                if (a > 0)
                {
                    return 2 * Pi - a;
                }
                return a;
            }
            if (a < 0)
            {
                return abs(a - Pi);
            }
            return a;
        }

        float2x2 RotationMatrix(float rotation)
        {
            float c = cos(rotation);
            float s = sin(rotation);
            return float2x2(c, -s, s, c);
        }
    }
}
