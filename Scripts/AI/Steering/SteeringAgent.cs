using Claw.Utility.Extensions;
using UnityEngine;

namespace Claw.AI.Steering {
    [RequireComponent(typeof(Rigidbody2D))]
    public class SteeringAgent : MonoBehaviour {

        [SerializeField] private SteeringController controller;

        [SerializeField] private LayerMask neighbourMask;

        private Vector2 heading;
        
        private Rigidbody2D rBody;
        
        private NeighbourTracker neighbourTracker;
        
        private ISteeringBehaviour[] behaviours;
        
        private Vector2 desiredVelocity;

        public NeighbourTracker NeighbourTracker => neighbourTracker;

        public float MaxSpeed => controller.MaxSpeed;

        public Vector2 Velocity => rBody.velocity;

        public Vector2 Heading => heading;
        
        public T GetBehaviour<T>() where T : class, ISteeringBehaviour {
            foreach (ISteeringBehaviour steeringBehaviour in behaviours) {
                if (!(steeringBehaviour is T castBehaviour)) { continue; }

                return castBehaviour;
            }

            return null;
        }

        private void Awake() {
            rBody = GetComponent<Rigidbody2D>();

            Collider2D collider = GetComponent<Collider2D>();
            neighbourTracker = new NeighbourTracker(neighbourMask, collider, controller.NeighbourRadius);

            behaviours = new ISteeringBehaviour[controller.Behaviours.Length];

            for (int i = 0; i < controller.Behaviours.Length; i++) {
                behaviours[i] = controller.Behaviours[i].CreateInstance(this);
            }
        }
        
        private void FixedUpdate() {
            
            neighbourTracker.NeighbourRadius = controller.NeighbourRadius;
            neighbourTracker.UpdateNeighbours();

            desiredVelocity = Vector2.zero;
            
            foreach (ISteeringBehaviour behaviour in behaviours) {

                if (!behaviour.Enabled) continue;
                
                if (!AccumulateForce(behaviour.Calculate())) {
                    break;
                }
            }

            Vector2 velocity = rBody.velocity;

            float maxSpeedChange = controller.MaxAcceleration * Time.deltaTime;

            rBody.velocity = Vector2.MoveTowards(velocity, desiredVelocity, maxSpeedChange);

            if (rBody.velocity.magnitude > MaxSpeed / 2.0f) {
                heading = rBody.velocity;
            }
        }

        private bool AccumulateForce(Vector2 toAdd) {

            float runningTotalMag = desiredVelocity.magnitude;

            float remainingMag = controller.MaxSpeed - runningTotalMag;

            if (remainingMag <= 0.0f) { return false; }

            float toAddMag = toAdd.magnitude;

            if (toAddMag < remainingMag) {
                desiredVelocity += toAdd;
            }
            else {
                desiredVelocity += toAdd.ScaledTo(remainingMag);
            }

            return true;
        }

        private void OnDrawGizmos() {
            if (!Application.isPlaying) return;
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, Velocity);
        }
    }
}