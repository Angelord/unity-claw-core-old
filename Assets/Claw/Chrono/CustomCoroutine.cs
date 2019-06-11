using UnityEngine;
using System.Collections;

namespace Claw.Chrono {
    public class CustomCoroutine : MonoBehaviour {
        private static CustomCoroutine instance;

        private static void TryCreateInstance() {
            if (instance == null) {
                instance = (new GameObject("CustomCoroutineRunner")).AddComponent<CustomCoroutine>();
            }
        }

        public static void WaitOnConditionThenExecute(System.Func<bool> condition, System.Action action) {
            TryCreateInstance();
            instance.StartWaitOnConditionThenExecute(condition, action);
        }

        public static void WaitThenExecute(float wait, System.Action action, bool unscaledTime = false) {
            TryCreateInstance();
            instance.StartWaitThenExecute(wait, action, unscaledTime);
        }

        private void StartWaitOnConditionThenExecute(System.Func<bool> condition, System.Action action) {
            StartCoroutine(DoWaitOnConditionThenExecute(condition, action));
        }

        private void StartWaitThenExecute(float wait, System.Action action, bool unscaledTime = false) {
            StartCoroutine(DoWaitThenExecute(wait, action, unscaledTime));
        }

        IEnumerator DoWaitOnConditionThenExecute(System.Func<bool> condition, System.Action action) {
            yield return new WaitUntil(() => condition());
            action();
        }

        IEnumerator DoWaitThenExecute(float wait, System.Action action, bool unscaledTime = false) {
            if (wait <= 0f) {
                yield return new WaitForEndOfFrame();
            }
            else {
                if (unscaledTime) {
                    yield return new WaitForSecondsRealtime(wait);
                }
                else {
                    yield return new WaitForSeconds(wait);
                }
            }

            action();
        }
    }
}