﻿using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
 
namespace Claw.UserInterface.Screens {
    public class UIScreenManager : MonoBehaviour {

        [SerializeField] private UIScreen InitialScreen = default;
        private readonly Stack<UIScreen> menuStack = new Stack<UIScreen>();
        private UIScreen[] screens;

        public int StackSize => menuStack.Count;

        private UIScreen CurrentScreen => menuStack.Peek();

        private void Start() {
            Assert.IsNotNull(InitialScreen, "UI Manager initial screen not set!");
            
            screens = GetComponentsInChildren<UIScreen>(true);
            foreach (UIScreen screen in screens) {
                screen.Initialize(this);
            }
            
            menuStack.Push(InitialScreen);
            InitialScreen.Show();
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
           
            if(menuStack.Count > 0)
                menuStack.Peek().Hide();
            
            menuStack.Push(state);
            state.Show();
        }

        public void Pop() {
            
            menuStack.Pop()?.Hide(); 
            
            menuStack.Peek()?.Show();
        }

        /// <summary>
        /// Finds the specified screen type inside the UI manager.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T FindScreen<T>() where T : UIScreen {
            
            foreach (UIScreen uiScreen in screens) {
                if (uiScreen.GetType() != typeof(T)) continue;
                
                return uiScreen as T;
            }

            throw new ScreenNotFoundException();
        }
    }
}