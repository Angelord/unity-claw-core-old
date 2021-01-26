﻿using System.Collections.Generic;
using UnityEngine;

namespace Claw.AI.Steering.Behaviours {
    public abstract class SteeringBehaviour<T> : ISteeringBehaviour where T : SteeringBehaviourData {

        private bool enabled = true;
        
        protected readonly T data;
        
        private readonly SteeringAgent agent;

        public bool Enabled { get => enabled; set => enabled = value; }

        protected IEnumerable<Collider2D> Neighbours => agent.NeighbourTracker;

        protected float NeighbourRange => agent.NeighbourTracker.NeighbourRadius;

        protected float MaxSpeed => agent.MaxSpeed;

        protected Vector2 Heading => agent.Heading;
        
        protected Vector2 Position => agent.transform.position;
        
        protected Vector2 Velocity => agent.Velocity;

        protected SteeringBehaviour(SteeringAgent agent, T data) {
            this.agent = agent;
            this.data = data;
        }

        public Vector2 Calculate() {
            return DoCalculate() * data.Weight;
        }

        protected abstract Vector2 DoCalculate();
    }
}