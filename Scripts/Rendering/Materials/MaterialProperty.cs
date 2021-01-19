using UnityEngine;

namespace Claw.Rendering.Materials {
	public abstract class MaterialProperty : ScriptableObject {

		[SerializeField] private string identifier = default;

		protected string Identifier => identifier;

		public abstract void Apply(MaterialPropertyBlock propertyBlock);
	}
}