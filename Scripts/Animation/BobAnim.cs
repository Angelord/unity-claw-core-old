using UnityEngine;

namespace Claw.Animation {
    public class BobAnim : MonoBehaviour {

        [SerializeField] private float range = 1.0f;

        [SerializeField] private float speed = 1.0f;

        private Vector2 initialPos;
        
        private void OnEnable() {
            initialPos = transform.position;
        }

        private void Update() {
            transform.position = initialPos + range * Mathf.Sin(Time.time * speed) * Vector2.up;
        }
    }
}