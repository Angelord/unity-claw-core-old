using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Claw.AI.Steering {
	public class Flee : SteeringBehaviour {

		[SerializeField] private Transform target;
		[SerializeField] private Vector2 targetPos;
		
		protected override Vector2 DoForceCalculation() {

			if (target != null) {
				targetPos = target.position;
			}

			Vector2 desiredVel = ((Vector2)transform.position - targetPos).normalized * Steerable.MaxSpeed;

			return (desiredVel - Rigidbody.velocity);
		}
	}
}
