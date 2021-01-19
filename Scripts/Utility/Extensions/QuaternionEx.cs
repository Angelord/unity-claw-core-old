﻿using UnityEngine;

namespace Claw.Utility.Extensions {
    public static class QuaternionEx {

        public static Quaternion Rotation2D(float angle) {
            return Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));
        }
    }
}