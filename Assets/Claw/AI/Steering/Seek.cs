
using UnityEngine;

namespace Claw.AI.Steering {
    public class Seek : SteeringBehaviour {

        [SerializeField] private Transform target;
        [SerializeField] private Vector2 targetPos;

        protected override Vector2 DoForceCalculation() {

            if (target != null) {
                targetPos = target.position;
            }

            Vector2 desiredVelocity = (targetPos - (Vector2)transform.position).normalized * Steerable.MaxSpeed;
            
            return (desiredVelocity - Rigidbody.velocity);
        }
    }
}