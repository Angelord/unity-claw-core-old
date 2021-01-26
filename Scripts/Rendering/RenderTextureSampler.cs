﻿using UnityEngine;

namespace Claw.Rendering {
    /// <summary>
    ///  Converts a camera's render texture to a regular Texture2D.
    ///  Allows color sampling from the scanned texture.
    /// </summary>
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class RenderTextureSampler : MonoBehaviour {
        
        [SerializeField] private float sampleFrequency = 0.05f;
        
        private Texture2D resultTexture; // The texture we sample from

        private float lastSample;

        public Color GetPixel(int x, int y) {
            return resultTexture.GetPixel(x, y);
        }

        private void Start() {
            // TODO : Handle screen resize!!
            resultTexture = new Texture2D(Screen.width, Screen.height);
        }

        private void OnPostRender() {
            
            if (Time.time - lastSample < sampleFrequency) return;
            
            resultTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            
            lastSample = Time.time;
        }
    }
}