using Claw.Utility.Extensions;
using UnityEngine;

namespace Claw.AI.Steering.Behaviours {
    public class Cohesion : SteeringBehaviour<CohesionData> {

        public Cohesion(SteeringAgent agent, CohesionData data) : base(agent, data) { }

        protected override Vector2 DoCalculate() {

            Vector2 centerOfMass = Vector2.zero;

            int neighbourCount = 0;
            foreach (Collider2D neighbour in Neighbours) {
                centerOfMass += (Vector2)neighbour.transform.position;
                neighbourCount++;
            }

            if (neighbourCount == 0) {
                return Vector2.zero;
            }

            centerOfMass /= neighbourCount;
            
            return (centerOfMass - Position).ScaledTo(MaxSpeed);
        }
    }
}