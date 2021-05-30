using System;
using System.Collections;
using Immortal.Stats;
using UnityEngine;

namespace Claw.Chrono {
	public class CustomCoroutine : MonoBehaviour {

		private const float MIN_LERP_TIME = 0.000001f;

		private static CustomCoroutine instance;
		
		private static void TryCreateInstance() {
			if (instance == null) {
				instance = (new GameObject("Runner_CustomCoroutine")).AddComponent<CustomCoroutine>();
			}
		}

		private void Start() {
			DontDestroyOnLoad(this.gameObject);
		}

		public static void Start(IEnumerator coroutine) {
			TryCreateInstance();
			instance.StartCoroutine(coroutine);
		}
		
		public static void Stop(IEnumerator coroutine) {
			TryCreateInstance();
			instance.StopCoroutine(coroutine);
		}

		public static void WaitOneFrameThenExecute(Action action) {
			TryCreateInstance();
			instance.StartCoroutine(instance.DoWaitOneFrameThenExecute(action));
		}

		public static void WaitOnConditionThenExecute(Func<bool> condition, Action action) {
			TryCreateInstance();
			instance.StartCoroutine(instance.DoWaitOnConditionThenExecute(condition, action));
		}

		public static void WaitThenExecute(float wait, Action action, bool unscaledTime = false) {
			TryCreateInstance();
			instance.StartCoroutine(instance.DoWaitThenExecute(wait, action, unscaledTime));
		}

		public static Coroutine LerpOverTime(float duration, float fromVal, float toVal, Action<float> callback) {
			TryCreateInstance();
			return instance.StartCoroutine(instance.DoLerpOverTime(duration, fromVal, toVal, callback));
		}

		IEnumerator DoWaitOneFrameThenExecute(Action action) {
			yield return 0;
			action();
		}

		IEnumerator DoWaitOnConditionThenExecute(Func<bool> condition, Action action) {
			yield return new WaitUntil(condition);
			action();
		}
		
		IEnumerator DoWaitThenExecute(float wait, Action action, bool unscaledTime = false) {
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

		IEnumerator DoLerpOverTime(float duration, float fromVal, float toVal, Action<float> callback) {

			if (Math.Abs(duration) < MIN_LERP_TIME) {
				callback(toVal);
				yield break;
			}

			float timeElapsed = 0.0f;

			while (timeElapsed < duration) {

				yield return 0;

				timeElapsed += Time.deltaTime;

				callback(Mathf.Lerp(fromVal, toVal, timeElapsed / duration));
			}
		}
	}
}
