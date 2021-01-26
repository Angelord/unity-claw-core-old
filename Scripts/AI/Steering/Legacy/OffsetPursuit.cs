using UnityEngine;

namespace Claw.AI.Steering.Legacy {
	public class OffsetPursuit : SteeringBehaviour {

		[SerializeField] private Rigidbody2D leader = default;
		[SerializeField] private Vector2 offsetPos = default; //In the leader's coordinate space
		private Arrive arrive;
		
		protected override void OnInitialize() {
			arrive = RequireBehaviour<Arrive>();
		}

		protected override Vector2 DoForceCalculation() {

			if (leader == null) {
				return Vector2.zero;
			}

			Vector2 worldOffsetPos = leader.transform.localToWorldMatrix.MultiplyPoint(offsetPos);
			Vector2 toOffset = worldOffsetPos - (Vector2)transform.position;
			
			float lookAheadTime = toOffset.magnitude / (Controller.MaxSpeed - leader.velocity.magnitude);

			return arrive.CalculateForce(worldOffsetPos + leader.velocity * lookAheadTime);
		}
	}
}
