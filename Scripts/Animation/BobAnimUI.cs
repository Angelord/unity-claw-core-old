using UnityEngine;

namespace Claw.Animation {
    public class BobAnimUI : MonoBehaviour {
        
        [SerializeField] private float range = 1.0f;

        [SerializeField] private float speed = 1.0f;

        private RectTransform rectTransform;

        private Vector2 initialPos;

        private void Awake() {
            rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable() {
            initialPos = rectTransform.anchoredPosition;
        }

        private void Update() {
            
            rectTransform.anchoredPosition = initialPos + range * Mathf.Sin(Time.time * speed) * Vector2.up;
        }
    }
}