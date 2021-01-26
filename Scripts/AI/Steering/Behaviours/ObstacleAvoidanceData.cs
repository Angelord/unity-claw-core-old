﻿using UnityEngine;

namespace Claw.AI.Steering.Behaviours {
    [CreateAssetMenu(fileName = "ObstacleAvoidance", menuName = "Custom/Steering/Behaviours/ObstacleAvoidance", order = 1)]
    public class ObstacleAvoidanceData : SteeringBehaviourData {

        public LayerMask ObstacleMask;
        
        public float DetectionRange = 3.0f;

        public override ISteeringBehaviour CreateInstance(SteeringAgent agent) {
            return new ObstacleAvoidance(agent, this);
        }
    }
}