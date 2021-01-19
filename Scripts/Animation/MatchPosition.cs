using UnityEngine;

namespace Claw.Animation {
    /// <summary>
    /// Follows a specified object's position on one or more axis.
    /// </summary>
    public class MatchPosition : MonoBehaviour {
    
        [SerializeField] private Transform target = default;
        [SerializeField] private bool x = true;
        [SerializeField] private bool y = true;
        [SerializeField] private bool z = true;

        void LateUpdate() {
            if (target == null) { return; }
            
            Vector3 targetPos = target.transform.position;

            Vector3 curPos = transform.position;
                
            transform.position = new Vector3(
                x ? targetPos.x : curPos.x,
                y ? targetPos.y : curPos.y,
                z ? targetPos.z : curPos.z
            );
        }
    }
}