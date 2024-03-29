﻿using UnityEngine;

namespace Claw.Objects {
	public class TemporaryObject : MonoBehaviour {

		[SerializeField] private float lifetime = 1.0f;

		private void Start() {
			Destroy(gameObject, lifetime);
		}
	}
}

