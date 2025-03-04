using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace  Blade.Test
{
    [CreateAssetMenu(fileName = "PlayerInput", menuName = "Scriptable Objects/PlayerInput")]
    public class PlayerInput : ScriptableObject , Controls.IPlayerActions
    {
        public event Action<Vector2> OnMovementChange;
        public event Action OnAttackPressed;
        public event Action OnRollingPressed;
        
        private Controls _controls;

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls();
                _controls.Player.SetCallbacks(this);
            }

            _controls.Player.Enable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 movementKet = context.ReadValue<Vector2>();
            OnMovementChange?.Invoke(movementKet);
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if(context.performed)
                OnAttackPressed?.Invoke();
        }

        public void OnRolling(InputAction.CallbackContext context)
        {
            
        }
    }
}
