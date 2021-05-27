using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Claw.Processes {
    [System.Serializable]
    public class FadeGraphicInOutProcess : Process {

        [SerializeField] private Graphic graphic;
		
        [SerializeField] private float fadeInDuration;
		
        [SerializeField] private float fadeOutDuration;
		
        [SerializeField] private float holdDuration;

        protected override IEnumerator DoRun() {
			
            yield return UiCoroutines.LerpGraphicAlpha(graphic, 0.0f, 1.0f, fadeInDuration);
	         
            yield return new WaitForSeconds(holdDuration);

            yield return UiCoroutines.LerpGraphicAlpha(graphic, 1.0f, 0.0f, fadeOutDuration);
        }
    }
}