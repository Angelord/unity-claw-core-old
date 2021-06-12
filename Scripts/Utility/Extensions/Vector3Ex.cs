using UnityEngine;

namespace Claw.Utility.Extensions {
    public static class Vector3Ex {

        public static Vector3 Reject(Vector3 vector, Vector3 onNormal) {
            return vector - Vector3.Project(vector, onNormal);
        }
        
        public static Vector3 Truncate(this Vector3 vec, float size) {
            return vec.magnitude < size ? vec : vec.ScaledTo(size);
        }
        
        public static Vector3 ScaledTo(this Vector3 vec, float size) {
            return vec.normalized * size;
        }
    }
}