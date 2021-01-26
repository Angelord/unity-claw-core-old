﻿using Claw.AI.Steering.Behaviours;
 using UnityEngine;

namespace Claw.AI.Steering {

    [CreateAssetMenu(fileName = "Steering Controller", menuName = "Custom/Steering/Steering Data", order = 1)]
    public class SteeringController : ScriptableObject {

        public float MaxSpeed;
        
        public float MaxAcceleration;

        public float NeighbourRadius;

        [HideInInspector] public SteeringBehaviourData[] Behaviours;
    }
}