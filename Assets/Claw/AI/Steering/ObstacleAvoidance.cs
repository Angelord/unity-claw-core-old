using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Claw.AI.Steering {
    public class ObstacleAvoidance : SteeringBehaviour {

        [SerializeField] private string obstacleLayer = "Obstacles";
        [SerializeField] private float maxSeeingDist = 6.0f;
        [SerializeField] private float avoidanceWidth = 4.0f;
        [SerializeField] private float breakingWeight = 0.1f;
        private RaycastHit2D hitInfo;
        private bool hit;


        protected override Vector2 DoForceCalculation() {
            if (hitInfo) {
                //The closer the obstacle is, the greater the steering force should be
                float multiplier = 1.0f + hitInfo.distance / GetSeeingDist();

                Vector2 steeringDir = hitInfo.point - (Vector2)hitInfo.transform.position;
                steeringDir.Normalize();
                steeringDir *= multiplier;

                Vector2 breakingDir = (Vector2)transform.position - hitInfo.point;
                breakingDir.Normalize();
                breakingDir *= breakingWeight * multiplier;

                steeringDir += breakingDir;

                
                return (steeringDir - Rigidbody.velocity);
            }
         
            return Vector2.zero;
        }

        private void FixedUpdate() {
            Vector2 boxSz = new Vector2(avoidanceWidth / 2.0f, avoidanceWidth / 2.0f);
            int layerMask = LayerMask.GetMask(obstacleLayer);
            hitInfo = Physics2D.BoxCast(transform.position, boxSz, 0.0f, transform.up, GetSeeingDist(), layerMask);
        }
        
        private float GetSeeingDist() {
            return Mathf.Clamp(Rigidbody.velocity.magnitude / Controller.MaxSpeed,
                       0.0f, 1.0f) * maxSeeingDist;
        }
        
        private void OnDrawGizmosSelected() {
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
            Gizmos.matrix = rotationMatrix;
            Gizmos.color = hitInfo ? Color.red : Color.yellow;
            float seeingDist = GetSeeingDist();
            Vector3 cubeSize = new Vector3(avoidanceWidth, seeingDist, 1.0f);
            Gizmos.DrawWireCube (Vector2.up * seeingDist / 2, cubeSize);
        }
    }
}