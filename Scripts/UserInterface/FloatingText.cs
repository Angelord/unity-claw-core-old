using UnityEngine;
using UnityEngine.UI;

namespace Claw.UserInterface {
	/// <summary>
	/// Text that appears and flows up while fading out.
	/// </summary>
	[RequireComponent(typeof(Text))]
	public class FloatingText : MonoBehaviour {

		[SerializeField] private float duration;
		
		[SerializeField] private float floatOffset;
		
		private float start;
		
		private float initialY;
		
		private RectTransform rectTransform;
		
		private Text uiText;
		
		public string Text { get => uiText.text; set => uiText.text = value; }
		
		public Color Color { get => uiText.color; set => uiText.color = value; }

		private void OnEnable() {
			
			uiText = GetComponent<Text>();
			rectTransform = GetComponent<RectTransform>();
		}

		public void Init(Vector2 pos) {
			start = Time.time;
			rectTransform.anchoredPosition = pos;
			initialY = pos.y;
			gameObject.SetActive(true);
		}

		private void Update() {

			Vector2 pos = rectTransform.anchoredPosition;
			Color col = uiText.color;

			float progress = (Time.time - start) / duration;
			col.a = 1.0f - (Time.time - start) / duration;
			pos.y = initialY + floatOffset * progress;
		
			rectTransform.anchoredPosition = pos;
			uiText.color = col;
		
			if (progress > 1.0f) {
				gameObject.SetActive(false);
			}
		}
	}
}