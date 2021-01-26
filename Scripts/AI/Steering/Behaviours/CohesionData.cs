﻿using UnityEngine;

namespace Claw.AI.Steering.Behaviours {
    [CreateAssetMenu(fileName = "Cohesion", menuName = "Custom/Steering/Behaviours/Cohesion", order = 1)]
    public class CohesionData : SteeringBehaviourData {
        public override ISteeringBehaviour CreateInstance(SteeringAgent agent) {
            return new Cohesion(agent, this);
        }
    }
}