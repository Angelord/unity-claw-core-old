﻿using UnityEngine;


namespace Claw.Animation {
    public class SizeFluctuation : MonoBehaviour {

        [SerializeField][Range(0.0f, 1.0f)] private float maxFluctuation = 0.03f;
        [SerializeField] private float fluctuationRate = 0.1f;
        private Vector2 initialScale;
        
        private void Start() {
            initialScale = transform.localScale;
            InvokeRepeating(nameof(ModifyScale), 0.0f, fluctuationRate);
        }

        private void ModifyScale() {

            transform.localScale = initialScale * Random.Range(1.0f - maxFluctuation, 1.0f + maxFluctuation);
        }
    }
}