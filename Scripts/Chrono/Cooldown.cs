﻿using UnityEngine;

namespace Claw.Chrono {
    [System.Serializable]
    public class Cooldown {

        [SerializeField] private float duration;

        private float lastReset;

        public bool Ready => TimeSinceLastReset > duration;

        public float Duration { get => duration; set => duration = value; }

        public float TimeRemaining => duration - TimeSinceLastReset;

        private float TimeSinceLastReset => Time.time - lastReset;

        public Cooldown(float duration) {
            this.duration = duration;
            lastReset = Time.time;
        }

        public void Reset() {
            lastReset = Time.time;
        }
    }
}