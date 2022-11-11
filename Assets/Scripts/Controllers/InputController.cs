using Common;
using Common.Injection;
using System;
using UnityEngine;

namespace Game
{
    [DI_Install]
    public class InputController : MonoBehaviour
    {
        public event Action OnMainActionDown;
        public event Action OnMainAction;
        public event Action OnMainActionUp;

        public event Action OnPauseActionDown;
        public event Action OnPauseAction;
        public event Action OnPauseActionUp;

        public bool IsMainButton => CustomInput.GetKey(KeyCode.Space);
        public bool IsMainButtonDown => CustomInput.GetKeyDown(KeyCode.Space);
        public bool IsMainButtonUp => CustomInput.GetKeyUp(KeyCode.Space);

        public bool IsPauseButton => CustomInput.GetKey(KeyCode.Escape);
        public bool IsPauseButtonDown => CustomInput.GetKeyDown(KeyCode.Escape);
        public bool IsPauseButtonUp => CustomInput.GetKeyUp(KeyCode.Escape);

        public void SetMainButtonDown()
        {
            CustomInput.SetKeyDown(KeyCode.Space);
        }

        public void SetMainButtonUp()
        {
            CustomInput.SetKeyUp(KeyCode.Space);
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

        private void Awake()
        {
            DI_Binder.Bind(this);
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

            DI_Binder.Unbind(this);
        }
    }
}