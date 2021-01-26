using System.Collections;
using Claw.Animation;
using UnityEngine;

namespace Claw.Rendering {
	public class ScreenEffects : MonoBehaviour {

		private static ScreenEffects instance;

		[SerializeField] private Color fadeColor = Color.white;
		
		[SerializeField] [Range(0, 1)] private float startingAlpha = 0.0f;

		private Texture2D overlay;

		public static void FadeOut(float duration) {
			instance.StartCoroutine(instance.DoFade(true, duration));
		}

		public static void FadeIn(float duration) {
			instance.StartCoroutine(instance.DoFade(false, duration));
		}

		private void Awake() {
			instance = this;

			overlay = new Texture2D(1, 1);
			overlay.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, startingAlpha));
			overlay.Apply();
		}

		private void OnGUI() {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), overlay);
		}

		private void OnDestroy() {
			instance = null;
		}

		private IEnumerator DoFade(bool fadeOut, float duration) {
			float timeRemaining = duration;

			while (timeRemaining >= 0.0f) {

				float alpha = fadeOut ? (1.0f - timeRemaining / duration) : timeRemaining / duration;
				overlay.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
				overlay.Apply();

				timeRemaining -= Time.deltaTime;

				yield return 0;
			}
		}
	}
}