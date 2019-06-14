using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Claw.Objects {
	//Defines a 2D world and its limits
	public class WorldBounds2D : MonoBehaviour {

		[SerializeField] private float width;
		[SerializeField] private float length;

		public float Width { get { return width; } }
		public float Length { get { return length; } }
		public float XMin { get { return transform.position.x - width / 2; } }
		public float XMax { get { return transform.position.x + width / 2; } }
		public float YMin { get { return transform.position.y - length / 2; } }
		public float YMax { get { return transform.position.y + length / 2; } }
		
		private void OnDrawGizmosSelected() {
			// Draw a semitransparent blue cube at the transforms position
			Gizmos.color = new Color(1, 0, 0, 0.5f);
			
			Gizmos.DrawCube(transform.position, new Vector3(width, length, 1.0f));
		}
	}
}