using UnityEngine;

namespace Claw.AI.Steering {
    [RequireComponent(typeof(Rigidbody2D), typeof(SteerableObject))]
    public class SteeringController : MonoBehaviour {

        private SteerableObject steerable;
        private Rigidbody2D rBody;
        private SteeringBehaviour[] behaviours;

        private Vector2 accumForce;
        private void Start() {
            steerable = GetComponent<SteerableObject>();
            rBody = GetComponent<Rigidbody2D>();
            behaviours = GetComponents<SteeringBehaviour>();
        }

        private void FixedUpdate() {
            accumForce = Vector2.zero;

            foreach (SteeringBehaviour behaviour in behaviours) {
                if (!behaviour.enabled) {
                    continue;
                }

                Vector2 force = behaviour.CalculateForce();
                if (!AccumulateForce(force)) {
                    break;
                }
            }
            
            rBody.AddForce(accumForce, ForceMode2D.Impulse);
        }

        private bool AccumulateForce(Vector2 toAdd) {
            
            float magCurrent = accumForce.magnitude;

            float magRemaining = steerable.MaxForce - magCurrent;
            if (magRemaining <= 0.0f) { return false; }

            float magToAdd = toAdd.magnitude;
            if (magToAdd > magRemaining) {
                accumForce += toAdd.normalized * magRemaining;
                return false;
            }
         
            accumForce += toAdd;
            return true;
        }
    }
}