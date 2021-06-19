using UnityEngine;

namespace Claw.UserInterface {
    [CreateAssetMenu(fileName = "Cursor", menuName = "Tentacles/Cursor", order = 1)]
    public class CustomCursor : ScriptableObject {
        
        public Texture2D cursorTexture;
        
        public CursorMode cursorMode = CursorMode.Auto;
        
        public Vector2 hotSpot = Vector2.zero;

        public void Set() {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
    }
}