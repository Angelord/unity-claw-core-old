using UnityEngine;

namespace Claw.Utility {
    public abstract class SingletonObject<T> : MonoBehaviour where T : MonoBehaviour {

        private static T instance;

        public static T Instance {
            get {
                if (instance == null) {
                    instance = (new GameObject(typeof(T).Name)).AddComponent<T>();
                }

                return instance;
            }
        }

        private void Start() {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}