﻿using UnityEngine;

namespace Claw.AI.Steering.Behaviours {
    
    public class Arrive : SteeringBehaviour<ArriveData> {

        private Transform target;

        public Transform Target { get => target; set => target = value; }

        public Arrive(SteeringAgent agent, ArriveData data) : base(agent, data) { }

        protected override Vector2 DoCalculate() {
            
            if (target == null) { return Vector2.zero; }

            Vector2 toTarget = (Vector2)target.position - Position;

            float distance = toTarget.magnitude;

            if (distance < data.StoppingDistance) return Vector2.zero;

            float t = (distance - data.StoppingDistance) / (data.DecelerationStartDistance - data.StoppingDistance);
            
            return toTarget / distance * Mathf.Lerp(0.0f, MaxSpeed, t);
        }
    }
}