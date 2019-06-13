
using System;
using UnityEngine;

namespace Claw.AI.Steering {
    [RequireComponent(typeof(SteeringController))]
    public abstract class SteeringBehaviour : MonoBehaviour {

        [SerializeField] private float multiplier = 1.0f;
        private Rigidbody2D rBody;
        private SteerableObject steerable;
        
        public float Multiplier { get { return multiplier; } set { multiplier = value; } }
        protected Rigidbody2D Rigidbody { get { return rBody; } }
        protected SteerableObject Steerable { get { return steerable; } }

        private void Start() {
            rBody = GetComponent<Rigidbody2D>();
            steerable = GetComponent<SteerableObject>();
            OnStart();
        }
        
        public Vector2 CalculateForce() {
            return DoForceCalculation() * multiplier;
        }

        protected abstract Vector2 DoForceCalculation();

        protected virtual void OnStart() { }
    }
}