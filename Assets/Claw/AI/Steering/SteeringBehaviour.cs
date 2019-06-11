
using UnityEngine;

namespace Claw.AI.Steering {
    [RequireComponent(typeof(SteeringController))]
    public abstract class SteeringBehaviour : MonoBehaviour {

        [SerializeField] private float multiplier = 1.0f;

        public float Multiplier { get { return multiplier; } set { multiplier = value; } }

        public Vector3 CalculateForce() {
            return DoCalculation() * multiplier;
        }

        protected abstract Vector3 DoCalculation();
    }
}