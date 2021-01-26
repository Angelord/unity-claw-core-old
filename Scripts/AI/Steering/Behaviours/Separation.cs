﻿using UnityEngine;

namespace Claw.AI.Steering.Behaviours {
    public class Separation : SteeringBehaviour<SeparationData> {
        
        public Separation(SteeringAgent agent, SeparationData data) : base(agent, data) {
        }

        protected override Vector2 DoCalculate() {

            Vector2 steeringForce = Vector2.zero;

            float lerpRangeMin = NeighbourRange * (1.0f - data.ForceLerpRange);
            float lerpRangeSize = NeighbourRange - lerpRangeMin;

            int neighbourCount = 0;
            foreach (Collider2D neighbour in Neighbours) {
                neighbourCount++;
                
                Vector2 toSelf = Position - neighbour.ClosestPoint(Position);

                float distance = toSelf.magnitude;
                
                float speed = Mathf.Lerp(MaxSpeed, 0.0f, (distance - lerpRangeMin) / lerpRangeSize);

                steeringForce += toSelf.normalized * speed;
            }

            if (neighbourCount == 0) { return Vector2.zero; }

            return steeringForce;
        }
    }
}