﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Claw.UserInterface {
    /// <summary>
    /// A text that lets you show a message that is slowly typed out. 
    /// </summary>
    public class TypedText : Text {

        public void Type(string text, float typeInterval) {
            StopAllCoroutines();
            StartCoroutine(PerformType(text, typeInterval));
        }

        private IEnumerator PerformType(string targetText, float typeInterval) {

            text = "";
            
            for (int i = 0; i < targetText.Length; i++) {

                text = targetText.Substring(0, i + 1);
                
                yield return new WaitForSeconds(typeInterval);
            }
        }
    }
}