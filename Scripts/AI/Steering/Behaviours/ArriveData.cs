﻿using UnityEngine;

namespace Claw.AI.Steering.Behaviours {
    [CreateAssetMenu(fileName = "Arrive", menuName = "Custom/Steering/Behaviours/Arrive", order = 1)]
    public class ArriveData : SteeringBehaviourData {
                    
        public float StoppingDistance = 1.0f;

        public float DecelerationStartDistance = 1.5f;
            
        public override ISteeringBehaviour CreateInstance(SteeringAgent agent) {
            return new Arrive(agent, this);
        }
    }
}