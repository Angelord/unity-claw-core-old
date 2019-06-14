using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Claw.Objects {
	public class WorldWrap2D : MonoBehaviour {

		[SerializeField] private WorldBounds2D bounds;

		private void Start() {
			if (bounds == null) {
				Destroy(this);
			}
		}

		private void Update() {

			Vector2 pos = transform.position;

			if (pos.x < bounds.XMin) { pos.x = bounds.XMax; }
			if (pos.x > bounds.XMax) { pos.x = bounds.XMin; }
			if (pos.y < bounds.YMin) { pos.y = bounds.YMax; }
			if (pos.y > bounds.YMax) { pos.y = bounds.YMin; }
			
			transform.position = new Vector3(pos.x, pos.y, transform.position.z);
		}
	}
}
