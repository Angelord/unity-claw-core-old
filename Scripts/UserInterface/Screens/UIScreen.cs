using UnityEngine;
using UnityEngine.Events;

namespace Claw.UserInterface.Screens {
    public class UIScreen : MonoBehaviour {
        private UIScreenManager screenManager;

        [SerializeField] private UnityEvent onShowEv;

        [SerializeField] private UnityEvent onHideEv;

        public void Initialize(UIScreenManager screenManager) {
            if (this.screenManager != null) {
                Debug.LogError("Attempting to initialize a UI screen twice!");
                return;
            }

            this.screenManager = screenManager;
            gameObject.SetActive(false);
            OnInitialize();
        }

        public void Show() {
            gameObject.SetActive(true);
            OnShow();
            onShowEv?.Invoke();
        }

        public void Hide() {
            gameObject.SetActive(false);
            OnHide();
            onHideEv?.Invoke();
        }

        protected T EnterScreen<T>() where T : UIScreen {
            return screenManager.Enter<T>();
        }

        protected T PushScreen<T>() where T : UIScreen {
            return screenManager.Push<T>();
        }

        protected void PopScreen() {
            screenManager.Pop();
        }

        /// <summary>
        /// Unrelated to the other UI events. This is just the regular unity OnDestroy.
        /// Written as overrideable here so we don't forget that some of the subclasses use it.
        /// </summary>
        protected virtual void OnDestroy() {
        }

        /// <summary> Called on Start. Use to run any initialization code. </summary>
        protected virtual void OnInitialize() {
        }

        /// <summary> Called when the screen is being opened. Use to subscribe to events.</summary>
        protected virtual void OnShow() {
        }

        /// <summary> Called when the screen is being closed. Use to unsubscribe from events.</summary>
        protected virtual void OnHide() {
        }
    }
}