﻿using UnityEngine;

namespace Claw.AI.Steering.Behaviours {
    [CreateAssetMenu(fileName = "Separation", menuName = "Custom/Steering/Behaviours/Separation", order = 1)]
    public class SeparationData : SteeringBehaviourData {

        [Range(0.0f, 1.0f)]
        public float ForceLerpRange = 1.0f;
        
        public override ISteeringBehaviour CreateInstance(SteeringAgent agent) { 
            return new Separation(agent, this);
        }
    }
}