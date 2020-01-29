using UnityEngine;

namespace Claw {
	[System.Serializable]
	public class Bounds2D {
		[SerializeField] private Vector2 _center;
		[SerializeField] private Vector2 _size;

		public Vector2 Center => _center;

		public Vector2 Size => _size;

		public float Left { get { return Center.x - Size.x / 2.0f; } }

		public float Right { get { return Center.x + Size.x / 2.0f; } }

		public float Top { get { return Center.y + Size.y / 2.0f; } }

		public float Bottom { get { return Center.y - Size.y / 2.0f; } }

		public Vector2 BottomLeft { get { return new Vector2(Left, Bottom); } }

		public Vector2 TopLeft { get { return new Vector2(Left, Top); } }

		public Vector2 BottomRight { get { return new Vector2(Right, Bottom); } }

		public Vector2 TopRight { get { return new Vector2(Right, Top); } }

		public Bounds2D(Vector2 center, Vector2 size) {
			_center = center;
			_size = size;
		}
	}
}