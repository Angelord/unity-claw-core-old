using System;
using UnityEngine;

namespace Claw.Controls {
	[Serializable]
	internal class Sequence {
		[SerializeField] private string name = default;
		[SerializeField] private float timeLimit = default;
		[SerializeField] private string[] inputs = default;

	    public string Name => name;
	    public float TimeLimit => timeLimit;
	    public int Length => inputs.Length;

	    public string GetInput(int index) {
	        return inputs[index];
	    }
	}	
}
