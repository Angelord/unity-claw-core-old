﻿using UnityEngine;

namespace Claw.Utility.Extensions {
    public static class ColorEx {

        public static readonly Color Transparent = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        public static Color Grayscale(float value) {
            return new Color(value, value, value, 1.0f);
        }

        public static Color RandomGrayscale() {
            return Grayscale(Random.Range(0.0f, 1.0f));
        }

        public static Color Lerp(Color from, Color to, float t) {
            return new Color(
                Mathf.Lerp(from.r, to.r, t),
                Mathf.Lerp(from.g, to.g, t),
                Mathf.Lerp(from.b, to.b, t),
                Mathf.Lerp(from.a, to.a, t)
            );
        }

        public static Color WithAlpha(this Color color, float alpha) {
            color.a = alpha;
            
            return color;
        }

        public static Color RandomAlpha(this Color color) {

            color.a = UnityEngine.Random.Range(0.0f, 1.0f);
            
            return color;
        }
    }
}