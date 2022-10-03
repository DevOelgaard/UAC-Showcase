using System;
using UnityEngine;

public class GameHandler: MonoBehaviour
{
        private readonly KeyboardInput keyboardInput = KeyboardInput.Instance;
        private void Start()
        {
                keyboardInput.InitKeyboard();
        }
}