﻿using System;
using UnityEngine;

namespace Claw.Utility {
    [Serializable]
    public class FloatRange {

        [SerializeField] private float min;
        [SerializeField] private float max;

        public float Min { get => min; set => min = value; }

        public float Max { get => max; set => max = value; }

        public FloatRange() { }

        public FloatRange(float min, float max) {
            Set(min, max);
        }

        public float Random() {
            return UnityEngine.Random.Range(min, max);
        }

        public float Lerp(float t) {
            return Mathf.Lerp(min, max, t);
        }

        public void Set(float min, float max) {
            UnityEngine.Assertions.Assert.IsTrue(min <= max, "Invalid range provided for float Range");
            this.min = min;
            this.max = max;
        }
    }
}