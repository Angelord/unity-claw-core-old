using Claw.Utility.Extensions;
using UnityEngine;

namespace Claw.AI.Steering.Behaviours {
    public class Seek : SteeringBehaviour<SeekData> {

        private Transform target;

        public Transform Target { get => target; set => target = value; }

        public Seek(SteeringAgent agent, SeekData data) : base(agent, data) {
        }

        protected override Vector2 DoCalculate() {
            if (Target == null) { return Vector2.zero; }

            Vector2 toTarget = (Vector2)target.position - Position;

            if (toTarget.magnitude <= data.stoppingDistance) {
                return Vector2.zero;
            }

            return toTarget.Truncate(MaxSpeed);
        }
    }
}