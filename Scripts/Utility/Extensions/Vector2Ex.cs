﻿using UnityEngine;

namespace Claw.Utility.Extensions {
    public static class Vector2Ex {

        public static Vector2 Truncate(this Vector2 vec, float size) {
            return vec.magnitude < size ? vec : vec.ScaledTo(size);
        }

        public static Vector2 ScaledTo(this Vector2 vec, float size) {
            return vec.normalized * size;
        }
    }
}