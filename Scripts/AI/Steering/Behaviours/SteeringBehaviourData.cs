﻿using UnityEngine;

namespace Claw.AI.Steering.Behaviours {
    public abstract class SteeringBehaviourData : ScriptableObject {

        [Range(0.0f, 1.0f)] public float Weight = 0.5f;

        public abstract ISteeringBehaviour CreateInstance(SteeringAgent agent);
    }
}