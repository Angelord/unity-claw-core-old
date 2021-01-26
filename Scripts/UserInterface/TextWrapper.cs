﻿using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Claw.UserInterface {
    /// <summary>
    /// A UI Component that resizes itself to completely wrap a ui text.
    /// </summary>
    [ExecuteInEditMode]
    public class TextWrapper : UIBehaviour {

        [SerializeField] private float paddingX = default;
        [SerializeField] private float paddingY = default;
        [SerializeField] private Text target = default;
        private RectTransform rectTransform;

        protected override void Start() {
            rectTransform = GetComponent<RectTransform>();
        }

        private void LateUpdate() {
            if (!target) return;

            if (!target.isActiveAndEnabled || string.IsNullOrEmpty(target.text)) {
                rectTransform.sizeDelta = Vector2.zero;
                return;
            }

            TextGenerator textGen = new TextGenerator();
            TextGenerationSettings generationSettings = target.GetGenerationSettings(target.rectTransform.rect.size); 
            float width = textGen.GetPreferredWidth(target.text, generationSettings);
            float height = textGen.GetPreferredHeight(target.text, generationSettings);
            
            rectTransform.sizeDelta = new Vector2(width + paddingX * 2, height + paddingY * 2);
        }
    }
}