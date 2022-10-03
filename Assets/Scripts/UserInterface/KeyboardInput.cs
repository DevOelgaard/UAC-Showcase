using System;
using UniRx;
using UnityEngine.InputSystem;


public class KeyboardInput
{
        private static KeyboardInput _instance;

        private readonly CompositeDisposable disposables = new CompositeDisposable();

        public static KeyboardInput Instance => _instance ??= new KeyboardInput();

        private readonly IObservable<long> keyboardStream;
        private Keyboard keyboard;

        private KeyboardInput()
        {
                keyboardStream = Observable.EveryUpdate();
        }

        public void InitKeyboard()
        {
                keyboard = Keyboard.current;
                keyboardStream
                        .Where(_ => keyboard.spaceKey.wasPressedThisFrame)
                        .Subscribe(_ => TurnHandler.Instance.TakeNextTurn())
                        .AddTo(disposables);
        }

        ~KeyboardInput()
        {
                disposables.Clear();
        }
}