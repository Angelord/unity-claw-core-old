﻿using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
 using Immortal._Vendor.Scripts.Utility.Extensions;

 namespace Claw.UserInterface.Screens {
    public class UIScreenManager : MonoBehaviour {

        [SerializeField] private UIScreen InitialScreen = default;
        
        private readonly Stack<UIScreen> menuStack = new Stack<UIScreen>();
        
        private UIScreen[] screens;

        private bool initialized;

        public int StackSize => menuStack.Count;

        public UIScreen CurrentScreen => menuStack.Peek();

        // Initializing in Start as most ui Depends on other object having initialized themselves already, whilst
        // not much should depend on the UI having initialized itself.
        private void Start() {
            
            Init();
        }

        public void Init() {

            if (initialized) return;
            
            screens = MonoBehaviourEx.GetComponentsInChildrenNoRoot<UIScreen>(this, true);
            foreach (UIScreen screen in screens) {
                screen.Initialize(this);
            }

            if (InitialScreen != null) {
                menuStack.Push(InitialScreen);
                InitialScreen.Show();
            }

            initialized = true;
        }

        public bool IsOpen<T>() where T : UIScreen {
            return CurrentScreen is T;
        }

        /// <summary>
        /// Clears the stack and puts the screen of the specified type on top.
        /// </summary>
        public T Enter<T>() where T : UIScreen {

            T screen = FindScreen<T>();

            Enter(screen);
            
            return screen;
        }

        /// <summary>
        /// Clears the stack and puts the specified screen on top
        /// </summary>
        public void Enter(UIScreen screen) {
            
            if(menuStack.Count > 0)
                menuStack.Pop().Hide();
            
            menuStack.Clear();

            Push(screen);
        }

        public T Push<T>() where T : UIScreen {
            
            T screen = FindScreen<T>();

            Push(screen);

            return screen;
        }
        
        public void Push(UIScreen state) {

            if (menuStack.Count > 0 && state == CurrentScreen) return;
           
            if(menuStack.Count > 0)
                menuStack.Peek().Hide();
            
            menuStack.Push(state);
            state.Show();
        }

        public void Pop() {
            
            menuStack.Pop()?.Hide();

            if (menuStack.Count > 0) {
                menuStack.Peek()?.Show();
            }
        }

        /// <summary>
        /// Finds the specified screen type inside the UI manager.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T FindScreen<T>() where T : UIScreen {
            
            foreach (UIScreen uiScreen in screens) {
                if (uiScreen.GetType() != typeof(T)) continue;
                
                return uiScreen as T;
            }

            throw new ScreenNotFoundException();
        }
    }
}