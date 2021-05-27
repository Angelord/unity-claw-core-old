using System.Collections;
using Claw.UserInterface.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Claw.Processes {
    public static class UiCoroutines {
		
        public static IEnumerator LerpGraphicAlpha(Graphic graphic, float from, float to, float duration) {

            float timeElapsed = 0.0f;
            while (timeElapsed < duration) {

                graphic.SetAlpha(Mathf.Lerp(from, to, timeElapsed / duration));
                yield return null;
                timeElapsed += Time.deltaTime;
            }
            graphic.SetAlpha(to);
        }
    }
}