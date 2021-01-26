using UnityEngine;

namespace Claw.Utility {
    /// <summary>
    /// A collection of useful functions that return nonlinear values in the range [0, 1] 
    /// </summary>
    public static class NormalizedFunctions {
        public static float BellCurve6(float t) {
            return SmoothStop3(t) * SmoothStart3(t);
        }

        public static float Arch(float t) {
            return 1.0f - Mathf.Abs(t - 0.5f) / 0.5f;
        }

        public static float SmoothStartArch3(float t) {
            return t * t * (1 - t);
        }

        public static float SmoothStopArch3(float t) {
            float flipped = 1 - t;
            return t * flipped * flipped;
        }

        public static float SmoothStart2(float t) {
            return t * t;
        }

        public static float SmoothStart3(float t) {
            return t * t * t;
        }

        public static float SmoothStart4(float t) {
            return t * t * t * t;
        }

        public static float SmoothStop2(float t) {
            return 1 - (1 - t) * (1 - t);
        }

        public static float SmoothStop3(float t) {
            float flipped = 1 - t;
            return 1 - flipped * flipped * flipped;
        }

        public static float SmoothStop4(float t) {
            float flipped = 1 - t;
            return 1 - flipped * flipped * flipped * flipped;
        }
    }
}