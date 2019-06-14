
using System;
using UnityEngine;

namespace Claw.AI.Steering {
    [RequireComponent(typeof(SteeringController))]
    public abstract class SteeringBehaviour : MonoBehaviour {

        [SerializeField] private float multiplier = 1.0f;
        private Rigidbody2D rBody;
        private SteeringController controller;
        
        protected Rigidbody2D Rigidbody { get { return rBody; } }
        protected SteeringController Controller { get { return controller; } }

        public void Initialize() {
            rBody = GetComponent<Rigidbody2D>();
            controller = GetComponent<SteeringController>();
            OnInitialize();
        }
        
        public Vector2 CalculateForce() {
            return DoForceCalculation() * multiplier;
        }

        protected abstract Vector2 DoForceCalculation();
        
        protected virtual void OnInitialize() { }

        //Needed so we can set [enabled] in the inspector
        private void Update() { }
    }
}