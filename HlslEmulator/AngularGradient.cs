namespace HlslEmulator
{
    using System;
    using NUnit.Framework;

    public class AngularGradient : EmulatorBase
    {
        [Test]
        public void AngleBetweenTest()
        {
            float2 v1 = float2(1, 0);
            float2 v2 = float2(0, 1);
            float f =acos (dot(normalize(v1), normalize(v2)));
        }



        float2x2 RotationMatrix(float rotation)
        {
            float c = cos(rotation);
            float s = sin(rotation);
            return float2x2(c, -s, s, c);
        }
    }
}
