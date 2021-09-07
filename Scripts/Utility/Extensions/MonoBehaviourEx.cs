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

        public static T[] GetComponentsOfDirectChildren<T>(MonoBehaviour obj, bool includeInactive) where T : MonoBehaviour {

            Transform transform = obj.transform;
            
            List<T> result = new List<T>(transform.childCount);

            for (int i = 0; i < transform.childCount; i++) {

                Transform child = transform.GetChild(i);

                if (!includeInactive && !child.gameObject.activeSelf) { continue; }
                
                T component = child.GetComponent<T>();

                if (component != null) result.Add(component);
            }

            return result.ToArray();
        }
    }
}