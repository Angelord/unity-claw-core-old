using UnityEngine;

namespace Claw.Utility.Extensions {
    public static class RectTransformEx {

        public static void SetHeight(this RectTransform rt, float height) {
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, height);
        }
        
        /// <summary>
        /// Retrieves the 'y' component of the rect's sizeDelta.
        /// </summary>
        public static float GetHeight(this RectTransform rt) {
            return rt.sizeDelta.y;
        }

        public static void SetLeft(this RectTransform rt, float left) {
            rt.offsetMin = new Vector2(left, rt.offsetMin.y);
        }

        public static void SetRight(this RectTransform rt, float right) {
            rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
        }

        public static void SetTop(this RectTransform rt, float top) {
            rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
        }

        public static void SetBottom(this RectTransform rt, float bottom) {
            rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
        }
    }
}