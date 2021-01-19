using System.Collections.Generic;
using UnityEngine;

namespace Claw.Rendering.Materials {
    [ExecuteInEditMode]
    [RequireComponent(typeof(Renderer))]
    public class PerRendererMaterialOptions : MonoBehaviour {

        [SerializeField] private List<MaterialProperty> materialProperties = new List<MaterialProperty>();
        private MaterialPropertyBlock propertyBlock;
        private new Renderer renderer;

        private void Start() {
            Initialize();
        }

        private void Reset() {
            Initialize();
        }

        private void OnValidate() {
            Initialize();
        }

        private void Initialize() {
            if(renderer != null && propertyBlock != null) return;

            renderer = GetComponent<Renderer>();
            propertyBlock = new MaterialPropertyBlock ();
        }

        private void Update() {
            
            foreach (var materialProperty in materialProperties) {
                if (materialProperty == null) continue;
                
                materialProperty.Apply(propertyBlock);
            }
            
            renderer.SetPropertyBlock (propertyBlock);
        }
    }
}
