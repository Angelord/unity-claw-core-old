﻿using UnityEngine;

namespace Claw.AI.Steering.Behaviours {
    [CreateAssetMenu(fileName = "Seek", menuName = "Custom/Steering/Behaviours/Seek", order = 1)]
    public class SeekData : SteeringBehaviourData {
            
        public float stoppingDistance;
            
        public override ISteeringBehaviour CreateInstance(SteeringAgent agent) {
            return new Seek(agent, this);
        }
    }
}