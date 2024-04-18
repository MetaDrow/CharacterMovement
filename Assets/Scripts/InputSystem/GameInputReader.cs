using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Scriptable Object/Game Input Reader")]
public class GameInputReader : ScriptableObject, GameInput.IGameplayActions
{
    private GameInput _gameInput;
    public event Action<Vector2> MoveEvent;
    public event Action JumpEvent;
    public event Action RollEvent;

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();

            _gameInput.Gameplay.SetCallbacks(this);

            SetGameplay();
        }
    }

    private void SetGameplay()
    {
        _gameInput.Gameplay.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            JumpEvent?.Invoke();
        }
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            RollEvent?.Invoke();
        }
    }
}
