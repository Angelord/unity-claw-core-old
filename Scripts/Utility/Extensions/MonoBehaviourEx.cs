using System.Collections.Generic;
using UnityEngine;

namespace Immortal._Vendor.Scripts.Utility.Extensions {
    public static class MonoBehaviourEx {

        /// <summary>
        /// Same as GetComponentsInChildren but ignores the parent.
        /// </summary>
        public static T[] GetComponentsInChildrenNoRoot<T>(MonoBehaviour obj, bool includeInactive) where T : MonoBehaviour {
            List<T> result = new List<T>(obj.GetComponentsInChildren<T>(includeInactive));

            for (int i = result.Count - 1; i >= 0; i--) {
                if (result[i].gameObject == obj.gameObject) {
                    result.RemoveAt(i);
                }
            }

            return result.ToArray();
        }
    }
}