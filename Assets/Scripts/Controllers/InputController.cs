using Common;
using System;
using UnityEngine;

namespace Game
{
    public class InputController : MonoBehaviour
    {
        public event Action OnMainActionDown;
        public event Action OnMainAction;
        public event Action OnMainActionUp;

        public event Action OnPauseActionDown;
        public event Action OnPauseAction;
        public event Action OnPauseActionUp;

        public bool IsMainButton => CrossPlatformInput.GetKey(KeyCode.Space);
        public bool IsMainButtonDown => CrossPlatformInput.GetKeyDown(KeyCode.Space);
        public bool IsMainButtonUp => CrossPlatformInput.GetKeyUp(KeyCode.Space);

        public bool IsPauseButton => CrossPlatformInput.GetKey(KeyCode.Escape);
        public bool IsPauseButtonDown => CrossPlatformInput.GetKeyDown(KeyCode.Escape);
        public bool IsPauseButtonUp => CrossPlatformInput.GetKeyUp(KeyCode.Escape);

        public void SetMainButtonDown()
        {
            CrossPlatformInput.SetKeyDown(KeyCode.Space);
        }

        public void SetMainButtonUp()
        {
            CrossPlatformInput.SetKeyUp(KeyCode.Space);
        }

        public void MainActionDown()
        {
            OnMainActionDown?.Invoke();
        }

        public void MainAction()
        {
            OnMainAction?.Invoke();
        }

        public void MainActionUp()
        {
            OnMainActionUp?.Invoke();
        }

        public void PauseActionDown()
        {
            OnPauseActionDown?.Invoke();
        }

        public void PauseAction()
        {
            OnPauseAction?.Invoke();
        }

        public void PauseActionUp()
        {
            OnPauseActionUp?.Invoke();
        }

        private void Update()
        {
            if (IsMainButtonDown)
                MainActionDown();
            if (IsMainButton)
                MainAction();
            if (IsMainButtonUp)
                MainActionUp();

            if (IsPauseButtonDown)
                PauseActionDown();
            if (IsPauseButton)
                PauseAction();
            if (IsPauseButtonUp)
                PauseActionUp();
        }

        private void OnDestroy()
        {
            OnMainActionDown = null;
            OnMainAction = null;
            OnMainActionUp = null;

            OnPauseActionDown = null;
            OnPauseAction = null;
            OnPauseActionUp = null;
        }
    }
}