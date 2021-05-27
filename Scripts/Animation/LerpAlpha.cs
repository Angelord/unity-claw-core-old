using UnityEngine;
using UnityEngine.UI;

namespace Claw.Animation {
	public class LerpAlpha : MonoBehaviour {

		[SerializeField] private float speed = 2.5f;
	
		private float intendedAlpha;
		private Graphic image;

		public float Speed { get => speed; set => speed = value; }
		
		public float IntendedAlpha { get { return intendedAlpha; } set { intendedAlpha = value; } }

		private void Awake () {
			image = GetComponent<Graphic>();
			intendedAlpha = image.color.a;
		}
	
		private void Update() {
			Color current = GetColor();
			Color c = new Color(current.r, current.g, current.b, Mathf.Lerp(current.a, intendedAlpha, Time.deltaTime * speed));
			SetColor (c);
		}

		/// <summary>
		/// Instantly sets the graphic's alpha.
		/// </summary>
		public void SetAlpha(float value) {
			Color col = image.color;
			col.a = value;
			image.color = col;
		}

		public Color GetColor() {
			return image.color;
		}

		public void SetColor (Color color) {
			image.color = color;
		}
	}
}
