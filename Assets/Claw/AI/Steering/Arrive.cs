using UnityEngine;

namespace Claw.AI.Steering {
    public class Arrive : SteeringBehaviour {

        [SerializeField] private Transform target;
        [SerializeField] private Vector2 targetPos;
        [SerializeField] private float decceleration = 1.0f;
        
        protected override Vector2 DoForceCalculation() {

            if (target != null) {
                targetPos = target.position;
            }

            Vector2 toTarget = targetPos - (Vector2)transform.position;

            float distance = toTarget.magnitude;

            if (distance > 0.0f) {

                float speed = distance / decceleration;

                speed = Mathf.Min(speed, Steerable.MaxSpeed);

                Vector2 desiredVel = (toTarget / distance) * speed;

                return desiredVel - Rigidbody.velocity;
            }

            return Vector2.zero;
        }
    }
}