using UnityEngine;

[System.Serializable]
public class Sequence {
	[SerializeField] private string name;
	[SerializeField] private float timeLimit;
	[SerializeField] private string[] inputs;

    public string Name { get { return name; } }
    public float TimeLimit { get { return timeLimit; } }
    public int Length { get { return inputs.Length; } }

    public string GetInput(int index) {
        return inputs[index];
    }
}	
