using System;
using UnityEngine.Experimental.VFX;

namespace UnityEditor.Experimental.VFX
{
    class VFXBlockSetSubUVRandom : VFXBlockType
    {
        public VFXBlockSetSubUVRandom()
        {
            Name = "Index (Random)";
            Icon = "Flipbook";
            Category = "Flipbook";

            Add(VFXProperty.Create<VFXFloatType>("MinIndex"));
            Add(VFXProperty.Create<VFXFloatType>("MaxIndex"));

            Add(new VFXAttribute(CommonAttrib.TexIndex, true));

            Source = @"
texIndex = lerp(MinIndex,MaxIndex,RAND);";
        }
    }

    class VFXBlockSubUVAnimateIndexCurve : VFXBlockType
    {
        public VFXBlockSubUVAnimateIndexCurve()
        {
            Name = "Index (Curve)";
            Icon = "Flipbook";
            Category = "Flipbook";

            Add(VFXProperty.Create<VFXCurveType>("Curve"));

            Add(new VFXAttribute(CommonAttrib.Age, false));
            Add(new VFXAttribute(CommonAttrib.Lifetime, false));
            Add(new VFXAttribute(CommonAttrib.TexIndex, true));

            Source = @"
float r = saturate(age/lifetime);
texIndex = SAMPLE(Curve, r);";
        }
    }

    class VFXBlockSubUVAnimateConstantRate : VFXBlockType
    {
        public VFXBlockSubUVAnimateConstantRate()
        {
            Name = "Rate (Constant)";
            Icon = "Flipbook";
            Category = "Flipbook";

            Add(VFXProperty.Create<VFXFloatType>("Framerate"));

            Add(new VFXAttribute(CommonAttrib.TexIndex, true));

            Source = @"
texIndex += Framerate * DeltaTime;";
        }
    }

    class VFXBlockSubUVAnimateCurveRate : VFXBlockType
    {
        public VFXBlockSubUVAnimateCurveRate()
        {
            Name = "Rate (Curve)";
            Icon = "Flipbook";
            Category = "Flipbook";

            Add(VFXProperty.Create<VFXCurveType>("RateCurve"));

            Add(new VFXAttribute(CommonAttrib.Age, false));
            Add(new VFXAttribute(CommonAttrib.Lifetime, false));
            Add(new VFXAttribute(CommonAttrib.TexIndex, true));

            Source = @"
float r = saturate(age/lifetime);
texIndex += SAMPLE(RateCurve, r) * DeltaTime;";
        }
    }




}
