﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Claw.AI.Steering {
    public class NeighbourTracker : IEnumerable<Collider2D> {
        
        private readonly LayerMask neighbourMask;

        private readonly Collider2D ownCollider;

        private readonly Collider2D[] collidersInRange = new Collider2D[16];

        private float neighbourRadius;
        
        private int collisionCount;

        public float NeighbourRadius { get => neighbourRadius; set => neighbourRadius = value; }

        private Vector2 Position => ownCollider.transform.position;

        public NeighbourTracker(LayerMask neighbourMask, Collider2D ownCollider, float neighbourRadius) {
            this.neighbourMask = neighbourMask;
            this.ownCollider = ownCollider;
            this.neighbourRadius = neighbourRadius;
        }

        public void UpdateNeighbours() {

            collisionCount =
                Physics2D.OverlapCircleNonAlloc(Position, neighbourRadius, collidersInRange, neighbourMask);
        }

        public IEnumerator<Collider2D> GetEnumerator() {
            for (int i = 0; i < collisionCount; i++) {
                if (collidersInRange[i] == ownCollider) { continue; }

                yield return collidersInRange[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}