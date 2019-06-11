using System;
using UnityEngine;

namespace Claw.AI.Steering {
    
    public class SteerableObject : MonoBehaviour {

        [SerializeField] private float maxSpeed = 12.0f;
        [SerializeField] private float maxForce = 10.0f;
        [SerializeField] private float maxRotation = 20.0f; 
        private Rigidbody2D rBody;
        
        public float MaxSpeed {
            get { return maxSpeed; }
        }

        public float MaxForce {
            get { return maxForce; }
        }

        private void Start() {
            rBody = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            
            if (rBody.velocity.sqrMagnitude > 0.00001f) {
                transform.rotation = Quaternion.LookRotation(Vector3.forward, rBody.velocity);
//                
//                transform.rotation = Quaternion.RotateTowards(
//                    transform.rotation,
//                    Quaternion.LookRotation(Vector3.forward, rBody.velocity),
//                    maxRotation * Time.deltaTime);
            }
        }
    }
}