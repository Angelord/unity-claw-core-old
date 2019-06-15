using System;
using UnityEngine;

namespace Claw.AI.Steering {
    public class Separation : SteeringBehaviour {

        [SerializeField] private string neighbourLayer = "Boids";
        [SerializeField] private float neighbourRange = 10.0f;
        [SerializeField] [Range(1, 1000)] private int maxNeighbours = 20;
        private Collider2D[] neighbours;

        protected override void OnInitialize() {
            neighbours = new Collider2D[maxNeighbours];
        }

        protected override Vector2 DoForceCalculation() {

            Vector2 steeringForce = Vector2.zero;
            
            int neighbourCount = GetNearbyObjects(neighbourRange, neighbours, LayerMask.GetMask(neighbourLayer));
            for (int i = 0; i < neighbourCount; i++) {
                Collider2D neighbour = neighbours[i];

                Vector2 toNeigh = transform.position - neighbour.transform.position;

                steeringForce += toNeigh.normalized / toNeigh.magnitude;
            }

            return steeringForce;
        }

    }
}