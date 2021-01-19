﻿using UnityEngine;

namespace Claw.Utility.Extensions {
    public static class LayerMaskEx {

        public static bool Contains(this LayerMask mask, int layer) {
            return (mask.value & 1 << layer) != 0;
        }
    }
}