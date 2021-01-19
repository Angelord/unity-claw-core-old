﻿using UnityEngine;

namespace Claw.Utility.Extensions {
    public static class RandomEx {

        /// <summary>
        /// Generates a random number between 0 and 1, returns true if the number falls below the target.
        /// </summary>
        public static bool Chance(float target) {
            return Random.Range(0.0f, 1.0f) < target;
        }
    }
}