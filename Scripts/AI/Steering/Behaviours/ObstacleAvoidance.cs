using Claw.Utility.Extensions;
using UnityEngine;

namespace Claw.AI.Steering.Behaviours {
    public class ObstacleAvoidance : SteeringBehaviour<ObstacleAvoidanceData> {
        
        public ObstacleAvoidance(SteeringAgent agent, ObstacleAvoidanceData data) : base(agent, data) {
        }

        protected override Vector2 DoCalculate() {

            Collider2D obstacle = Physics2D.OverlapCircle(Position, data.DetectionRange, data.ObstacleMask);

            if (!obstacle) { return Vector2.zero; }

            Vector2 steeringForce = Vector2.zero;

            Vector2 nearestPoint = obstacle.ClosestPoint(Position);

            Vector2 toSelf = Position - nearestPoint;

            float distance = toSelf.magnitude;

            float t = distance / data.DetectionRange;
            
            // The closer to the target we are, the stronger the steering force should be
            float force = Mathf.Lerp(MaxSpeed, 0.0f, t * t);

            // Apply backwards force proportional to distance
            steeringForce += force * (toSelf / distance);

//            Vector2 obstaclePos = obstacle.transform.position;
//            if (Velocity.magnitude / MaxSpeed > 0.1f) {
//                Vector2 nearestPointToHeading = Line.NearestPoint(Position, Velocity, obstaclePos);
//
//                Vector2 sideDir = nearestPointToHeading - obstaclePos;
//
//                steeringForce += data.SideWeight * force * sideDir.normalized;
//            }
            
            return steeringForce.Truncate(MaxSpeed);
        }
    }
}