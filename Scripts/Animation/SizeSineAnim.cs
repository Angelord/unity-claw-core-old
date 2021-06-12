using UnityEngine;

namespace Claw.Animation {
    public class SizeSineAnim : MonoBehaviour {
        
        [SerializeField][Range(0.0f, 1.0f)] private float maxFluctuation = 0.03f;
        
        [SerializeField] private float speed = 0.1f;
        
        private Vector2 initialScale;

        private void Start() {
            initialScale = transform.localScale;
        }

        private void Update() {
            transform.localScale = initialScale + Mathf.Sin(Time.time * speed) * maxFluctuation * Vector2.one;
        }
    }
}