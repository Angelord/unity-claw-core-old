using UnityEngine;

namespace Claw.AI.Steering {

	public class Pursuit : SteeringBehaviour {

		[SerializeField] private Rigidbody2D target;
		private Seek seek;
		
		protected override void OnInitialize() {
			seek = GetComponent<Seek>();
			if (seek == null) {
				seek = Controller.AddBehaviour<Seek>();
				seek.enabled = false;
			}
		}

		protected override Vector2 DoForceCalculation() {
			
			Vector2 toTarget = target.transform.position - transform.position;

			float relativeHeading = Vector2.Dot(transform.up, target.transform.up);

			if (Vector2.Dot(toTarget, transform.up) > 0 &&
			    relativeHeading < -0.95) {
				
				return seek.CalculateForce(target.position);
			}

			float lookAheadTime = toTarget.magnitude / (Controller.MaxSpeed + target.velocity.magnitude); 

			return seek.CalculateForce(target.position + target.velocity * lookAheadTime);
		}
	}
}
