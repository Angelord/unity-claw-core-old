﻿using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
 
namespace Claw.UserInterface.Screens {
    public class UIScreenManager : MonoBehaviour {

        [SerializeField] private UIScreen InitialScreen;
        private readonly Stack<UIScreen> menuStack = new Stack<UIScreen>();
        private UIScreen[] screens;

        private void Start() {
            Assert.IsNotNull(InitialScreen, "UI Manager initial screen not set!");
            
            screens = GetComponentsInChildren<UIScreen>(true);
            foreach (UIScreen screen in screens) {
                screen.Initialize(this);
            }
            
            menuStack.Push(InitialScreen);
            InitialScreen.Show();
        }

        public T Push<T>() where T : UIScreen {
            foreach (UIScreen uiScreen in screens) {
                if (uiScreen.GetType() != typeof(T)) continue;
                
                Push(uiScreen);
                
                return uiScreen as T;
            }
            
            throw new ScreenNotFoundException();
        }
        
        private void Push(UIScreen state) {
            
            menuStack.Peek().Hide();
            
            menuStack.Push(state);
            state.Show();
        }

        public void Pop() {
            
            menuStack.Pop()?.Hide(); // Hide 
            
            menuStack.Peek()?.Show();
        }
    }
}