using UnityEngine;

namespace Claw.AI.Steering {
    [RequireComponent(typeof(Rigidbody))]
    public class SteeringController : MonoBehaviour {

        [SerializeField] private float maxForce;
        private Rigidbody rBody;
        private SteeringBehaviour[] behaviours;

        private Vector2 accumForce;
        private void Start() {
            rBody = GetComponent<Rigidbody>();
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
            
            rBody.AddForce(accumForce);
        }

        private bool AccumulateForce(Vector2 toAdd) {
            
            float magCurrent = accumForce.magnitude;

            float magRemaining = maxForce - magCurrent;
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