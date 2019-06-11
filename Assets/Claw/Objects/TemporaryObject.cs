using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryObject : MonoBehaviour {

	[SerializeField] private float lifetime = 1.0f;

	private void Start() {
		Invoke("DestroySelf", lifetime);
	}

	private void DestroySelf() {
		Destroy(this.gameObject);
	}
}

