using Claw.Utility;
using UnityEditor;
using UnityEngine;

namespace Claw.Editors.PropertyDrawers {
    [CustomPropertyDrawer(typeof(FloatRange))]
    public class FloatRangeDrawer : PropertyDrawer {
        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            // Using BeginProperty / EndProperty on the parent property means that
            // prefab override logic works on the entire property.

            EditorGUI.BeginProperty(position, label, property);

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            position.width = 50;

            EditorGUI.LabelField(position, "min");
            position.x += 30;
            EditorGUI.PropertyField(position, property.FindPropertyRelative("min"), GUIContent.none);
            position.x += 70;
            EditorGUI.LabelField(position, "max");
            position.x += 30;
            EditorGUI.PropertyField(position, property.FindPropertyRelative("max"), GUIContent.none);

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}