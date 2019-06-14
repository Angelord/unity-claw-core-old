
using UnityEngine;

namespace Claw.AI.Steering {
    public class Seek : SteeringBehaviour {

        [SerializeField] private Transform target;
        [SerializeField] private Vector2 targetPos;

        public Transform Target {
            get { return target; }
            set { target = value; }
        }

        public Vector2 CalculateForce(Vector2 position) {
            
            Vector2 desiredVel = (position - (Vector2)transform.position).normalized * Controller.MaxSpeed;
            
            return (desiredVel - Rigidbody.velocity);
        }

        protected override Vector2 DoForceCalculation() {

            if (target != null) {
                targetPos = target.position;
            }

            return CalculateForce(targetPos);
        }
    }
}