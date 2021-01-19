﻿using UnityEngine;

namespace Claw.Rendering {
    /// <summary>
    /// Applies a post-processing shader prior to displaying the rendered scene.
    /// </summary>
    [ExecuteInEditMode]
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class ScreenShader : MonoBehaviour {

        [SerializeField] private Material effectMaterial = default;
        
        private void OnRenderImage(RenderTexture src, RenderTexture dest) {
            Graphics.Blit(src, dest, effectMaterial);
        }
    }
}