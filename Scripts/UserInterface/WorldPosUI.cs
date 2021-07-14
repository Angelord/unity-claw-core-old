using UnityEngine;

namespace Claw.UserInterface {
    /// <summary>
    /// Ui Component that matches a given world position
    /// </summary>
    public class WorldPosUI : MonoBehaviour {

        [SerializeField] private Vector3 offset;

        private Camera camera;

        private RectTransform rectTransform;
        
        private Transform transformTarget;

        private Vector3 posTarget;

        public Vector3 Offset { get => offset; set => offset = value; }

        public void SetTarget(Transform target) {
            transformTarget = target;
            MatchPosition(target.position);
        }

        public void SetTarget(Vector3 target) {
            transformTarget = null;
            posTarget = target;
            MatchPosition(target);
        }
        
        private void Awake() {
            camera = Camera.main;
            rectTransform = GetComponent<RectTransform>();
        }

        private void Update() {
            MatchPosition(transformTarget ? transformTarget.position : posTarget);
        }

        private void MatchPosition(Vector3 pos) {
            rectTransform.anchoredPosition = camera.WorldToScreenPoint(pos + offset);
        }
    }
}